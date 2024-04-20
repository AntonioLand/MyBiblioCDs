using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using Microsoft.Win32;
using System.Security;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Policy;
using System.Web;
using static System.Net.WebRequestMethods;
using Microsoft.Office.Core;
using MyBiblioCDs;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.ComTypes;
using System.Management;
using System.Diagnostics;
using System.Security.Principal;
using Microsoft.Extensions.Primitives;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Shapes;
//using System.Windows.Controls;

#pragma warning disable IDE1006, IDE0017, CS1591
namespace MyBiblioCDs
{
    public partial class MainForm : Form
    {
        // Data
        public DriveInfo[] allDrives;
        List<DirAndFiles> FILEINFO = new List<DirAndFiles>();
        List<CmbBxDRV> LscmbBxDRVs = new List<CmbBxDRV>();
        // Var
        AudioCD audioCDToSave;
        int CdType;
        ObjMainForm objMain;
        public string worklanguage;
        private UInt32 queryCancelAutoPlay = 0;
        Thread workerThread;
        public static string myConnectionString;

        public MainForm()
        {
            InitializeComponent();
            objMain = new ObjMainForm();
            CDContrl();
            DriveSearch(ref allDrives);
            InitializeBackgroundWorker();
            InitializebkgroundWkAudio();
            //InitializebackgroundWorkerDataBase();
            InitializeComboBoxDRV();
            //InitializeBackgroundInsert();
            lvwColumnSorter = new ListViewColumnSorter();
            listView.ListViewItemSorter = lvwColumnSorter;
            myConnectionString = (string)RegisterFunction.ReadKey("DataSource");

    }

    private void MainForm_Load(object sender, EventArgs e)
        {
            BSaveAll.Enabled = false;
            bSaveInfo.Enabled = false;
            BListFiles.Enabled = false;
            bStop.Enabled = false;
            RegisterFunction.OpenRegisterKey();
            numCDUpD.Value = Convert.ToInt32(RegisterFunction.ReadKey("CdNum")) + 1;
            worklanguage = (string)RegisterFunction.ReadKey("Language");
            this.flowLayoutPanel1.Visible = false;
            this.Size = new Size(555, 462);
            RegisterFunction.RegisterKeyClose();
            Translator(worklanguage);
            ShellContextMenu ctxMnu = new ShellContextMenu();
        } // End of MainForm_Load

        // START EVENT
        #region Event

        /// <summary>
        /// Check to see if a CD or other device was selected. Then start the thread to count files and directories. Then check if it is an audio cd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDriver_TextChanged(object sender, EventArgs e)
        {
            LogProj.Info("comboBoxDriver_TextChanged");
            this.comboBoxDriver.TextChanged -= new System.EventHandler(this.comboBoxDriver_TextChanged);
            if (comboBoxDriver.Text.Length > 3)
            {
                CdType = 9;
                cmBxTypeMediaCD.SelectedIndex = 9;
                cmBxTypeMediaCD.Refresh();
            }
            objMain.drive = comboBoxDriver.Text;
            objMain.cdnum = (int)numCDUpD.Value;
            if (cmBxTypeMediaCD.SelectedIndex == 11)
            {
                if (backgroundFileList.IsBusy)
                {
                    backgroundFileList.CancelAsync();
                    backgroundFileList.Dispose();
                    GC.Collect();
                }
                backgroundFileList.RunWorkerAsync();
                int w = CompilationCasus();
                this.comboBoxDriver.TextChanged -= new EventHandler(this.comboBoxDriver_TextChanged);
                this.comboBoxDriver.SelectedIndexChanged -= new EventHandler(this.comboBoxDriver_SelectedIndexChanged);
                if (w == 1)
                {
                    this.txtName.Text = audioCDToSave.Title;
                    dateTimePicker.Value = new DateTime(Convert.ToInt32(audioCDToSave.PublicationDate.Substring(0, 4)), Convert.ToInt32(audioCDToSave.PublicationDate.Substring(5, 2)), Convert.ToInt32(audioCDToSave.PublicationDate.Substring(8, 2)));
                    this.BSaveAll.Enabled = true;
                    return;
                }
                MessageBox.Show(Languages.QUQ);
            }
            if (flowLayoutPanel1.Visible == true)
            {
                toolStripTextBox1.Text = comboBoxDriver.Text;
                PopolateSoloLista(comboBoxDriver.Text);
            }
            if (!backgroundFileList.IsBusy)
            {
                labelInfo.Text = "Moment..";labelInfo.Refresh();
                backgroundFileList.RunWorkerAsync();
            }
            LogProj.Info("comboBoxDriver_TextChanged");
        } // End Of comboBoxDriver_TextChanged

