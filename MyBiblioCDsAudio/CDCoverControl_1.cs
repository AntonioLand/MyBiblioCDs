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

namespace MyBiblioCDsAudio
{
    public partial class CDCoverControl : UserControl
    {
        private static List<CDCoverControl> instance = new List<CDCoverControl>();
        private static int numIndex = -1;// { set; get; }
        public event EventHandler NumIndexReady;
        ToolTip toolTip1 = new ToolTip();
        //public event EventHandler PathFileChoosed;
        //private static string pathImgToCopy;

        public int NumIndex
        {
            get { return numIndex; }
            set { numIndex = value; }
        }

        private void OnDispose(object sender, EventArgs e)
        {
            this.CoverCd.Image.Dispose();
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

        private void ChooseThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numIndex = Convert.ToInt32(this.IndexTxt.Text) - 1;
            OnNumIndexReady(null);
            string p = "D:\\MyBiblioCds\\" + System.IO.Path.GetFileName(instance.ElementAt(numIndex).FileTxtBx.Text);
            if (File.Exists(p))
            {
                MessageBox.Show("File: " + p + "\n already exists\nChoose another");
                return;
            }
            else
                this.ParentForm.Dispose();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogProj.Info("SaveAsToolStripMenuItem_Click(object sender, EventArgs e)");

            SaveFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg;*.jpeg|BMP Files (*.bmp)|*.bmp|Tiff Files (*.Tif)|Tif";
            SaveFileDialog1.FileName = Path.GetFileName(FileTxtBx.Text.ToString());
            SaveFileDialog1.FilterIndex = 1;
            SaveFileDialog1.RestoreDirectory = true;
            SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(FileTxtBx.Text.ToString());

            DialogResult result = SaveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string newnamefile = SaveFileDialog1.FileName;
                try
                {
                    if (FileTxtBx.Text.ToString() != newnamefile)
                    {
                        numIndex = Convert.ToInt32(this.IndexTxt.Text) - 1;
                        File.Copy(this.FileTxtBx.Text.ToString(), newnamefile);
                        instance[numIndex].FileTxtBx.Text = newnamefile;
                        toolTip1.SetToolTip(this.FileTxtBx, this.FileTxtBx.Text);
                        instance[numIndex].Update();
                    }
                }
                catch (Exception ex)
                {
                    LogProj.exception(ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void EditInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ind = Convert.ToInt32(this.IndexTxt.Text) - 1;
            ImgCoverInfo imgCoverInfo = new ImgCoverInfo(instance.ElementAt(ind).FileTxtBx.Text,
                                            instance.ElementAt(ind).SizeTxt.Text,
                                            instance.ElementAt(ind).NameTxtBx.Text,
                                            ind);
            editCover info = new editCover(imgCoverInfo);
            info.ShowDialog();
            instance.ElementAt(ind).FileTxtBx.Text = info.mdf.CoverFile;
            instance.ElementAt(ind).NameTxtBx.Text = info.mdf.NameCover;
            instance.ElementAt(ind).SizeTxt.Text = info.mdf.CoverImgSize;
        }

        private void CDCoverControl_Load(object sender, EventArgs e)
        {
            //ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.FileTxtBx, this.FileTxtBx.Text);
            toolTip1.SetToolTip(this.HideInfoBtn, "Hide Info");
            toolTip1.SetToolTip(this.ShowInfoBtn, "Show Info");
            toolTip1.SetToolTip(this.NameTxtBx, this.NameTxtBx.Text);
            toolTip1.SetToolTip(this.CoverCd, "Right click for zoom");
        }
        
        protected virtual void OnNumIndexReady(EventArgs e)
        {
            EventHandler NumIndxRdy = NumIndexReady;
            if (NumIndxRdy != null)
            {
                    NumIndxRdy(this, e);
            }
        }
         private void CoverCd_DoubleClick(object sender, EventArgs e)
         {
            // pathImgToCopy = this.FileTxtBx.Text;
            numIndex = Convert.ToInt32(this.IndexTxt.Text) - 1;
            OnNumIndexReady(null);
            this.ParentForm.Close();
            this.ParentForm.Dispose();
         }
    }
}
