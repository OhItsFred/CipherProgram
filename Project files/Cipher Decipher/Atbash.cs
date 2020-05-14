using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class Atbash : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            String result = base.encrypt(key, plaintext);
            return result;
        }

        public override String decrypt(String key, String ciphertext)
        {
            String result = base.decrypt(key, ciphertext);
            return result;
        }
    }
}
