using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using HtmlAgilityPack;

#pragma warning disable IDE1006, IDE0017

namespace MyBiblioCDsAudio
{
    public partial class MainFormAudio : Form
    {
        private async Task<int> SearchUrlsCD(XmlNodeList ListCD, Audio_CD cd)
        {
            List<string> urls = new List<string>();
            int result = 0;
            foreach (XmlNode nd in ListCD)
            {
                XmlElement xm = (XmlElement)nd;
                urls.Add(@"https://musicbrainz.org/release/" + xm.GetAttributeNode("id").Value);
            }
            urls = urls.Distinct().ToList();
            if (urls.Count > 0)
            {
                await RefineSearch(urls, cd);
            }
            if (Global.listcdfound.Count > 0)
                result = 1;
            return result;
        } // End of ReadyCdsFound_2

        private void GetDataCountry(Audio_CD cd, XmlNodeList ListCD)
        {

            XmlNodeList nodeList = ListCD[0].ChildNodes;
            foreach (XmlNode xmlNode in nodeList)
            {
                if (xmlNode.Name == "date")
                {
                    cd.PublicationDate = xmlNode.InnerText;
                    cd.Country = xmlNode.NextSibling.InnerText;
                    break;
                }
            }
        }
        private async Task RefineSearch(List<string> urls, Audio_CD cd)
        {
            foreach (string ur in urls)
            {
                Audio_CD oneCD = new Audio_CD();
                cd.Cpy(ref oneCD);
                var hmlDocument = new HtmlAgilityPack.HtmlDocument();
                string sur =  webService.webcall(ur);
                hmlDocument.LoadHtml(sur);
                if (hmlDocument == null)
                    return;
                GetDuration(hmlDocument, oneCD);
                oneCD.numTracks = _GetTracksList(hmlDocument, oneCD);
                GetArtist(hmlDocument, oneCD);
                Getyeartandcountry(hmlDocument, oneCD);
                oneCD.Release_ID = ur.Remove(0, ur.LastIndexOf('/') + 1);
                Global.listcdfound.Add(oneCD);
            }
        }
        void GetDuration(HtmlAgilityPack.HtmlDocument hmlDocument, Audio_CD oneCD)
        {
            HtmlNodeCollection ListCD = hmlDocument.DocumentNode.SelectNodes("//script");
            foreach (HtmlNode nd in ListCD)
            {
                if (nd.Attributes.Count >= 1 && nd.Attributes.ElementAt(0).Name != "type" && nd.Attributes.ElementAt(0).Value != "application/ld+json")
                    continue;
                else if (nd.Attributes.Count >= 1)
                {
                    string jstringnode;
                    jstringnode = nd.InnerText.ToString();
                    Regex rx = new Regex(@"duration\"":""PT(([0-9]*)H([0-9]*)M([0-9]*)S)|(([0-9]*)M([0-9]*)S)");
                    MatchCollection duration =  rx.Matches(jstringnode);
                    string durationTime;
                    if (duration != null && duration.Count > 0)
                    {
                        Match ms = duration[duration.Count-1];
                        if (duration[duration.Count - 1].Value.Contains("duration"))
                        {
                            durationTime = duration[duration.Count - 1].Groups[2].Value.ToString() + ":" + duration[duration.Count - 1].Groups[3].Value.ToString() + ":" + duration[duration.Count - 1].Groups[4].Value.ToString();
                        }
                        else
                        {
                            durationTime = duration[duration.Count - 1].Groups[6].Value.ToString() + ":" + duration[duration.Count - 1].Groups[7].Value.ToString();
                        }
                        oneCD.Duration = durationTime;
                    }
                }
            }
        }
        void GetArtist(HtmlAgilityPack.HtmlDocument hmlDocument, Audio_CD oneCD)
        {
            if (oneCD.Artist == null)
                return;
            HtmlNodeCollection ListCD = hmlDocument.DocumentNode.SelectNodes("//body//div/div//div//p");
            foreach (HtmlNode nd in ListCD)
            {
                var artist = ListCD.Descendants("bdi");
                if (artist.ElementAt(0).InnerText != null)
                {
                    byte[] bytes = Encoding.Default.GetBytes(artist.ElementAt(0).InnerText);
                    oneCD.Artist = Encoding.UTF8.GetString(bytes);
                    break;
                }
            }
        }
        void Getyeartandcountry(HtmlAgilityPack.HtmlDocument hmlDocument, Audio_CD oneCD)
        {
            HtmlNodeCollection ListCD = hmlDocument.DocumentNode.SelectNodes("//body//div");
            foreach (HtmlNode nd in ListCD)
            {
                if (nd.Attributes.ElementAt(0).Name == "class" && nd.Attributes.ElementAt(0).Value == "release-events-container")
                {
                    var M = nd.Descendants("bdi");
                    foreach (HtmlNode mk in M)
                    {
                          oneCD.Country = mk.InnerText;
                    }
                }
            }
            var xmlNodeList = hmlDocument.DocumentNode.SelectNodes("//span");
            foreach (HtmlNode xmlNode1 in xmlNodeList)
            {
                if (xmlNode1.HasAttributes && xmlNode1.Attributes[0].Value == "release-date")
                {
                    oneCD.PublicationDate = xmlNode1.InnerText;
                    break;
                }
            }
        }
        private int _GetTracksList(HtmlAgilityPack.HtmlDocument hmlDocument, Audio_CD oneCD)
        {
            HtmlNodeCollection ListCD = hmlDocument.DocumentNode.SelectNodes("//body//div/div//div//tbody");
            var inputs = ListCD.Descendants("td").Where(n => n.Attributes["class"] != null && n.Attributes["class"].Value == "pos t").ToArray();
            oneCD.LTracks = new BindingList<Track_AU>();
            Encoding enc = Encoding.UTF8;
            foreach (HtmlNode el in inputs)
            {
                Track_AU nwTr = new Track_AU();
                if (el.Name == "td" && el.Attributes["class"].Value == "pos t")
                {
                    nwTr.TrNum = el.FirstChild.InnerText;
                }
                // Herlich Scheisseeeeeeeeeeeeeeeeeeee
                if (el.NextSibling.FirstChild.FirstChild.Name == "bdi")
                {
                    nwTr.TitleTrack = Global.decodeDummChar(el.NextSibling.FirstChild.FirstChild.InnerText);
                } else if (el.NextSibling.FirstChild.FirstChild.HasChildNodes)
                    if (el.NextSibling.FirstChild.FirstChild.FirstChild.Name == "bdi")
                    {
                        nwTr.TitleTrack = Global.decodeDummChar(el.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.InnerText);
                    } else if (el.NextSibling.FirstChild.FirstChild.FirstChild.HasChildNodes)
                    {
                        if (el.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.Name == "bdi")
                            nwTr.TitleTrack = Global.decodeDummChar(el.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText);
                    }
                if (el.NextSibling.NextSibling.NextSibling.Name == "td" && el.NextSibling.NextSibling.NextSibling.Attributes["class"].Value == "treleases")
                {
                    nwTr.Duration = el.NextSibling.NextSibling.NextSibling.InnerText;
                }
                else if (el.NextSibling.NextSibling.NextSibling.NextSibling.Name == "td" && el.NextSibling.NextSibling.NextSibling.NextSibling.Attributes["class"].Value == "treleases")
                {
                    nwTr.Duration = el.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                }
                oneCD.LTracks.Add(nwTr);
            }
            return oneCD.LTracks.Count;
        } // end of NumTracks

        private void ReadyCdsFound(XmlNodeList ListCD)
        {
            foreach (XmlNode X in ListCD)
            {
                Audio_CD elem = new Audio_CD();
                XmlElement xm = (XmlElement)X;
                XmlAttribute att = xm.GetAttributeNode("id");
                if (xm["title"] != null)
                    elem.Title = xm["title"].InnerText;
                if (xm["country"] != null)
                    elem.Country = xm["country"].InnerText;
                if (xm["date"] != null)
                    elem.PublicationDate = xm["date"].InnerText;
                if (xm["barcode"] != null)
                    elem.Barcode = xm["barcode"].InnerText;
                if (att.InnerText != null)
                    elem.Release_ID = att.InnerText;
                Global.listcdfound.Add(elem);
            }
        } // End of ReadyCdsFound
        public XmlNamespaceManager ManagerNs(ref XmlDocument xmldocument)
        {
            LogProj.Info(".... ManagerNs....");
            XmlNamespaceManager manager = null;
            try
            {
                XmlElement root = xmldocument.DocumentElement;
                string NSXmlns = root.NamespaceURI;
                manager = new XmlNamespaceManager(xmldocument.NameTable);
                manager.AddNamespace("MB", NSXmlns.ToString());
            } catch(Exception ex)
            {
                LogProj.exception(ex.Message);
            }
            return manager;
        } // End of ManagerNs
    }
} // End of Namespace

