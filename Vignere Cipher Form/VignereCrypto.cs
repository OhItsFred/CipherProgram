using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vignere_Cipher_Form
{
    class VignereCrypto
    {
        // Variable to store our single instance
        private static VignereCrypto instance;

        // Private initialisor method to prevent instantiation
        private VignereCrypto() { }

        // Allow others to access the class via the static instance
        public static VignereCrypto getInstance
        {
            get
            {
                // Lazy initialization
                if (instance == null)
                {
                    instance = new VignereCrypto();
                }
                return instance;
            }
        }

        public string Encrypt(string plainText, string key)
        {
            char[,] tabula = new char[26, 26];
            string tidy = "";
            string cipherText = "";
            plainText = plainText.ToUpper();
            key = key.ToUpper();
            for (int row = 0; row <= 25; row++)
            {
                for (int column = 0; column <= 25; column++)
                {
                    tabula[row, column] = (char)((65 + ((row + column) % 26)));
                }
            }
            for (int letters = 0; letters <= plainText.Length - 1; letters++)
            {
                if (((int)(plainText[letters]) >= 65) && ((int)(plainText[letters]) <= 90))
                {
                    tidy = tidy + plainText[letters];
                }
            }
            for (int letters = 0; letters <= tidy.Length - 1; letters++)
            {
                cipherText += tabula[(char)(key[letters % key.Length]) - 65, (char)(tidy[letters]) - 65];
            }
            return cipherText;
        }

        public string Decrypt(string cipherText, string key)
        {
            string plainText = "";
            cipherText = cipherText.ToUpper();
            key = key.ToUpper();
            for (int letters = 0; letters <= cipherText.Length - 1; letters++)
            {
                if (((int)cipherText[letters] - (int)key[letters % key.Length]) < 0)
                {
                    plainText += (char)(65 + 26 + ((int)cipherText[letters] - (int)key[letters % key.Length]));
                }
                else
                {
                    plainText += (char)(65 + ((int)cipherText[letters] - (int)key[letters % key.Length]));
                }
            }
            return plainText;
        }
    }
}
