using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace OverdeRheinKraanKeuringen.ExtensionMethods
{
    public static class ImageExtension
    {
        public static byte[] ConvertImage(string filePath)
        {
            //FileInfo f = new FileInfo(filePath);
            //string fullPath = f.FullName;
            Image img = Image.FromFile(filePath);
            byte[] ImageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                // saves image to stream using memorystream, file format
                string str = img.RawFormat.ToString();
                img.Save(ms, img.RawFormat);
                ImageBytes = ms.ToArray();
            }

            return ImageBytes;
        }

        // gets contentType (e.g. image/png) from byte array
        public static string GetMimeTypeFromImageByteArray(byte[] byteArray)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            using (Image image = Image.FromStream(stream))
            {
                return ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == image.RawFormat.Guid).MimeType;
            }
        }
    }
}