using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class Vigenere : Cipher
    {            
        char[,] tabula = new char[26, 26];
        public override String encrypt(String key, String plaintext)
        {
            string cipherText = "";
            tabulaCreation();
            for (int letters = 0; letters <= plaintext.Length - 1; letters++)
            {
                cipherText = cipherText + tabula[(char)(key[letters % key.Length]) - 65, (char)(plaintext[letters]) - 65];
            }
            return cipherText;
        }
        public override String decrypt(String key, String ciphertext)
        {
            string plainText = "";
            for (int letters = 0; letters <= ciphertext.Length - 1; letters++)
            {
                if (((int)ciphertext[letters] - (int)key[letters % key.Length]) < 0)
                {
                    plainText += (char)(65 + 26 + ((int)ciphertext[letters] - (int)key[letters % key.Length]));
                }
                else
                {
                    plainText += (char)(65 + ((int)ciphertext[letters] - (int)key[letters % key.Length]));
                }
            }
            return plainText;
        }

        private void tabulaCreation()
        {
            for (int row = 0; row <= 25; row++)
            {
                for (int column = 0; column <= 25; column++)
                {
                    tabula[row, column] = (char)((65 + ((row + column) % 26)));
                }
            }
        }

    }
}
