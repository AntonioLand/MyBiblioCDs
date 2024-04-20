using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Diagnostics;
using static MyBiblioCDsAudio.discogsJson.ReLeaseOf;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.ComponentModel;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Xml.XPath;

#pragma warning disable IDE0059

namespace MyBiblioCDsAudio
{
    /// <summary>
    /// Only in the case of a manual search, if Music Brainz does not give answers then you try Discogs.
    /// </summary>
    static class Discogs
    {
        private static void MatchGalleryImg(List<ImgCoverInfo> _coverList, List<string> newurl, string ArtTit, ref int numfile)
        {
            
            foreach (string r in newurl)
            {
                ImgCoverInfo element = new ImgCoverInfo
                {
                    CoverFile = r,
                    CoverImgSize = extrackSizeImg(r),
                    NameCover = ArtTit
                };
                if (webService.SavefileLocal(element.CoverFile, ArtTit, element))
                {
                    numfile++;
                    _coverList.Add(element);
                }
                if(numfile >= 30)
                    break;
            }
        }
        private static string extrackSizeImg(string st)
        {
            Regex Rx = new Regex(@"(h\W\d{2,})\W(w\W\d{2,})");
            MatchCollection matches= Rx.Matches(st);
            if (matches.Count > 0)
            {
                string H = matches[0].Groups[1].ToString();
                string W = matches[0].Groups[2].ToString();
                H = H.Remove(0, 2);
                W = W.Remove(0, 2);
                return H + "X" + W;
            }
            return "0X0";
        }

        public static int Disco_gs(ref List<ImgCoverInfo> _coverList, ref int numfile)
        {
            LogProj.Info("Disco_gs(List<ImgCoverInfo> _coverList, ref int numfile, bool cov = true)");
            string sURL;
            string Artist = string.Empty;
            string Title = string.Empty;
            sURL = RetrieveUrl(ref Artist, ref Title);
            List<string> Resource_Url= new List<string>();
            try
            {
                string js = webService.webcall(sURL);
                List<string> ImgUrl = Extractor(js, Title, Resource_Url);
                string ArtTit = Artist.Replace('+', '-') + "-" + Title.Replace('+', '-');
                MatchGalleryImg(_coverList, ImgUrl, ArtTit, ref numfile);

                //List<string> result = MatchImg(ref js, ArtTit);
            }
            catch (Exception e)
            {
                LogProj.exception(e.Message);
                return 0;
            }
            return numfile;
        } // End of Disco_gs II Versione

        private static string RetrieveUrl(ref string Artist, ref string Title)
        {
            string sURL;
            Artist        = Global.choosedCD.Artist;
            Title         = Global.choosedCD.Title;
            Artist        = Artist.Replace(' ', '+');
            Title         = Title.Replace(' ', '+');
            string Endstr = "cd&type=all&token=uaHbFAXyovBZDasPsYLZQtGJodExxxELIcQVnTWK";
            sURL = "https://api.discogs.com/database/search?q=" + Artist + "+" + Title + "+" + Endstr;
            return sURL;
        }

        private static string RetrieveUrl(Audio_CD FoundCD, ref string Artist, ref string Title)
        {
            string sURL;
            Artist = FoundCD.Artist;
            Title = FoundCD.Title;
            Artist = Artist.Replace(' ', '+');
            Title = Title.Replace(' ', '+');
            string Endstr = "cd&type=all&token=uaHbFAXyovBZDasPsYLZQtGJodExxxELIcQVnTWK";
            sURL = "https://api.discogs.com/database/search?q=" + Artist + "+" + Title + "+" + Endstr;
            return sURL;
        }

