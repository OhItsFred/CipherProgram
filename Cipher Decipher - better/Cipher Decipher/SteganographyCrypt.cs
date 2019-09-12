using System;
//using System.Collections;
using System.Drawing;
namespace Cipher_Decipher
{
    class SteganographyCrypt
    {
        private Queue<char> decryptedChar = new Queue<char>();

        public Bitmap encrypt(Bitmap plainImage, string plainText)
        {
            Bitmap image = new Bitmap(plainImage);
            Color colour;
            string letterBinary;
            int rValue = 0;
            int gValue = 0;
            int bValue = 0;
            int x = 0;
            int y = 0;
            string nullChar = "\0";
            plainText = plainText + nullChar;
            // pad message out to be multiple of 3

            for (int i = 0; i <= plainText.Length - 1; i++)
            {
                letterBinary = Convert.ToString(plainText[i], 2);
                letterBinary = padMessage(letterBinary);
                //pad to 8 digits
                do
                {
                    // do stuff
                    if (y == image.Height)
                    {
                        x++;
                        y = 0;
                    }
                    rValue = Convert.ToInt32(changePixelData(image, letterBinary, "R", x, y), 2);
                    letterBinary = letterBinary.Remove(0, 1);
                    gValue = Convert.ToInt32(changePixelData(image, letterBinary, "G", x, y), 2);
                    letterBinary = letterBinary.Remove(0, 1);
                    // if j = 2 skip this and set bvalue to 0
                    if (letterBinary.Length != 0)
                    {
                        bValue = Convert.ToInt32(changePixelData(image, letterBinary, "B", x, y), 2);
                        letterBinary = letterBinary.Remove(0, 1);
                    }
                    else
                    {
                        colour = image.GetPixel(x, y);
                        bValue = colour.B;
                    }
                    colour = Color.FromArgb(rValue, gValue, bValue);
                    image.SetPixel(x, y, colour);
                    y++;
                }
                while (letterBinary.Length != 0);
            }

            return image;
        }
        public string decrypt(Bitmap cipherImage)
        {
            //Queue decryptedChar = new Queue();
            const char nullChar = '\0';
            string characterBinary = "";
            Bitmap image = new Bitmap(cipherImage);
            Color colour;
            string rValue;
            string gValue;
            string bValue;
            int x = 0;
            int y = 0;
            characterBinary = "";
            while ((x * y) != (image.Width * image.Height))
            {
                characterBinary = "";
                for (int i = 0; i <= 2; i++)
                {
                    if (y == image.Height)
                    {
                        x++;
                        y = 0;
                    }
                    colour = image.GetPixel(x, y);
                    rValue = findLastDigit(padMessage(Convert.ToString(colour.R, 2)));
                    gValue = findLastDigit(padMessage(Convert.ToString(colour.G, 2)));
                    if (i != 2)
                    {
                        bValue = findLastDigit(padMessage(Convert.ToString(colour.B, 2)));
                    }
                    else { bValue = ""; }
                    characterBinary += rValue + gValue + bValue;
                    y++;
                }
                var temp = Convert.ToInt32(characterBinary, 2);
                if ((char)temp == nullChar)
                {
                    return queueToPlainText(decryptedChar);
                }
                else
                {
                    decryptedChar.Enqueue((char)temp);
                }
            }
            return queueToPlainText(decryptedChar);
        }

        private string changePixelData(Bitmap image, string letterBinary, string colourType, int x, int y)
        {
            string pixelBinary = "";
            Color colour = image.GetPixel(x, y);
            if (colourType == "R")
            {
                pixelBinary = Convert.ToString(colour.R, 2);
            }
            else if (colourType == "G")
            {
                pixelBinary = Convert.ToString(colour.G, 2);
            }
            else if (colourType == "B")
            {
                pixelBinary = Convert.ToString(colour.B, 2);
            }
            pixelBinary = pixelBinary.Remove(pixelBinary.Length - 1, 1) + letterBinary[0];
            //letterBinary = letterBinary.Remove(0, 1);
            return pixelBinary;
        }
        private string padMessage(string letterBinary)
        {
            string paddedMessage;
            paddedMessage = letterBinary.PadLeft(8, '0');
            return paddedMessage;
        }
        private string findLastDigit(string colourValue)
        {
            string singleDigit = colourValue.Remove(0, 7);
            return singleDigit;
        }
        private string queueToPlainText(Queue<char> decryptedMessage)
        {
            string plainText = "";
            foreach (var character in decryptedMessage)
            {
                plainText += character;
            }
            return plainText;
        }
    }
}