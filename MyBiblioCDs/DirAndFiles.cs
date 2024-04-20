using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591

namespace MyBiblioCDs
{

    /// <summary>
    /// The class is for the list of items in the ListView
    /// </summary>
    public class DirAndFiles
    {
        public string directoryInfos { set; get; }
        public List<InfoFiles> FilesInfos = new List<InfoFiles>();
    }

    /// <summary>
    /// La classe contiene le informazioni che saranno salvate nel DB
    /// </summary>
    public class InfoFiles
    {
        public FileInfo thisfile;
        public bool chck = false;
        public StringBuilder notes;
        public string hashcode;
        public List<NOTE> nota;

        public InfoFiles(FileInfo fl)
        {
            thisfile = fl;
            notes = null;
            chck = false;
        }
        public InfoFiles(FileInfo fl, NOTE nt)
        {
            thisfile = fl;
            notes = null;
            chck = false;
            if(nota == null)
            { 
                nota = new List<NOTE>(); 
            }
            nota.Add(new NOTE(nt.textNote, nt.codenote));
        }
    } 

    /// <summary>
    /// 
    /// </summary>
    public class NOTE
    {
        public StringBuilder textNote { get; set; }
        public int idFiles { get; set; }
        public int codenote = -1; // 0 == CD 1 == File 2 == Text

        public NOTE()
        {
        }

        public NOTE(StringBuilder textnota, int typenote)
        {
            textNote = new StringBuilder();
            textNote.Append(textnota);
            codenote = typenote;
        }
    }
}
