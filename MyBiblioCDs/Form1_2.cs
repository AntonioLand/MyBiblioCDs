using MyBiblioCDsAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#pragma warning disable IDE1006, IDE0017, CS1591
namespace MyBiblioCDs
{
    public partial class MainForm : Form //, IDisposable
    {
        static int NumFile = 0;
        static int NumDirectories = 0;
        private void InitializeBackgroundWorker()
        {
            backgroundFileList.DoWork += new DoWorkEventHandler(backgroundFileList_DoWork);
            backgroundFileList.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundFileList_RunWorkerCompleted);
            backgroundFileList.ProgressChanged += new ProgressChangedEventHandler(backgroundFileList_ProgressChanged);
            backgroundFileList.WorkerSupportsCancellation = true;
        } // end of InitializeBackgroundWorker

        /// <summary>
        /// Starts the thread for counting files and directories.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundFileList_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (FILEINFO.Count > 0)
            {
                FILEINFO.Clear();
                NumFile = NumDirectories = 0;
            }
            if (objMain.drive == string.Empty)
            {
                e.Cancel = true;
            }
            else
            {
                CountFilDir(objMain.drive, worker, e);
                if (labelInfo.InvokeRequired == true)
                    labelInfo.Invoke((MethodInvoker)delegate
                    {
                        labelInfo.Text = "driver:" + objMain.drive + "\n" + "Number File: " + NumFile + '\n' + "Number Direcories: " + NumDirectories;
                        labelInfo.Refresh();
                    });
            }
            if (backgroundFileList.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private void backgroundFileList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                NumFile= NumDirectories = 0;
                LogProj.Info("Threads terminate");
                labelInfo.Text = "driver:" + objMain.drive + "\n" + "Not Ready?" + '\n' + "Not Readable?\n" + "Defects?\n" + "BOH!!!";
            }
            else
            {
                Debug.WriteLine("end");
                backgroundFileList.Dispose();
                BListFiles.Enabled= true;
            }
        } // End of backgroundFileList_RunWorkerCompleted

        private void backgroundFileList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.labelInfo.Text = "driver:" + objMain.cdname + "\n" + "Number File: " + NumFile + '\n' + "Number Direcories: " + NumDirectories;
        } // End of backgroundFileList_ProgressChanged

        public void CountFilDir(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string[] SubDir = null;
            if (worker.CancellationPending)
                e.Cancel = true;
            try
            {
                try
                {
                    SubDir = Directory.GetDirectories(path);

                }
                catch (IOException ex)
                {
                    LogProj.Info(string.Format("{0}: The write operation could not " + "be performed because the specified " + "part of the file is locked.", ex.GetType().Name));
                    MessageBox.Show(string.Format("{0}: The write operation could not " + "be performed because the specified " + "part of the file is locked.", ex.GetType().Name));
                    worker.CancelAsync();
                    return;
                }
                string[] ElencoFile = Directory.GetFiles(path);
                DirAndFiles newelem = new DirAndFiles();
                newelem.directoryInfos = path;
                foreach (string fs in ElencoFile)
                {
                    FileInfo fi = new FileInfo(fs);
                    InfoFiles infoFiles = new InfoFiles(new FileInfo(fs));
                    newelem.FilesInfos.Add(infoFiles);
                }
                NumFile += ElencoFile.Length;
                NumDirectories += SubDir.Length;
                FILEINFO.Add(newelem);
                foreach (string s in SubDir)
                {
                    CountFilDir(s, worker, e);
                    if (worker.CancellationPending)
                        e.Cancel = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                e.Cancel = true;
            }
        } // end of CountFilDir

        private void bSaveInfo_Click(object sender, EventArgs e)
        {
            DbFunction.SaveOnlyInfo(objMain);
            RegisterFunction.OpenRegisterKey();
            RegisterFunction.SetKey("CdNum", numCDUpD.Value);
            RegisterFunction.RegisterKeyClose();
            ToClear();
            numCDUpD.Value += 1;
        }

        private void InitializebkgroundWkAudio()
        {
            bkgroundWkAudio.DoWork += new DoWorkEventHandler(bkgroundWkAudio_DoWork);
            bkgroundWkAudio.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkgroundWkAudio_RunWorkerCompleted);
        }
        private void bkgroundWkAudio_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
        }

        private void bkgroundWkAudio_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                ToClear(); 
            }
            if ((int)e.Result == -1)
                ToClear();
            Console.WriteLine("bkgroundWkAudio End");
        }
        /// <summary>
        /// search information for audio CD in Music Brainz
        /// </summary>
        /// <returns></returns>
        private int activeAduioSearch()
        {
            using (MyBiblioCDsAudio.Audio_CD FoundCD = new MyBiblioCDsAudio.Audio_CD())
            {
                FoundCD.CoverArtF = objMain.drive;
                FoundCD.numTracks = new DirectoryInfo(objMain.drive).GetFiles().Length;
                FoundCD.Artist = worklanguage;
                int response=0;
                try
                {
                    response = MyBiblioCDsAudio.MusicBrainz.findCDAudio(FoundCD, true);
                }catch (Exception exc)
                {
                    Debug.WriteLine(exc.ToString());
                }
                if (response != 1)
                {
                    return 2;
                }
                else
                {
                    audioCDToSave = new AudioCD();
                    AudioCD.copyat(FoundCD, ref audioCDToSave);
                }
                if (FoundCD.Title != null && FoundCD.Title.Length > 0)
                    txtName.Text = FoundCD.Title;
                else
                    txtName.Text = Languages.msgTitlenotFound;
                if (FoundCD.PublicationDate != string.Empty)
                 {
                    string Month = string.Empty;
                    string Day = string.Empty;
                    string Year = string.Empty;
                    if (FoundCD.PublicationDate.Length > 7)
                    {
                        Year = FoundCD.PublicationDate.Substring(0, 4);
                        Month = FoundCD.PublicationDate.Substring(5, 2);
                        Day = FoundCD.PublicationDate.Substring(8, 2);
                    } else if (FoundCD.PublicationDate.Length > 4 && FoundCD.PublicationDate.Length <= 7)
                    {
                        Year = FoundCD.PublicationDate.Substring(0, 4);
                        Month = FoundCD.PublicationDate.Substring(5, 2);
                        Day = "1";
                    } else if (FoundCD.PublicationDate.Length == 4)
                    {
                        Year = FoundCD.PublicationDate.Substring(0, 4);
                        Month = "01";
                        Day = "01";
                    }
                    try
                    {
                        dateTimePicker.Value = new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if(FoundCD.CoverArtF != string.Empty)
                    {
                         objMain.CoverPath = FoundCD.CoverArtF;
                    }
                 }
                FoundCD.PublicationDate = dateTimePicker.Value.ToShortDateString();
            }
            return 1;
        } // End of activeAduioSearch

        /// <summary>
        /// Search all drive
        /// </summary>
        /// <param name="allDrives"></param>
        public void DriveSearch(ref DriveInfo[] allDrives)
        {
            allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                DriveType varra = d.DriveType;
                if (d.DriveType.ToString() == "Fixed")
                    continue;
                if (d.DriveType.ToString() == "CDRom")
                    LscmbBxDRVs.Add(new CmbBxDRV(d.Name, false));
                comboBoxDriver.Items.Add(d.Name);
            }
        } /* End of public  void driveSearch */

