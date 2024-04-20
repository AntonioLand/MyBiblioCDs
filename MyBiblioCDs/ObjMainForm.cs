using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006, IDE0017,CS1591

namespace MyBiblioCDs
{
    /// <summary>
    /// This class stores all the information in the main window.
    /// </summary>
    public class ObjMainForm
    {
        public string drive { get; set; }
        public string cdname { get; set; }
        public int cdnum { get; set; }
        public string cdnote { get; set; }
        public string position { get; set; }
        public DateTime createdate { get; set; }
        public int cdtype { get; set; }
        public string Unic_IDCD { get; set; }
        public bool autorunYN { get; set; }
        public bool indwexWord { get; set; }
        public string CoverPath { get; set; }
        public void _Clear()
        {
            drive = cdname = cdnote = position = Unic_IDCD = string.Empty;
            createdate = DateTime.MinValue;
            cdtype = cdnum = -1;
            autorunYN = indwexWord = false;
            CoverPath = string.Empty;
        }
    }
}

