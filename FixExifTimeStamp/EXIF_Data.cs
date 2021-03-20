using System;
using System.Drawing;
using ExifLibrary;

namespace Exif_Ext
{
    class EXIF_Data
    {
        public ExifLibrary.ImageFile exiffile { get; private set; }
        public string status { get; private set; }
        public string CameraName { get; set; }
        public string CameraMake { get; private set; }
        public DateTime CameraDate { get; private set; }
        public float GPSLatitude { get; private set; }
        public float GPSLongitude { get; private set; }
        public DateTime GPSUTCDate { get; private set; }

        public EXIF_Data(string filename)
        {
            try
            {
                exiffile = ExifLibrary.ImageFile.FromFile(filename);
                LoadbaseProps();
                status = "ok";
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (ExifLibrary.NotValidImageFileException)
            {
                status = "Not Image";
            }

            catch (Exception ex)
            {
                status = "!EX"+ ex.ToString(); ;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        private void LoadbaseProps()
        {

            CameraName = exiffile.Properties.Get(ExifTag.Model).Value.ToString();
            CameraMake = exiffile.Properties.Get(ExifTag.Make).Value.ToString();
            ExifProperty exifDatetag = exiffile.Properties.Get(ExifTag.DateTime);
            CameraDate = (exifDatetag as ExifDateTime).Value;

            // GPS latitude is a custom type with three rational values
            // representing degrees/minutes/seconds of the latitude 
            var gpsLatTag = exiffile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
            var gpsLongTag = exiffile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLongitude);
            var gpsDate = exiffile.Properties.Get<ExifDate>(ExifTag.GPSDateStamp);
            var gpsTime = exiffile.Properties.Get<GPSTimeStamp>(ExifTag.GPSTimeStamp);

            if (gpsLatTag is null)
            {
                GPSLongitude = -999;
                GPSLatitude = -999;
                GPSUTCDate = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Unspecified);
                    return;
            }
            else
            {
                GPSLatitude = gpsLatTag.ToFloat();
                GPSLongitude = gpsLongTag.ToFloat();
            }

            if (gpsDate is null)
            {
                GPSUTCDate =  DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Unspecified);
            }
            else
            {
                GPSUTCDate = gpsDate.Value + new TimeSpan((int)gpsTime.Hour, (int)gpsTime.Minute, (int)gpsTime.Second);
                GPSUTCDate = DateTime.SpecifyKind(GPSUTCDate, DateTimeKind.Utc);
            }
        }
    }

    static class EXIF_Methods
    {
        /// <summary>
        /// Retrieve the rotate flip type to apply to the modified picture
        /// </summary>
        /// <param name="path">Original picture</param>
        /// <returns>Nullabe RotateFlipType</returns>
        public static RotateFlipType? ComputeRotateFlipType(string path)
        {

            ExifLibrary.ImageFile exiffile;
            try
            {
                exiffile = ExifLibrary.ImageFile.FromFile(path);
            }
            catch (ExifLibrary.NotValidImageFileException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }

            // GPS latitude is a custom type with three rational values
            // representing degrees/minutes/seconds of the latitude 
            var exifOrient = exiffile.Properties.Get(ExifTag.Orientation).Value;
            if (exifOrient == null)
            {
                return null;
            }

            switch (exifOrient)
            {
                case Orientation.Normal:
                    return RotateFlipType.RotateNoneFlipNone;

                case Orientation.Flipped: return RotateFlipType.RotateNoneFlipX;
                case Orientation.Rotated180: return RotateFlipType.Rotate180FlipNone;

                case Orientation.FlippedAndRotated180:
                    return RotateFlipType.Rotate180FlipX;

                case Orientation.FlippedAndRotatedLeft:
                case 5:
                    return RotateFlipType.Rotate90FlipX;

                case Orientation.RotatedLeft:
                case 6:
                    return RotateFlipType.Rotate90FlipNone;

                case Orientation.FlippedAndRotatedRight:
                case 7:
                    return RotateFlipType.Rotate270FlipX;

                case Orientation.RotatedRight:
                case 8:
                    return RotateFlipType.Rotate270FlipNone;

                default:
                    break;
            }

            return null;
        }

    }
}
