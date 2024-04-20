using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

#pragma warning disable CS1591

namespace MyBiblioCDs
{
    /// <summary>
    /// The class is for the open and close button of cds drivers.
    /// </summary>
    public class CDDRIVE
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        protected static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);

        public void openDriver(string strDriveLetter)
        {
            mciSendString("open " + strDriveLetter + " type cdaudio alias cdrom", null, 0, IntPtr.Zero);
            int ret = mciSendString("set cdrom door open", null, 0, IntPtr.Zero);
            mciSendString("close cdrom", null, 0, IntPtr.Zero);
        }

        public void close(string strDriveLetter)
        {
            mciSendString("open " + strDriveLetter + ":\\ type cdaudio alias cdrom", null, 0, IntPtr.Zero);
            int ret = mciSendString("set cdrom door closed", null, 0, IntPtr.Zero);
            mciSendString("close cdrom", null, 0, IntPtr.Zero);
        }
    }
}
