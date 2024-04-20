using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBiblioCDsAudio;

#pragma warning disable IDE1006, IDE0017, CS1591

namespace MyBiblioCDs
{
    /// <summary>
    /// Audio class for Audio CDs. The same class is found in the MyBiblioCDsAudio.dll library.
    /// The class is used to communicate with the library.
    /// </summary>
    public class AudioCD
    {
        public string Title             { get; set; }
        public string Artist            { get; set; }
        public string PublicationDate   { get; set; }
        public string Country           { get; set; }
        public string Barcode           { get; set; }
        public string Release_ID        { get; set; }
        public int numTracks            { get; set; }
        public string CoverArtF         { get; set; }
        public int genreMusic           { get; set; }
        public string Duration          { get; set; }

        public List<Track> tracks;
        public void _Clear()
        {
            Title = Artist = PublicationDate = Country = Barcode = Release_ID = CoverArtF = Duration = string.Empty;
            genreMusic = numTracks = 0;
            if (tracks.Count > 0)
                tracks.Clear();
            tracks = null;
        }

        public AudioCD()
        {
            Title = string.Empty;
            Artist = string.Empty;
            PublicationDate = string.Empty;
            Country = string.Empty;
            Barcode = string.Empty;
            Release_ID = string.Empty;
            genreMusic = -1;
            List<Track> tracks = new List<Track>();
            Duration = string.Empty;
        }

        static public void copyat(MyBiblioCDsAudio.Audio_CD source, ref AudioCD dest)
        {
            char[] buf = new char[256];
            if (source.Title.Length > 0)
            {
                source.Title.CopyTo(0, buf, 0, source.Title.Length);
                dest.Title = string.Join("", buf);
                dest.Title = dest.Title.Substring(0, source.Title.Length);
                dest.cleararray(buf);
            }

            if (source.Artist.Length > 0)
            {
                source.Artist.CopyTo(0, buf, 0, source.Artist.Length);
                dest.Artist = (string.Join("", buf)).Substring(0, source.Artist.Length);
                dest.cleararray(buf);
            }
            if (source.PublicationDate.Length > 0)
            {
                source.PublicationDate.CopyTo(0, buf, 0, source.PublicationDate.Length);
                dest.PublicationDate = (string.Join("", buf)).Substring(0, source.PublicationDate.Length);
                dest.cleararray(buf);
            }

            if (source.Country.Length > 0)
            {
                source.Country.CopyTo(0, buf, 0, source.Country.Length);
                dest.Country = (string.Join("", buf)).Substring(0, source.Country.Length);
                dest.cleararray(buf);
            }

            if (source.Barcode.Length > 0)
            {
                source.Barcode.CopyTo(0, buf, 0, source.Barcode.Length);
                dest.Barcode = (string.Join("", buf)).Substring(0, source.Barcode.Length);
                dest.cleararray(buf);
            }
            
            if (source.CoverArtF != null && source.CoverArtF.Length > 0)
            {
                source.CoverArtF.CopyTo(0, buf, 0, source.CoverArtF.Length);
                dest.CoverArtF = (string.Join("", buf)).Substring(0, source.CoverArtF.Length);
                dest.cleararray(buf);
            }
            if (source.genreMusic != -1)
                dest.genreMusic = source.genreMusic;

            if (source.Release_ID != null && source.Release_ID.Length > 0)
            {
                source.Release_ID.CopyTo(0, buf, 0, source.Release_ID.Length);
                dest.Release_ID = (string.Join("", buf)).Substring(0, source.Release_ID.Length);
                dest.cleararray(buf);
            }

            if (source.Duration.Length > 0)
            {
                source.Duration.CopyTo(0, buf, 0, source.Duration.Length);
                dest.Duration = (string.Join("", buf)).Substring(0, source.Duration.Length);
                dest.cleararray(buf);
            }
            dest.numTracks = source.numTracks;
            dest.copyTracks(source.LTracks, buf);
        }

        private void copyTracks(BindingList<MyBiblioCDsAudio.Track_AU> source, char[] buf)
        {
            this.tracks = new List<Track>();
            
            foreach (MyBiblioCDsAudio.Track_AU tr in source)
            {
                Track tc = new Track();
                tc.TrNum = tr.TrNum;
                if(tr.TitleTrack.Length > 0)
                {
                    tr.TitleTrack.CopyTo(0, buf, 0, tr.TitleTrack.Length);
                    tc.TitleTrack = string.Join("", buf);
                    tc.TitleTrack = tc.TitleTrack.Substring(0, tr.TitleTrack.Length);
                    cleararray(buf);
                }
                tc.Duration = tr.Duration;
                tracks.Add(tc);
            }
        }
        private void cleararray(char[] buf)
        {
            for (int i = 0; (i < 256) && (buf[i] != '\0'); i++)
                buf[i] = '\0';
        }
    }
}
