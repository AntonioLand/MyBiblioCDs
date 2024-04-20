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

namespace MyBiblioCDs
{
    public partial class MainForm : Form //, IDisposable
    {
        //private System.ComponentModel.BackgroundWorker BackgroundInsert = new BackgroundWorker();
        private void InitializeBackgroundInsert()
        {
            BackgroundInsert.DoWork += new DoWorkEventHandler(backgroundInsert_Work);
            BackgroundInsert.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundInsert_Completed);
            BackgroundInsert.ProgressChanged += new ProgressChangedEventHandler(BackgroundInsert_ProgressChanged);
            BackgroundInsert.WorkerSupportsCancellation = true;
            BackgroundInsert.WorkerReportsProgress = true;

        }

        private void BackgroundInsert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Debug.WriteLine(this.progressBar1.Value);
            this.progressBar1.Value = e.ProgressPercentage;
            //try
            //{
            //    if (labelInfo.InvokeRequired == true)
            //        labelInfo.Invoke((MethodInvoker)delegate
            //        {
            //            labelInfo.Text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            //            //labelInfo.Refresh();
            //            //labelInfo.Update();
            //        });
            //    else
            //    {
            //        this.labelInfo.Text = "BBBBBBBBBBBBBBBBBBB";
            //        this.labelInfo.Refresh();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    LogProj.exception(ex.Message);
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void BackgroundInsert_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("COMPLETED");
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                MessageBox.Show("CANCELED");
            }

        }

        private void backgroundInsert_Work(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //ExtractAndInsert((int)e.Argument, worker, e);

        }
    }
}
