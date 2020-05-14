using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class Bifid : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            string cipherAlphabet = key;
            int[] coordinates = new int[plaintext.Length * 2];
            int position = 0;
            for (int i = 0; i <= plaintext.Length - 1; i++)
            {
                position = cipherAlphabet.IndexOf(plaintext[i]);
                coordinates[i] = position / 5 + 1;
                coordinates[i + plaintext.Length] = (position % 5) + 1;
            }

            int counter = 0;
            string cipherText = "";
            for (int i = 0; i <= plaintext.Length - 1; i++)
            {
                cipherText += cipherAlphabet[((coordinates[counter] - 1) * 5) + coordinates[counter + 1] - 1];
                counter += 2;
            }
            return cipherText;
        }

        public override String decrypt(String key, String ciphertext)
        {
            // key = BGWKZQPNDSIOAXEFCLUMTHYVR
            //string cipherAlphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string cipherAlphabet = key;
            int[] coordinates = new int[ciphertext.Length * 2];
            int counter = 0;
            int position;
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                position = cipherAlphabet.IndexOf(ciphertext[i]);
                coordinates[counter] = position / 5 + 1;
                coordinates[counter + 1] = (position % 5) + 1;
                counter += 2;
            }
            counter = 0;
            string plaintext = "";
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                plaintext += cipherAlphabet[((coordinates[counter] - 1) * 5) + coordinates[counter + ciphertext.Length] - 1];
                counter++;
            }
            return plaintext;
        }
    }
}
