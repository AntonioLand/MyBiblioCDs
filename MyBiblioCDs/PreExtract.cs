using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using PdftoText;
using System.Data;
using LibVLCSharp.Shared;
using System.Xml.Xsl;
using System.Dynamic;
using static System.Net.WebRequestMethods;
using System.Diagnostics;

namespace MyBiblioCDs
{
    /// <summary>
    /// Decides which extractor is to be called.
    /// </summary>
    static public class PreExtract
    {
        /// <summary>
        /// For each file type, call the appropriate word extractor. For each Word the primary key of the file is associated
        /// </summary>
        /// <param name="pathfile">full path to the file</param>
        /// <param name="PkFile">Primary Key</param>
        /// <param name="casus">It depends on the type of file</param>
        /// <returns></returns>
        static public List<ExtractorWords> SelectExtractor(string pathfile, int PkFile, int casus = 0)
        {
            LogProj.Info("SelectExtractor Begin");
            string text = string.Empty;
            List<ExtractorWords> WordsList = null;
            Extractor _extr = new Extractor();
            try
            {
                using (StreamReader sr = new StreamReader(pathfile))
                {
                    if (casus == 1)
                    {
                        RichTextBox box = new RichTextBox();
                        box.Rtf = System.IO.File.ReadAllText(pathfile);
                        text = box.Text;
                    }
                    else if (casus == 2)
                    {
                        return _extr.ExtractWordsNew(pathfile, PkFile, 2);
                    }
                    else if (casus == 3)
                        text = Extractor.PdfExtract(pathfile);
                    else
                        text = sr.ReadToEnd();
                    text = removePat(text, @"\d");
                    text = text.ToLower();
                    WordsList = _extr.CreateList(PkFile, text);
                }
                return WordsList;
            }
            catch (ArgumentException ex)
            {
                LogProj.exception(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                LogProj.exception(ex.Message);
            }
            catch (IOException ex)
            {
                LogProj.exception(ex.Message);
            }
            LogProj.Info("SelectExtractor end");
            return null;
        } // End of SelectExtractor

        /// <summary>
        /// ExtractWordsProgram 
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="PkFile"></param>
        /// <param name="KEYWORDS"></param>
        /// <returns></returns>
        static public List<ExtractorWords> ExtractWordsProgram(string FullName, int PkFile, List<string> KEYWORDS)
        {
            List<ExtractorWords> WordsList = new List<ExtractorWords>();
            List<string> wls = new List<string>();
            Extractor _extr = new Extractor();
            using (StreamReader sr = new StreamReader(FullName))
            {
                string text;
                text = sr.ReadToEnd();
                text = removePat(text, @"\d");
                text = removePat(text, KEYWORDS);
                WordsList = _extr.CreateList(PkFile, text);
                return WordsList;
            }
        } // ExtractWordsProgram

        static string removePat(string text, string Pat)
        {
            Regex rgx1 = new Regex(Pat);
            return (string)(rgx1.Replace(text, ""));
        } // removePat
        static string removePat(string text, List<string> Pat)
        {
            string s = text;
            foreach (string pt in Pat)
            {
                Regex rgx1 = new Regex(pt);
                s = (string)(rgx1.Replace(s, ""));
            }
            return s;
        } // End of removePat

    }
}
