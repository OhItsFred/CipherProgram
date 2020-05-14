using System;
using System.Windows.Forms;

namespace Cipher_Decipher
{
    public partial class Steganography : Form
    {
        private AppImage image;
        public Steganography()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.BMP;*.PNG;*.jpg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    this.image = AppImage.OpenFromFile(dlg.FileName);
                    picPlain.Image = this.image.ScaleImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            // https://stackoverflow.com/questions/6122984/load-a-bitmap-image-into-windows-form-using-open-file-dialog
            // https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-save-files-using-the-savefiledialog-component
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap Image|*.bmp|PNG Image|*.png";
            sfd.Title = "Save an Image File";
            sfd.ShowDialog();
            // If the file name is not an empty string open it for saving.  
            if (sfd.FileName != "")
            {
                try
                {
                    System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                    this.image.SaveToFile(fs, sfd.FilterIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            textValidator textValidator = new textValidator();
            if (!textValidator.Validate(txtBox.Text))
            {
                MessageBox.Show(textValidator.failValidate());
                return;
            }
            if (this.image == null)
            {
                MessageBox.Show("Please open an image before encrypting.");
                return;
            }

            SteganographyCrypt steganography = new SteganographyCrypt();
            this.image.bitmapData = steganography.encrypt(this.image.bitmapData, txtBox.Text);
            picCipher.Image = this.image.ScaleImage();

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            SteganographyCrypt steganography = new SteganographyCrypt();
            string plainText = steganography.decrypt(this.image.bitmapData);
            txtBox.Text = plainText;
        }
    }
}

