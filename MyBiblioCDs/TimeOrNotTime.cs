using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioCDs
{
    internal class TimeOrNotTime
    {
        public TimeOrNotTime()
        {
        }

        public bool TimeOnly(ref string whatis)
        {
            string[] HMS;
            string sbs = string.Empty;
            
            int numstr;
            HMS = whatis.Split(':');
            if (HMS.Length == 1)
            {
                return false;
            }
            if (HMS.Length == 2)
            {
                string[] hmsSwap = new string[3];
                hmsSwap[2] = HMS[1];
                hmsSwap[1] = HMS[0];
                hmsSwap[0] = "00";
                HMS = null;
                HMS = new string[3];
                HMS = hmsSwap;
            }
            if (HMS[0].Length == 1)
                sbs = "0" + HMS[0] + ":";
            else
                sbs = HMS[0] + ":";
            if (HMS[1].Length == 1)
                sbs += "0" + HMS[1] + ":";
            else
                sbs += HMS[1] + ":";
            if (HMS[2].Length == 1)
                sbs += "0" + HMS[2];
            else
                sbs += HMS[2];

            bool number = true;
            if (HMS[0] != null && HMS[1].Length > 0)
            {
                number = int.TryParse(HMS[0], out numstr);
                if (!number)
                    return number;
            }
            if (HMS[1] != null && HMS[1].Length > 0)
            {
                number = int.TryParse(HMS[1], out numstr);
                if (!number)
                    return number;
            }
            if (HMS[2] != null && HMS[2].Length > 0)
            {
                number = int.TryParse(HMS[2], out numstr);
                if (!number)
                    return number;
            }
            whatis = sbs;
            return true;
        }
    }
}
