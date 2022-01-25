using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using ExifLibrary;


namespace FixExifTimeStamp
{
    class FixExif_methods
    {   
        private static TimeSpan lastCameraOffset = new TimeSpan(0, 0, 0);
        public static bool OverwriteFile = false;
        public static string outPutFolderName = "";
        public static bool RenameFile_asDate = false;

        public static bool OffsetUsePrevious;
        public static bool OffsetUseFixed;
        public static bool RenameVids;

        public static Dictionary<string, TimeSpan> cameraTimeOffsetbase = new Dictionary<string, TimeSpan>();
        static Dictionary<string, TimeSpan> cameraTimeOffset = new Dictionary<string, TimeSpan>();

        FixExif_methods()
        {

        }


        #region EXIFupdates
        /// <summary>
        /// update EXIF datetime from GPS Data.
        /// optional rename file to correct DateTime
        /// https://oozcitak.github.io/exiflibrary/articles/ReadFile.html
        /// </summary>
        /// <param name="filename">input filename. full path</param>
        /// <param name="outPutFolderName">folder to save fixed file. empty to use same.</param>
        /// <param name="RenameFile">rename output to date_time</param>
        /// <returns></returns>
        /// 

        public static string FixEXIFtimestamp(string filename)
                                              
        {
            bool keepExistingFile = true; 
            FileInfo fi = new FileInfo(filename);
            if (string.IsNullOrEmpty(outPutFolderName))
            {
                outPutFolderName = fi.Directory.FullName;
                keepExistingFile = false;
                OverwriteFile = true;
            }
            if (fi.Name == "Thumbs.db") return "";  //dont process

            ExifLibrary.ImageFile exiffile;
            try
            {
                exiffile = ExifLibrary.ImageFile.FromFile(filename);
            }
            catch (ExifLibrary.NotValidImageFileException)
            {
                if(RenameVids)
                {
                    //does the name match datetime   yyyyMMdd_HHmmss 
                    string saveVName;
                    char[] separators = new char[] { '_', '-' };
                    string[] dateparts = Path.GetFileNameWithoutExtension(fi.Name).Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    string stdfmt = string.Format("{0}-{1}", dateparts[0] , dateparts[1]);
                    bool success = DateTime.TryParseExact(
                                          stdfmt,
                                          "yyyyMMdd-HHmmss",
                                          CultureInfo.CurrentCulture,
                                          DateTimeStyles.AssumeLocal,
                                          out DateTime fileNameDate);
                    if (success)
                    {
                        //rename the file as date_time
                        var nextGPStime = fileNameDate.Add(lastCameraOffset);
                        string newName = nextGPStime.ToString("yyyyMMdd_HHmmss");
                        newName += fi.Extension;
                        saveVName = Path.Combine(outPutFolderName, newName);
                        if (OverwriteFile && saveVName == fi.FullName) keepExistingFile = false; else keepExistingFile = true; ;
                    }
                    else
                    { return ""; }
 
                    
                    if (!keepExistingFile)
                    {
                        fi.MoveTo(saveVName);  //rename file;   //delete the redundant original as saved to new folder or new name
                    }
                    else
                    {  fi.CopyTo(saveVName); }  //keep existing

                    return saveVName;
                }
                else return "";
            }
            catch (Exception)
            {
                throw;
            }

            // GPS latitude is a custom type with three rational values
            // representing degrees/minutes/seconds of the latitude 
            var gpsLatTag = exiffile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
            var gpsLongTag = exiffile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLongitude);
            var gpsDate = exiffile.Properties.Get<ExifDate>(ExifTag.GPSDateStamp);
            var gpsTime = exiffile.Properties.Get<GPSTimeStamp>(ExifTag.GPSTimeStamp);
            string cameramodel = exiffile.Properties.Get(ExifTag.Model).Value.ToString();
            if (!cameraTimeOffsetbase.ContainsKey(cameramodel))
            {
                throw new Exception("unexpected camera model");
            }

            TimeSpan baseOffset = cameraTimeOffsetbase[cameramodel];

            if (!cameraTimeOffset.ContainsKey(cameramodel))
            {
                cameraTimeOffset.Add(cameramodel, baseOffset);
                lastCameraOffset = baseOffset;
            }
            else
            {
                lastCameraOffset = cameraTimeOffset[cameramodel];
            }

            ExifProperty exifDatetag = exiffile.Properties.Get(ExifTag.DateTimeOriginal);
            if(exifDatetag == null) exifDatetag = exiffile.Properties.Get(ExifTag.DateTime) ;
            DateTime cameraDateTime = (exifDatetag as ExifDateTime).Value;

