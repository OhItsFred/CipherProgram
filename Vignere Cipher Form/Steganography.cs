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
    public partial class Steganography : Form
    {
        public Steganography()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = findImageFileDialog.ShowDialog();
            Bitmap photo;
            findImageFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            findImageFileDialog.FilterIndex = 1;
            if (findImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                photo = (Bitmap)Image.FromFile(findImageFileDialog.FileName);            
                pictureBox1.Image = (Image)photo;
            }
        }
    }
}
