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
using System.Collections.Generic;
using System;

namespace MyBiblioCDsAudio
{
    public partial class MainFormAudio : Form
    {
        int numRowClick = -1;
        private void TrackDtGrVw_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                DataObject d = TrackDtGrVw.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.C && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                DataObject d = TrackDtGrVw.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else
                Global.saveTracks = true;
        }

        private DataGridViewCell InitialCell(ref int numcelltopaste, DataGridView trckgrvw)
        {
            DataGridViewSelectedCellCollection selcell = trckgrvw.SelectedCells;
            if (selcell.Count == 0)
                return null;
            if (trckgrvw.SelectedRows.Count > 0)
                numcelltopaste = 1000;
            else
                numcelltopaste= selcell.Count;

            DataGridViewCell cell = selcell[0];
            int rw = cell.RowIndex;     //trckgrvw.Rows.Count - 1;
            int col = cell.ColumnIndex;// trckgrvw.SelectedCells.Count - 1;
            DataGridViewSelectedRowCollection selrw = trckgrvw.SelectedRows;
            DataGridViewRow[] cp = new DataGridViewRow[selrw.Count];
            selrw.CopyTo(cp, 0);
            if (selrw.Count > 0)
            {
                IEnumerable<DataGridViewRow> rwquery = cp.OrderBy(xi => xi.Index);
                rw = ((DataGridViewRow)(rwquery.First())).Index;
            
                DataGridViewSelectedColumnCollection selcol = trckgrvw.SelectedColumns;
                DataGridViewColumn[] Col = new DataGridViewColumn[selcol.Count];
                selcol.CopyTo(Col, 0);
                IEnumerable<DataGridViewColumn> colquery = Col.OrderBy(xi => xi.Index);
                if(colquery.Any())
                    col = colquery.First().Index;
            }

            int InitRow = trckgrvw.Rows.Count - 1;
            int InitColumn= trckgrvw.Columns.Count - 1;

            foreach (DataGridViewCell cl in trckgrvw.SelectedCells)
            {
                if (cl.RowIndex < InitRow)
                    InitRow = cl.RowIndex;
                if (cl.ColumnIndex < InitColumn)
                    InitColumn = cl.ColumnIndex;
            }

            return trckgrvw[InitColumn, InitRow];
        }
        private void TrackDtGrVw_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            numRowClick = e.RowIndex;
        }

        private void TrackDtGrVw_MouseClick(object sender, MouseEventArgs e)
        {

            if (dtgrvwInfoCd.IsCurrentCellDirty)
            {
                DataGridViewCell YY = dtgrvwInfoCd.CurrentCell;
                dtgrvwInfoCd.CurrentCell = dtgrvwInfoCd.Rows[YY.RowIndex + 1].Cells[0];
                dtgrvwInfoCd.CurrentCell = YY;
            }
            if (e.Button == MouseButtons.Right)
            {
                MyContextMenu();
                MyCntxMn.Show(TrackDtGrVw, new Point(e.X, e.Y));
            }
        }
        private void TrackDtGrVw_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            trackupdt = true;
        }

        private void TrackDtGrVw_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.ContextMenu = MyCntxMn;
        }

        private void TrackDtGrVw_Leave(object sender, EventArgs e)
        {
            if (TrackDtGrVw.IsCurrentCellDirty)
            {
                DataGridViewCell YY = TrackDtGrVw.CurrentCell;
                TrackDtGrVw.CurrentCell = TrackDtGrVw.Rows[YY.RowIndex + 1].Cells[0];
                TrackDtGrVw.CurrentCell = YY;
            }
            if (Global.saveTracks)
            {
                Global.savetracks(ref this.TrackDtGrVw, ref trackAUBindingSource);
                Global.saveTracks = false;
            }
        }

        private void TrackDtGrVw_DataError(object sender, DataGridViewDataErrorEventArgs ex)
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
            if (ex.Exception != null)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[ex.RowIndex].ErrorText = "an error";
                ex.ThrowException = false;
            }

        }
    }
}
