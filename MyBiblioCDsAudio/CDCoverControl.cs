using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

#pragma warning disable IDE1006, IDE0017, IDE0044

namespace MyBiblioCDsAudio
{
    /// <summary>
    /// User Control to show all found covers 
    /// </summary>
    public partial class CDCoverControl : UserControl
    {
        private static List<CDCoverControl> instance = new List<CDCoverControl>();
        private static int numIndex = -1;
        public event EventHandler NumIndexReady;
        static private string worklanguage;
        public int NumIndex
        {
            get { return numIndex; }
            set { numIndex = value; }
        }

        private void OnDispose(object sender, EventArgs e)
        {
            this.CoverCd.Image.Dispose();
            instance.Clear();
        }

        public CDCoverControl()
        {
            InitializeComponent();
            ShowInfoBtn.Enabled = false;
            ShowInfoBtn.Visible = false;
            Disposed += OnDispose;
        }

        public static CDCoverControl Instance
        {
            get
            {
                instance.Add(new CDCoverControl());
                return instance.ElementAt(instance.Count - 1);
            }
        }

        public List<CDCoverControl> InstanceList
        {
            get
            {
                if (instance.Count > 0)
                    return instance;
                return null;
            }
        }

        private void CoverCd_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    Zoom zoom = new Zoom(this.FileTxtBx.Text);
                    zoom.Show();
                    break;
            }
        }

        private void ShowInfoBtn_Click(object sender, EventArgs e)
        {
            InfoPanel.Visible = true;
            ShowInfoBtn.Enabled = false;
            ShowInfoBtn.Visible = false;
            this.Size = new Size(180, 290);
            this.cdPanelGradient1.Refresh();
        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            MenuCnt.Show(MousePosition.X, MousePosition.Y);
        }

        private void HideInfoBtn_Click(object sender, EventArgs e)
        {
            InfoPanel.Visible = false;
            ShowInfoBtn.Enabled = true;
            ShowInfoBtn.Visible = true;
            this.Size = new Size(180, 185); //DIMENSIONE
            this.cdPanelGradient1.Refresh();
        }

        private void chooseThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numIndex = Convert.ToInt32(this.IndexTxt.Text) - 1;
            OnNumIndexReady(null);
            this.OnDispose(sender, e);
            this.ParentForm.Dispose();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg;*.jpeg|BMP Files (*.bmp)|*.bmp|Tiff Files (*.Tif)|Tif";
            saveFileDialog1.FileName = Path.GetFileName(FileTxtBx.Text.ToString());
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(FileTxtBx.Text.ToString());

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string newnamefile = saveFileDialog1.FileName;
                try
                {
                    if (FileTxtBx.Text.ToString() != newnamefile)
                    {
                        File.Copy(this.FileTxtBx.Text.ToString(), newnamefile);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void editInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ind = Convert.ToInt32(this.IndexTxt.Text) - 1;
            ImgCoverInfo imgCoverInfo = new ImgCoverInfo(instance.ElementAt(ind).FileTxtBx.Text,
                                            instance.ElementAt(ind).SizeTxt.Text,
                                            instance.ElementAt(ind).NameTxtBx.Text,
                                            ind);
            editCover info = new editCover(imgCoverInfo, worklanguage);
            info.ShowDialog();
            instance.ElementAt(ind).FileTxtBx.Text = info.mdf.CoverFile;
            instance.ElementAt(ind).NameTxtBx.Text = info.mdf.NameCover;
            instance.ElementAt(ind).SizeTxt.Text = info.mdf.CoverImgSize;
        }

        private void CDCoverControl_Load(object sender, EventArgs e)
        {
            Translator(MainFormAudio.worklanguage);
            worklanguage = MainFormAudio.worklanguage;
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.FileTxtBx, this.FileTxtBx.Text);
            toolTip1.SetToolTip(this.HideInfoBtn, Languages.tpHideInfo);
            toolTip1.SetToolTip(this.ShowInfoBtn, Languages.tpShowInfo);
            toolTip1.SetToolTip(this.NameTxtBx, this.NameTxtBx.Text);
            toolTip1.SetToolTip(this.CoverCd, Languages.zoom);
            toolTip1.SetToolTip(this.MenuBtn, Languages.menuopen);
        }

        protected virtual void OnNumIndexReady(EventArgs e)
        {
            EventHandler NumIndxRdy = NumIndexReady;
            if (NumIndxRdy != null)
            {
                {
                    NumIndxRdy(this, e);
                }
            }
        }

        private void InfoPanel_DoubleClick(object sender, EventArgs e)
        {
            numIndex = Convert.ToInt32(this.IndexTxt.Text) - 1;
            this.ParentForm.Close();
        }

        internal static class Languages
        {
            static public string ChooseThis = string.Empty;
            static public string EditInfo = string.Empty;
            static public string SaveAS = string.Empty;

            static public string lbName = string.Empty;
            static public string lbSize = string.Empty;
            static public string lbFile = string.Empty;

            static public string tpHideInfo = string.Empty;
            static public string tpShowInfo = string.Empty;
            static public string tpNameTxt = string.Empty;
            static public string zoom = string.Empty;
            static public string menuopen = string.Empty;


            static public void Dictionary(string lang)
            {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
                ChooseThis          = Properties.Vocabolury.Dict.mnChooseThis;
                SaveAS              = Properties.Vocabolury.Dict.mnSaveAS;
                EditInfo            = Properties.Vocabolury.Dict.mnEditInfo;
                lbName              = Properties.Vocabolury.Dict.lbName;
                lbSize              = Properties.Vocabolury.Dict.lbSize;
                lbFile              = Properties.Vocabolury.Dict.mnFile;
                tpHideInfo          = Properties.Vocabolury.Dict.tpHideInfo;
                tpShowInfo          = Properties.Vocabolury.Dict.tpshowInfo;
                zoom                = Properties.Vocabolury.Dict.tpZoom;
                menuopen            = Properties.Vocabolury.Dict.menuop;
            }
        }

        private void Translator(string lang)
        {
            
            Languages.Dictionary(MainFormAudio.worklanguage);
            this.saveAsToolStripMenuItem.Text   = Languages.ChooseThis;
            this.saveAsToolStripMenuItem.Text   = Languages.SaveAS;
            this.editInfoToolStripMenuItem.Text = Languages.EditInfo;
            this.lbName.Text                    = Languages.lbName;
            this.lbSize.Text                    = Languages.lbSize;
            this.lbFile.Text                    = Languages.lbFile;
            this.saveFileToolStripMenuItem.Text = Languages.ChooseThis;
            this.saveAsToolStripMenuItem.Text   = Languages.SaveAS;
            this.editInfoToolStripMenuItem.Text = Languages.EditInfo;
        }
    }
}