            DateTime localGPStime;
            if (gpsDate is null)
            {
                //use lastCameraOffset;
                if (OffsetUseFixed)
                {
                    lastCameraOffset = baseOffset;
                }

                localGPStime = cameraDateTime.Add(lastCameraOffset);
                //ExifProperty exifDateOriginal = exiffile.Properties.Get(ExifTag.DateTimeOriginal);
                exiffile.Properties.Set(ExifTag.DateTime, localGPStime);
                exiffile.Properties.Set(ExifTag.DateTimeOriginal, localGPStime);
            }
            else
            {
                var gpsLatTagR = exiffile.Properties.Get<ExifEnumProperty<GPSLatitudeRef>>(ExifTag.GPSLatitudeRef);
                var gpsLongTagR = exiffile.Properties.Get<ExifEnumProperty<GPSLongitudeRef>>(ExifTag.GPSLongitudeRef);
                float gpsLat = gpsLatTag.ToFloat();
                if (gpsLat > 0 && gpsLatTagR.Value == GPSLatitudeRef.South) gpsLat *= -1;  //North = 1, south = -1
                float gpsLong = gpsLongTag.ToFloat();
                if (gpsLong > 0 && gpsLongTagR.Value == GPSLongitudeRef.West) gpsLong *= -1;  //east=1, west=-1
                DateTime UTCDateTime = gpsDate.Value + new TimeSpan((int)gpsTime.Hour, (int)gpsTime.Minute, (int)gpsTime.Second);
                localGPStime = GPSMethods.GetLocalTimefromGPS(gpsLat, gpsLong, UTCDateTime);


                lastCameraOffset = localGPStime.Subtract(cameraDateTime);  //save for next time
                if (!cameraTimeOffset.ContainsKey(cameramodel))
                {
                    cameraTimeOffset.Add(cameramodel, lastCameraOffset);
                }
                else
                {
                    cameraTimeOffset[cameramodel]= lastCameraOffset;
                }
                // ExifProperty exifDateOriginal = exiffile.Properties.Get(ExifTag.DateTimeOriginal);
                exiffile.Properties.Set(ExifTag.DateTime, localGPStime);
                exiffile.Properties.Set(ExifTag.DateTimeOriginal, localGPStime);

            }


            string saveName;
            if (RenameFile_asDate)
            {
                //rename the file as date_time
                string newName = localGPStime.ToString("yyyyMMdd_HHmmss");
                int uniquenum = 0;
                saveName = Path.Combine(outPutFolderName, newName + fi.Extension);
                while(File.Exists(saveName) && saveName != fi.FullName)
                {
                    uniquenum++;
                    saveName = Path.Combine(outPutFolderName, newName + string.Format("-{0}",uniquenum) + fi.Extension);
                }

                if (OverwriteFile && saveName != fi.FullName) keepExistingFile = false; else keepExistingFile = true; ;
            }
            else
            { saveName = Path.Combine(outPutFolderName, filename); }


            if (!keepExistingFile)
            {
                fi.Delete();   //delete the redundant original as saved to new folder or new name
            }

            exiffile.Save(saveName);  //save exif data back to file

            return saveName;
        }

        /// <summary>
        /// Gets the GPS time offset from EXIF timestamp
        /// assumes no camera date set 10years in future, but may be 10years behind if reset to default
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>
        ///     float to 0.05 hr  +12 -> -12 valid, 99999 not an image, 99901 no GPS time
        ///     camera name
        /// </returns>
        
        public static CameraTimeOffset GetEXIFtime_diff(string filename)
        {
            Exif_Ext.EXIF_Data exif_Data = new Exif_Ext.EXIF_Data(filename);

            switch (exif_Data.Status)
            {
                case "ok":
                    if (exif_Data.CameraName is null) exif_Data.CameraName = "---";
                    if(exif_Data.GPSUTCDate == DateTime.MinValue) return new CameraTimeOffset(exif_Data.CameraName, 99901);

                    DateTime localGPStime = GPSMethods.GetLocalTimefromGPS(exif_Data.GPSLatitude,exif_Data.GPSLongitude, exif_Data.GPSUTCDate);

                    TimeSpan lastCameraOffset = exif_Data.CameraDate.Subtract(localGPStime);

                    //float timedif = (float)Math.Round(lastCameraOffset.TotalHours,1);
                    double roundto = 0.05;
                    float timedif = (float)(Math.Ceiling(lastCameraOffset.TotalHours / roundto) * roundto);
                    CameraTimeOffset thisOffset = new CameraTimeOffset(exif_Data.CameraName, -1 * timedif);
                    return thisOffset;

                case "Not Image":
                    return new CameraTimeOffset("Not Image", 99999);

                default:
                    //error occurred
                    return new CameraTimeOffset("Exception", 99999);

            }
        }

        #endregion

    }
    class GPS2Date_options
    {
        public string OutputFolder { get; set; }
        public bool RenameFileasDate { get; set; }

        public bool OffsetUsePrevious { get; set; }
        public bool OffsetUseFixed { get; set; }
        public float OffsetFixed { get; set; }
    }

    internal struct CameraTimeOffset
    {
        public string cameraName;
        public float OffsetTime;

        public CameraTimeOffset(string item1, float item2)
        {
            cameraName = item1;
            OffsetTime = item2;
        }

        public override bool Equals(object obj)
        {
            return obj is CameraTimeOffset other &&
                   cameraName == other.cameraName &&
                   OffsetTime == other.OffsetTime;
        }

        public override int GetHashCode()
        {
            int hashCode = -1030903623;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cameraName);
            hashCode = hashCode * -1521134295 + OffsetTime.GetHashCode();
            return hashCode;
        }

        public void Deconstruct(out string CameraName, out float offsetTimespan)
        {
            CameraName = cameraName;
            offsetTimespan = OffsetTime;
        }


    }
}
