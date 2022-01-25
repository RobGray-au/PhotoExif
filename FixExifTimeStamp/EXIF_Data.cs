using System;
using System.Drawing;
using ExifLibrary;

namespace Exif_Ext
{
    class EXIF_Data
    {
        public ExifLibrary.ImageFile ExifFile { get; private set; }
        public string Status { get; private set; }
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
                ExifFile = ExifLibrary.ImageFile.FromFile(filename);

                LoadbaseProps();
                Status = "ok";
            }

            catch (ExifLibrary.NotValidImageFileException)
            {
                Status = "Not Image";
            }

            catch (Exception ex)
            {
                Status = "!EX"+ ex.ToString(); ;
            }

        }

        private void LoadbaseProps()
        {
            ExifProperty exifDatetag = ExifFile.Properties.Get(ExifTag.DateTimeOriginal);
            if (exifDatetag == null) exifDatetag = ExifFile.Properties.Get(ExifTag.DateTime);
            if (exifDatetag == null) return;

            CameraDate = (exifDatetag as ExifDateTime).Value;
            CameraName = ExifFile.Properties.Get(ExifTag.Model).Value.ToString();
            CameraMake = ExifFile.Properties.Get(ExifTag.Make).Value.ToString();
            

            // GPS latitude is a custom type with three rational values
            // representing degrees/minutes/seconds of the latitude 
            var gpsLatTag = ExifFile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
            var gpsLongTag = ExifFile.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLongitude);

            var gpsLatRef = ExifFile.Properties.Get<ExifEnumProperty<GPSLatitudeRef>>(ExifTag.GPSLatitudeRef);
            var gpsLongRef = ExifFile.Properties.Get<ExifEnumProperty<GPSLongitudeRef>>(ExifTag.GPSLongitudeRef);

            var gpsDate = ExifFile.Properties.Get<ExifDate>(ExifTag.GPSDateStamp);
            var gpsTime = ExifFile.Properties.Get<GPSTimeStamp>(ExifTag.GPSTimeStamp);

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

                if (gpsLatRef.Value == GPSLatitudeRef.South) { GPSLatitude *= -1; }
                if (gpsLongRef.Value == GPSLongitudeRef.West) { GPSLongitude *= -1; }
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
