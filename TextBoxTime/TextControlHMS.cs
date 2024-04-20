using System;
using System.Windows.Forms;
using System.Globalization;

namespace TextBoxTime
{
    public partial class TextControlHMS : UserControl
    {
        public event EventHandler TextInternalChanged;
        private bool minsec { get; set; }
        private bool ctrlKeyDown = false;
        public string time {
            get
            {
                string mom;
                if(textBoxH.Text.Length == 1)
                    mom = "0" + textBoxH.Text + ":";
                else
                    mom = textBoxH.Text + ":" ;
                if (textBoxM.Text.Length == 1)
                    mom += "0" + textBoxM.Text + ":";
                else
                    mom += textBoxM.Text + ":";
                if (textBoxS.Text.Length == 1)
                    mom += "0" + textBoxS.Text;
                else
                    mom += textBoxS.Text;
                return mom;
            }
            set { 
                char[] separator = {':'};
                string[] HMS = value.Split(separator);
                if (HMS.Length == 1)
                {
                    MessageBox.Show("Incorrect Time Format\n" + "Format: : \"hh:mm:ss\".");
                    //MessageBox.Show(Languages.TimeError +"\n" Languages.frmt + ": \"hh:mm:ss\".");
                    return;
                }
                if(HMS.Length == 2)
                {
                    string[] hmsSwap = new string[3];
                    hmsSwap[2] = HMS[1];
                    hmsSwap[1] = HMS[0];
                    hmsSwap[0] = "00";
                    HMS = null;
                    HMS = new string[3];
                    HMS = hmsSwap;
                    minsec= true;
                }
                if (HMS[0].Length == 1)
                    textBoxH.Text = "0" + HMS[0];
                else
                    textBoxH.Text = HMS[0];
                if (HMS[1].Length == 1)
                    textBoxM.Text = "0" + HMS[1];
                else
                    textBoxM.Text = HMS[1];
                if (HMS[2].Length == 1)
                    textBoxS.Text = "0" + HMS[2];
                else
                    textBoxS.Text = HMS[2];
            }
        }
        public TextControlHMS()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            
            textBoxH.Select(0,2);
        }

        private void flowLayoutPanel1_MouseEnter(object sender, System.EventArgs e)
        {
            textBoxH.Focus();
            textBoxH.Select(0, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxH.Focus();
            textBoxH.Select(0, 2);

        }

        private void textBoxM_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxH.Focus();
            textBoxH.Select(0, 2);

        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxH.Focus();
            textBoxH.Select(0, 2);

        }

        private void textBoxS_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxH.Focus();
            textBoxH.Select(0, 2);

        }

        private void textBoxH_MouseEnter(object sender, System.EventArgs e)
        {
            textBoxH.Focus();

        }

        private void textBoxH_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxH.Focus();
            textBoxH.Select(0, 2);

        }

        private void textBoxH_Enter(object sender, System.EventArgs e)
        {
            textBoxH.Select(0, 2);

        }

        private void textBoxM_Enter(object sender, System.EventArgs e)
        {
            textBoxM.Select(0, 2);

        }

        private void textBoxS_Enter(object sender, System.EventArgs e)
        {
            textBoxS.Select(0, 2);

        }

        private void textBoxH_TextChanged(object sender, System.EventArgs e)
        {
            if (ctrlKeyDown)
            {
                EventHandler handler = TextInternalChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        private void textBoxM_TextChanged(object sender, EventArgs e)
        {
            if (ctrlKeyDown)
            {
                EventHandler handler = TextInternalChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        private void textBoxS_TextChanged(object sender, EventArgs e)
        {
            if (ctrlKeyDown)
            {
                EventHandler handler = TextInternalChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        private void TextControlHMS_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlKeyDown = true;
        }

        private void TextControlHMS_Leave(object sender, EventArgs e)
        {
            ctrlKeyDown = false;
        }

        private void textBoxH_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlKeyDown = true;

        }

        private void textBoxM_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlKeyDown = true;

        }

        private void textBoxS_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlKeyDown = true;

        }
        public static string ctrTimeisOk(string verify)
        {
            string emit = string.Empty;
            char[] separator = { ':' };
            string[] HMS = verify.Split(separator);
            if (HMS.Length == 1)
            {
                MessageBox.Show("Incorrect Time Format\n" + "Format: : \"hh:mm:ss\".");
                emit = toRectify(verify);
                return emit;
            }
            if (HMS.Length == 2)
            {
                string[] hmsSwap = new string[3];

                if (HMS[0].Length < 2) //Minute
                    hmsSwap[1] = "0" + HMS[0];
                else if (HMS[0].Length == 2)
                    hmsSwap[1] = HMS[0];
                else
                    return(toRectify(verify));

                if (HMS[1].Length < 2) //Seconds
                    hmsSwap[2] = HMS[1] + "0";
                else if (HMS[1].Length == 2)
                    hmsSwap[2] = HMS[1];
                else
                    return (toRectify(verify));

                emit = "00" + ":" + hmsSwap[1] + ":" + hmsSwap[2];
            } else if (HMS.Length == 3) 
            {
                string[] hmsSwap = new string[3];
                if (HMS[0].Length == 1)
                    hmsSwap[0] = "0" + HMS[0];
                else if (HMS[0].Length == 2)
                    hmsSwap[0] = HMS[0];
                else
                    return(toRectify(verify));

                if (HMS[1].Length == 1)
                    hmsSwap[1] = "0" + HMS[1];
                else if (HMS[1].Length == 2)
                    hmsSwap[1] = HMS[1];
                else
                    return(toRectify(verify));

                if (HMS[2].Length == 1)
                    hmsSwap[2] = HMS[1] + 0;
                else if (HMS[2].Length == 2)
                    hmsSwap[2] = HMS[2];
                else
                    return(toRectify(verify));
                emit = hmsSwap[0] + ":" + hmsSwap[1] + ":" + hmsSwap[2];
            }
                return emit;
        }

        private static string toRectify(string verify)
        {
            ToCorrect toCorrect = new ToCorrect();
            toCorrect.label4.Text = "The time format is incorrect. Do you want to change it?";
            toCorrect.label4.Text = verify;
            toCorrect.ShowDialog();
            return toCorrect.hms;
        }

    }
}
