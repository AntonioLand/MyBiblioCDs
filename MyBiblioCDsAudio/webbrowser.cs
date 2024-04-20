using MyBiblioCDsAudio.Properties.Vocabolury;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.Threading;
using System.IO;

namespace MyBiblioCDsAudio
{
    public partial class webbrowser : Form
    {
        public string Url;
        bool discg;
        public HtmlDocument htmlDocument;
        public webbrowser(ref string pUrl, HtmlDocument phtmlDocument = null, bool pdisc = false)
        {
            InitializeComponent();
            Url = pUrl;
            Url = "https://www.corriere.it";
            discg = pdisc;
            webBrowser1.ScrollBarsEnabled = true;
            htmlDocument = phtmlDocument;
        }

        private void webbrowser_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(new Uri(Url));
            Thread.Sleep(2000);
            webBrowser1.Refresh();
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

        private void webbrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            int i = 0;
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
                                Url += "MyBiblioCds\\" + (++i).ToString() + "___ArtTit.jpg";
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
        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
        }
    }
}
