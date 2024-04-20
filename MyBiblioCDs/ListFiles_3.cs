
using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace MyBiblioCDs
{
    public partial class ListFiles : Form, IDisposable
    {
        //void BuildListView()
        //{
        //    listViewZip = new ListView();
        //    listViewZip.Size = flowLayoutPanel2.Size;
        //    ColumnHeaderCollection columnHeaderCollection = new ColumnHeaderCollection(listViewZip);
        //    ColumnHeader fulnm = new ColumnHeader();
        //    fulnm.Text = "FullName";
        //    fulnm.TextAlign = HorizontalAlignment.Left;
        //    fulnm.Width = 250;

        //    ColumnHeader ext = new ColumnHeader();
        //    ext.Text = "Ext";
        //    ext.TextAlign = HorizontalAlignment.Left;
        //    ext.Width = 50;

        //    ColumnHeader leng = new ColumnHeader();
        //    leng.Text = "Lenght";
        //    leng.TextAlign = HorizontalAlignment.Left;
        //    leng.Width = 110;

        //    ColumnHeader lastmod = new ColumnHeader();
        //    lastmod.Text = "Lenght";
        //    lastmod.TextAlign = HorizontalAlignment.Left;
        //    lastmod.Width = 113;

        //    listViewZip.Columns.Add(fulnm);
        //    listViewZip.Columns.Add(ext);
        //    listViewZip.Columns.Add(leng);
        //    listViewZip.Columns.Add(lastmod);
        //    listViewZip.View = View.Details;
        //    flowLayoutPanel2.Controls.Add(listViewZip);
        //    listViewZip.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        //    listViewZip.SizeChanged += new EventHandler(this.listViewZip_SizeChanged);

        //}

        //void InsertItem(string fileszip)
        //{
        //    try
        //    {
        //        using (FileStream zipToOpen = new FileStream(fileszip, FileMode.Open, FileAccess.Read))
        //        {
        //            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
        //            {
        //                foreach (ZipArchiveEntry cc in archive.Entries)
        //                {
        //                    string ext = cc.FullName.Substring(cc.FullName.LastIndexOf('.') + 1, cc.FullName.Length - cc.FullName.LastIndexOf('.') - 1);
        //                    ListViewItem item = new ListViewItem(cc.FullName);
        //                    ListViewItem.ListViewSubItem[] subItem = { new ListViewItem.ListViewSubItem(item, ext),
        //                                                           new ListViewItem.ListViewSubItem(item, cc.Length.ToString()),
        //                                                           new ListViewItem.ListViewSubItem(item, cc.LastWriteTime.ToString())
        //                                                          };
        //                    item.SubItems.AddRange(subItem);
        //                    listViewZip.Items.Add(item);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}
    
        //void listViewZip_SizeChanged(object sender, EventArgs e)
        //{
        //    listViewZip.Size = flowLayoutPanel2.Size;
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