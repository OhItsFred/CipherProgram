using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class LetterSub : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            String cipherText = base.encrypt(key, plaintext);
            return cipherText;
        }

        public override String decrypt(String key, String ciphertext)
        {
            String plainText = base.decrypt(key, ciphertext);
            return plainText;
        }
    }
}
