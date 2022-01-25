using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;


namespace KMZ_PhotoMapper
{
    class Processor
    {
        public Processor(string Description)
        {
            PopoutImagesize = 400;
            OutputDescription = Description;
            
        }
        private System.Threading.Thread T = null;

        public delegate void ProgressDelegate(string message, int percent);
        public event ProgressDelegate Progress;

        public int thumbSize = 128;

        private readonly string OutputDescription;
        public string Inputfolder { get; set; }
        public string OutputFileName { get; set; }
        public bool  IncludeThumbnails { get; set; }
        public bool PhotoFilename_asDescription { get; set; }
        public bool UseGPSDate { get; set; }

        public bool IncludePath { get; set; }
        public bool  SortByDateTaken { get; set; }
        public bool IncludeDateonpopout { get; set; }
        public int PopoutImagesize { get; internal set; }

        private SortedList<string, PhotoDetail> inputPhotos;
        private string imageFolder ;
        private string thumbFolder;
        private string tempFolder;

        bool isOk = true;
        public bool Begin()
        {
            //ensure KMZ saves to useful location
            FileInfo fi = new FileInfo(OutputFileName);
            if(fi.DirectoryName.Length==0)
            {
                OutputFileName = Path.Combine(Inputfolder, OutputFileName);
            }
            if (fi.Extension.Length == 0) OutputFileName += ".kmz";

            if (T == null)
            {
                T = new System.Threading.Thread(new System.Threading.ThreadStart(Worker));
                T.Start();
            }
            return isOk;
        }

        private void RaiseProgress(string message, int percent)
        {
            Progress?.Invoke(message, percent);
        }
        private void Worker()
        {
            RaiseProgress("Initializing...", 1);
            DirectoryInfo diInput = new DirectoryInfo(Inputfolder);

            inputPhotos = new SortedList<string, PhotoDetail>(diInput.GetFiles("*").Length / 2);  // a rough guess as to file count

            tempFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            System.IO.Directory.CreateDirectory(tempFolder);
            imageFolder = Path.Combine(tempFolder, "Images");
            thumbFolder = Path.Combine(tempFolder, "Thumbnails");

            System.IO.Directory.CreateDirectory(imageFolder);
            System.IO.Directory.CreateDirectory(thumbFolder);

            RaiseProgress("Making list and images...", 5);
            Makelist(diInput);

            #region export KMZ
            {
                isOk = CreateKMZ(OutputFileName,tempFolder);
            }
            #endregion


            //cleanup
            System.IO.Directory.Delete(tempFolder, true);
            isOk = true;
            RaiseProgress("finished!", 100);
        }

        #region KML
        private bool CreateKMZ(string outputFilename, string templocation)
        {
            //create KML in temp location
            FileInfo fi = new FileInfo(outputFilename);
            string kmlfilename = Path.Combine(templocation, fi.Name.Replace("kmz", "kml"));
            
            CreateKML(kmlfilename);
            RaiseProgress("Creating KMZ..", 85);
            //Makezip
            using(Ionic.Zip.ZipFile kmz = new Ionic.Zip.ZipFile())
            {
                kmz.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                kmz.AddFile(kmlfilename,"");
                kmz.AddDirectory(thumbFolder,"Thumbnails");
                kmz.AddDirectory(imageFolder,"Images");
                kmz.Save(outputFilename);
            }

            return true;
        }

