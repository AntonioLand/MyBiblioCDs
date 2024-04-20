using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MyBiblioCDsAudio
{
    public static class Global
    {
        public static BindingList<Audio_CD> listcdfound = new BindingList<Audio_CD>();
        public static Audio_CD choosedCD = new Audio_CD();
        public static bool ctrlnumcover = false;
        public static bool saveTracks = false;
        public static string decodeDummChar(string todec)
        {
            Encoding enc = Encoding.UTF8;
            byte[] bytes = Encoding.Default.GetBytes(todec);
            string decstring = enc.GetString(bytes);
            decstring = HttpUtility.HtmlDecode(decstring);
            if (decstring.Contains("â€™"))
                decstring = decstring.Replace("â€™", "'");
            return decstring;

        }
        public static void savetracks(ref DataGridView tr, ref BindingSource binds)
        {
            Object bs = tr.DataBindings;
            tr.Refresh();
            for (int i =  Global.choosedCD.LTracks.Count-1; i >= 0; i--) 
            {
                if(Global.choosedCD.LTracks.ElementAt(i).TrNum == null || Global.choosedCD.LTracks.ElementAt(i).TrNum == string.Empty ||
                    Global.choosedCD.LTracks.ElementAt(i).TitleTrack == null || Global.choosedCD.LTracks.ElementAt(i).TitleTrack == string.Empty ||
                    Global.choosedCD.LTracks.ElementAt(i).Duration == null || Global.choosedCD.LTracks.ElementAt(i).Duration == string.Empty)
    
                    Global.choosedCD.LTracks.RemoveAt(i);
            }
        }

        public static void Clear()
        {
            choosedCD.LTracks.Clear();
            choosedCD.Dispose();
            if(listcdfound.Count > 0)
            {
                foreach(Audio_CD y in listcdfound)
                {
                    y.LTracks.Clear();
                }
                listcdfound.Clear();
            }
        }
    }
}