/*        private void InitializebackgroundWorkerDataBase()
        {
            backgroundWorkerDataBase.DoWork += new DoWorkEventHandler(backgroundWorkerDataBaseInsert_DoWork);// backgroundFileList_DoWork);
            backgroundWorkerDataBase.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerDataBase_RunWorkerCompleted);
            backgroundWorkerDataBase.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerDataBase_ProgressChanged);
        } // end of InitializeBackgroundWorker
/ *
        private void backgroundWorkerDataBaseInsert_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> genericList = e.Argument as List<object>;
            bool which = (bool)genericList[0];
            int PkFile = (int)genericList[1];
            List<string> WordList = genericList[2] as List<string>;
            int I = 0;
            foreach (string s in WordList)
            {
                Console.WriteLine(I++ + "\t" + s);
            }
            BackgroundWorker worker = sender as BackgroundWorker;
            if ((bool)e.Argument == false)
            {
                ToInsertDBWork(worker, e);
            } else
            {
                ToInsertProgramWords(worker, e);
            }
        }
        private void backgroundWorkerDataBase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            if ((int)e.Result == -1)
                ToClear();
        }
        private void backgroundWorkerDataBase_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.labelInfo.Text = "driver:" + objMain.cdname + "\n" + "Number File: " + NumFile + '\n' + "Number Direcories: " + NumDirectories;
        } // End of backgroundFileList_ProgressChanged
        */
        private void InitializeComboBoxDRV()
        {
            this.cmbBxOpDrv.OnSelectedIndexChanged -= new System.EventHandler(this.cmbBxOpDrv_OnSelectedIndexChanged);
            cmbBxOpDrv.DisplayMember = "drv";
            cmbBxOpDrv.ValueMember = "opcl";
            cmbBxOpDrv.DataSource = LscmbBxDRVs;
            this.cmbBxOpDrv.OnSelectedIndexChanged += new System.EventHandler(this.cmbBxOpDrv_OnSelectedIndexChanged);
        }

        private void Translator(string lang)
        {
            Languages.Dictionary(lang);
            bSaveInfo.Text  = Languages.old_btnsaveInfo;
            bSaveInfo.Update();
            BListFiles.Text = Languages.btnListFiles;
            BListFiles.Update();
            BSaveAll.Text   = Languages.btnSaveAll;
            BSaveAll.Update();
            bStop.Text      = Languages.btnStop;
            bStop.Update();
            bCancel.Text    = Languages.btnCancel;
            bCancel.Update();

            // Label
            label1.Text         = Languages.lbSelectDrive; 
            label1.Location     = new Point(5, label1.Location.Y);
            label1.Update();
            label2.Text         = Languages.lbCdName;
            label2.Update();
            label3.Text         = Languages.lbCdNummer;
            label3.Update();
            label4.Text         = Languages.lbCdNote;
            label4.Update();
            label5.Text         = Languages.lbPosCD;
            label5.Update();
            label7.Text         = Languages.lbCreationDate;
            label7.Update();
            label6.Text         = Languages.lbMediaType;
            label6.Update();

            // CheckBox
            checkBoxIndexWord.Text = Languages.chkWordIndex;

            //Menu
            fileToolStripMenuItem.Text          = Languages.menuFile;
            newToolStripMenuItem.Text           = Languages.menuitNew;
            saveallToolStripMenuItem.Text       = Languages.menuitSaveAll;
            saveinfoToolStripMenuItem.Text      = Languages.menuitSaveInfo;
            previewsaveToolStripMenuItem.Text   = Languages.menuitSavePreview;
            exitToolStripMenuItem.Text          = Languages.menuitExit;
            aboutToolStripMenuItem.Text         = Languages.menuitAbout;
            editToolStripMenuItem.Text          = Languages.menuEdit;
            cancelToolStripMenuItem.Text        = Languages.menuitCancel;
            
            toolToolStripMenuItem.Text      = Languages.menuTools;
            showListToolStripMenuItem.Text  = Languages.menuitShowExplorer;
            toolStripMenuItem1.Text         = Languages.menuitLanguage;
            optionsToolStripMenuItem.Text   = Languages.menuitOptions;

            // Tooltip
            SaveOnllyNote.SetToolTip(bSaveInfo, Languages.toolpSavesInfo);
            SaveOnllyNote.SetToolTip(BListFiles, Languages.toolpListandAnalyzeFiles);
            this.Update();
        }
    }
}