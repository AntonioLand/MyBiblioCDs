using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioCDsAudio
{
    public class ImgCoverInfo
    {
        public string CoverFile { get; set; }
        public string CoverImgSize { get; set; }
        public string NameCover { get; set; }
        public int numCover { get; set; }
        public ImgCoverInfo() { numCover++; }
        public ImgCoverInfo(string pcf, string pcs, string pnc, int pnumc)
        {
            CoverFile = pcf;
            CoverImgSize = pcs;
            NameCover = pnc;
            numCover = pnumc;
        }
    }
}
