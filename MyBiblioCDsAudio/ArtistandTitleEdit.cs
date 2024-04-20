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
#pragma warning disable  IDE0044

namespace MyBiblioCDsAudio
{
    /// <summary>
    /// The class shows a window where you can enter the name of the Artist and the title of the CD. This is in case the automatic search did not work
    /// </summary>
    public partial class ArtistTitleEdit : Form
    {
        public string _Title;
        public string _Artist;
        public ArtistTitleEdit()//List<ImgCoverInfo> p_coverList)
        {
            InitializeComponent();
            _Title = _Artist = string.Empty;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            LogProj.Info("SearchBtn_Click");
            _Title =  this.TitleTxt.Text;
            _Artist = this.ArtistTxt.Text;
            LogProj.Info("SearchBtn_Click " +  _Artist + " " + _Title);
        }

        private void ArtistTitleEdit_Load(object sender, EventArgs e)
        {
            Translator(MainFormAudio.worklanguage);
        }
        internal static class Languages
        {
            static public string titform = string.Empty;
            static public string lbArtist = string.Empty;
            static public string lbTitle = string.Empty;
            static public string btnText = string.Empty;

            static public void Dictionary(string lang)
            {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
                titform = Properties.Vocabolury.Dict.nameform;
                lbArtist = Properties.Vocabolury.Dict.lbArtist;
                lbTitle = Properties.Vocabolury.Dict.lbTitle;
                btnText = Properties.Vocabolury.Dict.btnsearch;
            }
        }

        private void Translator(string lang)
        {
            Languages.Dictionary(lang);
            this.Text = Languages.titform;
            this.lbArtist .Text = Languages.lbArtist;
            this.lbTitle.Text = Languages.lbTitle;
            this.SearchBtn.Text = Languages.btnText;
        }
    }
}