        private void comboBoxDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Update();
            DriveInfo cds = null;
            this.comboBoxDriver.TextChanged -= new EventHandler(this.comboBoxDriver_TextChanged);
            this.comboBoxDriver.SelectedIndexChanged -= new EventHandler(this.comboBoxDriver_SelectedIndexChanged);
            if (string.IsNullOrEmpty(objMain.drive))
                return;
            try
            {
                cds = new DriveInfo(objMain.drive);
                txtName.Text = cds.VolumeLabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (cds.DriveType == DriveType.CDRom)
            {
                int res = Service.ToElaborateCD(comboBoxDriver.Text, allDrives);
                if (res == -1)
                {
                    backgroundFileList.CancelAsync();
                }
                else
                {
                    try
                    {
                        CdType = Service.WhatiS(allDrives[res]);
                        labelInfo.Text = "Reading...";
                        labelInfo.Refresh();
                        if (CdType == 1) // CD Audio
                        {
                            cmBxTypeMediaCD.SelectedIndex = 0;
                            cmBxTypeMediaCD.SelectedItem = 0;
                            cmBxTypeMediaCD.Update();
                            cmBxTypeMediaCD.Refresh();
                            this.Update();
                            checkBoxIndexWord.Enabled = false;
                            BListFiles.Enabled = false;
                            if (activeAduioSearch() != 1)
                                this.ToClear();
                        }
                        else if (CdType == 2) // CD ROM
                        {
                            bSaveInfo.Enabled = true;
                            cmBxTypeMediaCD.SelectedIndex = 1;
                            cmBxTypeMediaCD.Refresh();
                        }
                        else if (CdType == 3) // DVD
                        {
                            cmBxTypeMediaCD.SelectedIndex = 4;
                            cmBxTypeMediaCD.Refresh();
                        }
                        else if (CdType == 5)
                        {
                            cmBxTypeMediaCD.SelectedIndex = 6;
                            cmBxTypeMediaCD.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (cds.DriveType == DriveType.Removable)
            {
                cmBxTypeMediaCD.SelectedIndex = 8;
                cmBxTypeMediaCD.Refresh();
                CdType = 8;
            }
            this.comboBoxDriver.TextChanged += new EventHandler(this.comboBoxDriver_TextChanged);
            this.comboBoxDriver.SelectedIndexChanged += new EventHandler(this.comboBoxDriver_SelectedIndexChanged);
        } // End of comboBoxDriver_SelectedIndexChanged


        private void bBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (comboBoxDriver.Text.Length > 0)
                {
                    ToClear();
                    NumFile = NumDirectories = 0;
                }
                comboBoxDriver.Text = folderBrowserDialog.SelectedPath;
                DirectoryInfo choosed = new DirectoryInfo(comboBoxDriver.Text);
                dateTimePicker.Value = choosed.CreationTime;
            }
        }
        /// <summary>
        /// Stores the contents of the Pos. CD. The maximum number of characters 45
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PosCDTxt_Enter(object sender, EventArgs e)
        {
            NoteCD note = new NoteCD();
            note.MaxChar = 45;
            note.Text = "CD Location";
            note.labmaxChar.Text = "(Max 45 Char)";
            if (PosCDTxt.Text.Length > 0)
            {
                note.rTxtBx.Text = PosCDTxt.Text;
                // note.textBoxNote.Text = PosCDTxt.Text;
            }
            if (note.ShowDialog(this) == DialogResult.OK)
            {
                objMain.position = PosCDTxt.Text = note.rTxtBx.Text;
                textNote.Select(0, 0);
                note.Close();
                ActiveAndDeactive();
            }
        }

        private void BListFiles_Click(object sender, EventArgs e)
        {
            ListFiles lsfl = new ListFiles(ref FILEINFO, comboBoxDriver.Text, NumFile + NumDirectories, worklanguage);
            
            if (lsfl.ShowDialog(this) == DialogResult.OK)
            {
                lsfl.Dispose();
                this.BSaveAll.Enabled = true;
            }
        }

        private void textNote_Enter(object sender, EventArgs e)
        {
            NoteCD note = new NoteCD(0);
            note.MaxChar = 20000;
            if (textNote.Text.Length > 0)
            {
                note.rTxtBx.Text = textNote.Text;
                //note.textBoxNote.Text = textNote.Text;
            }

            note.Text = "CD Notes";
            note.labmaxChar.Text = "(Max 20000 Char)";
            if (note.ShowDialog() == DialogResult.OK)
            {
                objMain.cdnote = textNote.Text = note.rTxtBx.Text;
                textNote.Select(0, 0);
            }
        }
        private void textNote_TextChanged(object sender, EventArgs e)
        {
            if (textNote.Text.Length > 0)
            {
                textNote.Select(textNote.Text.Length, 0);
            }
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            ActiveAndDeactive();
        }
        private void textNote_Leave(object sender, EventArgs e)
        {
            ActiveAndDeactive();
        }

        private void showListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.flowLayoutPanel1.Visible)
            {
                this.Size = new Size(1071, 462);
                this.flowLayoutPanel1.Visible = true;
                toolStripTextBox1.Text = comboBoxDriver.Text;
                if (comboBoxDriver.Text != string.Empty)
                    PopolateSoloLista(comboBoxDriver.Text);
            }
            else
            {
                this.listView.Items.Clear();
                this.flowLayoutPanel1.Visible = false;
                this.Size = new Size(553, 462);
            }
            showListToolStripMenuItem.Checked = this.flowLayoutPanel1.Visible;
        }
        private void BSaveAll_Click(object sender, EventArgs e)
        {
            LogProj.Info("SaveAll");
            RegisterFunction.SetKey("CdNum", (int)numCDUpD.Value);
            //if (BackgroundInsert.IsBusy)
            //{
            //    MessageBox.Show("Cant start now, already running!");
            //    return;
            //}
            if (txtName.Text == string.Empty)
                if (CDNoName())
                    return;
            BSaveAll.Enabled = false;
            bSaveInfo.Enabled = false;
            BListFiles.Enabled = false;
            if (cmBxTypeMediaCD.SelectedIndex == 0 || cmBxTypeMediaCD.SelectedIndex == 11)
            {
                if (DbFunction.writeAllAudio(audioCDToSave, objMain, labelInfo) == -1)
                    MessageBox.Show(Languages.msgProblDBConnection);
                else
                    ToClear();
            }
            else if (cmBxTypeMediaCD.SelectedIndex == 1 || cmBxTypeMediaCD.SelectedIndex == 4 || cmBxTypeMediaCD.SelectedIndex == 6 || cmBxTypeMediaCD.SelectedIndex == 8 || cmBxTypeMediaCD.SelectedIndex == 9)
            {
                toInsert();
            }
            else if (cmBxTypeMediaCD.SelectedIndex == 5)
            { 
                DbFunction.insertfilm(objMain);
            }
            numCDUpD.Value += 1;
        } // End of BSaveAll_Click

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            objMain.cdname = txtName.Text;
            ActiveAndDeactive();
        }

