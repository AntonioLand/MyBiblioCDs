using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBiblioCDsAudio
{
    

    public partial class SmallCDImgForm : Form
    {
        public CDCoverControl cdcoverctrl;// = new CDCoverControl();
        public int numindex =-1;
        static public string _pathimgtocopy = string.Empty;
        public SmallCDImgForm()
        {
            InitializeComponent();
            Disposed += OnDispose;
        }

        private void SmallCDImgForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            numindex = cdcoverctrl.NumIndex;
        }

        protected void OnDispose(object sender, EventArgs e)
        {
            if (components != null)
            {
                components.Dispose();
            }
            base.Dispose(true);
        }

        private void SmallCDImgForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
