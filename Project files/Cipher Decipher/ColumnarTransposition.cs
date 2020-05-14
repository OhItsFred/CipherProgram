using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher_Decipher
{
    class ColumnarTransposition : Cipher
    {
        public override String encrypt(String key, String plaintext)
        {
            string cipherText = "";
            // pad out the message to ensure that it fills all the columns completely
            plaintext = PadMessage(key, plaintext);
            // create array variable to store the contents of each column
            string[] columns = ColumnCreation(key, plaintext);
            // create array to store each character of the key so that it can be sorted into alphabetical order
            char[] sortedKey = new char[key.Length -1];
            // add each character of the keyword into the sortedKey array
            sortedKey = key.ToCharArray();
            // using an insertion sort, sort the char array alphabetically
            MergeSort(ref sortedKey);
            for (int i = 0; i<= key.Length -1; i++)
            {
                cipherText += columns[key.IndexOf(sortedKey[i])]; 
            }
            return cipherText;
        }

        public override String decrypt(String key, String ciphertext)
        {
            string plaintext = "";
            string[] encryptedColumns = new string[key.Length];
            for (int i = 0; i <= key.Length - 1; i++)
            {
                encryptedColumns[i] = ciphertext.Substring(i * (ciphertext.Length / key.Length), ciphertext.Length / key.Length);
            }
            // create array to store each character of the key so that it can be sorted into alphabetical order
            char[] sortedKey = new char[key.Length - 1];
            // add each character of the keyword into the sortedKey array
            sortedKey = key.ToCharArray();
            // using an insertion sort, sort the char array alphabetically
            MergeSort(ref sortedKey);
            int[] order = new int[key.Length];
            for (int i =0; i<=key.Length -1; i++)
            {
                order[i] = key.IndexOf(sortedKey[i]);
            }
            string[] decryptedColumns = new string[key.Length];
            for (int i = 0; i <= key.Length - 1; i++)
            {
                decryptedColumns[i] = encryptedColumns[order[i]];
            }
            for (int i = 0; i<=decryptedColumns[0].Length -1;i++)
            {
                for (int j = 0; j<=key.Length - 1; j++)
                {
                    plaintext += decryptedColumns[j][i];
                }
            }
            return plaintext;
        }

        private string PadMessage(String key, String plainText)
        {
            // create a variable to store the padded message
            string plainTextPad = plainText;
            // declare variable to randomly generate a number
            Random randomNumber = new Random();
            // while the plaintext's length modded by the keyword's length doesent equal 0, create a random number between 65 and 90, and add the character code to the padded message
            while (plainTextPad.Length % key.Length != 0)
            {
                int random = randomNumber.Next(65, 91);
                plainTextPad += (char)random;
            }
            // returns the padded plaintext message
            return plainTextPad;
        }

        private string[] ColumnCreation(String key, String plaintext)
        {
            string[] columns = new string[key.Length];
            for (int i = 0; i <= plaintext.Length -1; i++)
            {
                columns[i % key.Length] += plaintext[i];
            }
            return columns;
        }

        static void MergeSort(ref char[] array)
        {

            char[] tempArray = new char[array.Length];
            // starts the process off - lower and upperbound are set to unsorted array bounds
            RecursiveMergeSort(tempArray, 0, array.Length - 1, ref array);
        }

        static void RecursiveMergeSort(char[] tempArray, int lbound, int ubound, ref char[] array)
        {
            if (lbound == ubound)
            {
                // array of size 1
                return;
            }
            else
            {
                // find the midpoint of the list
                int mid = (lbound + ubound) / 2;
                // sort the bottom half
                RecursiveMergeSort(tempArray, lbound, mid, ref array);
                // sort the top half
                RecursiveMergeSort(tempArray, mid + 1, ubound, ref array);
                // merge the two lists back into the unsorted array
                Merge(tempArray, lbound, mid + 1, ubound, ref array);
            }
        }

        static void Merge(char[] tempArray, int lowp, int highp, int ubound, ref char[] array)
        {
            int j = 0;
            int lbound = lowp;
            int mid = highp - 1;
            int n = ubound - lbound + 1;
            while ((lowp <= mid & highp <= ubound))
            {
                if (array[lowp] < array[highp])
                {
                    tempArray[j] = array[lowp];
                    j += 1;
                    lowp += 1;
                }
                else
                {
                    tempArray[j] = array[highp];
                    j += 1;
                    highp += 1;
                }
            }
            while ((lowp <= mid))
            {
                tempArray[j] = array[lowp];
                j += 1;
                lowp += 1;
            }
            while (highp <= ubound)
            {
                tempArray[j] = array[highp];
                j += 1;
                highp += 1;

            }
            for (j = 0; j <= n - 1; j++)
            {
                array[lbound + j] = tempArray[j];
            }
        }

    }
}
