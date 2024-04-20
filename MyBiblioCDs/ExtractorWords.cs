using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using PdftoText;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Threading;
using ICSharpCode.SharpZipLib.Core;
using System.Runtime.InteropServices;
using Microsoft.Vbe.Interop;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

#pragma warning disable CS1591

namespace MyBiblioCDs
{
    /// <summary>
    /// The Extractor
    /// </summary>
    public class ExtractorWords : IEquatable<ExtractorWords>
    {

        public int numfile { get; set; }
        public string word { get; set; }
        public bool Equals(ExtractorWords ot)
        {
            if (Object.ReferenceEquals(ot, null))
                return false;
            if (Object.ReferenceEquals(this, ot)) return true;
            return word.Equals(ot.word) && numfile.Equals(ot.numfile);
        }
        public ExtractorWords(int innumfls, string inword)
        {
            numfile = innumfls;
            word = inword;
        }
    }

    public class Extractor 
    {
        private static IntPtr _hook;
        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        private readonly WinEventDelegate _winEventProc = new WinEventDelegate(WinEventCallback);
        public static uint idprocessnewword;
        public static Process CtrlWord = null;
        static string[] NameClassNoModalWord = { "#32770", "bosa_sdm_msword", "NUIDialog" };
        const uint WINEVENT_SKIPOWNPROCESS = 0x0002;
        const uint PM_NOREMOVE = 0;
        const uint PM_REMOVE = 1;
        const uint WM_QUIT = 0x0010;
        const int SW_RESTORE = 9;

        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public IntPtr Hwnd;
            public uint Message;
            public IntPtr WParam;
            public IntPtr LParam;
            public uint Time;
        }