        public static void ManuelSearch(Audio_CD _cdfound, List<ImgCoverInfo> _coverList, ref int numfile)
        {
            LogProj.Info("ManuelSearch " + _cdfound.Artist + " " + _cdfound.Title);

            string sURL;
            string Artist = string.Empty;
            string Title = string.Empty;
            List<string> Resource_Url = new List<string>();
            try
            {
                sURL = RetrieveUrl(_cdfound, ref Artist, ref Title);
                string page = webService.webcall(sURL);
                List<string> ImgUrl = Extractor(page, Title, Resource_Url, true);
                if (ImgUrl == null)
                    return;
                string ArtTit = Artist.Replace('+', '-') + "-" + Title.Replace('+', '-');
                MatchGalleryImg(_coverList, ImgUrl, ArtTit, ref numfile);
                retrieveInfoCd(_cdfound, Resource_Url);

            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        } // end of ManuelSearch
        private static void retrieveInfoCd(Audio_CD _cdfound, List<string> Resource_Url)
        {
            string Artist = _cdfound.Artist;
            string Title = _cdfound.Title;
            Artist = Artist.Replace('+', '-');
            Title = Title.Replace('+', '-');
            MyBiblioCDsDiscogs.Rootobject rootobject;
            foreach (string uRl in Resource_Url)
            {
               string trNum, TTitleTrack, duration;
               string page = webService.webcall(uRl);
                if (page == null || page == string.Empty)
                    continue;
                try
                {
                    rootobject = System.Text.Json.JsonSerializer.Deserialize<MyBiblioCDsDiscogs.Rootobject>(page);
                } catch(Exception e)
                {
                    LogProj.exception(e.Message);
                    continue;
                }
                Audio_CD cdf = new Audio_CD();
                if (rootobject.artists_sort != null)
                    cdf.Artist = rootobject.artists_sort.ToString();
                if (rootobject.country != null)
                    cdf.Country = rootobject.country.ToString();
                if(rootobject.released != null)
                    cdf.PublicationDate = rootobject.released.ToString();
                if (rootobject.title != null)
                    cdf.Title = rootobject.title.ToString();
                foreach(MyBiblioCDsDiscogs.Identifier id in rootobject.identifiers)
                {
                    if (id.type == "Barcode")
                    {
                        cdf.Barcode = id.value.ToString();
                        break;
                    }
                }
                if(rootobject.tracklist.Length > 0)
                {
                    foreach (MyBiblioCDsDiscogs.Tracklist trk in rootobject.tracklist)
                    {
                        trNum = trk.position;
                        TTitleTrack = trk.title;
                        duration = trk.duration;
                        Track_AU tr = new Track_AU(trNum, TTitleTrack, duration);
                        cdf.LTracks.Add(tr);
                    }
                }
                Global.listcdfound.Add(cdf);
                _cdfound.numTracks = cdf.LTracks.Count;
            }
        } // End of Manualsearch II Vers

        private static List<string> Extractor(string page, string Title, List<string> Resource_Url, bool res_url=false)
        {
            List<string> Urlimg = new List<string>();
            Rootobject rootobject = System.Text.Json.JsonSerializer.Deserialize<Rootobject>(page);
            Title = Title.Replace('+', ' ');
            if(rootobject.results.Length == 0)
                return null;
            for (int j = 0; j < rootobject.pagination.pages; j++)
            {
                for (int i = 0; i < rootobject.pagination.per_page; i++)
                {
                    Result mom = rootobject.results.ElementAt(i);
                    if (mom.title.ToLower().Contains(Title.ToLower()))
                    {
                        if (mom.cover_image != null && mom.cover_image != string.Empty)
                            Urlimg.Add(mom.cover_image);
                        if (mom.thumb != null && mom.thumb != string.Empty)
                            Urlimg.Add(mom.thumb);
                        if(res_url && mom.resource_url != null && mom.resource_url != string.Empty)
                            Resource_Url.Add(mom.resource_url);
                    }
                    else
                        continue;
                }
                if (Urlimg.Count >= 30)
                    break;
                string next = rootobject.pagination.urls.next;
                page = string.Empty;
                page = webService.webcall(next);
            }
            return Urlimg;
        }
    }
}
