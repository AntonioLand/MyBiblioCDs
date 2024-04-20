using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CS1591
namespace MyBiblioCDs
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            string path = (string)RegisterFunction.ReadKey("DirFileMyBiblioCDs");
            path += "Readme.rtf";
            RTFTxt.LoadFile(path);
            ButtonAbout.Focus();
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