        // Delegate Func callback
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        #region IMPORT_USER32
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool PeekMessage(out MSG lpMsg, IntPtr hwnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
        [DllImport("user32.dll")]
        private static extern bool TranslateMessage(ref MSG lpMsg);
        [DllImport("user32.dll")]
        private static extern IntPtr DispatchMessage(ref MSG lpMsg);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        
        [DllImport("user32.dll")] 
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")] [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        #endregion //IMPORT_USER32

        // CONST STANDARD
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOSIZE = 0x0001;
        const uint WINEVENT_OUTOFCONTEXT = 0x0000;
        const uint WINEVENT_SKIPOWNTHREAD = 0x0001;
        const uint EVENT_SYSTEM_DIALOGSTART = 0x0010;
        const int MAX_LENGTH_WORD = 50;
        const int WINEVENT_INCONTEXT = 4;
        public static bool windowsnum = false;
        static bool goagain;

        public List<ExtractorWords> ExtractWordsNew(string pathfile, int PkFile, int casus = 0)
        {
            string text = string.Empty;
            using (StreamReader sr = new StreamReader(pathfile))
            {
                if (casus == 1)
                {
                    System.Windows.Forms.RichTextBox box = new System.Windows.Forms.RichTextBox();
                    box.Rtf = System.IO.File.ReadAllText(pathfile);
                    text = box.Text;
                }
                else if (casus == 2)
                {
                    Extractor _extr = new Extractor();
                    //text = Extractor.WordExtract(pathfile);
                    text = _extr.WordExtract(pathfile);
                }
                else if(casus == 3)
                    text = PdfExtract(pathfile);
                else
                    text = sr.ReadToEnd();
                text = removePat(text, @"\d");
                text = text.ToLower();
            }
            return CreateList(PkFile, text);
        } // End of ExtractWordsNew

        Process ProcessWinwordCotroll(List<Process> WinwordListPreCall)
        {
            List<Process> ListAfterCallWW = Process.GetProcessesByName("WINWORD").ToList();
            if(WinwordListPreCall.Count == 0)
                return (ListAfterCallWW.First());
            return (ListAfterCallWW.Except(WinwordListPreCall, new ProcessComparer()).ToList()).First();
        }

        static List<WindowInfo>  GetAllWindows(Process process, uint processId = 0)
        {
            List<WindowInfo> windows = new List<WindowInfo>();
            // 1, 2, 3 are the same 
            // 1. IntPtr hWndd = (IntPtr)FindWindow(null, @"MyBiblioCds");
            // 2. var hww = FindWindowByCaption(IntPtr.Zero, @"MyBiblioCds");
            // 3. var hwHn = this.Handle;

            // Process Handle and Id-Process
            IntPtr processHandle = Process.GetCurrentProcess().Handle;
            {
                //processHandle = process.Handle;
                EnumWindows((hWnd, lParam) =>
                {
                    // Id of the process that created the window
                    uint windowPrId;
                    GetWindowThreadProcessId(hWnd, out windowPrId);
                    if (windowPrId == (uint)processId)
                    {
                        // Caption von Window
                        StringBuilder title = new StringBuilder(1024);
                        StringBuilder className = new StringBuilder(1024);
                        GetWindowText(hWnd, title, title.Capacity);
                        GetClassName(hWnd, className, className.Capacity);
                        // Add List obj WindowInfo
                        WindowInfo window = new WindowInfo();
                        window.Handle = hWnd;
                        window.ProcessId = (int)windowPrId;
                        window.Title = title.ToString();
                        window.ClassName = className.ToString();
                        windows.Add(window);
                    }
                    return true;
                }, IntPtr.Zero);
            }
            return windows;
        }
        public List<ExtractorWords> CreateList(int PkFile, string text)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            String pattern;
            Regex rgx;
            pattern = @"\w+";
            rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(text);
            List<ExtractorWords> WordsList = new List<ExtractorWords>();
            foreach (Match m in matches)
                if(m.Value.Length > 2 && m.Value.Length <= MAX_LENGTH_WORD && m.Value.All(c => Char.IsLetterOrDigit(c) && (c < 254)))
                    WordsList.Add(new ExtractorWords(PkFile, m.Value));
            var uniqueItemsList = WordsList.Distinct().ToList();
            stopwatch.Stop();
            LogProj.Info("CreateList = " + stopwatch.Elapsed);

            return uniqueItemsList;
        } // End of CreateList


        public string WordExtract(object pathfile) //, CancellationToken ct/*, ref Microsoft.Office.Interop.Word.Application word*/)
        {
            LogProj.Info("Begin WordExtract");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Microsoft.Office.Interop.Word.Application word =null;
            Document doc = null;// = new Microsoft.Office.Interop.Word.Document();
            windowsnum = false;
            string text = string.Empty;
            // Create a new Word application instance
            try
            {
                var ListnumWorProcess = Process.GetProcessesByName("WINWORD").ToList();
                word = new Microsoft.Office.Interop.Word.Application();
                idprocessnewword =(uint)(Process.GetProcessesByName("WINWORD").First()).Id; 
                word.Visible = false;
                object missing = System.Type.Missing;
                object dontsave = WdSaveOptions.wdDoNotSaveChanges;

                goagain = true;
                Thread eventThread = new Thread(SetupEventHook);
                eventThread.Name = "WordNotModalInTopMost";
                eventThread.Start();
                doc = word.Documents.Open(ref pathfile, ReadOnly: true);
                UnhookWinEvent(_hook); 
                goagain = false;
                doc.Activate();
                foreach (Microsoft.Office.Interop.Word.Range tmpRange in doc.StoryRanges)
                {
                    text += tmpRange.Text.ToLower();
                    windowsnum = true;
                }
                (word.ActiveDocument).Close(ref dontsave, ref missing, ref missing);
                word.Quit(ref dontsave, ref missing, ref missing);
                Thread.Sleep(150);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Task canceled");
            }
            catch (Exception ex)
            {
                LogProj.exception("WordExtract: " + pathfile + " " + ex.Message);
                text = "";
                if (doc != null)
                {
                    doc.Close();
                    Marshal.FinalReleaseComObject(doc);
                    LogProj.Info("WordExtract: OK");
                }
                if (word != null)
                {
                    word.Quit();
                }
                return text;
            }
            finally
            {
                if (word != null)
                {
                    LogProj.Info("WordExtract: sono in finally");
                    GC.Collect();
                    LogProj.Info("WordExtract: dopo gc.collect");
                    GC.WaitForPendingFinalizers();
                    LogProj.Info("WordExtract: sono in finally dopo GC.WaitForPendingFinalizers()");
                    LogProj.Info("doc:=" + doc);
                    doc = null;
                    LogProj.Info("word :=" + word);
                    word = null;
                }
            }
            LogProj.Info("WordExtract = chiano stopwatch");
            stopwatch.Stop();
            LogProj.Info("WordExtract = torno da stop");
            Thread.Sleep(1000);
            LogProj.Info("WordExtract = " + stopwatch.Elapsed);
            return text;
        } // End of WordExtract

