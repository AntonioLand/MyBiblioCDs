using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyBiblioCDsAudio
{
    class MusicBr
    {
        public static bool RetrieveImgByMusicBrainz(List<ImgCoverInfo> _coverList, ref int numfile)
        {
            string s1 = "https://musicbrainz.org/release/" + Global.choosedCD.Release_ID + "/cover-art";
            string text;
            text = webService.webcall(s1);
            if (text != string.Empty)
            {
                if (!MatchImg(ref s1, ref text, _coverList, ref numfile))
                    return false;
            }
            else
                return false;
            return true;
        } // end of RetrieveImgByMusicBrainz II

        private static bool MatchImg(ref string url, ref string text, List<ImgCoverInfo> _coverList, ref int numfile)
        {
            LogProj.Info("MatchImg(ref string url = " + url + ", ref string text = " + text + ", List<ImgCoverInfo> _coverList = " + _coverList !=null ? "Not Null" : " NULL)");
            string pattern = @"Cover Art \(\d?\)";
            Regex rx = new Regex(pattern);
            string[] div = rx.Split(text);
            
            if (div.Length >= 2)
                text = div[1];
            url = url.Remove(0, @"https://musicbrainz.org".Length);
            url = "//coverartarchive.org" + url;
            url = url.Remove(url.IndexOf(@"cover-art"), @"cover-art".Length);
            string regEX = url + @"(\d*.jpg)" + "|" + url + @"(\d*-\d*.jpg)";

            Regex rx1 = new Regex(regEX);
            MatchCollection matches = rx1.Matches(text);
            List<string> list = new List<string>();
            foreach (Match match in matches)
            {
                list.Add(match.Value);
            }
            list = list.Distinct().ToList();
            foreach (string s in list)
            {
                ImgCoverInfo element = new ImgCoverInfo
                {
                    CoverFile = "https:" + s
                };
                string ArtTit = Global.choosedCD.Artist + " " + Global.choosedCD.Title;
                RemoveUndesiredChar(ref ArtTit);
                if (webService.SavefileLocal(element.CoverFile, ArtTit, element))
                {
                    _coverList.Add(element);
                    numfile++;
                    if (!Global.ctrlnumcover && numfile >= 10)
                        break;
                }
            }
            if (numfile > 0)
                return true;
            return false;
        } // End of MatchImg II
        static private void RemoveUndesiredChar(ref string ArtTit)
        {
            ArtTit = Regex.Replace(ArtTit, "[,|!|*|+|&|~|/|\\|>|:|<|;|\"|§|°|^|$]", "");
        }
    }
}
