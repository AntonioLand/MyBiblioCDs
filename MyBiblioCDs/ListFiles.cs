using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.ListView;
using System.IO.Compression;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Office.Interop.Word;
using System.Windows.Controls;
using ICSharpCode.SharpZipLib.Zip;
using System.Globalization;
//using static Google.Protobuf.WellKnownTypes.Field.Types;
#pragma warning disable CS1591


#region statements
namespace MyBiblioCDs
{
    public partial class ListFiles : Form, IDisposable
    {
        string driver;
        string worklanguage;
        int numTot;
        List<DirAndFiles> FILESINFO;
        Dictionary<string, string> extfiles = new Dictionary<string, string>();
        private tplistViewColumnSorter tplistView_lvwColumnSorter;
        PictureBox bxImg;
        AxAcroPDFLib.AxAcroPDF axpdf;
        System.Windows.Forms.RichTextBox richTextBox;
        Tuple<int, string>[] ThreeColor = new Tuple<int, string>[3];
        System.Windows.Forms.ListView listViewZip;
        List<int> retrieveditem = new List<int>();
        VLC newfrm = null;
        bool vlcisopen = false;
        //bool browser = true;
        public System.Windows.Forms.ContextMenu MyCntxMn1;
        public System.Windows.Forms.ContextMenu MyCntxMn2;
        string cliptext;
        string fileSelected;
        static System.Drawing.Color[] color = { System.Drawing.Color.PaleGreen,
                                                System.Drawing.Color.LightGray,
                                                System.Drawing.Color.DarkSalmon,
                                                System.Drawing.Color.LemonChiffon,
                                                System.Drawing.Color.CadetBlue
                                               };
        static int ci = 0; //Color index
        bool SelOrNotSel = true;

        public ListFiles(ref List<DirAndFiles> pfllist, string cddriver, int numTotal, string language)
        {

            InitializeComponent();
            InitializeBckgrWkLoadLsFiles();
            driver = cddriver;
            worklanguage = language;
            btnCancel.DialogResult = DialogResult.Cancel;
            FILESINFO = pfllist;
            RegisterFunction.OpenRegisterKey();
            string file = (string)RegisterFunction.ReadKey("DirFileMyBiblioCDs");
            file = file + @"extImgFiles.txt";
            LoadDict(ref extfiles, file);
            tplistView_lvwColumnSorter = new tplistViewColumnSorter();
            tplistView.ListViewItemSorter = tplistView_lvwColumnSorter;
            numTot = numTotal;
            axWndMediaPlayer.Visible = false;
            HashButton.Enabled = btnNote.Enabled = false;
            toolStripDropDownButton1.Enabled = false;
            MyContextMenu();
        }


        public void MyContextMenu()
        {
            MyCntxMn1 = new System.Windows.Forms.ContextMenu();
            MyCntxMn1.MenuItems.Add(new System.Windows.Forms.MenuItem("Note", new System.EventHandler(btnNote_Click)));
            MyCntxMn1.MenuItems.Add(new System.Windows.Forms.MenuItem("All Note", new System.EventHandler(ViewAllNote)));
            tplistView.ContextMenu = MyCntxMn1;
        }
        private void MyCntxMn1_Collapse(object sender, EventArgs e)
        {
            MyCntxMn1.Dispose();
        }
        #endregion

