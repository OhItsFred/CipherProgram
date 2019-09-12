using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Cipher_Decipher
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void btnBugReport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:jonasf006363@tbshs.org?subject=Bug Report&body=Description of bug: ";
            proc.Start();

        }
    }
}
