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
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Windows;
using Clipboard = System.Windows.Clipboard;

namespace MyBiblioCDsAudio
{
    public partial class MainFormAudio : Form
    {
        private void dtgrvwInfoCd_SelectionChanged(object sender, EventArgs e)
        {
            numRow = dtgrvwInfoCd.CurrentCell.RowIndex;
            Global.choosedCD = Global.listcdfound[numRow];
            writeInfo();
            this.Refresh();
        } // End of dtgrvwInfoCd_SelectionChanged

        private void HideColumn()
        {
            dtgrvwInfoCd.Columns["numTracks"].Visible = false;
            dtgrvwInfoCd.Columns["CoverArtF"].Visible = false;
            dtgrvwInfoCd.Columns["genreMusic"].Visible = false;
            dtgrvwInfoCd.Refresh();
        }

        private void dtgrvwInfoCd_DataError(object sender, DataGridViewDataErrorEventArgs ex)
        {
            MessageBox.Show("Error happened " + ex.Context.ToString());

            if (ex.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (ex.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (ex.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (ex.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }
            if ((ex.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[ex.RowIndex].ErrorText = "an error"; view.Rows[ex.RowIndex].Cells[ex.ColumnIndex].ErrorText = "an  Horror";
                ex.ThrowException = false;
            }
        } // End of dtgrvwInfoCd_DataError

        private void HeadInfoCd()
        {
            DataGridViewCellStyle style = dtgrvwInfoCd.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dtgrvwInfoCd.Font, System.Drawing.FontStyle.Bold);
            dtgrvwInfoCd.Columns.Clear();

            DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
            column1.DataPropertyName = "Title";
            column1.Name = "Title";
            column1.HeaderText = Languages.lbTitle;
            column1.Width = 270;
            this.dtgrvwInfoCd.Columns.Add(column1);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
            column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "Artist";
            column2.Name = "Artist";
            column2.HeaderText = Languages.lbArtist;
            column2.Width = 200;
            this.dtgrvwInfoCd.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
            column3 = new DataGridViewTextBoxColumn();
            column3.DataPropertyName = "Country";
            column3.Name = "Country";
            column3.HeaderText = Languages.lbCountry;
            column3.Width = 100;
            this.dtgrvwInfoCd.Columns.Add(column3);

            DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
            column4 = new DataGridViewTextBoxColumn();
            column4.DataPropertyName = "PublicationDate";
            column4.Name = "PublicationDate";
            column4.HeaderText = Languages.lbDate;
            column4.Width = 80;
            this.dtgrvwInfoCd.Columns.Add(column4);

            DataGridViewColumn column5 = new DataGridViewTextBoxColumn();
            column5 = new DataGridViewTextBoxColumn();
            column5.DataPropertyName = "Barcode";
            column5.Name = "Barcode";
            column5.HeaderText = Languages.lbBarcode;
            this.dtgrvwInfoCd.Columns.Add(column5);

            DataGridViewColumn column6 = new DataGridViewTextBoxColumn();
            column6 = new DataGridViewTextBoxColumn();
            column6.DataPropertyName = "Release_ID";
            column6.Name = "Release_ID";
            column6.HeaderText = Languages.releaseidGridview1;
            column6.Width = 80;
            this.dtgrvwInfoCd.Columns.Add(column6);

            DataGridViewColumn column7 = new DataGridViewTextBoxColumn();
            column7 = new DataGridViewTextBoxColumn();
            column7.DataPropertyName = "CoverArtF";
            column7.Name = "CoverArtF";
            column7.HeaderText = Languages.CoverPath;
            column7.Width = 200;
            this.dtgrvwInfoCd.Columns.Add(column7);

            DataGridViewColumn column8 = new DataGridViewTextBoxColumn();
            column8 = new DataGridViewTextBoxColumn();
            column8.DataPropertyName = "Genre";
            column8.Name = "Genre";
            column8.HeaderText = Languages.lbGenre;
            column8.Width = 70;
            this.dtgrvwInfoCd.Columns.Add(column8);

            DataGridViewColumn column9 = new DataGridViewTextBoxColumn();
            column9 = new DataGridViewTextBoxColumn();
            column9.DataPropertyName = "Duration";
            column9.Name = "Duration";
            column9.Width = 60;
            column9.HeaderText = Languages.TrackDtGrVw_Duration;
            this.dtgrvwInfoCd.Columns.Add(column9);
        } // End of HeadInfoCd
 
        public void MyContextMenu() 
        {
            MyCntxMn = new ContextMenu();
            MyCntxMn.MenuItems.Add(new System.Windows.Forms.MenuItem("Copy", new System.EventHandler(CopyToClipBoard)));
            MyCntxMn.MenuItems.Add(new System.Windows.Forms.MenuItem("Paste", new System.EventHandler(Paste)));
            MyCntxMn.MenuItems.Add(new System.Windows.Forms.MenuItem("Delete", new System.EventHandler(ContextMenuClick)));
            MyCntxMn.MenuItems.Add(new System.Windows.Forms.MenuItem("Insert", new System.EventHandler(InsertOneRow)));
            MyCntxMn.MenuItems.Add(new System.Windows.Forms.MenuItem("Save Tracks", new System.EventHandler(ContextMenuClick)));
        } // End of MyContextMenu

        private void Paste(object sender, EventArgs e)
        {
            int linesInClipboard, iRowIndex = 0, rowsselect = 0;
            TrackDtGrVw.DataSource= this.trackAUBindingSource;
            DataGridViewCell intcell = InitialCell(ref rowsselect, TrackDtGrVw);
            Dictionary<int, string> RowToClipboard = new Dictionary<int, string>();
            Dictionary<int, Dictionary<int, string>> cbValue;
            if (Clipboard.ContainsText())
            {
                cbValue = CpClipBoard(Clipboard.GetText());
                linesInClipboard = CountLines(cbValue);
            }
            else
            {
                MessageBox.Show("La clipboard non contiene Testo");
                return;
            }
            try
            {
                iRowIndex = intcell.RowIndex;
            } catch (Exception)
            {
                MessageBox.Show(Languages.w_OneMoreCellRows);
            }
            if (TrackDtGrVw.SelectedCells.Count == 1 && cbValue.Count == 1)
            {
                DataGridViewSelectedCellCollection selcell = TrackDtGrVw.SelectedCells;
                InsertAndWrite(selcell[0], cbValue, true);
            }
            if (TrackDtGrVw.SelectedCells.Count == 1 && cbValue.Count > 1)
            {
                InsertAndWrite(iRowIndex, intcell, cbValue);
            }
            else if(rowsselect == 1000)
            {
                InsertAndWrite(iRowIndex, intcell, cbValue, true);
            }
            else if (TrackDtGrVw.SelectedCells.Count >= 1 && cbValue.Count == 1)
            {
                if ((string)TrackDtGrVw.SelectedCells[0].Value == string.Empty)
                    InsertAndWrite(iRowIndex, intcell, cbValue);
                else
                    InsertAndWrite(iRowIndex, intcell, cbValue, true);
            }
            else if (TrackDtGrVw.SelectedCells.Count >= 1 && cbValue.Count > 1)
            {
                    InsertAndWrite(iRowIndex, cbValue);
            }
        } // End of Paste

        private void InsertAndWrite(int iRowIndex, Dictionary<int, Dictionary<int, string>> cbValue)
        {
            DataGridViewCell cell = TrackDtGrVw.SelectedCells[0];
            int rw = cell.RowIndex;     //trckgrvw.Rows.Count - 1;
            int col = cell.ColumnIndex;// trckgrvw.SelectedCells.Count - 1;
            DataGridViewSelectedCellCollection selrw = TrackDtGrVw.SelectedCells;
            DataGridViewCell[] cp = new DataGridViewCell[selrw.Count];
            selrw.CopyTo(cp, 0);
            if (selrw.Count > 0)
            {
                IEnumerable<DataGridViewCell> rwquery = cp.OrderBy(xi => xi.ColumnIndex);
                rwquery = cp.OrderBy(xi => xi.RowIndex);
                rw = ((DataGridViewCell)(rwquery.First())).RowIndex;
                
                int i = 0;
                foreach (DataGridViewCell cl in rwquery)
                {
                        switch (cl.ColumnIndex)
                        {
                            case 0:
                                Global.choosedCD.LTracks.ElementAt(cl.RowIndex).TrNum = cbValue[i++][0];
                                break;
                            case 1:
                                Global.choosedCD.LTracks.ElementAt(cl.RowIndex).TitleTrack = cbValue[i++][0];
                                break;
                            case 2:
                                Global.choosedCD.LTracks.ElementAt(cl.RowIndex).Duration = cbValue[i++][0];
                                break;
                            default:
                                break;
                        }
                }
            }
            trackAUBindingSource.ResetBindings(false);
            TrackDtGrVw.Refresh();
        } // End of InsertAndWrite

        private void InsertAndWrite(DataGridViewCell intcell, Dictionary<int, Dictionary<int, string>> cbValue, bool overwrite = false)
        {
            int rowindx = intcell.RowIndex;
            int colindex = intcell.ColumnIndex;
            switch(colindex)
            {
                case 0:
                    Global.choosedCD.LTracks.ElementAt(rowindx).TrNum = cbValue[0][0];
                    break;
                case 1:
                    Global.choosedCD.LTracks.ElementAt(rowindx).TitleTrack = cbValue[0][0];
                    break;
                case 2:
                    Global.choosedCD.LTracks.ElementAt(rowindx).Duration = cbValue[0][0];
                    break;
            }
            cbValue.Remove(0);
        } // End of InsertAndWrite

        private void InsertAndWrite(int iRowIndex, DataGridViewCell intcell, Dictionary<int, Dictionary<int, string>> cbValue, bool overwrite = false)
          {
            foreach (int rowKey in cbValue.Keys)
            {
                Track_AU track_AU = new Track_AU();
                int iColIndex = intcell.ColumnIndex;
                foreach (int cellKey in cbValue[rowKey].Keys)
                {
                    if (iColIndex <= TrackDtGrVw.Columns.Count - 1 && iRowIndex <= TrackDtGrVw.Rows.Count - 1)
                    {
                        switch (cellKey)
                        {
                            case 0:
                                track_AU.TrNum = cbValue[rowKey][cellKey];
                                break;
                            case 1:
                                track_AU.TitleTrack = cbValue[rowKey][cellKey];
                                break;
                            case 2:
                                track_AU.Duration = cbValue[rowKey][cellKey];
                                break;
                            default:
                                break;
                        }
                    }
                    iColIndex++;
                }
                if (overwrite)
                    OverWrite(ref iRowIndex, track_AU);
                else
                    Global.choosedCD.LTracks.Insert(iRowIndex++, track_AU);
                trackAUBindingSource.ResetBindings(false);
                TrackDtGrVw.Refresh();
            }
        } // End of InsertAndWrite

        private void OverWrite(ref int iRowIndex, Track_AU track_AU)
        {
            Global.choosedCD.LTracks.ElementAt(iRowIndex).TrNum = track_AU.TrNum;
            Global.choosedCD.LTracks.ElementAt(iRowIndex).TitleTrack = track_AU.TitleTrack;
            Global.choosedCD.LTracks.ElementAt(iRowIndex++).Duration= track_AU.Duration;
        } // End of OverWrite

        int CountLines(Dictionary<int, Dictionary<int, string>> cbValue)
        {
            int count = 0;
            bool deleline;
            int[] array = new int[cbValue.Count];
            int indx = 0;
            foreach (int key in cbValue.Keys)
            {
                deleline = false;
                for (int i = 0; i < cbValue[key].Count; i++)
                    if (cbValue[key][i] != "")
                    {
                        count++;
                        deleline = true;
                        break;
                    }
                if (!deleline)
                    array[indx++] = key;
            }
            indx = 0;
            while (array[indx] != 0)
                cbValue.Remove(array[indx++]);

            return count;
        } // End of CountLines

        private Dictionary<int, Dictionary<int, string>> CpClipBoard(string TextInClipBoard)
        {
            TextInClipBoard = TextInClipBoard.Replace("\t\t", "\t");
            TextInClipBoard = TextInClipBoard.Replace("\r\n", "\n");
            Dictionary<int, Dictionary<int, string>> DictClip = new Dictionary<int, Dictionary<int, string>>();
            string[] lines = TextInClipBoard.Split('\n');

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                DictClip[i] = new Dictionary<int, string>();
                string[] colinclip = lines[i].Split('\t');

                if (colinclip.Length == 0)
                    DictClip[i][0] = string.Empty;
                else
                {
                    for (int j = 0; j <= colinclip.Length - 1; j++)
                        DictClip[i][j] = colinclip[j];
                }
            }
            return DictClip;
        }
        private void CopyToClipBoard(object sender, EventArgs e)
        {
            if (this.TrackDtGrVw.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(this.TrackDtGrVw.GetClipboardContent());
                }
                catch (System.Runtime.InteropServices.ExternalException ext)
                {
                    MessageBox.Show(ext.Message + "\n\nThe Clipboard could not be accessed. Please try again.");
                }
            }
        }

        public void ContextMenuClick(Object sender, System.EventArgs e)
        {
            int pos = sender.ToString().Trim().LastIndexOf(':');
            string mn = sender.ToString().Trim().Substring(pos + 2);
            switch (mn)
            {
                case "Delete":
                    try
                    {

                        DataGridViewSelectedRowCollection sel = TrackDtGrVw.SelectedRows;
                        DataGridViewRow[] cp = new DataGridViewRow[sel.Count];
                        sel.CopyTo(cp, 0);
                        IEnumerable<DataGridViewRow> query = cp.OrderByDescending(xi => xi.Index);
                        foreach (DataGridViewRow row in query)
                        {
                            Global.choosedCD.LTracks.RemoveAt(row.Index);
                        }
                             trackAUBindingSource.ResetBindings(false);
                       TrackDtGrVw.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Save Tracks":
                    if (TrackDtGrVw.IsCurrentCellDirty)
                    {
                        DataGridViewCell YY = TrackDtGrVw.CurrentCell;
                        TrackDtGrVw.CurrentCell = TrackDtGrVw.Rows[YY.RowIndex + 1].Cells[0];
                        TrackDtGrVw.CurrentCell = YY;
                    }
                    trackAUBindingSource.ResetBindings(false);
                    TrackDtGrVw.Refresh();
                    break;
                case "Copy":
                    CopyToClipBoard(sender, e);
                    break;
                case "Insert":
                    InsertOneRow(sender, e);
                    break;
            }
        }
        private void InsertOneRow(object sender, EventArgs e)
        {
            Global.choosedCD.LTracks.Insert(numRowClick+1, new Track_AU());
            trackAUBindingSource.ResetBindings(false);
            TrackDtGrVw.Refresh();
        }
    }
}