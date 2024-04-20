
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
 
namespace MyBiblioCDs
{
    public partial class ListFiles : Form, IDisposable
    {
        //private int hiPercReached = 0;

        //private void InitializeBckgrWkLoadLsFiles()
        //{
        //    bckgrWkLoadLsFiles.DoWork += new DoWorkEventHandler(bckgrWkLoadLsFiles_DoWork);
        //    bckgrWkLoadLsFiles.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckgrWkLoadLsFiles_RunWorkerCompleted);
        //    bckgrWkLoadLsFiles.ProgressChanged += new ProgressChangedEventHandler(bckgrWkLoadLsFiles_ProgressChanged);
        //    tplistView.BeginUpdate();
        //}
        //private void bckgrWkLoadLsFiles_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;
        //    e.Result = LoadListView(worker, e);
        //}

        //private void bckgrWkLoadLsFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        MessageBox.Show(e.Error.Message);
        //    }
        //    else if (e.Cancelled)
        //    {
        //        toolStripStatusLabel1.Text = "Canceled";
        //    }
        //    else
        //    {
        //        Tuple<int, int> response = (Tuple<int, int>)e.Result;
        //        toolStripStatusLabel1.Text = "Num. Files: " + response.Item1.ToString() + " Num. Dir." + response.Item2;
        //    }
        //    this.toolStripProgBar.Value = 0;
        //    this.tplistView.EndUpdate();
        //    this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        //    HashButton.Enabled = true;
        //    btnsave.Enabled = true; 
        //    btnNote.Enabled = true; 
        //    toolStripDropDownButton1.Enabled = true;
        //}

        //private void bckgrWkLoadLsFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    try
        //    {
        //        this.toolStripProgBar.Value = e.ProgressPercentage;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private Tuple<int, int> LoadListView(BackgroundWorker worker, DoWorkEventArgs e, int totalItem = 0, int indx = 0)
        //{
        //    if (worker.CancellationPending)
        //    {
        //        e.Cancel = true;
        //        return new Tuple<int, int>(-1, -1);
        //    }
        //    int numfiles =0;
        //    int numdir = 0;
        //    OnOffUpdate(true);
        //    List<ListViewItem> blockAdd = new List<ListViewItem>();
        //    for (int i = indx; i < FILESINFO.Count; i++)
        //    {
        //        numdir++;
        //        string[] item = { FILESINFO[i].directoryInfos, "", "", "", "", "-1" };
        //        ListViewItem Item = new ListViewItem(item, 1);
        //        Item.ToolTipText = "If checked it is not processed";
        //        Item.Tag = new Tuple<int, int>(i, -1);
        //        if (FILESINFO[i].FilesInfos.Count > 0)
        //        {
        //            blockAdd.Add(Item);
        //        }
        //        else
        //            continue;
        //        try
        //        {
        //            int j = 0; 
        //            foreach (InfoFiles fi in FILESINFO[i].FilesInfos)
        //            {
        //                string[] items = {fi.thisfile.Name, fi.thisfile.Length.ToString(), fi.thisfile.CreationTime.ToString(),
        //                                  fi.thisfile.LastWriteTime.ToString(), fi.thisfile.Extension, ""};
        //                this.imageList1.Images.Add(GetFileIcon(fi.thisfile.Name, false));
        //                int img = this.imageList1.Images.Count - 1;
        //                ListViewItem itemf = new ListViewItem(items, img);
        //                itemf.ToolTipText = "If checked it is not processed";
        //                itemf.Tag = new Tuple<int, int>(i, j);
        //                blockAdd.Add(itemf);
        //                j++;

        //                numfiles++;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            Application.ExitThread();
        //        }
        //        int percentComplete = (int)((float)numfiles / (float)numTot * 100);
        //        if (percentComplete > hiPercReached && percentComplete < 100)
        //        {
        //            hiPercReached = percentComplete;
        //            worker.ReportProgress(percentComplete);
        //        }
        //    }
        //    OnOffUpdate(false);
        //    lsadd(blockAdd);
        //    return new Tuple<int, int>(numfiles, numdir);
        //}

        //void lsadd(List<ListViewItem> itms)
        //{
        //    if (tplistView.InvokeRequired)
        //    {
        //        tplistView.Invoke(new MethodInvoker(delegate
        //        {
        //            tplistView.Items.AddRange(itms.ToArray());
        //        }));
        //    } else
        //    {
        //        tplistView.Items.AddRange(itms.ToArray());
        //    }
        //}

        //void lsadd(ListViewItem itms)
        //{
        //    if (tplistView.InvokeRequired)
        //    {
        //        tplistView.Invoke(new MethodInvoker(delegate
        //        {
        //            tplistView.Items.Add(itms);
        //        }));
        //    }
        //    else
        //    {
        //        tplistView.Items.Add(itms);
        //    }
        //}


        //void OnOffUpdate(bool onoff)
        //{
        //    if (tplistView.InvokeRequired)
        //    {
        //        tplistView.Invoke(new MethodInvoker(delegate
        //        {
        //            if (onoff)
        //            {
        //                tplistView.BeginUpdate();
        //                tplistView.Refresh();
        //            }
        //            else
        //            {
        //                tplistView.EndUpdate();
        //                tplistView.Refresh();
        //            }
        //        }));
        //    }
        //}

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListFiles));
        //    this.SuspendLayout();
        //    // 
        //    // ListFiles
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        //    this.Name = "ListFiles";
        //    //this.ShowIcon = false;
        //    this.ResumeLayout(false);
        //}
    }
}