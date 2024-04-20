using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591

namespace MyBiblioCDs
{
    public class Track
    {
        public string TrNum { get; set; }
        public string TitleTrack { get; set; }
        public string Duration { get; set; }
        public string ExtendedData { get; set; }

        public Track()
        {
        }
        public Track(string title)
        {
            TitleTrack = title;
        }
        public Track(string title, string extendedData)
        {
            TitleTrack  = title;
            Duration    = extendedData;
        }
    }
}
