using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class CaesarCipher : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            int offset = System.Convert.ToInt32(key);
            String key2 = helperMethod(offset);
            String result = base.encrypt(key2, plaintext);
            return result;
        }

        public override String decrypt(String key, String ciphertext)
        {
            int offset = System.Convert.ToInt32(key); ;
            String key2 = helperMethod(offset);
            String result = base.decrypt(key2, ciphertext);
            return result;
        }

        public String helperMethod(int offset)
        {
            // Generate Caesar cipher offset alphabet...
            string plainAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cipherAlphabet = "";
            for (int i = 0; i <= 25; i++)
            {
                cipherAlphabet += (char)(65+mod((int)plainAlphabet[i] - (65 + offset), 26));
            }
            return cipherAlphabet;
        }
        private int mod (int number, int divider)
        {
            return ((number % divider) + divider) % divider;
        }
        //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
        // reference
    }
}

