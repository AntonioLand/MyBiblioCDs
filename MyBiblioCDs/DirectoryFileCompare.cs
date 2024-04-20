using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591


namespace MyBiblioCDs
{
    /// <summary>
    /// Compare files and directories
    /// </summary>
    public class DirCompare : IComparer
    {
        public int Compare(object first, object second)
        {
            DirectoryInfo dir1 = (DirectoryInfo)first;
            DirectoryInfo dir2 = (DirectoryInfo)second;
            return dir1.Name.CompareTo(dir2.Name);
        }
    }

    public class FileCompare : IComparer
    {
        public int Compare(object first, object second)
        {
            FileInfo file1 = (FileInfo)first;
            FileInfo file2 = (FileInfo)second;
            return file1.Name.CompareTo(file2.Name);
        }
    }
}
