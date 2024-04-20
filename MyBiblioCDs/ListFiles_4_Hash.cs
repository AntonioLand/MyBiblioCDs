using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
 

namespace MyBiblioCDs
{
    public partial class ListFiles : Form, IDisposable
    {
        private void InitializebackgroundHash()
        {
            backgroundHash.DoWork += new DoWorkEventHandler(backgroundHashWork);
            backgroundHash.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundHashCompleted);
            backgroundHash.ProgressChanged += new ProgressChangedEventHandler(backgroundHash_ProgressChanged);
        }

        private void backgroundHashWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Hashcalculation(worker, e);
        }


        /// <summary>
        /// For each file it calculates the SHA-1 value. For each file where possible.
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        private void Hashcalculation(BackgroundWorker worker, DoWorkEventArgs e)
        {

            int numTot = 0;
            hiPercReached = 0;
            foreach (DirAndFiles dd in FILESINFO)
                numTot += dd.FilesInfos.Count;
            List<string> hashNoCalculate = new List<string>();
            LoadListHash(hashNoCalculate);
            int numprocessed = 0;
            for (int indxdir = 0; indxdir < FILESINFO.Count; indxdir++)
            {
                for (int indxfl = 0; indxfl < FILESINFO[indxdir].FilesInfos.Count; indxfl++)
                {
                    if (hashNoCalculate.Count >= 0 && hashNoCalculate.Contains(FILESINFO[indxdir].FilesInfos[indxfl].thisfile.Extension.ToLower()) || FILESINFO[indxdir].FilesInfos[indxfl].chck)
                    {
                        numprocessed++;
                        continue;
                    }
                    else
                    {
                        if (!FILESINFO[indxdir].FilesInfos[indxfl].chck)
                            FilesWorks.HashString(FILESINFO[indxdir].FilesInfos[indxfl], false);
                    }
                    numprocessed++;
                    int percentComplete = (int)((float)numprocessed / (float)numTot * 100);
                    if (percentComplete > hiPercReached)
                    {
                        hiPercReached = percentComplete;
                        worker.ReportProgress(percentComplete);
                        if (toolStripStatusLabel1.GetCurrentParent().InvokeRequired == true)
                            toolStripStatusLabel1.GetCurrentParent().Invoke((MethodInvoker)delegate
                            {
                                toolStripStatusLabel1.Text = percentComplete.ToString();
                            });

                        //worker.toolStripStatusLabel1.Text = percentComplete.ToString();
                    }
                }
            }
        }
        private void LoadListHash(List<string> hashNoCalculate)
        {
            object filename = RegisterFunction.ReadKey("NoHash");
            foreach (string line in System.IO.File.ReadLines(filename.ToString()))
            {
                hashNoCalculate.Add(line);
            }

        }
        private void backgroundHashCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // resultLabel.Text = "Canceled";
            }
            else
            {
                LogProj.Info("Hash is terminate");
                this.toolStripProgBar.Value = 0;
                btnsave.Enabled = btnNote.Enabled = toolStripDropDownButton1.Enabled = true;
                this.backgroundHash.Dispose();
            }
        }

        private void backgroundHash_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgBar.Value = e.ProgressPercentage;
        }
    }
}