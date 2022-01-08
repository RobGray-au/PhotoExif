﻿using System;
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
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
                    DateTime fileNameDate;
                    bool success = DateTime.TryParseExact(
                                          stdfmt,
                                          "yyyyMMdd-HHmmss",
                                          CultureInfo.CurrentCulture,
                                          DateTimeStyles.AssumeLocal,
                                          out fileNameDate);
                    if (success)
                    {
                        //rename the file as date_time
                        var nextGPStime = fileNameDate.Add(lastCameraOffset);
                        string newName = nextGPStime.ToString("yyyyMMdd_HHmmss");
                        newName += fi.Extension;
                        saveVName = Path.Combine(outPutFolderName, newName);
                        if (OverwriteFile && saveVName != fi.FullName) keepExistingFile = false; else keepExistingFile = true; ;
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

            ExifProperty exifDatetag = exiffile.Properties.Get(ExifTag.DateTime);
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
                DateTime UTCDateTime = gpsDate.Value + new TimeSpan((int)gpsTime.Hour, (int)gpsTime.Minute, (int)gpsTime.Second);
                localGPStime = GPSMethods.GetLocalTimefromGPS(gpsLatTag.ToFloat(), gpsLongTag.ToFloat(), UTCDateTime);

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
        /// <returns>+12 -> -12 valid, -999 not an image, -99 no GPS time</returns>
        public static CameraTimeOffset GetEXIFtime_diff(string filename)
        {
            ExifLibrary.ImageFile exiffile;
            
            try
            {
                exiffile = ExifLibrary.ImageFile.FromFile(filename);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (ExifLibrary.NotValidImageFileException)
            {
                CameraTimeOffset thisOffset = new CameraTimeOffset("Not Image", 99999);
                return thisOffset;
            }

            catch (Exception)
            {
                CameraTimeOffset thisOffset = new CameraTimeOffset("Exception", 99999);
                return thisOffset;
            }
#pragma warning restore CA1031 // Do not catch general exception types
            string cameraName = exiffile.Properties.Get(ExifTag.Model).Value.ToString();

            // GPS latitude is a custom type with three rational values
            // representing degrees/minutes/seconds of the latitude 
            var gpsLatTag = exiffile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
            var gpsLongTag = exiffile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLongitude);
            var gpsDate = exiffile.Properties.Get<ExifDate>(ExifTag.GPSDateStamp);
            var gpsTime = exiffile.Properties.Get<GPSTimeStamp>(ExifTag.GPSTimeStamp);
            ExifProperty exifDatetag = exiffile.Properties.Get(ExifTag.DateTime);
            DateTime cameraDateTime = (exifDatetag as ExifDateTime).Value;

            if (gpsDate is null)
            {
                CameraTimeOffset thisOffset = new CameraTimeOffset(cameraName, 99901);
                return thisOffset;
                  //assumed no camera set 10years in advance
            }
            else
            {
                DateTime UTCDateTime = gpsDate.Value + new TimeSpan((int)gpsTime.Hour, (int)gpsTime.Minute, (int)gpsTime.Second);
                DateTime localGPStime = GPSMethods.GetLocalTimefromGPS(gpsLatTag.ToFloat(), gpsLongTag.ToFloat(), UTCDateTime);
                TimeSpan lastCameraOffset = cameraDateTime.Subtract(localGPStime);

                //float timedif = (float)Math.Round(lastCameraOffset.TotalHours,1);
                double roundto = 0.05;
                float timedif = (float)(Math.Ceiling(lastCameraOffset.TotalHours / roundto) * roundto);
                CameraTimeOffset thisOffset = new CameraTimeOffset(cameraName, -1 * timedif);
                return thisOffset;
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
