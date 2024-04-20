using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable IDE1006

namespace MyBiblioCDsAudio
{
    public partial class editCover : Form
    {
        public ImgCoverInfo mdf;
        private string lang;
        public editCover()
        {
            InitializeComponent();
        }
        public editCover(ImgCoverInfo inf, string language)
        {
            InitializeComponent();
            mdf = new ImgCoverInfo
            {
                CoverFile = inf.CoverFile,
                NameCover = inf.NameCover,
                CoverImgSize = inf.CoverImgSize,
                numCover = inf.numCover
            };
            lang = language;
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            mdf.CoverFile = filetxtBx.Text.ToString();
            mdf.NameCover = nameTxtBx.Text;
            mdf.CoverImgSize = sizeXtxtBx.Text + ',' + sizeYtxtBx.Text;
            this.Close();
        }

        private void editCover_Load(object sender, EventArgs e)
        {
            this.filetxtBx.Text = mdf.CoverFile;
            this.nameTxtBx.Text = mdf.NameCover;
            int pos = mdf.CoverImgSize.IndexOf(',');
            Translator(lang);
            if (mdf.CoverImgSize != null || mdf.CoverImgSize != "")
            {
                if (pos > 0) 
                    this.sizeXtxtBx.Text = mdf.CoverImgSize.Substring(0, pos);
                this.sizeYtxtBx.Text = mdf.CoverImgSize.Substring(pos + 1, mdf.CoverImgSize.Length - pos - 1);
            }
        }

        internal static class Languages
        {
            static public string titform  = string.Empty;
            static public string lblabel1 = string.Empty;
            static public string lblabel2 = string.Empty;
            static public string lblabel3 = string.Empty;
            static public string btnOK    = string.Empty;
            static public string btnCancel = string.Empty;

            static public void Dictionary(string lang)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
                titform   = Properties.Vocabolury.Dict.nameform2;
                lblabel1  = Properties.Vocabolury.Dict.editCover_SizeX;
                lblabel2  = Properties.Vocabolury.Dict.editCover_SizeY;
                lblabel3  = Properties.Vocabolury.Dict.lbFile;
                btnOK     = Properties.Vocabolury.Dict.btnOK;
                btnCancel = Properties.Vocabolury.Dict.btnCancel;
            }
        }

        private void Translator(string lang)
        {
            Languages.Dictionary(lang);
            this.Text               = Languages.titform;
            this.label1.Text        = Languages.lblabel1;
            this.label2.Text        = Languages.lblabel2;
            this.label3.Text        = Languages.lblabel3;
            this.OKbtn.Text         = Languages.btnOK;
            this.CancelBtn.Text     = Languages.btnCancel;
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
