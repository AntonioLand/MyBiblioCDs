using Microsoft.Office.Core;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Web;
using System.Windows.Forms;

namespace MyBiblioCDs
{
    public partial class MainForm : Form
    {
        private void ToClear()
        {
            LogProj.Info("ToClear");
            ComboBoxDriverClear();
            cmBxTypeMediaCDClear();
            checkBoxIndexWordClear();
            BListFilesCkear();
            bStopClear();
            bSaveInfoClear();
            bBrowseClear();
            numCDUpDClear();
            textNoteClear();
            PosCDTxtClear();
            BListFilesClear();
            BSaveAllClear();
            dateTimePickerClear();
            txtNameClear();
            objMain._Clear();
            progressBar1Clear();
            labelInfoClear();
            NumFile = 0;
            FILEINFO.Clear();
            if (backgroundFileList.IsBusy)
            {
                backgroundFileList.CancelAsync();
                backgroundFileList.Dispose();
                GC.Collect();
            }
            comboBoxDriverReActiveEvent();
            NumFile = NumDirectories = 0;
            LogProj.Info("End ToClear");
        } // end of ToClear
        void ComboBoxDriverClear()
        {
            if (comboBoxDriver.InvokeRequired)
            {
                comboBoxDriver.BeginInvoke(new Action(() =>
                {
                    this.comboBoxDriver.SelectedIndexChanged -= new EventHandler(this.comboBoxDriver_SelectedIndexChanged);
                    this.comboBoxDriver.TextChanged -= new EventHandler(this.comboBoxDriver_TextChanged);
                    this.comboBoxDriver.Text = string.Empty;
                    this.comboBoxDriver.SelectedIndex = -1;
                    this.comboBoxDriver.Refresh();
                    comboBoxDriver.Enabled = true;

                }));
            }
            else
            {
                this.comboBoxDriver.SelectedIndexChanged -= new EventHandler(this.comboBoxDriver_SelectedIndexChanged);
                this.comboBoxDriver.TextChanged -= new EventHandler(this.comboBoxDriver_TextChanged);
                this.comboBoxDriver.Text = string.Empty;
                this.comboBoxDriver.SelectedIndex = -1;
                this.comboBoxDriver.Refresh();
                comboBoxDriver.Enabled = true;
            }
        } // End of ComboBoxDriverClear
        void cmBxTypeMediaCDClear()
        {
            if (cmBxTypeMediaCD.InvokeRequired)
            {
                cmBxTypeMediaCD.BeginInvoke(new Action(() => { cmBxTypeMediaCD.SelectedIndex = -1; }));
            }
            else
                cmBxTypeMediaCD.SelectedIndex = -1;
        } // End of cmBxTypeMediaCDClear
        void checkBoxIndexWordClear()
        {
            if (checkBoxIndexWord.InvokeRequired)
            {
                checkBoxIndexWord.Invoke(new Action(() =>
                {
                    checkBoxIndexWord.Enabled = true;
                }));
            }
            else
                checkBoxIndexWord.Enabled = true;
        } // End of checkBoxIndexWordClear

        void BListFilesCkear()
        {
            if (BListFiles.InvokeRequired)
            {
                BListFiles.Invoke(new Action(() =>
                {
                    BListFiles.Enabled = false;
                }));
            } else
                BListFiles.Enabled = false;
        } //end of BListFilesCkear

        void bStopClear()
        {
            if (bStop.InvokeRequired)
            {
                bStop.Invoke(new Action(() =>
                {
                    bStop.Visible = false;
                    bStop.Enabled = false;
                }));
            } else
            {
                bStop.Visible = false;
                bStop.Enabled = false;
            }
        }// End of bStopClear

