using ICSharpCode.SharpZipLib.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable IDE1006, IDE0017, CS1591
namespace MyBiblioCDs
{
    public partial class MainForm : Form //, IDisposable
    {
        CancellationTokenSource source = new CancellationTokenSource();
        //CancellationToken token;
        /// <summary>
        /// Call extractors for file types
        /// </summary>
        /// <param name="ext">ext file</param>
        /// <param name="filename">File Name</param>
        /// <param name="PkFile">Primary Key in DB</param>
        /// <returns></returns>
        private List<ExtractorWords> WordTextExtrakt(string ext, string filename, int PkFile)
        {
            switch (ext)
            {
                case ".rtf":
                    return PreExtract.SelectExtractor(filename, PkFile,/* token,*/ 1);
                case ".doc":
                case ".docx":
                case ".dcx":
                case ".odt":
                    return PreExtract.SelectExtractor(filename, PkFile, /* token,*/ 2);
                case ".pdf":
                default:
                    return PreExtract.SelectExtractor(filename, PkFile, /* token, */ 4);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BigList">List of words </param>
        /// <param name="ext">files extension</param>
        /// <param name="filename"> </param>
        /// <param name="PkFile"></param>
        private void casusText(ref List<ExtractorWords> BigList, string ext, string filename, int PkFile)
        {
            List<ExtractorWords> WordList = null;
            WordList = WordTextExtrakt(ext, filename, PkFile);
            if (WordList != null && WordList.Count > 0)
            {
                BigList = BigList.Concat(WordList).ToList();
            }
        } // End of casusText

        /// <summary>
        /// For program files
        /// </summary>
        /// <param name="NumWordsPro"></param>
        /// <param name="filename"></param>
        /// <param name="PkFile"></param>
        /// <param name="wls"></param>
        /// <param name="KEYWORDS"></param>
        private void casusProgFile(ref int NumWordsPro, string filename, int PkFile, List<ExtractorWords> wls, List<string> KEYWORDS)
        {
            wls = PreExtract.ExtractWordsProgram(filename, PkFile, KEYWORDS);
            if (wls != null && wls.Count > 0)
            {
                if (wls.Count > 1000)
                {
                    if (!Insert1000WordProg(wls, ref NumWordsPro, ref PkFile))
                    {
                        MessageBox.Show(Languages.ProblemDB);
                    }
                }
                else
                {
                    DbFunction.InsertWordProg(wls);

                }
                NumWordsPro += wls.Count;
                wls.Clear();
            }
        } // End of casusProgFile

        private bool Insert1000WordProg(List<ExtractorWords> WordList, ref int NumWordsPro, ref int PkFile)
        {
            int it = (int)(WordList.Count / 1000);
            List<ExtractorWords> moment = new List<ExtractorWords>();
            for (int j = 1; j <= it; j++)
            {
                moment.AddRange(WordList.Take(1000));
                if (!DbFunction.InsertWordProg(moment))
                    return false;
                NumWordsPro += moment.Count;
                moment.Clear();
                WordList.RemoveRange(0, 1000);
            }
            if (WordList.Count > 0)
            {
                if (!DbFunction.InsertWordProg(WordList))
                    return false;
                NumWordsPro += WordList.Count;
                WordList.Clear();
            }
            return true;
        } // End Insert1000Word
    }
}
