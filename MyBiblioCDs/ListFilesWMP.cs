using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;
#pragma warning disable CS1591

namespace MyBiblioCDs
{
    public partial class ListFiles : Form, IDisposable
    {
        WebBrowser webBrowser;

        void LoadAdPdf(int numdir, int indx)
        {
            try
            {
                if(axpdf == null)
                    axpdf = new AxAcroPDFLib.AxAcroPDF();
                ((System.ComponentModel.ISupportInitialize)(this.axpdf)).BeginInit();
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                axpdf.Enabled = true;
                axpdf.Location = new System.Drawing.Point(0, 0);
                axpdf.Name = "pdfReader";
                axpdf.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                axpdf.TabIndex = 1;
                flowLayoutPanel2.Controls.Add(axpdf);
                axpdf.setViewRect(flowLayoutPanel2.Location.X, flowLayoutPanel2.Location.Y, flowLayoutPanel2.Size.Width, flowLayoutPanel2.Size.Height);
                axpdf.BringToFront();
                axpdf.Size = new System.Drawing.Size(flowLayoutPanel2.Width, flowLayoutPanel2.Height);
                axpdf.src = FILESINFO[numdir].FilesInfos[indx].thisfile.FullName;
                ((System.ComponentModel.ISupportInitialize)(this.axpdf)).EndInit();
                axpdf.setShowScrollbars(false);
                axpdf.setLayoutMode("SinglePage");
                
                axpdf.Visible = true;
                axpdf.Show();
                axpdf.Update();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ImageLoader(string file_name)
        {
            try
            {
                bxImg = new PictureBox();
                Image img = Image.FromFile(file_name);
                Bitmap bmpp = new Bitmap(img, img.Width, img.Height);
                bxImg.Size = new Size(flowLayoutPanel2.Width, flowLayoutPanel2.Height);
                flowLayoutPanel2.AutoScroll = true;
                flowLayoutPanel2.Controls.Add(bxImg);
                bxImg.Image = bmpp;
                bxImg.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel2.HorizontalScroll.Enabled = true;
                bxImg.Refresh();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDocFile(string theDoc)
        {
            this.TopMost = false;
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass wordObject = new Microsoft.Office.Interop.Word.ApplicationClass() { Visible = false };
                object readOnly = false;
                object visible = true;
                object save = false;
                object file = theDoc;
                object newTemplate = false;
                object docType = 0;
                object missing = Type.Missing;
                object nullobject = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document docs = wordObject.Documents.Open
                    (ref file, ref nullobject, ref nullobject, ref nullobject,
                    ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                    ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                    ref nullobject, ref nullobject, ref nullobject, ref nullobject);
                docs.ActiveWindow.Selection.WholeStory();
                docs.ActiveWindow.Selection.Copy();
                IDataObject data = Clipboard.GetDataObject();
                richTextBox.Rtf = data.GetData(DataFormats.Rtf).ToString();
                docs.Close(ref nullobject, ref nullobject, ref nullobject);
            }
            catch (Exception j)
            {
                LogProj.exception("LoadDocFile: " + j.Message);
                MessageBox.Show(j.Message);
                
            }
            this.TopMost = true;
        }

        private void OpenWebBrowser(Uri uri)
        {
            if (!WhatAlreadyExists("WebBrowser"))
            {
                webBrowser = new WebBrowser();
                flowLayoutPanel2.Controls.Add(webBrowser);
                webBrowser.Size = new System.Drawing.Size(flowLayoutPanel2.Width, flowLayoutPanel2.Height);
                webBrowser.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                webBrowser.AllowWebBrowserDrop = false;
                webBrowser.Url = uri;
                webBrowser.Show();
            }
            webBrowser.Url = uri;
            webBrowser.Update();
        }
    }
}