        void bSaveInfoClear()
        {
            if (bSaveInfo.InvokeRequired)
            {
                bSaveInfo.BeginInvoke(new Action(() =>
                {
                    bSaveInfo.Enabled = false;
                }));
            } else
                bSaveInfo.Enabled = false;
        } // End of bSaveInfo
        void bBrowseClear()
        {
            if (bBrowse.InvokeRequired)
            {
                bBrowse.Invoke(new Action(() =>
                {
                    bBrowse.Enabled = true;
                }));
            } else
                bBrowse.Enabled = true;
        }// End of bBrowseClear

        void numCDUpDClear()
        {
            if (numCDUpD.InvokeRequired)
            {
                numCDUpD.Invoke(new Action(() =>
                {
                    numCDUpD.Enabled = false;
                }));
            }
            else
                numCDUpD.Enabled = false;
        }// End of numCDUpDClear

        void textNoteClear()
        {
            if (textNote.InvokeRequired)
            {
                textNote.BeginInvoke(new Action(() =>
                {
                    textNote.Enabled = true;
                    textNote.Text = "";
                }));
            }
            else
            {
                textNote.Enabled = true;
                textNote.Text = "";
            }
        }// End of textNoteClear
        void PosCDTxtClear()
        {
            if (PosCDTxt.InvokeRequired)
            {
                PosCDTxt.BeginInvoke(new Action(() =>
                {
                    PosCDTxt.Text = "";
                }));
            }
            else
            {
                PosCDTxt.Text = "";
            }
        }// End of PosCDTxtClear

        void BListFilesClear()
        {
            if (BListFiles.InvokeRequired)
            {
                BListFiles.BeginInvoke(new Action(() => { BListFiles.Enabled = false; }));
            }
            else
                BListFiles.Enabled = false;
        }//End of BListFilesClear
        void BSaveAllClear()
        {
            if (BSaveAll.InvokeRequired)
            {
                BSaveAll.Invoke(new Action(() => { BSaveAll.Enabled = false; }));

            } else
                BSaveAll.Enabled = false;
        } // End of BSaveAllClear()

        void dateTimePickerClear()
        {
            if (dateTimePicker.InvokeRequired)
            {
                dateTimePicker.BeginInvoke(new Action(() =>
                {
                    dateTimePicker.Value = new DateTime((DateTime.Now).Year, (DateTime.Now).Month, (DateTime.Now).Day);

                }));
            }
            else
                dateTimePicker.Value = new DateTime((DateTime.Now).Year, (DateTime.Now).Month, (DateTime.Now).Day);

        } // End of dateTimePickerClear

        void txtNameClear()
        {
            if (txtName.InvokeRequired)
            { txtName.BeginInvoke(new Action(() =>
                {
                    txtName.Text = string.Empty;
                }));
            }
            else
                txtName.Text = string.Empty;
        } // End of txtNameClear

        void progressBar1Clear()
        { if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(new Action(() => { progressBar1.Value = 0; }));
            }
            else { progressBar1.Value = 0; }

        }// End of progressBar1Clear

        void labelInfoClear()
        {
            if (labelInfo.InvokeRequired)
            { labelInfo.BeginInvoke(new Action(() => { labelInfo.Text = string.Empty; }));
            } else { labelInfo.Text = string.Empty; }
        } // End of labelInfoClear

        void comboBoxDriverReActiveEvent()
        {
            if (comboBoxDriver.InvokeRequired)
            {
                comboBoxDriver.BeginInvoke(new Action(() =>
                {
                    this.comboBoxDriver.TextChanged += new EventHandler(this.comboBoxDriver_TextChanged);
                    this.comboBoxDriver.SelectedIndexChanged += new EventHandler(this.comboBoxDriver_SelectedIndexChanged);

                }));
            }
            else
            {
                this.comboBoxDriver.TextChanged += new EventHandler(this.comboBoxDriver_TextChanged);
                this.comboBoxDriver.SelectedIndexChanged += new EventHandler(this.comboBoxDriver_SelectedIndexChanged);
            }
        } // End of comboBoxDriverReActiveEvent
    }
}