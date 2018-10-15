using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vignere_Cipher_Form
{
    class Matrix
    {
        private int[,] matrix;
        public Matrix(int rows, int columns)
        {
            matrix = new int[rows, columns];
        }

        public int getElement(int i, int j)
        {
            return matrix[i, j];
        }

        public void setElement(int i, int j, int value)
        {
            matrix[i, j] = value;
        }

        public int numColumns()
        {
            return matrix.GetLength(1);
        }

        public int numRows()
        {
            return matrix.GetLength(0);
        }

        public static Matrix product(Matrix mat1, Matrix mat2)
        {
            int a = mat1.numColumns();
            int b = mat2.numRows();
            if (mat1.numColumns() != mat2.numRows())
            {
                throw new ArgumentException("Matrices are not conformable for multiplication.");
            }
            Matrix prod = new Matrix(mat1.numRows(), mat2.numColumns());
            for (int i=0; i < mat1.numRows(); i++)
            {
                for (int j=0; j < mat2.numColumns(); j++)
                {
                    prod.setElement(i, j, productHelper(mat1, mat2, i, j));
                }
            }
            return prod;
        }

        private static int productHelper(Matrix mat1, Matrix mat2, int i, int j)
        {
            int sum = 0;
            for (int index=0; index < mat1.numColumns(); index++)
            {
                sum += mat1.getElement(i, index) * mat2.getElement(index, j);
            }
            return sum;
        }

        public int[,] Test()
        {
            return matrix;
        }
    }
}
