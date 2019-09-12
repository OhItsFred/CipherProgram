using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class OneTimePad : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int cipherLetterNum = 0;
            int KeyLetterNum = 0;
            int totalNum = 0;
            string ciphertext = "";
            for (int i = 0; i<= plaintext.Length -1; i++)
            {
                totalNum = 0;
                cipherLetterNum = alphabet.IndexOf(plaintext[i]);
                KeyLetterNum = alphabet.IndexOf(key[i % key.Length]);
                totalNum = (cipherLetterNum + KeyLetterNum) % 26;
                ciphertext += alphabet[totalNum];
            }
            return ciphertext;
        }

        public override String decrypt(String key, String ciphertext)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int cipherLetterNum = 0;
            int KeyLetterNum = 0;
            int totalNum = 0;
            string plaintext = "";
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                totalNum = 0;
                cipherLetterNum = alphabet.IndexOf(ciphertext[i]);
                KeyLetterNum = alphabet.IndexOf(key[i % key.Length]);
                totalNum = mod((cipherLetterNum - KeyLetterNum), 26);
                plaintext += alphabet[totalNum];
            }
            return plaintext;
        }
        private int mod(int number, int divider)
        {
            return ((number % divider) + divider) % divider;
        }
    }
}