        #region EventForm
        /// <summary>
        /// Abort thread to read files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bckgrWkLoadLsFiles.IsBusy)
                bckgrWkLoadLsFiles.CancelAsync();

        }
        /// <summary>
        /// Activated when the selection of an item changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tplistView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && SelOrNotSel)
            {
                Tuple<int, int> hiddingInfo = e.Item.Tag as Tuple<int, int>;
                if (hiddingInfo != null)
                {
                    int numdir = -1;
                    int indx = -1;
                    PosDirAndfile(hiddingInfo, ref numdir, ref indx);
                    if (indx != -1)
                    {
                        fileSelected = FILESINFO[numdir].FilesInfos[indx].thisfile.FullName;
                        showfile(numdir, indx);
                    }
                    else
                        toolStripTextBox1.Text = e.Item.Text;
                }
            }
        }
        /// <summary>
        /// Starts the thread for reading files and directories and uploads them to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListFiles_Load(object sender, EventArgs e)
        {
            btnsave.Enabled = false;
            toolStripTextBox1.Text = driver;
            //this.FormBorderStyle = FormBorderStyle.Fixed3D;
            bckgrWkLoadLsFiles.RunWorkerAsync();
            Translator(worklanguage);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        /// <summary>
        /// Search the Shell for the icon of the selected file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="linkOverlay"></param>
        /// <returns></returns>
        private static System.Drawing.Icon GetFileIcon(string name, bool linkOverlay)
        {
            Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
            uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;
            if (linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;
            flags += Shell32.SHGFI_SMALLICON; // include the small icon flag
            Shell32.SHGetFileInfo(name,
                Shell32.FILE_ATTRIBUTE_NORMAL,
                ref shfi,
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                flags);
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            User32.DestroyIcon(shfi.hIcon); // Cleanup
            return icon;
        } // End of GetFileIcon

        private void ListFiles_Resize(object sender, EventArgs e)
        {
            flowLayoutPanel2.PerformLayout();
            if (flowLayoutPanel2.Controls.Count > 0)
                flowLayoutPanel2.Controls[0].Size = flowLayoutPanel2.Size;
            if (axWndMediaPlayer.Visible)
            {
                axWndMediaPlayer.Location = new System.Drawing.Point(flowLayoutPanel2.Location.X, flowLayoutPanel2.Location.Y);
                axWndMediaPlayer.Size = new System.Drawing.Size((int)(flowLayoutPanel2.Width), flowLayoutPanel2.Size.Height);
            }
        }

        /// <summary>
        /// Change column sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tplistView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == tplistView_lvwColumnSorter.ColumnToSort)
            {
                if (tplistView_lvwColumnSorter.OrderOfSort == SortOrder.Ascending)
                {
                    tplistView_lvwColumnSorter.OrderOfSort = SortOrder.Descending;
                }
                else
                {
                    tplistView_lvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }
            }
            else
            {
                tplistView_lvwColumnSorter.ColumnToSort = e.Column;
                tplistView_lvwColumnSorter.OrderOfSort = SortOrder.Ascending;
            }
            tplistView.Sort();
        }

        /// <summary>
        /// Load file extensions from extImgFiles.txt. 
        /// </summary>
        /// <param name="theDict"></param>
        /// <param name="filename"></param>
        private void LoadDict(ref Dictionary<string, string> theDict, string filename)
        {
            char[] param = { ' ' };
            foreach (string line in System.IO.File.ReadLines(filename))
            {

                string[] lineKV = line.Split(' ');
                theDict.Add(lineKV[0].ToLower(), lineKV[1]);
            }
        }
        #endregion

        #region WorkToWork
        private void PosDirAndfile(Tuple<int, int> hiddingInfo, ref int numdir, ref int indx)
        {
            if (hiddingInfo != null)
            {
                numdir = hiddingInfo.Item1;
                indx = hiddingInfo.Item2;
            }
        }
        void showfile(int numdir, int indx)
        {
            if (extfiles.ContainsKey(FILESINFO[numdir].FilesInfos[indx].thisfile.Extension.ToLower()))
            {
                string ext = extfiles[FILESINFO[numdir].FilesInfos[indx].thisfile.Extension.ToLower()];

                switch (ext)
                {
                    case "img":
                        //Creabitmap show file
                        if (WhatAlreadyExists("PictureBox"))
                        {
                            flowLayoutPanel2.Controls.RemoveAt(0);
                            bxImg.Image.Dispose();
                            bxImg.Refresh();
                        }
                        ImageLoader(FILESINFO[numdir].FilesInfos[indx].thisfile.FullName);
                        break;
                    case "txt":
                    case "pro":
                    case "script":
                    case "ini":
                    case "bat":
                        //case "log":
                        LoadText(numdir, indx);
                        break;
                    case "pdf":
                        if (WhatAlreadyExists("AxAcroPDF"))
                        {
                            axpdf.src = null;
                            axpdf.Invalidate();
                            axpdf.Visible = false;
                        }
                        LoadAdPdf(numdir, indx);
                        break;
                    case "doc":
                    case "docx":
                        {
                            if (WhatAlreadyExists("RichTextBox"))
                            {
                                richTextBox.Text = "";
                            }
                            else
                            {
                                richTextBox = new System.Windows.Forms.RichTextBox();
                                flowLayoutPanel2.Controls.Add(richTextBox);
                                richTextBox.Anchor = AnchorStyles.Top;
                                richTextBox.Width = flowLayoutPanel2.Width;
                                richTextBox.Height = flowLayoutPanel2.Height;
                            }

                            LoadDocFile(FILESINFO[numdir].FilesInfos[indx].thisfile.FullName);
                            break;
                        }
                    case "audio":
                    case "video1":
                        if (!WhatAlreadyExists("axWndMediaPlayer"))
                        {
                            axWndMediaPlayer.Location = new System.Drawing.Point(flowLayoutPanel2.Location.X, flowLayoutPanel2.Location.Y);
                            axWndMediaPlayer.Size = new System.Drawing.Size((int)(flowLayoutPanel2.Width) - 10, flowLayoutPanel2.Size.Height - 20);
                            axWndMediaPlayer.Visible = true;
                        }
                        axWndMediaPlayer.URL = FILESINFO[numdir].FilesInfos[indx].thisfile.FullName;
                        break;
                    case "video":
                    case "audio1":
                        {
                            this.TopMost = false;
                            if (!WhatAlreadyExists("newfrm"))
                            {
                                newfrm = new VLC(FILESINFO[numdir].FilesInfos[indx].thisfile.FullName);
                                newfrm.IsClosedOrNotClosed += new VLC.ClosedEventHandler(_closeVLC);
                                newfrm.TopMost = true;
                                newfrm.Show();
                                newfrm.mediapl.Play();
                                vlcisopen = true;
                            }
                            newfrm.TopMost = true;
                            newfrm.playnow(FILESINFO[numdir].FilesInfos[indx].thisfile.FullName);
                        }
                        break;
                    case "mail":
                        break;
                    case "zipped":
                        {
                            if (WhatAlreadyExists("ListView"))
                            {
                                foreach (System.Windows.Forms.ListViewItem itm in listViewZip.Items)
                                    itm.Remove();
                            }
                            else
                                BuildListView();
                            InsertItem(FILESINFO[numdir].FilesInfos[indx].thisfile.FullName);
                            listViewZip.Refresh();
                        }
                        break;
                    case "browser":
                        {
                            Uri uri = new Uri(FILESINFO[numdir].FilesInfos[indx].thisfile.FullName);
                            OpenWebBrowser(uri);
                        }
                        break;
                }
                toolStripTextBox1.Text = FILESINFO[numdir].FilesInfos[indx].thisfile.FullName;
            }
        } // End show File
        private void _closeVLC()
        {
            newfrm.IsClosedOrNotClosed -= new VLC.ClosedEventHandler(_closeVLC);
            newfrm = null;
            vlcisopen = false;
        }
        private bool WhatAlreadyExists(string isthat)
        {
            if (isthat == "axWndMediaPlayer")
            {
                if (vlcisopen)
                {
                    newfrm._closeVLC();
                    vlcisopen = false;
                    newfrm = null;
                }
                if (axWndMediaPlayer.Visible)
                    return true;
            }
            else if (axWndMediaPlayer.Visible)
            {
                axWndMediaPlayer.Visible = false;
                axWndMediaPlayer.Ctlcontrols.stop();
            }
            if (isthat == "newfrm")
            {
                if (newfrm != null && newfrm.mediapl != null)
                    return true;
                else
                    return false;
            }
            System.Windows.Forms.Control.ControlCollection actichild = flowLayoutPanel2.Controls;
            string name;
            if (actichild.Count > 0)
            {
                Type X = actichild[0].GetType();
                name = X.Name;
                if (name == isthat)
                    return true;
                else
                    flowLayoutPanel2.Controls.RemoveAt(0);
            }
            return false;
        }
        /*   ckfiles .ext allfiles           */
        /*   ckIndir .ext in directory       */
        /*   * || .ext search in all list   */
        /*   Path\*:EXT SEARCH IN Path       */
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.AcceptButton = null;
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    string ext = toolStripTextBox1.Text;
                    string path = ext.Substring(0, ext.LastIndexOf("\\") + 1);
                    char[] separator = { ' ' };
                    string[] collect = ext.Split(separator);
                    if (collect[0] == "audio") 
                    {
                        // Find all audio
                        foreach (KeyValuePair<string, string> s in extfiles)
                        {
                            if(s.Value == "audio" || s.Value == "audio1")
                                searchinallList(s.Key);
                        }
                    }
                    else if (collect[0] == "video")
                    {
                        foreach (KeyValuePair<string, string> s in extfiles)
                            if (s.Value == "video" || s.Value == "video1")
                            searchinallList(s.Key);

                    }
                    else if (collect[0] == "ckfiles")
                    {
                        ext = collect[1];
                        ext = ext.ToLower();
                        Checkallfile(ext);
                    }
                    else if (collect[0] == "ckIndir")
                    {
                        ext = collect[1];
                        ext = ext.ToLower();
                        Checkindir(ext);
                    }
                    else if (collect[0][0] == '*' || collect[0][0] == '.')
                    {
                        searchinallList(ext);
                    }
                    else if (Path.GetFullPath(path) != null)
                    {
                        ext = ext.Substring(ext.LastIndexOf("\\") + 1, ext.Length - 1 - ext.LastIndexOf("\\"));
                        if (ext[0] == '*')
                        {
                            ext = ext.Remove(0, 1);
                        }
                        if (ext != null && path != null)
                        {
                            SelectedListViewItemCollection thisIs = tplistView.SelectedItems;
                            if (thisIs.Count > 0)
                            {
                                Tuple<int, int> hiddingInfo = thisIs[0].Tag as Tuple<int, int>;
                                int indxDr = hiddingInfo.Item1;
                                if (indxDr != -1)
                                    selectitemfiles(ext, FILESINFO[indxDr].FilesInfos.Count, thisIs[0].Index);
                            }
                        }
                    }
                    this.SelectNextControl(this.tplistView, true, false, false, true);
                }
            } catch (Exception ex)
            {
                LogProj.exception(ex.Message);
            }
        }
        private void LoadText(int numdir, int indx)
        {
            if (WhatAlreadyExists("RichTextBox"))
                richTextBox.Text = "";
            else
            {
                richTextBox = new System.Windows.Forms.RichTextBox();
                flowLayoutPanel2.Controls.Add(richTextBox);
                richTextBox.Anchor = AnchorStyles.Top;
                richTextBox.Width = flowLayoutPanel2.Width;
                richTextBox.Height = flowLayoutPanel2.Height;
            }
            MyCntxMn2 = new System.Windows.Forms.ContextMenu();
            MyCntxMn2.MenuItems.Add(new System.Windows.Forms.MenuItem("Note", new System.EventHandler(writenote)));
            richTextBox.ContextMenu = MyCntxMn2;
            this.richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this.richTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseDown);

            string inp = "";
            using (StreamReader sr = new StreamReader(fileSelected))
            {
                string txt = sr.ReadToEnd();
                richTextBox.Text = txt;
            }
        }

        private void richTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MyCntxMn2.Show(richTextBox, new System.Drawing.Point(e.X, e.Y));
            }
        }

        private void writenote(object sender, EventArgs e)
        {
            InsertNote(2);
        }
        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            cliptext = richTextBox.SelectedText;
        }
        private void tplistView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int x = e.Index;
            Tuple<int, int> tag = tplistView.Items[x].Tag as Tuple<int, int>;
            this.tplistView.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
            if (tag.Item2 == -1)
            {
                bool chornoch = false;
                if ((chornoch = tplistView.Items[x].Checked))
                    chornoch = false;
                else
                    chornoch = true;
                tplistView.Items[x].Checked = !tplistView.Items[x++].Checked;
                foreach (InfoFiles fi in FILESINFO[tag.Item1].FilesInfos)
                {
                    tplistView.Items[x++].Checked = chornoch;
                    fi.chck = chornoch;
                }
            }
            else
            {
                tplistView.Items[x].Checked = !tplistView.Items[x].Checked;
                FILESINFO[tag.Item1].FilesInfos[tag.Item2].chck = tplistView.Items[x].Checked;
            }
            this.tplistView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
        }
        void Checkindir(string ext)
        {
            this.tplistView.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
            SelectedListViewItemCollection itselected = tplistView.SelectedItems;
            string dirname = itselected[0].Text;
            int indx = itselected[0].Index + 1;
            int find = 0;
            Tuple<int, int> hiddingInfo = itselected[0].Tag as Tuple<int, int>;
            int indxDr = hiddingInfo.Item1;
            for (int I = 0; I < FILESINFO[indxDr].FilesInfos.Count; I++)
            {
                if (tplistView.Items[indx + I].SubItems[4].Text.ToLower() == ext)
                {
                    find++;
                    tplistView.Items[indx + I].Checked = !tplistView.Items[indx + I].Checked;
                    FILESINFO[indxDr].FilesInfos[I].chck = tplistView.Items[indx + I].Checked;
                }
            }
            toolStripStatusLabel1.Text = find.ToString() + " files Checked";
            this.tplistView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
        }
        int Checkallfile(string ext)
        {
            int find = 0;
            this.tplistView.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
            for (int i = 0; i < tplistView.Items.Count; i++)
            {
                if (tplistView.Items[i].SubItems[4].Text.ToLower() == ext)
                {
                    find++;
                    tplistView.Items[i].Checked = !tplistView.Items[i].Checked;
                }
            }
            foreach (DirAndFiles d in FILESINFO)
                foreach (InfoFiles fl in d.FilesInfos)
                    if (fl.thisfile.Extension.ToLower() == ext)
                        if (fl.chck == false)
                            fl.chck = true;
                        else
                            fl.chck = false;
            toolStripStatusLabel1.Text = find.ToString() + " files Checked";
            this.tplistView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tplistView_ItemCheck);
            return find;
        }

        void selectitemfiles(string ext, int count, int indxlw)
        {
            System.Drawing.Color color = tplistView.Items[indxlw].BackColor;
            if (ThreeColor != null)
            {
                if (ThreeColor[0] == null)
                {
                    ThreeColor[0] = new Tuple<int, string>(indxlw, ext);
                    color = System.Drawing.Color.Aquamarine;
                }
                else if (ThreeColor[1] == null)
                {
                    ThreeColor[1] = new Tuple<int, string>(indxlw, ext);
                    color = System.Drawing.Color.CadetBlue;
                }
                else if (ThreeColor[2] == null)
                {
                    color = System.Drawing.Color.SkyBlue;
                }
            }
            else
            {
                Tuple<int, string> X = new Tuple<int, string>(indxlw, ext);
                ThreeColor[0] = X;
                color = System.Drawing.Color.Aquamarine;
            }
            for (int i = 0; i <= count; i++, indxlw++)
                if (((tplistView.Items[indxlw].SubItems)[4].Text).ToUpper() == ext.ToUpper())
                {
                    tplistView.Items[indxlw].BackColor = color;
                    retrieveditem.Add(indxlw);
                }
            tplistView.EnsureVisible(retrieveditem[0]);
            toolStripStatusLabel1.Text = retrieveditem.Count.ToString() + ":  Item(s)";
        }
        private void searchinallList(string ext)
        {

            if (ext[0] == '*')
            {
                ext = ext.Remove(0, 1);
            }
            if (ext != string.Empty)
            {
                retrieveditem.Clear();
                for (int i = 0; i < tplistView.Items.Count; i++)
                    if (((tplistView.Items[i].SubItems)[4].Text).ToUpper() == ext.ToUpper())
                    {
                        tplistView.Items[i].BackColor = color[ci]; //System.Drawing.Color.AliceBlue;
                        retrieveditem.Add(i);
                    }
                if (retrieveditem.Count > 0)
                {
                    toolStripStatusLabel1.Text = retrieveditem.Count.ToString() + ":  Item(s)";
                    tplistView.EnsureVisible(retrieveditem[0]);

                    if (ci == 4)
                        ci = 0;
                    else
                        ci++;
                }
            }
        }
        private void resetcolor()
        {
            while (retrieveditem.Count > 0)
            {
                tplistView.Items[retrieveditem[0]].BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                retrieveditem.RemoveAt(0);
            }
        }
        private void tplistView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                resetcolor();
            }
        }
        #endregion
        private void Translator(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            Languages.Dictionary(lang);
            btnsave.Text = Languages.btnsave;
            btnNote.Text = Languages.btnNote;
            btnCancel.Text = Languages.btnCancel;
        }
        private void btnNote_Click(object sender, EventArgs e)
        {
            InsertNote(1);
            //MyCntxMn1.Dispose();
        }

        /// <summary>
        /// Show CD notes and all the notes of the selected file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewAllNote(object sender, EventArgs e)
        {
            int numdir = -1;
            int indx = -1;
            try
            {
                SelectedListViewItemCollection sf = tplistView.SelectedItems;
                Tuple<int, int> hiddingInfo = sf[0].Tag as Tuple<int, int>;
                if (hiddingInfo != null)
                    PosDirAndfile(hiddingInfo, ref numdir, ref indx);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "A file needs to be selected.");
            }
            NoteCD novaNote = new NoteCD();
            if (FILESINFO[numdir].FilesInfos[indx].nota != null && FILESINFO[numdir].FilesInfos[indx].nota.Count > 0)
            {
                foreach (NOTE nt in FILESINFO[numdir].FilesInfos[indx].nota)
                {
                    novaNote.rTxtBx.Text += nt.textNote.ToString() + "\n------------------------------------------------\n";
                }
                novaNote.Show();
            }
        } // Private void ViewAllNote

        public void InsertNote(int typenote)
        {
            try
            {
                SelectedListViewItemCollection sf = tplistView.SelectedItems;
                int numdir = -1;
                int indx = -1;
                Tuple<int, int> hiddingInfo = sf[0].Tag as Tuple<int, int>;
                if (hiddingInfo != null)
                    PosDirAndfile(hiddingInfo, ref numdir, ref indx);
                bool changecol = false;
                if (typenote == 0 || typenote == 1)
                {
                    NoteCD novaNote = new NoteCD();
                    novaNote.MaxChar = 2000;
                    if (FILESINFO[numdir].FilesInfos[indx].nota != null && FILESINFO[numdir].FilesInfos[indx].nota.Count > 0)
                    {
                        foreach (NOTE nt in FILESINFO[numdir].FilesInfos[indx].nota)
                        {
                            if (nt.codenote == typenote)
                            {
                                novaNote.rTxtBx.Text = nt.textNote.ToString();
                                FILESINFO[numdir].FilesInfos[indx].nota.Remove(nt);
                                break;
                            }
                        }
                    }
                    changecol = WriteNote(novaNote, numdir, indx, typenote);
                }
                else if (typenote == 2)
                {
                    string NameFile = fileSelected;
                    string TextSelected = cliptext;
                    NoteCD nt = new NoteCD(fileSelected, cliptext, 2, true);
                    nt.MaxChar = 2000;
                    changecol = WriteNote(nt, numdir, indx, typenote);
                }

                if (changecol)
                    sf[0].BackColor = System.Drawing.Color.Gold;
                else
                    sf[0].BackColor = System.Drawing.Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Note");
            }
        } // End of InsertNote

        private bool WriteNote(NoteCD novaNote, int numdir, int indx, int typenote)
        {
            try
            {
                if (novaNote.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(novaNote.rTxtBx.Text))
                    {
                        NOTE nt = new NOTE(new StringBuilder(novaNote.rTxtBx.Text), typenote);
                        if (FILESINFO[numdir].FilesInfos[indx].nota == null)
                            FILESINFO[numdir].FilesInfos[indx].nota = new List<NOTE>();
                        FILESINFO[numdir].FilesInfos[indx].nota.Add(nt);
                        return true;
                    }
                }
                return false;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Saves the file list by deleting files and diractories that have been checked 
        /// </summary>
        private void RemoveChecked()
        {
            int numdir = -1;
            int indx = -1;
            int numitem = tplistView.Items.Count - 1;
            for (int index = numitem; index >= 0; index--)
            {
                System.Windows.Forms.ListViewItem itm = tplistView.Items[index];
                Tuple<int, int> hiddingInfo = itm.Tag as Tuple<int, int>;
                numdir = -1;
                indx = -1;
                PosDirAndfile(hiddingInfo, ref numdir, ref indx);
                if (itm.Checked)
                {
                    if (hiddingInfo != null)
                    {
                        if (numdir < FILESINFO.Count && numdir != -1 && indx == -1)
                        {
                            FILESINFO.RemoveAt(numdir);
                        }
                        else
                        {
                            FILESINFO[numdir].FilesInfos.RemoveAt(indx);
                        }
                    }
                }
            }
            FILESINFO.RemoveAll(x => x.FilesInfos.Count == 0);
            toolStripDropDownButton1.Enabled = true;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            RemoveChecked();
            this.Dispose();

        }


        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnNote;
            toolStripTextBox1.Text = driver;
        }

        private void ckfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".resources");
        }

        private void ckfilesuserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".user");
        }

        private void ckfilesisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".iso");
        }

        private void ckfilespchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".pch");
        }

        private void ckfilespdbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".pdb");
        }

        private void ckfilesdllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".dll");
        }

        private void ckfilesexeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".exe");
        }

        private void ckfileslogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".log");
        }

        private void ckfilesobjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".obj");
        }

        private void ckfilesresxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkallfile(".resx");
        }

        private void loadCheckFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numfilechecked = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Check files (*.chk)|*.chk";
            openFileDialog.Title = "Open File Check Item";
            RegisterFunction.OpenRegisterKey();
            string dir = (string)RegisterFunction.ReadKey("ChkFilesDir");
            RegisterFunction.RegisterKeyClose();
            openFileDialog.InitialDirectory = dir;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dir = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(dir))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        numfilechecked += Checkallfile(line);
                }
            }
            toolStripStatusLabel1.Text = numfilechecked.ToString() + " files Checked";
        }

        private void HashButton_Click(object sender, EventArgs e)
        {
            InitializebackgroundHash();
            backgroundHash.RunWorkerAsync();
            HashButton.Enabled = false;
            btnNote.Enabled = false;
            btnsave.Enabled = false;
        }
        private void tplistView_MouseClick(object sender, MouseEventArgs e)
        {
            SelOrNotSel = true;
            if (e.Button == MouseButtons.Right)
            {
                int i;
                for (i = 0; i < tplistView.Items.Count; i++)
                {
                    var rectangle = tplistView.GetItemRect(i);
                    if (rectangle.Contains(e.Location))
                    {
                        break;
                    }
                }
                Tuple<int, int> tag = tplistView.Items[i].Tag as Tuple<int, int>;
                string itemClick = (FILESINFO[tag.Item1].FilesInfos[tag.Item2]).thisfile.FullName;
                MyContextMenu();
                MyCntxMn1.Show(tplistView, new System.Drawing.Point(e.X, e.Y));
            }

        }

        private void ListFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        // ERRRORRRR ListFiles_2.cs
        private int hiPercReached = 0;

        private void InitializeBckgrWkLoadLsFiles()
        {
            bckgrWkLoadLsFiles.DoWork += new DoWorkEventHandler(bckgrWkLoadLsFiles_DoWork);
            bckgrWkLoadLsFiles.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckgrWkLoadLsFiles_RunWorkerCompleted);
            bckgrWkLoadLsFiles.ProgressChanged += new ProgressChangedEventHandler(bckgrWkLoadLsFiles_ProgressChanged);
            tplistView.BeginUpdate();
        }
        private void bckgrWkLoadLsFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = LoadListView(worker, e);
        }

        private void bckgrWkLoadLsFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = "Canceled";
            }
            else
            {
                Tuple<int, int> response = (Tuple<int, int>)e.Result;
                toolStripStatusLabel1.Text = "Num. Files: " + response.Item1.ToString() + " Num. Dir." + response.Item2;
            }
            this.toolStripProgBar.Value = 0;
            this.tplistView.EndUpdate();
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            HashButton.Enabled = true;
            btnsave.Enabled = true;
            btnNote.Enabled = true;
            toolStripDropDownButton1.Enabled = true;
            this.bckgrWkLoadLsFiles.Dispose();
        }

        private void bckgrWkLoadLsFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.toolStripProgBar.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Tuple<int, int> LoadListView(BackgroundWorker worker, DoWorkEventArgs e, int totalItem = 0, int indx = 0)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return new Tuple<int, int>(-1, -1);
            }
            int numfiles = 0;
            int numdir = 0;
            OnOffUpdate(true);
            List<System.Windows.Forms.ListViewItem> blockAdd = new List<System.Windows.Forms.ListViewItem>();
            for (int i = indx; i < FILESINFO.Count; i++)
            {
                numdir++;
                string[] item = { FILESINFO[i].directoryInfos, "", "", "", "", "-1" };
                System.Windows.Forms.ListViewItem Item = new System.Windows.Forms.ListViewItem(item, 1);
                Item.ToolTipText = "If checked it is not processed";
                Item.Tag = new Tuple<int, int>(i, -1);
                if (FILESINFO[i].FilesInfos.Count > 0)
                {
                    blockAdd.Add(Item);
                }
                else
                    continue;
                try
                {
                    int j = 0;
                    foreach (InfoFiles fi in FILESINFO[i].FilesInfos)
                    {
                        string[] items = {fi.thisfile.Name, fi.thisfile.Length.ToString(), fi.thisfile.CreationTime.ToString(),
                                          fi.thisfile.LastWriteTime.ToString(), fi.thisfile.Extension, ""};
                        this.imageList1.Images.Add(GetFileIcon(fi.thisfile.Name, false));
                        int img = this.imageList1.Images.Count - 1;
                        System.Windows.Forms.ListViewItem itemf = new System.Windows.Forms.ListViewItem(items, img);
                        itemf.ToolTipText = "If checked it is not processed";
                        itemf.Tag = new Tuple<int, int>(i, j);
                        blockAdd.Add(itemf);
                        j++;

                        numfiles++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    System.Windows.Forms.Application.ExitThread();
                }
                int percentComplete = (int)((float)numfiles / (float)numTot * 100);
                if (percentComplete > hiPercReached && percentComplete < 100)
                {
                    hiPercReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }
            OnOffUpdate(false);
            lsadd(blockAdd);
            return new Tuple<int, int>(numfiles, numdir);
        }

        void lsadd(List<System.Windows.Forms.ListViewItem> itms)
        {
            if (tplistView.InvokeRequired)
            {
                tplistView.Invoke(new MethodInvoker(delegate
                {
                    tplistView.Items.AddRange(itms.ToArray());
                }));
            }
            else
            {
                tplistView.Items.AddRange(itms.ToArray());
            }
        }

        void lsadd(System.Windows.Forms.ListViewItem itms)
        {
            if (tplistView.InvokeRequired)
            {
                tplistView.Invoke(new MethodInvoker(delegate
                {
                    tplistView.Items.Add(itms);
                }));
            }
            else
            {
                tplistView.Items.Add(itms);
            }
        }


        void OnOffUpdate(bool onoff)
        {
            if (tplistView.InvokeRequired)
            {
                tplistView.Invoke(new MethodInvoker(delegate
                {
                    if (onoff)
                    {
                        tplistView.BeginUpdate();
                        tplistView.Refresh();
                    }
                    else
                    {
                        tplistView.EndUpdate();
                        tplistView.Refresh();
                    }
                }));
            }
        }

        void BuildListView()
        {
            listViewZip = new System.Windows.Forms.ListView();
            listViewZip.Size = flowLayoutPanel2.Size;
            ColumnHeaderCollection columnHeaderCollection = new ColumnHeaderCollection(listViewZip);
            ColumnHeader fulnm = new ColumnHeader();
            fulnm.Text = "FullName";
            fulnm.TextAlign = HorizontalAlignment.Left;
            fulnm.Width = 250;

            ColumnHeader ext = new ColumnHeader();
            ext.Text = "Ext";
            ext.TextAlign = HorizontalAlignment.Left;
            ext.Width = 50;

            ColumnHeader leng = new ColumnHeader();
            leng.Text = "Lenght";
            leng.TextAlign = HorizontalAlignment.Left;
            leng.Width = 110;

            ColumnHeader lastmod = new ColumnHeader();
            lastmod.Text = "Lenght";
            lastmod.TextAlign = HorizontalAlignment.Left;
            lastmod.Width = 113;

            listViewZip.Columns.Add(fulnm);
            listViewZip.Columns.Add(ext);
            listViewZip.Columns.Add(leng);
            listViewZip.Columns.Add(lastmod);
            listViewZip.View = System.Windows.Forms.View.Details;
            flowLayoutPanel2.Controls.Add(listViewZip);
            listViewZip.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            listViewZip.SizeChanged += new EventHandler(this.listViewZip_SizeChanged);
        }

        void InsertItem(string fileszip)
        {
            try
            {
                using (FileStream zipToOpen = new FileStream(fileszip, FileMode.Open, FileAccess.Read))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry cc in archive.Entries)
                        {
                            string ext = cc.FullName.Substring(cc.FullName.LastIndexOf('.') + 1, cc.FullName.Length - cc.FullName.LastIndexOf('.') - 1);
                            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(cc.FullName);
                            System.Windows.Forms.ListViewItem.ListViewSubItem[] subItem = { new System.Windows.Forms.ListViewItem.ListViewSubItem(item, ext),
                                                                   new System.Windows.Forms.ListViewItem.ListViewSubItem(item, cc.Length.ToString()),
                                                                   new System.Windows.Forms.ListViewItem.ListViewSubItem(item, cc.LastWriteTime.ToString())
                                                                  };
                            item.SubItems.AddRange(subItem);
                            listViewZip.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void listViewZip_SizeChanged(object sender, EventArgs e)
        {
            listViewZip.Size = flowLayoutPanel2.Size;
        }

        private void ListFiles_Paint(object sender, PaintEventArgs e)
        {
            this.TopMost = false;
        }

        private void tplistView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
                SelOrNotSel = false;
                //this.tplistView.ItemSelectionChanged -= new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.tplistView_ItemSelectionChanged);
            else if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                SelOrNotSel = true;
           // this.tplistView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.tplistView_ItemSelectionChanged);
        }
    }
}
