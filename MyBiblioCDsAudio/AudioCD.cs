using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBoxTime;

namespace MyBiblioCDsAudio
{
    /// <summary>
    /// The same class can be found in the main program. The class contains all the information from the audio CD
    /// </summary>
    public class Audio_CD : IDisposable
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string PublicationDate { get; set; }
        public string Country { get; set; }
        public string Barcode { get; set; }
        public string Release_ID { get; set; }
        public int numTracks { get; set; }
        public string CoverArtF { get; set; }
        public int genreMusic { get; set; }
        public string Duration { get; set; }
        
        public BindingList<Track_AU> LTracks;

        public Audio_CD()
        {
            Title = string.Empty;
            Artist = string.Empty;
            PublicationDate = string.Empty;
            Country = string.Empty;
            Barcode = string.Empty;
            Release_ID = string.Empty;
            CoverArtF = string.Empty;
            genreMusic = -1;
            Duration = string.Empty;
            LTracks = new BindingList<Track_AU>();
        }
        public void Cpy(ref Audio_CD par)
        {
            char[] buf = new char[256];

            if (Title.Length > 0)
            {
                Title.CopyTo(0, buf, 0, Title.Length);
                par.Title = string.Join("", buf);
                par.Title = par.Title.Substring(0, Title.Length);
                cleararray(buf);
            }
            if (Artist.Length > 0)
            {
                Artist.CopyTo(0, buf, 0, Artist.Length);
                par.Artist = (string.Join("", buf)).Substring(0, Artist.Length);
                cleararray(buf);
            }
            if (CoverArtF.Length > 0)
            {
                CoverArtF.CopyTo(0, buf, 0, CoverArtF.Length);
                par.CoverArtF = (string.Join("", buf)).Substring(0, CoverArtF.Length);
                cleararray(buf);
            }
            if (PublicationDate != null && PublicationDate.Length > 0)
            {
                PublicationDate.CopyTo(0, buf, 0, PublicationDate.Length);
                par.PublicationDate = (string.Join("", buf)).Substring(0, PublicationDate.Length);
                cleararray(buf);
            }

            if (Country.Length > 0)
            {
                Country.CopyTo(0, buf, 0, Country.Length);
                par.Country = (string.Join("", buf)).Substring(0, Country.Length);
                cleararray(buf);
            }

            if (Barcode.Length > 0)
            {
                Barcode.CopyTo(0, buf, 0, Barcode.Length);
                par.Barcode = (string.Join("", buf)).Substring(0, Barcode.Length);
                cleararray(buf);
            }
            else
                par.Barcode = "";

            if (Release_ID.Length > 0)
            {
                Release_ID.CopyTo(0, buf, 0, Release_ID.Length);
                par.Release_ID = (string.Join("", buf)).Substring(0, Release_ID.Length);
                cleararray(buf);
            }
            else
                par.Release_ID = "";

            if (Duration.Length > 0)
            {
                Duration.CopyTo(0, buf, 0, Duration.Length);
                par.Duration = (string.Join("", buf)).Substring(0, Duration.Length);
                cleararray(buf);
            }
            else
                par.Duration = "";
            if (genreMusic >= 0)
                par.genreMusic = genreMusic;
            if (LTracks != null)
            {   
                List<Track_AU> momls= new List<Track_AU>(this.LTracks);
                par.copyTracks(momls, buf);
            }
        }

        private void copyTracks(List<MyBiblioCDsAudio.Track_AU> source, char[] buf)
        {
            foreach (MyBiblioCDsAudio.Track_AU tr in source)
            {
                Track_AU tc = new Track_AU();
                tc.TrNum = tr.TrNum;
                if (tr.TitleTrack != null && tr.TitleTrack.Length > 0)
                {
                    tr.TitleTrack.CopyTo(0, buf, 0, tr.TitleTrack.Length);
                    tc.TitleTrack = string.Join("", buf);
                    tc.TitleTrack = tc.TitleTrack.Substring(0, tr.TitleTrack.Length);
                    cleararray(buf);
                }
                if (tr.Duration.Length == 0)
                    tc.Duration = "00:00:00";
                else
                {
                    TextControlHMS mom= new TextControlHMS();
                    tc.Duration = TextBoxTime.TextControlHMS.ctrTimeisOk(tr.Duration);
                }
                LTracks.Add(tc);
            }
        }

        private void cleararray(char[] buf)
        {
            for (int i = 0; (i < 256) && (buf[i] != '\0'); i++)
                buf[i] = '\0';
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                 GC.Collect();
            }
        }
    }
}