        static void SetupEventHook()
        {
            // set event hook 
            _hook = SetWinEventHook(0x8000, 0x8001, IntPtr.Zero, WinEventCallback, idprocessnewword, 0, WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);
            MSG msg;
            while (goagain)
            {
                if (PeekMessage(out msg, IntPtr.Zero, 0, 0, PM_REMOVE))
                {
                    if (msg.Message == WM_QUIT)
                        break;
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
            }
            UnhookWinEvent(_hook);
        }

        /// <summary>
        /// Extract the words from the .pdf files
        /// </summary>
        /// <param name="pathfile"></param>
        /// <returns></returns>
        public static string PdfExtract(string pathfile)
        {
            StringBuilder text = new StringBuilder();

            try
            {
                text = PdftoText.ConvertPdf.Run(pathfile);
            }
            catch (Exception ex)
            {
                LogProj.exception("error in " + pathfile + " " + ex.Message);
            }
            return text.ToString();
        } // End PdfExtract
        static string removePat(string text, string Pat)
        {
            Regex rgx1 = new Regex(Pat);
            return (string)(rgx1.Replace(text, ""));
        }
        class WindowInfo
        {
            public IntPtr Handle { get; set; }
            public int ProcessId { get; set; }
            public string Title { get; set; }
            public string ClassName { get; set; }
        }

        class WindowInfoComparer : IEqualityComparer<WindowInfo>
        {
            public bool Equals(WindowInfo x, WindowInfo y)
            {
                if ((x.Title == y.Title) && (x.Handle == y.Handle) && (x.ProcessId == y.ProcessId))
                    return true;
                return false;
            }

            public int GetHashCode(WindowInfo obj)
            {
                if (obj == null) return 0;
                return obj.Handle.GetHashCode();
            }
        }
        class ProcessComparer : IEqualityComparer<Process>
        {
            public bool Equals(Process x, Process y)
            {
                if ((x.Id == y.Id))
                    return true;
                return false;
            }
            //
            //A HOAX: BUT IT WORKS
            public int GetHashCode(Process obj)
            {
                if (obj == null) return 0;
                return obj.Id;
            }
        }

       private static void WinEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
       {
            if (eventType == 0x8000 && goagain == true)
            {
               List<WindowInfo> lswnd = GetAllWindows(CtrlWord, idprocessnewword);
               
               foreach (WindowInfo y in lswnd)
               {
                    if (NameClassNoModalWord.Contains(y.ClassName)) // && y.Title != string.Empty
                    {
                        goagain = false;
                        SetWindowPos(y.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                        SetForegroundWindow(y.Handle);
                        ShowWindow(y.Handle, SW_RESTORE);
                        UnhookWinEvent(_hook);
                        break;                        
                    }
               }
                //UnhookWinEvent(_hook);
            }
        } // End of WinEventCallback
    }
}




