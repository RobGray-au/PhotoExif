using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;


using Exif_Ext;
using ImagerLib;

namespace KMZ_PhotoMapper
{

    static class ImageMethods
    {

        public static Image ResizeImageFile(FileInfo fi, int max_width = 128, int max_height = 128)
        {
            var rotationDegree = EXIF_Methods.ComputeRotateFlipType(fi.FullName);

            Image image_blob = Image.FromFile(fi.FullName);
            Image resized = ImagerLib.Imager.ImageResize(image_blob, max_width, max_height, true, rotationDegree);

            return resized;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public static bool SaveOutputImage(string outputfilename,Image imagetoSave,long quality=80L)
        {
            try
            {
                FileInfo fo = new FileInfo(outputfilename);
                string fext = fo.Extension.ToLower();

                switch (fext)
                {
                    case ".jpg":
                    case ".jpeg":
                        {
                            Imager.SaveJpeg(fo.FullName, imagetoSave, quality);
                            break;
                        }

                    case ".png":

                        {
                            ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Png);
                            Imager.Save(fo.FullName, imagetoSave, codecInfo, quality);
                            break;
                        }

                    case ".gif":
                        {
                        ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Gif);
                        Imager.Save(fo.FullName, imagetoSave, codecInfo, quality);
                        break;
                        }

                    default:
                        {
                        ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Jpeg);
                        Imager.Save(fo.FullName, imagetoSave, codecInfo, quality);
                        break;
                        }
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        /// <summary>
        /// Rotate the modified picture based on the orientation property of the original picture
        /// </summary>
        /// <param name="inputPath">Original picture path</param>
        /// <param name="outputPath">Modified picture path</param>
        public static void RotationWhenTransformationIsRequired(string inputPath, string outputPath)
        {
            var rotationDegree = EXIF_Methods.ComputeRotateFlipType(inputPath);
            if (rotationDegree.HasValue && rotationDegree.Value != RotateFlipType.RotateNoneFlipNone)
            {
                var bitmap = (Bitmap)Bitmap.FromFile(outputPath);
                bitmap.RotateFlip(rotationDegree.Value);
                using (var stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                }
            }
        }

        /// <summary>
        /// Returns the date of phototaken 
        /// due to different manufactures stringrepresentaions in EXIF
        /// </summary>
        /// <param name="cameramaker"></param>
        /// <param name="sdateTime"></param>
        /// <returns></returns>
        public static DateTime ConvertDate_Cameraspecific(string cameramaker, string sdateTime)
        {
            if (sdateTime is null)
            {
                return DateTime.MinValue; //amke default 01/Jan/0001
            }

            CultureInfo provider = CultureInfo.InvariantCulture;
            if (!DateTime.TryParse(sdateTime, out DateTime dateTaken))
            {
                //try a type for Nikon camera
                string datefmt = "yyyy:MM:dd HH:nn:ss";
                switch (cameramaker.ToUpper())
                {
                    case "SAMSUNG":
                        datefmt = "yyyy:MM:dd HH:mm:ss";
                        break;
                    case "NIKON":
                        datefmt = "yyyy:MM:dd HH:mm:ss";
                        break;
                    case "OLYMPUS IMAGING CORP.":
                        datefmt = "yyyy:MM:dd HH:mm:ss";
                        break;
                    default:
                        dateTaken = Convert.ToDateTime(sdateTime);
                        break;
                }
                // Parse date and time with custom specifier.
                try
                {
                    dateTaken = DateTime.ParseExact(sdateTime, datefmt, provider);
                    //Console.WriteLine("{0} converts to {1}.", sdateTime, dateTaken.ToString());
                }
                catch (FormatException)
                {
                    //Console.WriteLine("{0} is not in the correct format.", sdateTime);
                }
            }

            return dateTaken;
        }

    }
}
