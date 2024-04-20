using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiblioCDs
{
    /// <summary>
    /// Class for the list of all drivers present. opcl open or closed
    /// </summary>
    public class CmbBxDRV
    {
        /// <summary>
        /// Get and Set drv 
        /// </summary>
        public string drv { get; set; }
        /// <summary>
        /// get and Set opcl
        /// </summary>
        public bool opcl { get; set; }

        /// <summary>
        /// ComboBox for Drives
        /// </summary>
        /// <param name="inp">drive Name</param>
        /// <param name="st">Status</param>
        public CmbBxDRV(string inp, bool st)
        {
            drv = inp;
            opcl = st;

        }
    }
}
