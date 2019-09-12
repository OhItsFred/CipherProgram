using System;
using System.IO;
using System.Drawing;
namespace Cipher_Decipher
{
    public class AppImage
    {
        public string fileName;
        public Bitmap bitmapData;

        public AppImage(string fn, Bitmap bd)
        {
            fileName = fn;
            bitmapData = bd;
        }

        public static AppImage OpenFromFile(string fileName)
        {
            var bitmapData = new Bitmap(fileName);
            AppImage image = new AppImage(fileName, bitmapData);
            return image;
        }

        public string GetFileExtension()
        {
            return Path.GetExtension(this.fileName);

        }

        public void SaveToFile(System.IO.FileStream fs, int fi)
        {
            switch (fi)
            {
                case 1:
                    this.bitmapData.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case 2:
                    this.bitmapData.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                    break;
            }
            fs.Close();
        }

        public Bitmap ScaleImage()
        {
            double ratioX = (double)315 / this.bitmapData.Width;
            double ratioY = (double)315 / this.bitmapData.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(this.bitmapData.Width * ratio);
            int newHeight = (int)(this.bitmapData.Height * ratio);

            var newBitmapData = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newBitmapData).DrawImage(this.bitmapData, 0, 0, newWidth, newHeight);
            return newBitmapData;
        }
    }
}