        private void cmBxTypeMediaCD_TextChanged(object sender, EventArgs e)
        {
            objMain.cdtype = cmBxTypeMediaCD.SelectedIndex + 1;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                objMain.createdate = dateTimePicker.Value;
            } catch(Exception ex)
            {
                LogProj.exception(ex.Message);
            }
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            ToClear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // waiting for the sun
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToClear();
        }
        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator("de-DE");
            worklanguage = "de-DE";
            RegisterFunction.OpenRegisterKey();
            RegisterFunction.SetKey("Language", "de-DE");
            RegisterFunction.RegisterKeyClose();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dddd dd.MMMMM.yyyy";
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator("en-US");
            worklanguage = "en-US";
            RegisterFunction.OpenRegisterKey();
            RegisterFunction.SetKey("Language", "en-US");
            RegisterFunction.RegisterKeyClose();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = System.Windows.Forms.Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            dateTimePicker.CustomFormat = "MMMM MM dddd dd yyyy";
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator("es-ES");
            worklanguage = "es-ES";
            RegisterFunction.OpenRegisterKey();
            RegisterFunction.SetKey("Language", "es-ES");
            RegisterFunction.RegisterKeyClose();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            dateTimePicker.CustomFormat = System.Windows.Forms.Application.CurrentCulture.DateTimeFormat.LongDatePattern;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dddd dd MMMM yyyy";
        }

        private void italianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Translator("it-IT");
            worklanguage = "it-IT";
            RegisterFunction.OpenRegisterKey();
            RegisterFunction.SetKey("Language", "it-IT");
            RegisterFunction.RegisterKeyClose();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dddd dd MMMM MM yyyy";
        }
        private void previewsaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CdType == 1)
            {
                string summary = "Artist =     : " + audioCDToSave.Artist + "\n" +
                                 "Title =      : " + audioCDToSave.Title + "\n" +
                                 "Country =    : " + audioCDToSave.Country + "\n" +
                                 "Cover =      : " + audioCDToSave.CoverArtF + "\n" +
                                 "Genre =      : " + audioCDToSave.genreMusic + "\n" +
                                 "Year =       : " + audioCDToSave.PublicationDate + "\n" +
                                 "Barcode      : " + audioCDToSave.Barcode + "\n" +
                                 "num. Tracks  : " + audioCDToSave.numTracks + "\n" +
                                 "Release      : " + audioCDToSave.Release_ID + "\n";

                foreach (Track tr in audioCDToSave.tracks)
                {
                    summary += tr.TrNum + " " + tr.TitleTrack + " " + tr.Duration + "\n";
                }
                MessageBox.Show(summary);
            }
        } // End of previewsaveToolStripMenuItem_Click

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab =  new About();
            ab.ShowDialog();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Color the driver names red if they are open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBxOpDrv_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CDDRIVE one = new CDDRIVE();
            string dr = ((CmbBxDRV)((ComboBox)sender).SelectedItem).drv;
            bool onoff = ((CmbBxDRV)((ComboBox)sender).SelectedItem).opcl;
            if (!onoff)
                one.openDriver(dr);
            else
                one.close(dr);
            ((CmbBxDRV)((ComboBox)sender).SelectedItem).opcl = !((CmbBxDRV)((ComboBox)sender).SelectedItem).opcl;
        } 

        private void cmbBxOpDrv_OnDrawItem(object sender, EventArgs e)
        {
            DrawItemEventArgs ey = (DrawItemEventArgs)e;
            SolidBrush brush;
            var rect = ey.Bounds;
            var n = "";
            var f = new Font("Arial", 9, FontStyle.Regular);
            bool PP = ((CmbBxDRV)((ComboBox)sender).SelectedItem).opcl;
            if (ey.Index >= 0)
            {
                n = ((CmbBxDRV)((ComboBox)sender).SelectedItem).drv;
                Console.WriteLine(PP + " " + n.ToString());
                if (((CmbBxDRV)(cmbBxOpDrv.Items[ey.Index])).opcl)
                    brush = new SolidBrush(Color.Red);
                else
                    brush = new SolidBrush(SystemColors.Window);
                ey.Graphics.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
                ey.Graphics.DrawString(((CmbBxDRV)(cmbBxOpDrv.Items[ey.Index])).drv, f, Brushes.Black, rect.X, rect.Y);
                ey.DrawFocusRectangle();

            }
        } // End of cmbBxOpDrv_OnDrawItem

        #endregion


        /// <summary>
        /// search for drivers CDs USB hard disk
        /// </summary>
        private void CDContrl()
        {
            SelectQuery query =
            new SelectQuery("select * from win32_logicaldisk where drivetype=5");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in searcher.Get())
            {
                // If both properties are null I suppose there's no CD
                if ((mo["volumename"] != null) || (mo["volumeserialnumber"] != null))
                {
                    LogProj.Info("CD is named: " + mo["volumename"].ToString());
                    LogProj.Info("CD Serial Number: " + mo["volumeserialnumber"].ToString());
                }
                else
                {
                    LogProj.Info(string.Format("{0} + No CD in Unit {1}  2= {2}", mo.Path, mo.ClassPath, mo.Properties));
                }
            }
        }

        /// <summary>
        /// Check if it is an audio cd
        /// </summary>
        /// <returns></returns>
        private int CompilationCasus()
        {
            using (MyBiblioCDsAudio.Audio_CD FoundCD = new MyBiblioCDsAudio.Audio_CD())
            {
                FoundCD.CoverArtF = objMain.drive;
                FoundCD.numTracks = new DirectoryInfo(objMain.drive).GetFiles().Length;
                FoundCD.Artist = worklanguage;
                if (MyBiblioCDsAudio.MusicBrainz.findCDAudio(FoundCD, false) != 1)
                {
                    ToClear();
                    comboBoxDriver.SelectedIndex = -1;
                    comboBoxDriver.Text = "";

                    return 2;
                }
                else
                {
                    audioCDToSave = new AudioCD();
                    AudioCD.copyat(FoundCD, ref audioCDToSave);
                }
                return 1;
            }
        } // End of PopolateSoloLista

        private void ActiveAndDeactive()
        {
            if (textNote.Text.Length > 0 || this.txtName.Text.Length > 0 || PosCDTxt.Text.Length > 0)
            {
                bSaveInfo.Enabled = true;
                BSaveAll.Enabled = true;
            }
            else
            {
                bSaveInfo.Enabled = false;
                BSaveAll.Enabled = false;
            }
        }
        private bool CDNoName()
        {
            if (MessageBox.Show(Languages.msgInsertCdName, Languages.namCapCdMiss, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                return true;
            return false;
        }
        private List<string> LoadKeyWords()
        {
            List<string> keys = new List<string>();
            RegisterFunction.OpenRegisterKey();
            string file = (string)RegisterFunction.ReadKey("DirFileMyBiblioCDs");
            file = file + @"KeyWords.txt";
            keys = System.IO.File.ReadAllLines(file).ToList<string>();
            return keys;
        }   // End of LoadKeyWords
            // public async Task toInsert()
            // public async Task toInsert()

        public async Task toInsert()
        {
            LogProj.Info("In toInsert");

            int PkCdNew = CdInfo();
            NumFile = 0;
            NumFile = newNumFiles();
            string Notice = "Num. Files: " + NumFile + "==>" + NumFile;
            SET_PROGRESSBAR(NumFile);

            if (checkBoxIndexWord.Checked == true)
            {
                bStop.Visible = true;
                bStop.Enabled = true;
                bStop.Click += new System.EventHandler(this.bStop_Click);
                workerThread = new Thread(new ParameterizedThreadStart(ExtractAndInsert));
                workerThread.Name = "Extract";
                workerThread.Start(PkCdNew);
            }
            else
            {
                InsertFiles(PkCdNew);
            }
        }
        public void InsertFiles(int PkCdNew)
        {
            StringBuilder insertinto = new StringBuilder();
            StringBuilder notecmdInsert = new StringBuilder();
            string initcmd = "INSERT INTO files (FullNameFile, FileName, CreationData, LastModified, Ext, Size, Hashcode, CdNew_idCdNew, Note) VALUES ";
            insertinto.Append(initcmd); //"INSERT INTO files (FullNameFile, FileName, CreationData, LastModified, Ext, Size, Hashcode, CdNew_idCdNew, Note) VALUES ");
            int count = 0;
            foreach (DirAndFiles dir in FILEINFO)
            {
                foreach (InfoFiles f in dir.FilesInfos)
                {
                    count++;
                    if (f.nota == null)
                    {
                        DbFunction.CommonFileInfoCollect(f, PkCdNew, insertinto, notecmdInsert);
                    }
                    else
                    {
                        if (count > 0)
                        {
                            _LABELINFO("Update DB");
                            InsertBlock(insertinto);
                            insertinto.Append(initcmd);
                            count = 0;
                        }
                        DbFunction.CommonFileInfo(f, PkCdNew);
                        continue;
                    }
                    if (count >= 100)
                    {
                        _LABELINFO("Update DB");
                        InsertBlock(insertinto);
                        insertinto.Append(initcmd);
                        count = 0;
                    }
                }
            }
            if (count > 0)
            {
                _LABELINFO("Update DB");
                InsertBlock(insertinto);
            }
        }

        private void InsertBlock(StringBuilder insertinto)
        {
            if (insertinto[insertinto.Length - 1] == ',')
                insertinto.Remove(insertinto.Length - 1, 1);
            int PkFile2 = DbFunction.InsertInto(insertinto.ToString(), "files", false);
            insertinto.Clear();
        }
        private int newNumFiles()
        {
            int numfiles = 0;
            foreach (DirAndFiles dir in FILEINFO)
                numfiles += dir.FilesInfos.Count;
            if (FILEINFO.Count > 0)
                numfiles += FILEINFO.Count;
            return numfiles;
        }
        string[] OpenExtFile(string filename)
        {
            List<string> ext = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ext.Add(line);
                    }
                }
            } catch (Exception e)
            {
                LogProj.exception(e.Message);
            }
            return ext.ToArray();
        }

    public void ExtractAndInsert(object PrimKeyCD)
    {
            LogProj.Info("ExtractAndInsert");

            int PkCdNew = (int)PrimKeyCD;
            object path = RegisterFunction.ReadKey("DirFileMyBiblioCDs");
            string[] EXTtxt= OpenExtFile(path.ToString() + "extTextfiles.txt");
            string[] EXTpro  = OpenExtFile(path.ToString() + "extProgramfiles.txt");
            List<string> KEYWORDS = LoadKeyWords();
            List<ExtractorWords> wls = new List<ExtractorWords>();
            List<ExtractorWords> BigList = new List<ExtractorWords>();
            int NumWords = 0;
            int NumWordsPro = 0;
            NumFile = newNumFiles();
            LogProj.Info("Start Loop Extrack and Save");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            int n = 0;
            if (!DbFunction.connect())
                return;
            foreach (DirAndFiles dir in FILEINFO)
            {
                foreach (InfoFiles f in dir.FilesInfos)
                {
                    n++;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    LogProj.Info("\n\n------------------------------------------------------------\n" + f.thisfile.FullName + "\n------------------------------------------------------------\n");
                    _LABELINFO(f.thisfile.FullName + "\n" + n.ToString() + "#" + NumFile.ToString());
                    int PkFile = DbFunction.CommonFileInfo(f, PkCdNew);
                    string ext = f.thisfile.Extension.ToLower();
                    if (EXTtxt.Contains(ext) && checkBoxIndexWord.Checked == true)
                    {
                        casusText(ref BigList, ext, f.thisfile.FullName, PkFile);
                        if (BigList.Count > 10000)
                        {
                            if (!Insert1000Word(BigList, ref NumWords, ref PkFile))
                            {
                                MessageBox.Show(Languages.ProblemDB);
                            }
                            BigList.Clear();
                        }
                        LogProj.Info("NumWords = " + NumWords.ToString());
                        if (NumWords >= 10000)
                        {
                            DeactivateStp();
                            _LABELINFO("Update DB");
                            DbFunction.UpdateDB();
                            NumWords = 0;
                            DeactivateStp();
                        }
                    }
                    else if (EXTpro.Contains(ext) && checkBoxIndexWord.Checked == true)
                    {
                        casusProgFile(ref NumWordsPro, f.thisfile.FullName, PkFile, wls, KEYWORDS);
                        if(NumWordsPro >= 5000)
                        {
                            DeactivateStp();
                            _LABELINFO("Update DB");
                            DbFunction.UpdateDB_ProgWord();
                            NumWordsPro = 0;
                            DeactivateStp();
                        }
                    }
                    PROGRESSBAR_FORWARD();
                    stopwatch.Stop();
                    LogProj.Info("\n\n" + f.thisfile.FullName + " ======== " + stopwatch.Elapsed + "\n\n");
                }
            }
            if (BigList.Count > 0)
                DbFunction.InsertWord(BigList);
            _LABELINFO("Update DB");
            if (checkBoxIndexWord.Checked == true)
            {
                DeactivateStp();
                DbFunction.UpdateDB();
                DbFunction.UpdateDB_ProgWord();
                DeactivateStp();
            }
            stopwatch1.Stop();
            TimeSpan ts = stopwatch1.Elapsed;
            LogProj.Info("\n\rEnd Loop ======== " + stopwatch1.Elapsed + "\n");
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            LogProj.Info("\n\r ======== " + elapsedTime + "\n\n");
            //ToClear();
            MessageBox.Show(new Form {TopMost = true }, "COMPLETED");
            ToClear();
        } // End of toInsert

        void DeactivateStp()
        {
            if(bStop.InvokeRequired)
            {
                bStop.Invoke(new Action(() => { bStop.Enabled = !bStop.Enabled; }));
            }
            else
                bStop.Enabled = !bStop.Enabled;
        } // DeactivateStp Piano

        private bool Insert1000Word(List<ExtractorWords> WordList, ref int NumWords, ref int PkFile)
        {
            int it = (int)(WordList.Count / 10000);
            List<ExtractorWords> moment = new List<ExtractorWords>();
            for (int j = 1; j <= it; j++)
            {
                moment.AddRange(WordList.Take(10000));
                if (!DbFunction.InsertWord(moment))
                    return false;
                NumWords += moment.Count;
                moment.Clear();
                WordList.RemoveRange(0, 10000);
            }
            if (WordList.Count > 0)
            {
                if (!DbFunction.InsertWord(WordList))
                        return false;
                NumWords += WordList.Count;
                WordList.Clear();
            }
            return true;
        } // End Insert1000Word

        private void _LABELINFO(string tx)
        {
            try
            {
                if (labelInfo.InvokeRequired == true)
                    labelInfo.Invoke((MethodInvoker)delegate
                    {
                        labelInfo.Text = tx;
                    });
                else
                {
                    this.labelInfo.Text = tx;
                    this.labelInfo.Refresh();
                }

            }
            catch (Exception ex)
            {
                LogProj.exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
        } // End of _LABELINFO
        private void SET_PROGRESSBAR(int NumFile)
        {
            progressBar1.Maximum = NumFile;
            progressBar1.Value = 0;
            //if (progressBar1.InvokeRequired == true)
            //    progressBar1.Invoke((MethodInvoker)delegate {
            //        progressBar1.Maximum = NumFile;
            //        progressBar1.Value = 0;
            //    });
        } // End of SET_PROGRESSBAR

        private void PROGRESSBAR_FORWARD()
        {
            if (progressBar1.InvokeRequired == true)
                progressBar1.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value += 1;
                });
        } // End of PROGRESSBAR_FORWARD

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);

        protected override void WndProc(ref Message m)
        {
            // calling the base first is important, otherwise the values you set later will be lost
            // if the QueryCancelAutoPlay message id has not been registered...
            if (queryCancelAutoPlay == 0)
                queryCancelAutoPlay = RegisterWindowMessage(Convert.ToString("QueryCancelAutoPlay"));

            //if the window message id equals the QueryCancelAutoPlay message id
            if ((UInt32)m.Msg == queryCancelAutoPlay)
            {
                m.Result = (IntPtr)1;
            }
            else
                base.WndProc(ref m);
        } //WndProc

        private void comboBoxDriver_Enter(object sender, EventArgs e)
        {
            if (comboBoxDriver.Text.Length > 0)
                ToClear();
        }
        private void saveCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                RegisterFunction.OpenRegisterKey();
                string path = dialog.SelectedPath;
                RegisterFunction.SetKey("MyBiblioCDCoverArt", path);    //.ReadKey("Language");
            }
        } // End of  saveCoverToolStripMenuItem_Click

        private void bStop_Click(object sender, EventArgs e)
        {
            try
            {
                workerThread.Abort();
                ToClear();
                bStop.Click -= new System.EventHandler(this.bStop_Click);
            }
            catch(ThreadAbortException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

