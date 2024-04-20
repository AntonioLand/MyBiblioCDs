using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxTime
{
    public partial class ToCorrect : Form
    {
        public string hms;
        public ToCorrect()
        {

            InitializeComponent();
            hms = "00:00:00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hms = (string)textBox1.Text + ":" + (string)textBox2.Text + ":" + (string)textBox3.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);

        }
    }
}
