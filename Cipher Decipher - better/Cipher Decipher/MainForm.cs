using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cipher_Decipher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private KeyValidator keyValidator = new KeyValidator();
        private textValidator textValidator = new textValidator();

        public enum cipherName { Atbash, Caesar, ColumnarTransposition, Keyword, LetterSub, RailFence, Vatsyayana, Vigenere, OneTimePad, Bifid, Trifid };

        // checks which radio box is currently selected, and returns the enum position of the that cipher
        public cipherName CurrentCipher()
        {
            if (rbtnAtbash.Checked)
            {
                return cipherName.Atbash;
            }
            else if (rbtnCaesar.Checked)
            {
                return cipherName.Caesar;
            }
            else if (rbtnColTransposition.Checked)
            {
                return cipherName.ColumnarTransposition;
            }
            else if (rbtnKeyword.Checked)
            {
                return cipherName.Keyword;
            }
            else if (rbtnLetterSub.Checked)
            {
                return cipherName.LetterSub;
            }
            else if (rbtnRailFence.Checked)
            {
                return cipherName.RailFence;
            }
            else if (rbtnVatsyayana.Checked)
            {
                return cipherName.Vatsyayana;
            }
            else if (rbtnVigenere.Checked)
            {
                return cipherName.Vigenere;
            }
            else if (rbtnOneTimePad.Checked)
            {
                return cipherName.OneTimePad;
            }
            else if (rbtnBifid.Checked)
            {
                return cipherName.Bifid;
            }
            else if (rbtnTrifid.Checked)
            {
                return cipherName.Trifid;
            }
            else
            {
                throw new Exception();
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // if the text entered by the user is not valid
            if (!textValidator.Validate(txtInput.Text))
            {
                // display a message box with an error message telling the user what they have done wrong
                MessageBox.Show(textValidator.failValidate());
                // stops the current encryption and returns to the default state of the program
                return;
            }
            // if the keyword entered is not valid
            if (!keyValidator.Validate(txtKeyWord.Text))
            {
                // display a message box with an error message telling the user what they have done wrong
                MessageBox.Show(keyValidator.failValidate());
                // stops the current encryption and returns to the default state of the program
                return;
            }
            // checks if the vigenere or columnar transposition ciphers are chosen, and if they are validates to ensure the keyword isn't longer than the input text
            if ((rbtnVigenere.Checked || rbtnColTransposition.Checked) && keyValidator.lengthCheck(txtKeyWord.TextLength, txtInput.TextLength))
            {
                MessageBox.Show("Your keyword cannot be greater in length than the input text length.");
                return;
            }
            // checks if the one time pad cipher is chosen, and if so then validates to ensure the keyword is longer than or equal to the length of the input message
            if (rbtnOneTimePad.Checked && (txtKeyWord.Text.Length < txtInput.Text.Length))
            {
                MessageBox.Show("Your keyword must be equal to or greater than the length of the message.");
                return;
            }
            // declares an instance of cipher called myCipher and using the determineCipher function make it equal to the current cipher chosen
            Cipher myCipher = determineCipher();
            // declare a variable called key and make it equal to the returned value of the determineKey function
            string key = determineKey();
            // output to the txtOutput textbox the encrypted text that is now encrypted with the user's input and key
            txtOutput.Text = myCipher.encrypt(key, cleanMessage(txtInput.Text));

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // if the text entered by the user is not valid
            if (!textValidator.Validate(txtInput.Text))
            {
                // display a message box with an error message telling the user what they have done wrong
                MessageBox.Show(textValidator.failValidate());
                // stops the current decryption and returns to the default state of the program
                return;
            }
            // validates the user's keyword to ensure that it is valid
            if (!keyValidator.Validate(txtKeyWord.Text)) return;
            // checks if the vigenere or columnar transposition ciphers are chosen, and if they are validates to ensure the keyword isn't longer than the input text
            if ((rbtnVigenere.Checked || rbtnColTransposition.Checked) && keyValidator.lengthCheck(txtKeyWord.TextLength, txtInput.TextLength))
            {
                MessageBox.Show("Your keyword cannot be greater in length than the input text length.");
                return;
            }
            // checks if the one time pad cipher is chosen, and if so then validates to ensure the keyword is longer than or equal to the length of the input message
            if (rbtnOneTimePad.Checked && (txtKeyWord.Text.Length < txtInput.Text.Length))
            {
                MessageBox.Show("Your keyword must be equal to or greater than the length of the message.");
                return;
            }
            // declares an instance of cipher called myCipher and using the determineCipher function make it equal to the current cipher chosen
            Cipher myCipher = determineCipher();
            // declare a variable called key and make it equal to the returned value of the determineKey function
            string key = determineKey();
            // output to the txtOutput textbox the decrypted text that is now decrypted with the user's input and key
            txtOutput.Text = myCipher.decrypt(key, cleanMessage(txtInput.Text));
        }

        private string determineKey()
        {
            // if the caesar cipher radio button is pressed then 'clean' the key and return it
            if (rbtnCaesar.Checked) return cleanMessage(txtKeyWord.Text);
            // if the letter substituion radio button is pressed then return the output from the letterSubstitutionKey function
            if (rbtnLetterSub.Checked) return letterSubstitutionKey(); ;
            // if the vatsyayana radio button is pressed then return the output from the letterSubstitutionKey function
            if (rbtnVatsyayana.Checked) return letterSubstitutionKey();
            // if the keyword radio button is pressed then 'clean' the key and return it
            if (rbtnKeyword.Checked) return keywordKey(cleanMessage(txtKeyWord.Text));
            // if the atbash radio button is pressed return the key shown below
            if (rbtnAtbash.Checked) return "ZYXWVUTSRQPONMLKJIHGFEDCBA";
            // if the rail fence radio button is pressed then 'clean' the key and return it
            if (rbtnRailFence.Checked) return cleanMessage(txtKeyWord.Text);
            // if the columnar transposition radio button is pressed then 'clean' the key and return it
            if (rbtnColTransposition.Checked) return cleanMessage(txtKeyWord.Text);
            // if the vigenere radio button is pressed then 'clean' the key and return it
            if (rbtnVigenere.Checked) return cleanMessage(txtKeyWord.Text);
            // if the one-time pad radio button is pressed then 'clean' the key and return it
            if (rbtnOneTimePad.Checked) return cleanMessage(txtKeyWord.Text);
            // declares instance of bipid polybius square form so that the function getCipherAlphabet can be used
            BifidPolybiusSquare bifidPolybiusSqaure = new BifidPolybiusSquare();
            // if the bipid radio button is pressed then the cipher alphabet selected by the user will be returned
            if (rbtnBifid.Checked) return txtKeyWord.Text;
            // if none of the radio buttons are pressed then throw an exception (this should not be possible)
            TrifidPolybiusSquare trifidPolybiusSquare = new TrifidPolybiusSquare();
            if (rbtnTrifid.Checked) return txtKeyWord.Text;
            throw new Exception();
        }

        private Cipher determineCipher()
        {
            // if the radio button of the cipher is chosen then return an instance of this cipher
            if (rbtnCaesar.Checked) return new CaesarCipher();
            if (rbtnLetterSub.Checked) return new LetterSub();
            if (rbtnVatsyayana.Checked) return new Vatsyayana();
            if (rbtnKeyword.Checked) return new Keyword();
            if (rbtnAtbash.Checked) return new Atbash();
            if (rbtnRailFence.Checked) return new RailFence();
            if (rbtnColTransposition.Checked) return new ColumnarTransposition();
            if (rbtnVigenere.Checked) return new Vigenere();
            if (rbtnBifid.Checked) return new Bifid();
            if (rbtnTrifid.Checked) return new Trifid();
            if (rbtnOneTimePad.Checked) return new OneTimePad();
            // if none of the radio buttons are pressed then throw an exception (this should not be possible)
            throw new Exception();
           }

        // using the tags of picture boxes, create a key that is the order of the pictureboxes
        private string letterSubstitutionKey()
        {
            // declare an array of pictureboxes of eahc of the 26 pictureboxes
            PictureBox[] boxes = { picCipher1, picCipher2, picCipher3, picCipher4, picCipher5, picCipher6, picCipher7, picCipher8, picCipher9, picCipher10, picCipher11, picCipher12, picCipher13, picCipher14, picCipher15, picCipher16, picCipher17, picCipher18, picCipher19, picCipher20, picCipher21, picCipher22, picCipher23, picCipher24, picCipher25, pictureBox10 };
            // stores the key that will be returned
            string key = "";
            // loops through the array adding the letter that is within the tag of each picturebox to the key variable
            for (int i = 0; i<=25;i++)
            {
                key += boxes[i].Tag;
            }
            // returns the key variable 
            return key;
        }

        private string keywordKey(string userKeyword)
        {
            // delcares a variable to store key, makes it equal to normal alphabet at start
            string keyword = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // loops through each letter of the user's keyword and removes that letter from the keyword variable
            for (int i = 0; i <=userKeyword.Length -1; i++)
            {
                keyword = keyword.Replace(Convert.ToString(userKeyword[i]), "");
            }
            // adds the keyword variable (which now has no letter repetition from the user's keyword) to the user's keyword
            keyword = userKeyword + keyword;
            // returns the keyword
            return keyword;
        }

        // if the 'help' button is pressed on the tool strip button then display the help form
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help form = new Help();
            form.Show();
        }

        // if the 'steganography' button is pressed on the tool strip button then display the steganograph' form
        private void steganographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Steganography form = new Steganography();
            form.Show();
        }

        // produces a clean message that does not contain any invalid characters (numbers, symbols, etc)
        private string cleanMessage(string message)
        {
            // stores the cleared message that contains no invalid letters that could cause a crash
            string cleanedMessage = "";
            // temporarily stores the ASCII of a character 
            int tempASCII;
            // loops though the message
            for (int i = 0; i <= message.Length - 1; i++)
            {
                // makes tempASCII variable equal to the ASCII representation of the character when in upper case
                tempASCII = (int)(message.ToUpper()[i]);
                // if the character is between 65 and 90 ASCII values (is an uppercase character)
                if (tempASCII >= 65 && tempASCII <= 90)
                {
                    // add the uppercase character to the cleanedMessage variable
                    cleanedMessage += message.ToUpper()[i];
                }
                // or if the ASCII values are between 48 and 57
                else if (tempASCII >= 48 && tempASCII <= 57)
                {
                    // add the character directly to the cleanedMessage variable
                    cleanedMessage += message[i];
                }
            }
            // returns the cleanedMessage variable
            return cleanedMessage;
        }       

        // on the main form load event do...
        private void MainForm_Load(object sender, EventArgs e)
        {

            // dock the PictureBox to the form and set its background to white
            picPlain.BackColor = Color.White;            
            // connect the Paint event of the PictureBox to the event handler method
            picPlain.Paint += new System.Windows.Forms.PaintEventHandler(this.picPlain_Paint);
            // declares an array to store each of the pictureboxes related to each letter of the cipher alphabet
            PictureBox[] boxes = {picCipher1, picCipher2, picCipher3, picCipher4, picCipher5, picCipher6, picCipher7, picCipher8, picCipher9, picCipher10, picCipher11, picCipher12, picCipher13, picCipher14, picCipher15, picCipher16, picCipher17, picCipher18, picCipher19, picCipher20, picCipher21, picCipher22, picCipher23, picCipher24, picCipher25, pictureBox10 };
            // loops through the pictureboxes and docks the menu strip to it (so that the user can right click and select a new letter for the cipher alphabet
            for (int i = 0; i <=25; i++)
            {
                boxes[i].ContextMenuStrip = this.menuCipherAlphabet;
            }

            
        }

        private void picPlain_Paint(object sender, PaintEventArgs e)
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
                // declares a rectangle width 41, height 41, every 41 pixels along the x-axis
                rectangle = new RectangleF(i * 41, 0, 41, 41);
                // converts the current character to be drawn to a char
                character = Convert.ToChar((char)i + 65);
                // draws a rectangle with a black pen, width 41, height 41, every 41 pixels along the x-axis
                e.Graphics.DrawRectangle(Pens.Black, i * 41, 0, 41, 41);
                // draws the character with the styling set out by the drawFont and sf variables inside the rectangle
                e.Graphics.DrawString(Convert.ToString(character), drawFont, Brushes.Black, rectangle, sf);
            }
        }

        private void picCipher_Paint(object sender, PaintEventArgs e)
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
                rectangle = new RectangleF(0, 0, 41, 41);
                // converts the tag of the picturebox to a char and makes it equal to the character variable
                character = Convert.ToChar((sender as PictureBox).Tag);
                // draws a rectangle with a black pen, width 41, height 41 in pixels
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, 41, 41);
                // draws the character with the styling set out by the drawFont and sf variables inside the rectangle
                e.Graphics.DrawString(Convert.ToString(character), drawFont, Brushes.Black, rectangle, sf);
            }
        }

        private void cipherAlphabetMenuClick(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            Control sourceControl = owner.SourceControl;
            PictureBox picbox = (PictureBox)sourceControl;
            // if the vatsyayana radio box is clicked
            if (rbtnVatsyayana.Checked)
            {
                // declare an array to store each of the cipher alphabet picture boxes
                PictureBox[] boxes = { picCipher1, picCipher2, picCipher3, picCipher4, picCipher5, picCipher6, picCipher7, picCipher8, picCipher9, picCipher10, picCipher11, picCipher12, picCipher13, picCipher14, picCipher15, picCipher16, picCipher17, picCipher18, picCipher19, picCipher20, picCipher21, picCipher22, picCipher23, picCipher24, picCipher25, pictureBox10 };
                // loops from 0 to 25
                for (int i = 0; i <=25; i++)
                {
                    // if the tag of the current picturebox is equal to the tag of the picturebox that was clicked upon, make the tag of the current picturebox equal to the tag of the clicked upon picturebox
                    if (boxes[i].Tag == menuItem.Tag)
                    {
                        // makes the tag equal to the 
                        boxes[i].Tag = picbox.Tag;
                        // update the box and have it redrawn
                        boxes[i].Refresh();
                    }
                }
            }
            // makes the tag of the picturebox chosen equal to the chosen button on the menu strip
            picbox.Tag = menuItem.Tag;
            // update the box and have it redrawn
            picbox.Refresh();
        }

        private void radioButtonClicked(object sender, EventArgs e)
        {
            // declare an array to store each of the cipher alphabet picture boxes
            PictureBox[] boxes = { picCipher1, picCipher2, picCipher3, picCipher4, picCipher5, picCipher6, picCipher7, picCipher8, picCipher9, picCipher10, picCipher11, picCipher12, picCipher13, picCipher14, picCipher15, picCipher16, picCipher17, picCipher18, picCipher19, picCipher20, picCipher21, picCipher22, picCipher23, picCipher24, picCipher25, pictureBox10 };
            // if the caesar cipher radio button is clicked
            if (rbtnCaesar.Checked)
            {
                // calls caesar cipher draw procedure
                caesarCipherDraw(txtKeyWord, e);
            }
            // if the atbash radio button is clicked
            else if (rbtnAtbash.Checked)
            {
                // make the current regex expression equal to atbash expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Atbash));
                string cipherAlphabet = "ZYXWVUTSRQPONMLKJIHGFEDCBA";
                // rewrite the cipher alphabet according to the key above
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = true;
                    boxes[i].Tag = cipherAlphabet[i];
                    boxes[i].Refresh();
                }
                // hides the keyword textbox & label
                txtKeyWord.Visible = false ;
                label1.Visible = false;
                // make the plain akphabet picturebox visible
                picPlain.Visible = true;
            }
            // if the columnar transposition radio button is clicked
            else if (rbtnColTransposition.Checked)
            {
                // make the current regex expression equal to columnar transposition expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.ColumnarTransposition));
                // hides the cipher alphabet pictureboxes
                for (int i = 0; i<=25; i++)
                {
                    boxes[i].Visible = false;
                }                    
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
            }
            // if the keyword radio button is pressed
            else if (rbtnKeyword.Checked)
            {
                // make the current regex expression equal to keyword expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Keyword));
                // hides the cipher alphabet pictureboxes
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = false;
                }
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
            }
            // if the letter substituion radio button is pressed
            else if (rbtnLetterSub.Checked)
            {
                // make the current regex expression equal to letter substituion expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.LetterSub));
                // make the cipher alphabet pictureboxes visible
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = true;
                }
                // make the plain alphabet picturebox visible
                picPlain.Visible = true;
                // hide the keyword textbox & label
                txtKeyWord.Visible = false;
                label1.Visible = false;
            }
            // if the rail fence radio button is pressed
            else if (rbtnRailFence.Checked)
            {
                // make the current regex expression equal to rail fence expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.RailFence));
                // hide the cipher alphabet pictureboxes 
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = false;
                }
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
            }
            else if (rbtnVatsyayana.Checked)
            {
                // make the current regex expression equal to vatsyayana expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Vatsyayana));
                // makes the cipher alphabet pictureboxes visible
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = true;
                }
                // makes the plain alphabet picturebox visible
                picPlain.Visible = true;
                // hides the keyword textbox and label
                txtKeyWord.Visible = false;
                label1.Visible = false;
            }
            else if (rbtnVigenere.Checked)
            {
                // make the current regex expression equal to vigenere expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Vigenere));
                // hide the cipher alphabet pictureboxes 
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = false;
                }
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
            }
            else if (rbtnBifid.Checked)
            {
                // make the current regex expression equal to bifid expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Bifid));
                // hide the cipher alphabet pictureboxes 
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = false;
                }
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
                BifidPolybiusSquare form = new BifidPolybiusSquare();
                form.ShowDialog();
                txtKeyWord.Text = form.cipherAlphabet;
            }
            else if (rbtnTrifid.Checked)
            {
                // make the current regex expression equal to trifid expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Trifid));
                // hide the cipher alphabet pictureboxes 
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = false;
                }
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
                TrifidPolybiusSquare form = new TrifidPolybiusSquare();
                form.ShowDialog();
                txtKeyWord.Text = form.cipherAlphabet;
            }
            else if (rbtnOneTimePad.Checked)
            {
                // make the current regex expression equal to one-time pad expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.OneTimePad));
                // hide the cipher alphabet pictureboxes 
                for (int i = 0; i <= 25; i++)
                {
                    boxes[i].Visible = false;
                }
                // hides the plain alphabet picturebox
                picPlain.Visible = false;
                // make the keyword textbox & label visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
            }
        }

        private void importTextToolStrip_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Text File";
            dlg.Filter = "Text File (*.txt|*.TXT;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(dlg.FileName);
                    txtInput.Text = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void exportTextToolStrip_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt|*.TXT;";
            sfd.Title = "Save a Text File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtOutput.Text);                   
            }
        }

        private void caesarCipherDraw(object sender, EventArgs e)
        {
            if (rbtnCaesar.Checked)
            {
                PictureBox[] boxes = { picCipher1, picCipher2, picCipher3, picCipher4, picCipher5, picCipher6, picCipher7, picCipher8, picCipher9, picCipher10, picCipher11, picCipher12, picCipher13, picCipher14, picCipher15, picCipher16, picCipher17, picCipher18, picCipher19, picCipher20, picCipher21, picCipher22, picCipher23, picCipher24, picCipher25, pictureBox10 };
                // make the current regex expression equal to caesar cipher expression
                keyValidator.updateRegex(keyValidator.findRegex((int)cipherName.Caesar));
                int keyOffset = 0;
                // if the key is valid then
                if (keyValidator.Validate(txtKeyWord.Text))
                {
                    // make the keyOffset variable equal to the contents of the keyword textbox
                    keyOffset = Convert.ToInt16(txtKeyWord.Text);
                }
                // declares a new instance of the caesar cipher class
                CaesarCipher caesarCipher = new CaesarCipher();
                // using the helpermethod from the caesar cipher class, produce a cipher alphabet
                string cipherAlphabet = caesarCipher.helperMethod(keyOffset);
                for (int i = 0; i <= 25; i++)
                {
                    // makes each of the pictureboxes visible
                    boxes[i].Visible = true;
                    // updates the tag of picturebox to the letter of the cipherAlphabet
                    boxes[i].Tag = cipherAlphabet[i];
                    // redraw the picturebox
                    boxes[i].Refresh();
                }
                // makes the keyword textbox & plain alphabet picturebox visible
                txtKeyWord.Visible = true;
                label1.Visible = true;
                picPlain.Visible = true;
            }
        }

    }
}
