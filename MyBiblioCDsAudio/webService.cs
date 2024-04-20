using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyBiblioCDsAudio
{
    static public class webService
    {

        static public string sUrl = "";

        public static async Task<string> cdsearch()
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true }))
            {
                using (HttpResponseMessage response = client.GetAsync(sUrl).Result)
                {
                     
                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await content.ReadAsStringAsync();
                        return responseBody;
                    }
                }
            }
        } // End of webService

        static int num = 0;
        public static string webcall(string url)
        {
            string page = string.Empty;
            using (WebClient cl = new WebClient())
            {
                //HttpGet httpGet = new HttpGet(URL_HERE);
                //httpGet.setHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");
                //                cl.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";
                cl.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");
                try
                {
                    //cl.Credentials = CredentialCache.DefaultCredentials;
                    var txt = cl.DownloadString(url);
                    page = txt.ToString();
                }
                catch (Exception ex)
                {
                    LogProj.exception(ex.Message);
                }
                return page;
            }
        } // End of webcall

        public static bool SavefileLocal(string CoverFile, string ArtTit, ImgCoverInfo element)
        {
            try
            {
                string typeimg = element.CoverFile.Substring(element.CoverFile.LastIndexOf("."), element.CoverFile.Length - element.CoverFile.LastIndexOf("."));
                string tempPath = System.IO.Path.GetTempPath();
                tempPath = tempPath + "MyBiblioCds\\" + ArtTit + "_" + (++num).ToString() + typeimg;
                using (WebClient client = new WebClient())
                {
                //    HtmlDocument htmlDocument = null;
                  //  Form2 frm2 = new Form2(ref CoverFile, htmlDocument);
                    client.DownloadFile(new Uri(CoverFile), tempPath);
                    element.CoverFile = tempPath;
                }
            }
            catch (Exception e)
            {
                LogProj.exception(e.Message);
                return false;
            }
            return true;
        } // End of SavefileLocal

        static public XmlDocument Dwnld(string url)
        {
            XmlDocument xPathDocument = new XmlDocument();
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                webRequest.UserAgent = ".NET Framework/4.8.1";
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            xPathDocument.Load(reader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogProj.exception(e.Message);
            }
            return xPathDocument;
        } // End of Dwnld
    }
}
