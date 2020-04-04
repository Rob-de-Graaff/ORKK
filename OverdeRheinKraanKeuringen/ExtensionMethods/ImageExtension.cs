using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace OverdeRheinKraanKeuringen.ExtensionMethods
{
    public static class ImageExtension
    {
        public static byte[] ConvertImage(string FileName)
        {
            Image img = Image.FromFile(FileName);
            byte[] ImageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                ImageBytes = ms.ToArray();
            }

            return ImageBytes;
        }
    }
}