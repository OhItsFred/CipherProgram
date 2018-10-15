using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vignere_Cipher_Form
{
    public partial class Cipher : Form
    {
        VignereCrypto crypt;

        public Cipher()
        {
            InitializeComponent();
            crypt = VignereCrypto.getInstance;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Encrypt
            textBox3.Text = crypt.Encrypt(textBox2.Text, textBox1.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Decrypt
            //textBox3.Text = crypt.Decrypt(textBox2.Text, textBox1.Text);
            Matrix t1 = new Matrix(2, 2);
            Matrix t2 = new Matrix(2, 1);
            t1.setElement(0, 0, 10);
            t1.setElement(0, 1, 3);
            t1.setElement(1, 0, -2);
            t1.setElement(1, 1, 7);
            t2.setElement(0, 0, 5);
            t2.setElement(1, 0, 2);
            var test = Matrix.product(t1, t2).Test();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void encryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label4.Text = "Caeser Cipher - Encrypt"; 
        }

        private void decryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label4.Text = "Caeser Cipher - Decrypt";
        }

        private void cryptanalysisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label4.Text = "Caeser Cipher - Cryptanalysis";
        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Vigenere Cipher - Encrypt";
        }

        private void decryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Vigenere Cipher - Decrypt";
        }

        private void cryptanalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "Vigenere Cipher - Cryptanalysis";
        }

        private void steganographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Steganography Steganography = new Steganography();
            Steganography.Show();
            //Cipher.Hide();
        }
    }
}
//http://www.programming-algorithms.net/article/45623/Vigenere-cipher
 
