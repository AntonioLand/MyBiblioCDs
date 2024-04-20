using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
#pragma warning disable IDE1006, IDE0017,CS1591

namespace MyBiblioCDs
{
    public partial class MainForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        /// <summary>
        /// Populates the explorer list of the main window
        /// </summary>
        /// <param name="path"></param>
        void PopolateSoloLista(string path)
        {
            ListViewItem item;
            DirectoryInfo info = new DirectoryInfo(path);
            DriveInfo driveInfo = new DriveInfo(path);
            listView.Items.Clear();

            switch (driveInfo.DriveType)
            {
                    case DriveType.CDRom:
                        item = new ListViewItem(info.Name, 2);
                        item.Tag = info.FullName;
                        listView.Items.Add(item);
                        break;
                    case DriveType.Removable:
                    case DriveType.Fixed:
                    item = new ListViewItem(info.Name, 0);
                        item.Tag = info.FullName;
                        listView.Items.Add(item);
                        break;
            }
        } // End of PopolateSoloLista

        private void GetDirectories2(ListViewItem pitem, string path)
        {
            if (pitem != null)
                path = pitem.Tag.ToString();

            DirectoryInfo relRoot = new DirectoryInfo(path);
            DirectoryInfo[] subSubDirs = relRoot.GetDirectories();
            Array.Sort(subSubDirs, new DirCompare());
            listView.Items.Remove(pitem);
            listView.Items.Clear();
            foreach (DirectoryInfo subDir in subSubDirs)
            {
                try
                {
                    ListViewItem item = new ListViewItem(subDir.Name, 1);
                    item.Tag = subDir.FullName;
                    ListViewItem.ListViewSubItem[] subItem = { new ListViewItem.ListViewSubItem(item, ""),
                                                               new ListViewItem.ListViewSubItem(item, subDir.LastWriteTime.ToString()) };
                    item.SubItems.AddRange(subItem);
                    listView.Items.Add(item);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }
            FileInfo[] files = relRoot.GetFiles();
            Array.Sort(files, new FileCompare());
            foreach(FileInfo file in relRoot.GetFiles())
            {
                this.imageList1.Images.Add(GetFileIcon(file.FullName, false));
                int img = this.imageList1.Images.Count - 1;
                ListViewItem item = new ListViewItem(file.Name, img);
                item.Tag = file.FullName;
                ListViewItem.ListViewSubItem[] subItem = { new ListViewItem.ListViewSubItem(item, file.Length.ToString()),
                                                           new ListViewItem.ListViewSubItem(item, file.LastWriteTime.ToString()) };
                item.SubItems.AddRange(subItem);
                listView.Items.Add(item);
            }
        } // End of GetDirectories2

        public static System.Drawing.Icon GetFileIcon(string name, bool linkOverlay)
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
            // Copy (clone) the returned icon to a new object, thus allowing us 
            // to call DestroyIcon immediately
            System.Drawing.Icon icon = (System.Drawing.Icon)
                                 System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            User32.DestroyIcon(shfi.hIcon); // Cleanup
            return icon;
        } // End of GetFileIcon

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                GetDirectories2(item, string.Empty);
            } catch (Exception ex)
            {
                LogProj.exception(ex.Message);
            }
        } // End of listView_MouseDoubleClick

        private void listView_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                ShellContextMenu ctxMnu = new ShellContextMenu();
                DirectoryInfo[] dir = new DirectoryInfo[1];
                dir[0] = new DirectoryInfo(item.Tag.ToString());
                Point PP = this.PointToScreen(new Point(flowLayoutPanel1.Location.X + listView.Location.X + e.X, flowLayoutPanel1.Location.Y + listView.Location.Y + e.Y));
                if (dir[0].Exists)
                    ctxMnu.ShowContextMenu(dir, PP);
                else
                {
                    FileInfo[] arrFI = new FileInfo[1];
                    arrFI[0] = new FileInfo(item.Tag.ToString());
                    ctxMnu.ShowContextMenu(arrFI, PP);
                }
            }
            if(item != null)
                toolStripTextBox1.Text = item.Tag.ToString();
        } // End of listView_MouseDown

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.ColumnToSort)//.SortColumn)
            {
                if (lvwColumnSorter.OrderOfSort == SortOrder.Ascending)
                {
                    lvwColumnSorter.OrderOfSort = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.OrderOfSort = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.ColumnToSort = e.Column;
                lvwColumnSorter.OrderOfSort = SortOrder.Ascending;
            }
            this.listView.Sort();
        } // End of listView_ColumnClick

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DirectoryInfo parent = Directory.GetParent(toolStripTextBox1.Text.ToString());
            if (parent != null && Path.IsPathRooted(parent.FullName))
            {
                GetDirectories2(null, parent.FullName);
                toolStripTextBox1.Text = parent.FullName;
            }
        }
        private void flowLayoutPanel1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.flowLayoutPanel1.Visible) //(showList) 
            {
                PopolateSoloLista(comboBoxDriver.Text);
                toolStripTextBox1.Text = comboBoxDriver.Text;
            }
        }
    }
}