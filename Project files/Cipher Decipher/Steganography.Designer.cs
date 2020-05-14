namespace Cipher_Decipher
{
    partial class Steganography
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Steganography));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.picPlain = new System.Windows.Forms.PictureBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.picCipher = new System.Windows.Forms.PictureBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPlain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCipher)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(446, 333);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(98, 59);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open Image";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // picPlain
            // 
            this.picPlain.Image = global::Cipher_Decipher.Properties.Resources.border;
            this.picPlain.Location = new System.Drawing.Point(12, 12);
            this.picPlain.Name = "picPlain";
            this.picPlain.Size = new System.Drawing.Size(315, 315);
            this.picPlain.TabIndex = 1;
            this.picPlain.TabStop = false;
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 333);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox.Size = new System.Drawing.Size(428, 118);
            this.txtBox.TabIndex = 2;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(550, 333);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(98, 59);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // picCipher
            // 
            this.picCipher.Image = global::Cipher_Decipher.Properties.Resources.border;
            this.picCipher.Location = new System.Drawing.Point(333, 12);
            this.picCipher.Name = "picCipher";
            this.picCipher.Size = new System.Drawing.Size(315, 315);
            this.picCipher.TabIndex = 4;
            this.picCipher.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(446, 398);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(98, 59);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "Download Image";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(550, 398);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(98, 59);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // Steganography
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 463);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.picCipher);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.picPlain);
            this.Controls.Add(this.btnOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Steganography";
            this.Text = "Steganography";
            ((System.ComponentModel.ISupportInitialize)(this.picPlain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCipher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.PictureBox picPlain;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.PictureBox picCipher;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDecrypt;
    }
}