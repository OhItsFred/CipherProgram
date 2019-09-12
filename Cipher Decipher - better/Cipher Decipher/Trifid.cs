using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class Trifid : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            int[] coordinates = new int[(plaintext.Length * 3)];
            string cipherAlphabet = key;
            int position = 0;
            int counter = 0;
            string ciphertext = "";
            for (int i = 0; i <= plaintext.Length - 1; i++)
            {
                position = cipherAlphabet.IndexOf(plaintext[i]);
                coordinates[i] = ((position % 9) / 3) + 1;
                coordinates[i + plaintext.Length] = (position / 9) +1;
                coordinates[i + (plaintext.Length * 2)] = (position % 3) + 1;
            }
            counter = 0;
            for (int i = 0; i <= plaintext.Length - 1; i++)
            {
                ciphertext += cipherAlphabet[(coordinates[counter] * 3) + coordinates[counter + 2] + (coordinates[counter + 1] * 9) - 13];
                counter += 3;
            }
            return ciphertext;
        }

        public override String decrypt(String key, String ciphertext)
        {
            int[] coordinates = new int[(ciphertext.Length * 3)];
            string cipherAlphabet = key;
            int position = 0;
            int counter = 0;
            string plaintext = "";
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                position = cipherAlphabet.IndexOf(ciphertext[i]);
                coordinates[counter] = ((position % 9) / 3) + 1;
                coordinates[counter + 1] = (position / 9) + 1;
                coordinates[counter + 2] = (position % 3) + 1;
                counter += 3;
            }
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                plaintext += cipherAlphabet[(coordinates[i]*3) + coordinates[i+ (ciphertext.Length * 2)] + (coordinates[i+ ciphertext.Length] * 9) -13];
            }
            return plaintext;
        }
    }
}
