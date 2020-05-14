using System;
namespace Cipher_Decipher
{
    class RailFence : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            string cipherText = "";
            Matrix Rails = new Matrix(Convert.ToInt16(key), plaintext.Length);
            bool direction = false;
            int row = 0;
            int col = 0;
            //for (int i = 0; i <= Convert.ToInt16(key); i++)
            //{
            //    for (int j = 0; j<=plaintext.Length; j++)
            //    {
            //        Rails.setElement(i,j, Convert.ToInt32(""));
            //    }
            //}
            for (int i = 0; i<=plaintext.Length -1;i++)
            {
                if (row ==0 | row == Convert.ToInt16(key)-1)
                {
                    direction = !(direction);
                }
                Rails.setElement(row, col, Convert.ToInt32(plaintext[i]));
                col++;
                if (direction)
                {
                    row += 1;
                }
                else
                {
                    row -= 1;
                }
            }
            cipherText = cipherTextCreation(Rails, plaintext, Convert.ToInt16(key));
            return cipherText;
        }

        public override String decrypt(String key, String ciphertext)
        {
            string plainText = "";
            Matrix Rails = new Matrix(Convert.ToInt16(key), ciphertext.Length);
            bool direction = false;
            int row = 0;
            int col = 0;
            char comparison = '*';
            int counter = 0;
            char letterStore;
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {
                if (row ==0 | row == Convert.ToInt16(key)-1)
                {
                    direction = !(direction);
                }
                Rails.setElement(row, col, Convert.ToInt32(comparison));
                col++;
                if (direction)
                {
                    row += 1;
                }
                else
                {
                    row -= 1;
                }
            }
            for (int i = 0; i <= Convert.ToInt16(key) - 1; i++)
            {
                for (int j = 0; j<= ciphertext.Length -1; j++)
                {
                    if (Rails.getElement(i,j) == 42)
                    {
                        letterStore = Convert.ToChar(ciphertext.Substring(counter, 1));
                        Rails.setElement(i, j, (char)letterStore);                        
                        counter++;
                        //Rails.setElement(i, j, Convert.ToInt32(ciphertext[j]));
                    }
                }
            }
            row = 0; col = 0;direction = false;
            for (int i = 0; i <= ciphertext.Length - 1; i++)
            {                
                plainText += (char)Convert.ToChar(Rails.getElement(row,col));

                if (row ==0 | row == Convert.ToInt16(key)-1)
                {
                    direction = !(direction);
                }
                col++;
                if (direction)
                {
                    row += 1;
                }
                else
                {
                    row -= 1;
                }
            }

                return plainText;
        }
        private string cipherTextCreation(Matrix rails, string plaintext, int key)
        {
            string cipherText = "";
            for (int i = 0; i <= Convert.ToInt16(key) - 1; i++)
            {
                for (int j = 0; j <= plaintext.Length - 1; j++)
                {
                    if (rails.getElement(i,j) != 0)
                    {
                        cipherText += (char)(rails.getElement(i, j));
                    }
                }
            }
            return cipherText;
        }

    }
}
