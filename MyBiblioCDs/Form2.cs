using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

#pragma warning disable CS1591


namespace MyBiblioCDs
{
    /// <summary>
    /// For comments on the CDs and i files.
    /// </summary>
    public partial class NoteCD : Form, IDisposable
    {
        public int MaxChar;
        public string txtNote = string.Empty;
        bool changeColor= false;
        string head1= string.Empty;
        string head2= string.Empty;
        public int forwhat= 0;

        public NoteCD()
        {
            InitializeComponent();
        }
        public NoteCD(int forWhat)
        {
            InitializeComponent();
            this.Text = "Note File";
            this.forwhat = forWhat;
        }

        public NoteCD(string s1, string s2, int forWhat, bool cColor = false )
        {
            InitializeComponent();
            changeColor = cColor;
            head1= s1;
            head2= s2;
            forwhat = forWhat;
        }
        private void NoteCD_Load(object sender, EventArgs e)
        {
            this.rTxtBx.TextChanged -= new System.EventHandler(this.richTextBox1_TextChanged);
            if (txtNote != string.Empty)
            {
                rTxtBx.Text = txtNote;
            }
            if (changeColor)
            {
                System.Drawing.Font currentFont = rTxtBx.SelectionFont;
                rTxtBx.Font = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold);
                head1 = "File: " + head1;
                rTxtBx.Text = head1 + "\r\n";
                head2 = "Function: " + head2 + "\nProblem:"+ "\n\nAlgorithm:";
                rTxtBx.Text += head2 + "\r\n" + "\r\n";
                rTxtBx.Select(0, head1.Length + head2.Length + 2);
                rTxtBx.SelectionColor = System.Drawing.Color.White;
                rTxtBx.Select(head1.Length + head2.Length + 3, 0);
                rTxtBx.Font = currentFont;
            }
            this.rTxtBx.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = rTxtBx.Text.Length.ToString();
            if((rTxtBx.Text.Length) > MaxChar)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
                rTxtBx.Select(MaxChar, rTxtBx.Text.Length);
            }
        }
    }
}
