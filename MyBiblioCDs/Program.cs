using LibVLCSharp.Shared;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBiblioCDs
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            IsRunnning();
            LogProj.SetLogFile(partialfilename: "MyBiblioLog_");

            if (FirstTime())
            {
                return;
            }
            Application.Run(new MainForm());
        }
        public static bool FirstTime()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MyBiblioCDs");
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MyBiblioCDs");
                    if (key != null)
                    {
                        key.SetValue("CdNum", 0, RegistryValueKind.DWord);
                        string path = Environment.CurrentDirectory;
                        key.SetValue("DirFileMyBiblioCDs", path + "\\.fl\\", RegistryValueKind.String);
                        FolderBrowserDialog folderBrowseDlgCover = new FolderBrowserDialog();
                        folderBrowseDlgCover.Description = "Select a directory for CD covers.";
                        DialogResult dir = folderBrowseDlgCover.ShowDialog();
                        if(dir == DialogResult.OK)
                        {
                            string Path = folderBrowseDlgCover.SelectedPath + "\\";
                            key.SetValue("MyBiblioCDCoverArt", Path, RegistryValueKind.String);
                        }
                        CultureInfo culture = CultureInfo.CurrentUICulture;
                        key.SetValue("Language", culture.Name, RegistryValueKind.String);
                        key.SetValue("ChkFilesDir", path + "\\.fl\\ChkFiles\\", RegistryValueKind.String);
                        key.SetValue("NoHash", path + "\\.fl\\extHash.txt", RegistryValueKind.String);
                        key.SetValue("discogs", path + "\\.fl\\DiscoGs.jpg", RegistryValueKind.String);
                        key.SetValue("musicbrainz", path + "\\.fl\\musicbrainz.jpg", RegistryValueKind.String);
                        key.SetValue("DataSource", "Data Source=(local); Initial Catalog = MyBiblioCDsDB; Integrated Security = True", RegistryValueKind.String);
                        string TmpPath = System.IO.Path.GetTempPath();
                        DirectoryInfo TmpDir = new DirectoryInfo(TmpPath);
                        TmpDir.CreateSubdirectory("MyBiblioCDs");

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return true;
            }
            return false;
        }

        static void IsRunnning()
        {
            Process[] processes = Process.GetProcessesByName("MyBiblioCDs");

            if (processes.Length > 1)
            {
                MessageBox.Show("The program is already running.");
                Environment.Exit(1);
            }

            // Codice del programma
        }
    }
}
