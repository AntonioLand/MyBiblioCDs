using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;

#pragma warning disable IDE1006, IDE0044

namespace MyBiblioCDsAudio
{
    public partial class Form2 : Form
    {
        public string Url;
        bool discg;
        public HtmlDocument htmlDocument;
        public Form2(ref string pUrl, HtmlDocument phtmlDocument = null, bool pdisc = false)
        {
            InitializeComponent();
            Url = pUrl;
            discg = pdisc;
            webBrowser1.ScrollBarsEnabled = true;
            htmlDocument = phtmlDocument;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(new Uri(Url));
            Thread.Sleep(1000);
            webBrowser1.Refresh();
            this.TopMost = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement elem;
            try
            {
                HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("HTML");
                if (elems.Count == 1)
                {
                    elem = elems[0];
                    richTextBox1.Text = elem.OuterHtml;
                }
            }
            catch (Exception b)
            {
                LogProj.exception(b.Message);
                return;
            }
            Url = richTextBox1.Text;
            htmlDocument = webBrowser1.Document;
            webBrowser1.ScrollBarsEnabled = true;
            Thread.Sleep(500);
            Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (discg)
            {
                IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();
                foreach (IHTMLImgElement img in doc.images)
                {
                    imgRange.add((IHTMLControlElement)img);
                    imgRange.execCommand("Copy", false, null);
                    try
                    {
                        using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
                        {
                            if (bmp != null)
                            {
                                Url = Path.GetTempPath();
                                Url += "MyBiblioCds\\" + "___ArtTit.jpg";
                                bmp.Save(Url, System.Drawing.Imaging.ImageFormat.Jpeg);
                                bmp.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogProj.exception("Form2_FormClosing: " + ex.Message);
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
