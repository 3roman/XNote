using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace XNote
{
    public static class ImageHelper
    {
        public static byte[] ImageToBytes(Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                var imageBytes = ms.ToArray();

                return imageBytes;
            }

        }

        public static void BytesToImage(byte[] bytes, string imagePath, bool isOverlay)
        {
            if (File.Exists(imagePath) && !isOverlay)
            {
                return;
            }
            var fs = new FileStream(imagePath, FileMode.CreateNew);
            var bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();

        }
    }
}
