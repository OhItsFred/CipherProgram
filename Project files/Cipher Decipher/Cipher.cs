using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    abstract class Cipher
    {
        public virtual String encrypt(string key, string plaintext)
        {
            // Shared code
            // variable to store the cipher alphabet used to encrypt
            string cipherAlphabet = key;
            // variable to temporarily store the ASCII value of a character
            int tempASCII;
            // variable to store the encrypted text
            string cipherText = "";
            // loops from 0 to the length of the plaintext minus one
            for (int i = 0; i <= plaintext.Length - 1; i++)
            {
                // makes tempASCII variable equal to the ASCII value of the current character
                tempASCII = (int)plaintext[i];
                // if the ASCII value is a valid letter character
                if (tempASCII >= 65 && tempASCII <= 90)
                {
                    // add the encrypted character to the ciphertext
                    cipherText += cipherAlphabet[tempASCII - 65];
                }
                else
                {
                    // otherwise just add the unencrypted character straight into the ciphertext
                    cipherText += plaintext[i];
                }
            }
            // return the ciphertext to that it can be outputted
            return cipherText;
        }
        public virtual String decrypt(String key, String ciphertext)
        {
            // Shared code...
            // define plain alphabet
            string plainAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // see previous comments for following variable declarations
            string cipherAlphabet = key;
            int tempASCII;
            // variable to store the plaintext or decrypted version of the emssage
            string plainText = "";
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                // makes tempASCII variable equal to the ASCII value of the current character
                tempASCII = (int)ciphertext[i];
                // if the ASCII value is a valid letter character
                if (tempASCII >= 65 && tempASCII <= 90)
                {
                    // add the decrypted character to the plaintext variable
                    plainText += plainAlphabet[cipherAlphabet.IndexOf(ciphertext[i])];
                }
                else
                {
                    // otherwise just add the unencrypted character straight into the plaintext
                    plainText += ciphertext[i];
                }
            }
            // return the decrypted message so it can be outputted
            return plainText;
        }
    }
}

