using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cipher_Decipher
{
    public partial class TrifidPolybiusSquare : Form
    {
        public TrifidPolybiusSquare()
        {
            InitializeComponent();
        }

        public string cipherAlphabet = string.Empty;

        private void TrifidPolybiusSquare_Load(object sender, EventArgs e)
        {
            PictureBox[] boxes = { picTrifid1, picTrifid2, picTrifid3, picTrifid4, picTrifid5, picTrifid6, picTrifid7, picTrifid8, picTrifid9, picTrifid10, picTrifid11, picTrifid12, picTrifid13, picTrifid14, picTrifid15, picTrifid16, picTrifid17, picTrifid18, picTrifid19, picTrifid20, picTrifid21, picTrifid22, picTrifid23, picTrifid24, picTrifid25, picTrifid26, picTrifid27 };
            for (int i = 0; i <= boxes.Length - 1; i++)
            {
                boxes[i].ContextMenuStrip = this.menuCipherAlphabet;
            }
        }

        private void menuCipherAlphabet_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            Control sourceControl = owner.SourceControl;
            PictureBox picbox = (PictureBox)sourceControl;
            // if the vatsyayana radio box is clicked
            // makes the tag of the picturebox chosen equal to the chosen button on the menu strip
            picbox.Tag = menuItem.Tag;
            // update the box and have it redrawn
            picbox.Refresh();
        }

        private void picTrifid_Paint(object sender, PaintEventArgs e)
        {
            // use font arial and size 14
            Font drawFont = new Font("Arial", 14);
            StringFormat sf = new StringFormat();
            RectangleF rectangle = new RectangleF();
            // align the text centrally
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            // stores the character that is currently being drawn
            char character;
            // loops from 0 to 25 (for each character in the alphabet)
            for (int i = 0; i <= 25; i++)
            {
                // declares a rectangle with width 41 and height 41 in pixels
                rectangle = new RectangleF(0, 0, 21, 28);
                // converts the tag of the picturebox to a char and makes it equal to the character variable
                character = Convert.ToChar((sender as PictureBox).Tag);
                // draws a rectangle with a black pen, width 41, height 41 in pixels
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, 20, 27);
                // draws the character with the styling set out by the drawFont and sf variables inside the rectangle
                e.Graphics.DrawString(Convert.ToString(character), drawFont, Brushes.Black, rectangle, sf);
            }
        }

        public string getCipherAlphabet()
        {
            string cipherAlphabet = "";
            PictureBox[] boxes = { picTrifid1, picTrifid2, picTrifid3, picTrifid4, picTrifid5, picTrifid6, picTrifid7, picTrifid8, picTrifid9, picTrifid10, picTrifid11, picTrifid12, picTrifid13, picTrifid14, picTrifid15, picTrifid16, picTrifid17, picTrifid18, picTrifid19, picTrifid20, picTrifid21, picTrifid22, picTrifid23, picTrifid24, picTrifid25, picTrifid26,picTrifid27 };
            for (int i = 0; i <= boxes.Length -1; i++)
            {
                cipherAlphabet += boxes[i].Tag;
            }
            return cipherAlphabet;
        }

        private void TrifidPolybiusSquare_FormClosing(object sender, FormClosingEventArgs e)
        {
            cipherAlphabet = getCipherAlphabet();
        }
    }
}
