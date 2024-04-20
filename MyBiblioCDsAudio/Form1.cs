using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Collections;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Policy;
using TextBoxTime;
using System.Windows.Media;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Timers;
using Microsoft.Win32;
using System.Security;

namespace MyBiblioCDsAudio
{
    public partial class MainFormAudio : Form
    {
#pragma warning disable IDE1006, IDE0059, IDE0044
#pragma warning disable IDE1006, IDE0059, IDE0044

        [DllImport(@"MusicBrainz.dll",  CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //[DllImport(@"D:\Visual_2019\Progetto\Finale_DLL_X64\MusicBrainz\x64\Release\MusicBrainz.dll",  CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //       [DllImport(@"D:\Visual_2019\Progetto\DLL_C\MusicBrainz\x64\Release\MusicBrainz.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //       [DllImport("MusicBrainz.dll", EntryPoint = "MusicBrainzLibDisc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern public int MusicBrainzLibDisc(IntPtr mb_disc_private, StringBuilder device);
        public static List<ImgCoverInfo> _coverList;
        public bool searchornotsearch;
        bool close;
        public bool trackupdt = false;
        int numRow = 0;
        static BindingSource bs=null;
        //static int searchCover = 0;
        public int numCov { get; set; }
        string drive;
        public Audio_CD cdx;
        public static string worklanguage;
        public bool changeText { get; set; }
        public ContextMenu MyCntxMn;

        public MainFormAudio(string drv, ref Audio_CD pFoundCD, bool sons)
        {
            LogProj.SetLogFile(partialfilename: "MyBiblioAudioLog_");
            InitializeComponent();
            numCov = -1;
            drive = drv;
            pFoundCD.CoverArtF = string.Empty;
            cdx = pFoundCD;
            worklanguage = pFoundCD.Artist;
            Translator(worklanguage);
            changeText = false;
            searchornotsearch= sons;
            trackupdt = false;
            close = false;
            trackAUBindingSource.DataSource = Global.choosedCD.LTracks;
            TrackDtGrVw.DataSource = trackAUBindingSource;
            _coverList = new List<ImgCoverInfo>();
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// Try searching the internet for images of the CD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicBrainz_Click(object sender, EventArgs e)
        {
            LogProj.Info("MusicBrainz_Click");
            MusicBrainz.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            Point parentPos = this.Location;
            Size sz = this.Size;
            Point newPos = new Point();

            WaitincCD sleepmom = new WaitincCD();
            newPos.X = parentPos.X + sz.Width/2  - sleepmom.Width / 2;// Owner.Location.X + Owner.Width / 2 - sleepmom.Width / 2;
            newPos.Y = parentPos.Y + sz.Height/2 -  sleepmom.Height / 2;
            
            //sleepmom.MdiParent = this;
            int numtried = Global.listcdfound.Count;
            if(CheckInternetConnection())
            {
                Global.choosedCD = Global.listcdfound[numRow];
                btnsave.Enabled = false;
                bLocal.Enabled = false;
                sleepmom.Show();
                sleepmom.Location = newPos;
                sleepmom.Refresh();
                selectCD();
                sleepmom.Close();
                btnsave.Enabled = true;
                GC.Collect();
            }
            else
            {
                MessageBox.Show(Languages.msgInternetConnection);
                return;
            }
            Cursor.Current = Cursors.Default;
            this.WindowState = FormWindowState.Minimized;
            if (ShowCover() == -1)
            {
                Global.choosedCD.CoverArtF = string.Empty;
                this.MusicBrainz.Enabled = bLocal.Enabled = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Global.choosedCD.CoverArtF = CpandClDir();
                this.WindowState = FormWindowState.Normal;
                LoadImage(Global.choosedCD.CoverArtF);
                linkToDiscOrMBr.Enabled = true;
                linkToDiscOrMBr.Text = "https://musicbrainz.org/";
                this.Refresh();
            }
        } // End of MusicBrainz_Click

        /// <summary>
        /// Copies the chosen image to the Cover directory and deletes all others found.
        /// </summary>
        /// <returns></returns>
        string CpandClDir()
        {
            string obj = string.Empty;
            if (numCov == -1)
            {
                return string.Empty;
            }
            string p = System.IO.Path.GetFileName(_coverList.ElementAt(numCov).CoverFile);
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyBiblioCDs", true);
                obj = (string)key.GetValue("MyBiblioCDCoverArt");
            }
            catch (SecurityException e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }

            p = obj.ToString() +"\\"+ System.IO.Path.GetFileName(_coverList.ElementAt(numCov).CoverFile);
            //p = "C:\\MyBiblioCdsCover\\" + System.IO.Path.GetFileName(_coverList.ElementAt(numCov).CoverFile);
            try
            {
                System.IO.File.Copy(_coverList.ElementAt(numCov).CoverFile, p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Delete
            deltempDir();
            return p;
        } // End of CpandClDir
        void deltempDir()
        {
            string pathTem = Path.GetTempPath();
            pathTem += "MyBiblioCds\\";
            System.IO.DirectoryInfo di = new DirectoryInfo(pathTem);
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception ex)
                {
                    LogProj.exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// Test if there is internet coession
        /// </summary>
        /// <returns></returns>
        private bool CheckInternetConnection()
        {
                Ping pingSender = new Ping();
                String url = "musicbrainz.org";
            try
            {
                PingReply reply = pingSender.Send(url);
                if (reply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void LoadImage(string p)
        {
            Bitmap cdimg = new Bitmap(p);
            cdfilepicbx.SizeMode = PictureBoxSizeMode.StretchImage;
            cdfilepicbx.Image = (System.Drawing.Image)cdimg;
        }
        private bool ReadCDCallMusicBrainz()
        {
            Structure.mb_disc_private disc = new Structure.mb_disc_private(0, 0);
            Structure.device = new StringBuilder(drive);
            IntPtr pMyStructPTR = Marshal.AllocHGlobal(Marshal.SizeOf(disc));
            Marshal.StructureToPtr(disc, pMyStructPTR, false);
            MusicBrainzLibDisc(pMyStructPTR, Structure.device);
            Structure.mb_disc_private pMyStruct = (Structure.mb_disc_private)Marshal.PtrToStructure(pMyStructPTR, typeof(Structure.mb_disc_private));
            XmlDocument xmlDocument = null;

            if (pMyStructPTR != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pMyStructPTR);
                pMyStructPTR = IntPtr.Zero;
            }
            try
            {
                xmlDocument = webService.Dwnld(new string(disc.webservice_url));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            XmlNamespaceManager manager = ManagerNs(ref xmlDocument);
            XmlNodeList ListCD = xmlDocument.SelectNodes("//MB:disc//MB:release-list//MB:release", manager);

            if (ListCD.Count > 0)
            {
                ReadyCdsFound(ListCD);
            }
            else
            {
                MessageBox.Show(Languages.msgCDNotFound);
                return false;
            }
            if (bs.Count > 0)
                bs.Clear();
            bs.DataSource = Global.listcdfound;
           
            dtgrvwInfoCd.DataSource = bs;
            return true;
        } // End of ReadCDCallMusicBrainz

        /// <summary>
        /// Writes in the Forms the information found on the CD
        /// </summary>
        private void writeInfo()
        {
            textTitle.Text = Global.choosedCD.Title;
            textArtist.Text = Global.choosedCD.Artist;
            textDate.Text = Global.choosedCD.PublicationDate;
            textCountry.Text = Global.choosedCD.Country;
            textBarcode.Text = Global.choosedCD.Barcode;

            if(Global.choosedCD.Duration.Length > 0)
                textCtrlHMS.time = Global.choosedCD.Duration;
             this.Refresh();
            trackAUBindingSource.DataSource = Global.choosedCD.LTracks;
            TrackDtGrVw.Refresh();
        } // End of writeInfo

        private bool selectCD()
        {
            if (_coverList.Count > 0)
            {
                this.linkToDiscOrMBr.Visible = true;
                this.linkToDiscOrMBr.Text = "https://www.discogs.com/";
                return true;
            }
            Cursor.Current = Cursors.WaitCursor;
            int numfile = 0;
            for (int j = 0; j < Global.listcdfound.Count; j++)
            {
                Global.choosedCD = Global.listcdfound[j];
                if (!MusicBr.RetrieveImgByMusicBrainz(_coverList, ref numfile))
                {
                    Cursor.Current = Cursors.Default;
                    if (numfile >= 10)
                        return true; ;
                }
            }
            {
                numfile = (int)SearchCoverDiscoGS(numfile).Result;
                this.linkToDiscOrMBr.Text = "https://www.discogs.com/";
            }
            Cursor.Current = Cursors.Default;
            if(numfile >0)
                return true;
            else
                return false;
        } // End of selectCD

        /// <summary>
        /// Start the thread to search the internet for covers
        /// </summary>
        /// <param name="numfile"></param>
        /// <returns></returns>
        private static async Task<int> SearchCoverDiscoGS(int numfile)
        {
            var t = new Thread(new ThreadStart(() => Discogs.Disco_gs(ref _coverList, ref numfile)));
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
            t.Join();
            return numfile;
        }

        void small_NumIndexReady(object sender, EventArgs e)
        {
            CDCoverControl child = sender as CDCoverControl;
            if (child != null)
                numCov = child.NumIndex;
        }

        /// <summary>
        /// Search the cd information in Music Brainz 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool cdsearch(string dr)
        {
            LogProj.Info("IN cdsearch");
            Structure.mb_disc_private disc = new Structure.mb_disc_private(0, 0);
            Structure.device = new StringBuilder(dr.ToString());
            int numtr;
            XmlDocument xmlDocument = null;
            try
            {
                IntPtr pMyStructPTR = Marshal.AllocHGlobal(Marshal.SizeOf(disc));
                Marshal.StructureToPtr(disc, pMyStructPTR, false);
                numtr = MusicBrainzLibDisc(pMyStructPTR, Structure.device);
                Structure.mb_disc_private pMyStruct = (Structure.mb_disc_private)Marshal.PtrToStructure(pMyStructPTR, typeof(Structure.mb_disc_private));
            
                if (pMyStructPTR != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pMyStructPTR);
                   pMyStructPTR = IntPtr.Zero;
                }
                try
                {
                      string URL = string.Empty;
                      foreach (char c in pMyStruct.webservice_url)
                            if (c != '\0')
                                 URL += c;
                      xmlDocument = webService.Dwnld(URL);
                }
                catch (Exception ex)
                {
                       LogProj.exception(ex.Message);
                       MessageBox.Show(ex.ToString());
                       return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            XmlNamespaceManager manager = ManagerNs(ref xmlDocument);
            if (xmlDocument == null)
                return false;
            XmlNodeList ListCD = xmlDocument.SelectNodes("//MB:disc//MB:release-list//MB:release", manager);
            if (ListCD != null && ListCD.Count > 0)
            {
                XmlNode Title = ListCD.Item(0);
                XmlNode mom = Title.FirstChild;
                cdx.Title = mom.InnerText;
                GetDataCountry(cdx, ListCD);
                cdx.Barcode = getBarcode(xmlDocument);
                Task<int> fn = SearchUrlsCD(ListCD, cdx);
                if (fn.Result ==1)
                {

                    audioCDBindingSource.DataSource = Global.listcdfound;
                    dtgrvwInfoCd.DataSource = audioCDBindingSource; //bs;
                    //HideColumn();
                    MusicBrainz.Enabled = true;
                    try
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyBiblioCDs", true);
                        object obj = key.GetValue("musicbrainz");
                        cdfilepicbx.Load(obj.ToString());
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return true;
                }
                else
                    return false;
            }
            return false;
        } // End of cdsearch

        string getBarcode(XmlDocument xmlDocument)
        {
            XmlNodeList barList = xmlDocument.GetElementsByTagName("barcode");
            foreach (XmlNode m in barList)
            {
                if (m.InnerText != "")
                    return m.InnerText;
            }
            return string.Empty;
        }

        /// <summary>
        /// If it doesn't find anything automatically... 
        /// </summary>
        /// <returns></returns>
        private bool askquestion()
        {
            System.Windows.Forms.DialogResult result = MessageBox.Show(new Form { TopMost = true }, Languages.msgbxCDnotFound, "Notice", MessageBoxButtons.YesNo);//   "Information not found in MusicBrainz for the CD in the driver\nDo you want to manually enter Info: title, artist and restart the search?", "Notice", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Upload the form is start the iternet search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int numfile = 0;
            bool close = false;
            this.textCtrlHMS.TextInternalChanged -= new System.EventHandler(this.textCtrlHMS_TextInternalChanged);
            this.TrackDtGrVw.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TrackDtGrVw_CellValueChanged);
            this.dtgrvwInfoCd.AutoGenerateColumns = false;
            HeadInfoCd();
            if (!searchornotsearch)
            {
                this.dtgrvwInfoCd.Enabled = false;
                this.dtgrvwInfoCd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            }
            else if (!cdsearch(drive))
            {
                _coverList = new List<ImgCoverInfo>();
                if (searchornotsearch && askquestion())
                {
                    ArtistTitleEdit ed = new ArtistTitleEdit();//_coverList);
                    ed.TopMost = true;
                    Audio_CD _cdfound = new Audio_CD();
                    DialogResult dialogResult = ed.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        _cdfound.Title = ed?._Title;
                        _cdfound.Artist = ed?._Artist;
                        ed.Dispose();
                        Discogs.ManuelSearch(_cdfound, _coverList, ref numfile);

                        if (Global.listcdfound.Count > 0)
                        {
                            audioCDBindingSource.DataSource = Global.listcdfound;
                            dtgrvwInfoCd.DataSource = audioCDBindingSource; // bs;
                            MusicBrainz.Enabled = true;
                            this.dtgrvwInfoCd.Refresh();
                            try
                            {
                                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyBiblioCDs", true);
                                object obj = key.GetValue("discogs");
                                cdfilepicbx.Load(obj.ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show(new Form { TopMost = true }, _cdfound.Title + " " + _cdfound.Artist + "\n" + Languages.msgcdnotfoundAlternative, "Notice", MessageBoxButtons.OK);
                            close = true;;
                        }
                    }
                    else
                        close = true;
                } 
                else
                    close = true;
                if(close)
                {
                    this.dtgrvwInfoCd.SelectionChanged -= new System.EventHandler(this.dtgrvwInfoCd_SelectionChanged);
                    this.WindowState= FormWindowState.Minimized;
                    this.Close();
                }
            }
                this.textCtrlHMS.TextInternalChanged += new System.EventHandler(this.textCtrlHMS_TextInternalChanged);
        } // End of Form1_Load

        /// <summary>
        /// Opens the window and shows the found covers. Here you choose the cover that will be saved.
        /// </summary>
        /// <returns></returns>
        private int ShowCover()
        {
            SmallCDImgForm smallCDImgForm = new SmallCDImgForm();
            int num = 0;
            foreach (ImgCoverInfo imginf in _coverList)
            {
                try
                {
                    smallCDImgForm.flowLayoutPanel1.Controls.Add(smallCDImgForm.cdcoverctrl = CDCoverControl.Instance);
                    smallCDImgForm.cdcoverctrl.CoverCd.SizeMode = PictureBoxSizeMode.StretchImage;
                    smallCDImgForm.cdcoverctrl.CoverCd.Image = System.Drawing.Image.FromFile(imginf.CoverFile, true);
                    smallCDImgForm.cdcoverctrl.NameTxtBx.Text = Global.choosedCD.Artist + " " + Global.choosedCD.Title;
                    smallCDImgForm.cdcoverctrl.FileTxtBx.Text = imginf.CoverFile;
                    smallCDImgForm.cdcoverctrl.SizeTxt.Text = imginf.CoverImgSize;
                    smallCDImgForm.cdcoverctrl.IndexTxt.Text = (num + 1).ToString();
                    imginf.numCover = num++;
                    smallCDImgForm.cdcoverctrl.NumIndexReady += new EventHandler(small_NumIndexReady);
                    smallCDImgForm.cdcoverctrl.InfoPanel.Update();
                }
                catch (Exception e)
                {
                    LogProj.exception(e.Message);
                    int i = smallCDImgForm.flowLayoutPanel1.Controls.Count;
                    smallCDImgForm.flowLayoutPanel1.Controls.RemoveAt(i - 1);
                    num++;
                    continue;
                }
            }
            try
            {
                smallCDImgForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return smallCDImgForm.numindex;
        } // End of ShowCover



        private void ReadyCdsFound_2(BindingList<Audio_CD> Bindlistcdfound, List<Audio_CD> listcdfound)
        {
            foreach (Audio_CD X in listcdfound)
            {
                Audio_CD elem = new Audio_CD();
                if (X.Title != null)
                    elem.Title = X.Title;
                if (X.Country != null)
                    elem.Country = X.Country;
                if (X.PublicationDate != null)
                    elem.PublicationDate = X.PublicationDate;
                if (X.Barcode != null)
                    elem.Barcode = X.Barcode;
                if (X.Release_ID != null)
                    elem.Release_ID = X.Release_ID;
                 if(X.numTracks != 0)
                     elem.numTracks = X.numTracks;
                Bindlistcdfound.Add(elem);
            }
        } // End of ReadyCdsFound

        private void bLocal_Click(object sender, EventArgs e)
        {
            if(searchornotsearch)
                Global.choosedCD = Global.listcdfound[numRow];
            bool path = OpenDlgFile();
            if (path)
            {
                    if (Global.choosedCD.CoverArtF != string.Empty)
                         LoadImage(Global.choosedCD.CoverArtF);
                    dtgrvwInfoCd.Rows[numRow].Cells[6].Value = Global.choosedCD.CoverArtF;
            }
        }
        private static bool OpenDlgFile()
        {
            OpenFileDialog folderDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\",
                Filter = "image (*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;*.TIFF| All files (*.*)|*.* "
            };
            if (folderDialog.ShowDialog(new Form { TopMost = true }) == DialogResult.OK)
            {

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(folderDialog.FileName);
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyBiblioCDs", true);
                object obj = key.GetValue("MyBiblioCDCoverArt");
                string filename = obj.ToString() + "\\" + fileInfo.Name;
                try
                {
                    if(System.IO.File.Exists(filename))
                    {
                        MessageBox.Show(filename + "\n" + Languages.FileExists);
                        
                    } else
                        System.IO.File.Copy(fileInfo.FullName, filename);
                }
                catch (Exception ex)
                {
                        MessageBox.Show(ex.Message);
                        return false;
                }
                Global.choosedCD.CoverArtF = filename;
            }
            return true;
        }

        /// <summary>
        /// Check and Save Selected CD 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            if (InfoControl() == false)
            {
                close = true;
                return; 
            }
            Global.choosedCD.Cpy(ref cdx);
            this.Close();
            dtgrvwInfoCd.Dispose();
            Global.Clear();
            Global.choosedCD.Dispose();
            _coverList.Clear();
            this.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Check and the information is all present and correct
        /// </summary>
        /// <returns></returns>
        private bool InfoControl()
        {
            if (textTitle.Text.Length == 0)
            {
                if (MessageBox.Show(Languages.msgNameCDnotFound, Languages.nameCaptionTitle, MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
            }
            if(textArtist.Text.Length == 0)
            {
                    if (MessageBox.Show(Languages.msgNameArtistNotFound, Languages.nameCaptionmsgBox, MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
            }
            if(textCountry.Text.Length == 0)
            {
                if (MessageBox.Show(Languages.msgNameLandNotFound, Languages.nameCaptionLand, MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
            }
            if(cmbgenreMusic.SelectedIndex == -1)
            {
                if (MessageBox.Show(Languages.msgGenreMiss, Languages.nameCapGenre, MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
            }
            if(textDate.Text.Length < 4 )
            {
                if(MessageBox.Show(Languages.msgMissngData, Languages.nameCapDate, MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
                else
                    Global.choosedCD.PublicationDate = null;
            }
            else if(textDate.Text.Length > 4)
            {
                if(MessageBox.Show(Languages.msgFormatDatencorrect, Languages.nameCapDate, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return false;
                else
                    Global.choosedCD.PublicationDate = null;
            }
            return true;
        } // End of InfoControl

        private void cmbgenreMusic_TextChanged(object sender, EventArgs e)
        {
            if(cmbgenreMusic.SelectedIndex !=-1)
                Global.choosedCD.genreMusic = cmbgenreMusic.SelectedIndex;
            dtgrvwInfoCd.Rows[numRow].Cells[7].Value = cmbgenreMusic.Text;
        }

        private void Translator(string lang)
        {
            // Button
            Languages.Dictionary(lang);
            MusicBrainz.Text = Languages.btninNet;
            bLocal.Text = Languages.btnLocal;
            btnsave.Text = Languages.btnSave;

            // Label
            label1.Text = Languages.lbAlbum;
            label1.Location = new Point(5, label1.Location.Y);
            label2.Text = Languages.lbTitle;
            label3.Text = Languages.lbArtist;
            label4.Text = Languages.lbDate;
            label5.Text = Languages.lbCountry;
            label6.Text = Languages.lbBarcode;
            label7.Text = Languages.lbSearchCover;
            label8.Text = Languages.lbGenre;

            TrackDtGrVw.Columns[0].HeaderText = Languages.TrackDtGrVw_TrNum;
            TrackDtGrVw.Columns[1].HeaderText = Languages.TrackDtGrVw_Title;
            TrackDtGrVw.Columns[2].HeaderText = Languages.TrackDtGrVw_Duration;
        }

        private void MainFormAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                if (bs != null && bs.Count > 0)
                {
                    this.dtgrvwInfoCd.SelectionChanged -= new System.EventHandler(this.dtgrvwInfoCd_SelectionChanged);
                    bs.Clear();
                }
            if(close)
            {
                e.Cancel = true;
                close = false;
            }
        }

       private void bCancel_Click(object sender, EventArgs e)
       {
            this.dtgrvwInfoCd.SelectionChanged -= new System.EventHandler(this.dtgrvwInfoCd_SelectionChanged);
            Global.Clear();
            this.Close();
            this.Dispose();
        }

        private void textCtrlHMS_TextInternalChanged(object sender, EventArgs e)
        {
            Global.choosedCD.Duration = textCtrlHMS.time;
        }

        private void textCtrlHMS_Leave(object sender, EventArgs e)
        {
            Global.choosedCD.Duration = textCtrlHMS.time;
            dtgrvwInfoCd.Rows[numRow].Cells[8].Value = Global.choosedCD.Duration;
        }

        private void textTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            changeText = true;
        }

        private void textTitle_Leave(object sender, EventArgs e)
        {
            if(changeText)
            {
                Global.choosedCD.Title = textTitle.Text;
                dtgrvwInfoCd.Rows[numRow].Cells[0].Value = textTitle.Text;
                changeText= false;
            }
        }

        private void textArtist_KeyPress(object sender, KeyPressEventArgs e)
        {
            changeText = true;
        }
        private void textArtist_Leave(object sender, EventArgs e)
        {
            if (changeText)
            {
                Global.choosedCD.Artist = textArtist.Text;
                dtgrvwInfoCd.Rows[numRow].Cells[1].Value = textArtist.Text;
                changeText = false;
            }
        }
        private void textDate_Leave(object sender, EventArgs e)
        {
            if (changeText)
            {
                Global.choosedCD.PublicationDate = textDate.Text;
                dtgrvwInfoCd.Rows[numRow].Cells[3].Value = textDate.Text;
                changeText = false;
            }
        }

        private void textDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            changeText = true;
        }

        private void textCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            changeText = true;

        }

        private void textCountry_Leave(object sender, EventArgs e)
        {
            if (changeText)
            {
                Global.choosedCD.Country = textCountry.Text;
                dtgrvwInfoCd.Rows[numRow].Cells[2].Value = textCountry.Text;
                changeText = false;
            }
        }

    }
}
