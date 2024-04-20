using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioCDsAudio
{
    public class Track_AU
    {
        public string TrNum { get; set; }
        public string TitleTrack { get; set; }
        public string Duration { get; set; }

        public Track_AU(string tr, string tit, string dur)
        {
            TrNum = tr;
            TitleTrack = tit;
            Duration = dur;
        }
        public Track_AU() { }

    }
}
