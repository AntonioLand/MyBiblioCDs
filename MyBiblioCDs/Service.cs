using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591


namespace MyBiblioCDs
{
    public static class Service
    {
        public const long OneKb = 1024;
        public const long OneMb = OneKb * 1024;
        public const long OneGb = OneMb * 1024;

        public static int WhatiS(DriveInfo drive)
        {
            int driveis = 0;
            if (drive.DriveType == DriveType.CDRom)
            {
                if (drive.VolumeLabel == "Audio CD")
                    driveis = 1;
                else if (drive.TotalSize <= 700 * OneMb)
                    driveis = 2; // CDRom
                else if (drive.TotalSize > 700 * OneMb && drive.TotalSize <= 4.7 * OneGb)
                    driveis = 3; // DVD
                else if ((drive.TotalSize > 4.7 * OneGb && drive.TotalSize < 9.4 * OneGb))// || drive.DriveFormat == "UDF")
                    driveis = 4; // DVD
                else if (drive.TotalSize > 9.4 * OneGb && drive.TotalSize < 27 * OneGb)
                    driveis = 5; // Blu Ry
            }
            else if (drive.DriveType == DriveType.Removable)
                driveis = 6; // USB
            return driveis;
        } /* End of public static int whatis(string NameDriver) */

        public static string BytesAsString(float bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double doubleBytes = 0;

            for (i = 0; (int)(bytes / 1024) > 0; i++, bytes /= 1024)
            {
                doubleBytes = bytes / 1024.0;
            }

            return string.Format("{0:0.00} {1}", doubleBytes, suffix[i]);
        }

        public static int DVDAnalyse(string rt)
        {
            DirectoryInfo root = new DirectoryInfo(rt);
            DirectoryInfo[] dirs = root.GetDirectories("VIDEO_TS");
            if (dirs.Length > 0)
                return 1;
            else
                return 0;
        }
        public static int ToElaborateCD(string NameDriver, DriveInfo[] allDrives)
        {
            LogProj.Info("ToElaborateCD");
            int i = 0;
            for (; allDrives[i].Name != NameDriver; i++) ;
            if (!allDrives[i].IsReady)
            {
                LogProj.Info("End ToElaborateCD -1");
                return -1;
            }
            else
            {
                LogProj.Info("End ToElaborateCD 1");
                return i;
            }
        }
    }
}