        private bool CreateKML(string outputFilename)
        {
            RaiseProgress("Creating KML..", 80);
            try
            {
                string kml = MakeKMLString();
                File.WriteAllText(outputFilename, kml);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private string MakeKMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<?xml version='1.0' encoding='UTF-8' ?>");
            sb.AppendLine(@"<kml xmlns='http://www.opengis.net/kml/2.2'>");
            sb.AppendLine(@" <Document>");
            sb.AppendLine(@"  <name>" + OutputDescription + "</name>");
            sb.AppendLine(@"  <description>" + "KMZPhotomapper" + "</description>");
            sb.AppendLine(GetKMLStyles());
            sb.AppendLine(@" <Folder>");
            sb.AppendLine(@"  <name>Pictures</name>");
            sb.AppendLine(@"  <description>" + OutputDescription + "</description>");
            sb.AppendLine(@"  <visibility>0</visibility>");
            sb.AppendLine(@"  <open>1</open>");

            foreach (var pd in inputPhotos)
            {
                sb.AppendLine(GetPlaceMark(pd.Value));

            }
            if (IncludePath)
            {
                sb.AppendLine(MakeKMLLine());
            }

            sb.AppendLine(@"</Folder></Document></kml>");
            return sb.ToString();
        }

        /// <summary>
        /// create a KML placemark with thumbnail or std icon
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        private string GetPlaceMark(PhotoDetail pd)
        {
            StringBuilder sb = new StringBuilder(@"    <Placemark>");

            sb.AppendLine(@"      <description>");
            sb.Append(@"       <![CDATA[<br>");
       
            if (PhotoFilename_asDescription)
            {
                sb.AppendFormat("<b>{0}</b>", pd.Description);
            }

            if (IncludeDateonpopout)
            {
                sb.AppendLine("<span style='padding-left:5em;font-style:italic;'>" + pd.DateTaken.ToString("ddd dd-MMM-yyyy HH:mm") + "</span>");
            }

            sb.Append(@"<br><table><tr><td><img src='" + pd.ImageFilename.Replace(tempFolder+@"\",@"") + "'></td></tr></table>]]>");
            sb.AppendLine();
            sb.AppendLine(@"      </description>");
            sb.AppendLine(@"      <Snippet maxLines='0'></Snippet>");
            sb.AppendLine(@"      <name>"+ pd.DateTaken.ToString("ddd dd-MMM-yyyy HH:mm") +"</name>");
            sb.AppendLine(@"      <LookAt>");
            sb.AppendLine(@"        <longitude>"+ pd.longitude.ToString() +"</longitude>");
            sb.AppendLine(@"        <latitude>" + pd.latitude.ToString() + "</latitude>"); ;
            sb.AppendLine(@"        <range>500</range>");
            sb.AppendLine(@"        <tilt>40</tilt>");
            sb.AppendLine(@"        <heading>0</heading>");
            sb.AppendLine(@"      </LookAt>");
            sb.AppendLine(@"      <visibility>1</visibility>");
            sb.AppendLine(@"      <open>0</open>");
            sb.AppendLine(@"      <styleUrl>#vtgStyleMap</styleUrl>");
            sb.AppendLine(@"      <Style>      <IconStyle><Icon><href>" + pd.ThumbnailFilename.Replace(tempFolder + @"\", @"") + "</href></Icon></IconStyle>      <BalloonStyle><text><![CDATA[$[description]]]></text></BalloonStyle></Style>");
            sb.AppendLine(@"      <Point>");
            sb.AppendLine(@"        <extrude>0</extrude>");
            sb.AppendLine(@"        <tessellate>0</tessellate>");
            sb.AppendLine(@"        <altitudeMode>clampToGround</altitudeMode>");
            sb.AppendLine(@"        <coordinates>" + pd.longitude.ToString() + "," + pd.latitude.ToString() + ",0</coordinates>");
            sb.AppendLine(@"      </Point>");
            sb.AppendLine(@"    </Placemark>");

            return sb.ToString();
        }

        private string MakeKMLLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<Placemark>");
            sb.AppendLine(@" <styleUrl>#groundLine</styleUrl>");
            sb.AppendLine(@" <name>Path of travel</name>");
            sb.AppendLine(@" <description>Path of travel</description>");
            sb.AppendLine(@" <LineString>");
            sb.AppendLine(@"  <coordinates>");

            foreach (var pdz in inputPhotos)
            {
                sb.AppendLine(string.Format("  {0:0.00000},{1:0.00000},{2:0.0}", pdz.Value.longitude, pdz.Value.latitude, 0));
            }
            sb.AppendLine(@"  </coordinates> ");
            sb.AppendLine(@" </LineString> ");
            sb.AppendLine(@" </Placemark> ");


            return sb.ToString();
        }
        private string GetKMLStyles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@" <Style id='normalPlacemark'>");
            sb.AppendLine(@"    <IconStyle>");
            sb.AppendLine(@"      <scale>0.6</scale>");
            sb.AppendLine(@"      <Icon>");
            sb.AppendLine(@"        <href>icones/cible.png</href>");
            sb.AppendLine(@"        <w>64</w>");
            sb.AppendLine(@"        <h>64</h>");
            sb.AppendLine(@"      </Icon>");
            sb.AppendLine(@"    </IconStyle>");
            sb.AppendLine(@"    <LabelStyle id='defaultLabelStyle'>");
            sb.AppendLine(@"      <color>00ffffff</color>");
            sb.AppendLine(@"    </LabelStyle>");
            sb.AppendLine(@"  </Style>");
            sb.AppendLine(@"  <Style id='highlightPlacemark'>");
            sb.AppendLine(@"    <IconStyle>");
            sb.AppendLine(@"      <scale>2</scale>");
            sb.AppendLine(@"      <Icon>");
            sb.AppendLine(@"        <href>icones/cible.png</href>");
            sb.AppendLine(@"        <w>64</w>");
            sb.AppendLine(@"        <h>64</h>");
            sb.AppendLine(@"      </Icon>");
            sb.AppendLine(@"    </IconStyle>");
            sb.AppendLine(@"    <LabelStyle id='defaultLabelStyle'>");
            sb.AppendLine(@"      <color>00ffffff</color>");
            sb.AppendLine(@"    </LabelStyle>");
            sb.AppendLine(@"  </Style>");
            sb.AppendLine(@"  <Style id='groundLine'>");
            sb.AppendLine(@"    <LineStyle>");
            sb.AppendLine(@"     <color>#ff0000ff</color>");
            sb.AppendLine(@"     <width>2</width>");
            sb.AppendLine(@"    </LineStyle>");
            sb.AppendLine(@"  </Style>");
            sb.AppendLine(@"  <StyleMap id='vtgStyleMap'>");
            sb.AppendLine(@"    <Pair>");
            sb.AppendLine(@"      <key>normal</key>");
            sb.AppendLine(@"      <styleUrl>#normalPlacemark</styleUrl>");
            sb.AppendLine(@"    </Pair>");
            sb.AppendLine(@"    <Pair>");
            sb.AppendLine(@"      <key>highlight</key>");
            sb.AppendLine(@"      <styleUrl>#highlightPlacemark</styleUrl>");
            sb.AppendLine(@"    </Pair>");
            sb.AppendLine(@"  </StyleMap>");

            return sb.ToString();
        }

        #endregion

        private void Makelist(DirectoryInfo di)
        {

            RaiseProgress("Creating image list..", 10);
            FileInfo[] availFiles = di.GetFiles();
            int maxFiles = availFiles.Length;
            int filenum = 0;
            #region make the list
            foreach (FileInfo thisPhotoFile in di.GetFiles())
            {
                filenum++;
                int percentdone = Convert.ToInt32(filenum * 100.0 / maxFiles);
                if(filenum % 5 == 0)
                {
                    RaiseProgress(string.Format("processing image #{0}",filenum), Convert.ToInt32( 10+ percentdone /2 ));
                }

                PhotoDetail thisPhoto = new PhotoDetail
                {
                    latitude = -99 //cant be plotted
                };
                //test if it is a valid image
                switch (thisPhotoFile.Extension.ToUpper())
                {
                    case ".JPG":
                    case ".JPEG":
                    case ".TIFF":

                        thisPhoto.Description = thisPhotoFile.Name;

                        Exif_Ext.EXIF_Data exif = new Exif_Ext.EXIF_Data(thisPhotoFile.FullName);

                        DateTime dateTaken = exif.CameraDate;
                        
                        if (exif.GPSLatitude == 0) break;
                        if (exif.GPSLatitude == -999) break;
                        //if(exif.GPSUTCDate > DateTime.MinValue && UseGPSDate)
                        //{
                        //    dateTaken = GPSMethods.GetLocalTimefromGPS(exif.GPSLatitude, exif.GPSLongitude, exif.GPSUTCDate);
                        //}
                        thisPhoto.latitude = exif.GPSLatitude;
                        thisPhoto.longitude = exif.GPSLongitude;

                       
                        thisPhoto.DateTaken = dateTaken;

                        if (SortByDateTaken)
                        {
                            thisPhoto.keyid = thisPhoto.DateTaken.ToString("yyyyMMdd-HHmmss");
                        }
                        else
                        {
                            thisPhoto.keyid = thisPhoto.Description;
                        }

                        break;
                    default:
                        //ignore unsupperted files
                        break;
                }

                //now attempt to load to the list. may generate duplicate key.
                int retry = 0;
                string originalkeyid = thisPhoto.keyid;

                if (thisPhoto.latitude > -99)
                { 
                    do
                    {
                        if (retry > 0)
                        {
                            thisPhoto.keyid = string.Format("{0}{1:00}", originalkeyid, retry);
                        }
                        thisPhoto.ThumbnailFilename = Path.Combine(thumbFolder, thisPhoto.keyid + thisPhotoFile.Extension);
                        thisPhoto.ImageFilename = Path.Combine(imageFolder, thisPhoto.keyid + thisPhotoFile.Extension);
                        try
                        {
                            //save the data to the Sorted list
                            inputPhotos.Add(thisPhoto.keyid, thisPhoto);
                            retry = 0;
                        }
                        catch (ArgumentException)
                        {
                            retry++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            throw;
                        }
                    } while (retry > 0);

                    //now have unique id, create the smaller images and thumbnails
                    ResizeImages(thisPhotoFile, thisPhoto);
                }
            }

            #endregion
        }



        private void ResizeImages(FileInfo thisPhotoFile, PhotoDetail thisPhoto)
        {
            //resize to temp folder
            //make the small images as markers
            if (IncludeThumbnails)
            {
                var imgresized = ImageMethods.ResizeImageFile(thisPhotoFile, thumbSize, thumbSize);
                ImageMethods.SaveOutputImage(thisPhoto.ThumbnailFilename, imgresized, 60L);

            }

            //now make the popout images
            {
                var imgresized = ImageMethods.ResizeImageFile(thisPhotoFile, PopoutImagesize, PopoutImagesize);
                ImageMethods.SaveOutputImage(thisPhoto.ImageFilename, imgresized, 80L);

            }
        }
    }

    public class PhotoDetail
    {
        public string keyid;
        public string Description;
        public DateTime DateTaken;
        public string ThumbnailFilename;
        public string ImageFilename;
        public bool isLandscape;
        public double longitude;
        public double latitude;

        public PhotoDetail()
        {
            isLandscape = true;
        }
    }
}
