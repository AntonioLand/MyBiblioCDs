using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyBiblioCDsAudio
{
    public static class LogProj
    {
        #region Enum
        public enum LevelMsg
        {
            Info,
            Warning,
            FatalError,
            Exception
        };
        #endregion
        #region Fields
        private static DirectoryInfo currentlogDir = new DirectoryInfo(Directory.GetCurrentDirectory());
        private static string dirLog = "Log";
        private static string PartialFileName;
        private static string dateFormat;
        private static string extensionfilename;
        private static XDocument XmlLog;
        private static LevelMsg logLevel = LevelMsg.Info;
        private static string FullFileName = null;
        private static readonly object LockFile = new object();
        private static string textSeparator = " #|# ";
        #endregion

        #region Propriert
        public static string LogDir
        {
            get
            {
                return currentlogDir.FullName;
            }
        }

        public static string Fullfilename
        {
            get
            {
                return FullFileName;
            }
            set
            {
                FullFileName = value;
            }
        }
        public static string Prefix
        {
            get
            {
                return PartialFileName ?? string.Empty;
            }
            set
            {
                PartialFileName = value;
            }
        }
        public static string ExtensionFileName
        {
            get
            {
                return extensionfilename ?? "xml";
            }
            set
            {
                extensionfilename = value;
            }
        }

        public static string DateFormat
        {
            get
            {
                return dateFormat ?? "dd_MM_yyyy";
            }
            set
            {
                dateFormat = value;
            }
        }

        public static LevelMsg LogLevel
        {
            get
            {
                return logLevel;
            }
            set
            {
                logLevel = value;
            }
        }

        public static string TextSeparator
        {
            get
            {
                return textSeparator;
            }
            set
            {
                textSeparator = value ?? string.Empty;
            }
        }

        #endregion

        #region Public Methods
        public static Exception SetLogFile(string partialfilename = null,
                                           string ext = null,
                                           string dateFormat = null,
                                           LevelMsg? logLevel = null,
                                           string textSeparator = null)
        {
            Exception ex_out = null;

            try
            {
                ex_out = CreateLogDir(true);

                if (textSeparator != null)
                    TextSeparator = textSeparator;

                if (logLevel != null)
                    LogLevel = logLevel.Value;

                if (ext != null)
                    ExtensionFileName = ext;

                if (dateFormat != null)
                    DateFormat = dateFormat;

                if (partialfilename != null)
                    PartialFileName = partialfilename;

                FullFileName = GetFileName(DateTime.Now);
                if (Fullfilename != null)
                {
                    XmlLog = new XDocument();
                    XmlLog.Add(new XElement("LogEntries"));
                    XmlLog.Save(FullFileName);
                }
            }
            catch (Exception ex)
            {
                ex_out = ex;
            }
            return ex_out;
        }


        public static Exception CreateLogDir(bool createIfNotExisting = false)
        {
            if (string.IsNullOrEmpty(dirLog))
                dirLog = Directory.GetCurrentDirectory();
            try
            {
                string TmpPath = System.IO.Path.GetTempPath();
                currentlogDir = new DirectoryInfo(TmpPath + dirLog);
                if (!currentlogDir.Exists)
                {
                    if (createIfNotExisting)
                    {
                        currentlogDir.Create();
                    }
                    else
                    {
                        throw new DirectoryNotFoundException(string.Format("Directory '{0}' does not exist!", currentlogDir.FullName));
                    }
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

        public static Exception Info(string message)
        {
            return Log(message);
        }

        public static Exception Warning(string message)
        {
            return Log(message, LevelMsg.Warning);
        }

        public static Exception FatalError(string message)
        {
            return Log(message, LevelMsg.FatalError);
        }
        public static Exception exception(string message)
        {
            return Log(message, LevelMsg.Exception);
        }

        public static Exception Log(string message, LevelMsg level = LevelMsg.Info)
        {
            return string.IsNullOrEmpty(message) ? null : Log(new XElement("Message", message), level);
        }

        public static Exception Log(XElement xElement, LevelMsg level = LevelMsg.Info)
        {
            if (xElement == null || level < LogLevel)
                return null;
            try
            {
                var logEntry = new XElement("MyBiblioCDsLog");
                logEntry.Add(new XAttribute("Date", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                logEntry.Add(new XAttribute("LevelMsg", level));
                logEntry.Add(new XAttribute("Source", RecognizeSource()));
                logEntry.Add(new XAttribute("ThreadId", Thread.CurrentThread.ManagedThreadId));
                logEntry.Add(xElement);
                XmlLog.Element("LogEntries").Add(logEntry);
                XmlLog.Save(Fullfilename);
                return WriteLogEntryToFile();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static string GetFileName(DateTime dateTime)
        {
            string path = string.Format("{0}\\{1}{2}_{3}{4}{5}.{6}", LogDir, Prefix, dateTime.ToString(DateFormat), dateTime.Hour.ToString(), dateTime.Minute.ToString(), dateTime.Second.ToString(), ExtensionFileName);
            if (File.Exists(path))
                File.Delete(path);

            return path;
        }
        public static void ShowLogFile()
        {
            if (!File.Exists(Fullfilename))
                return;
            System.Diagnostics.Process.Start(Fullfilename);
        }
        #endregion

        #region Private Methods
        private static Exception WriteLogEntryToFile()
        {
            const int TimeToWaitForFile = 3;
            if (Monitor.TryEnter(LockFile, new TimeSpan(0, 0, 0, TimeToWaitForFile)))
            {
                try
                {
                    XmlLog.Save(FullFileName);
                    return null;
                }
                catch (Exception ex)
                {
                    try
                    {
                        ex.Data["Filename"] = FullFileName;
                    }
                    catch
                    {
                        return ex;
                    }
                    return ex;
                }
                finally
                {
                    Monitor.Exit(LockFile);
                }
            }
            try
            {
                return new Exception(string.Format("Could not write to file '{0}'.", FullFileName));
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        private static string RecognizeSource(int numframe = 0)
        {
            string result = string.Empty;
            string a = string.Empty;
            StackTrace stackFrame = new StackTrace(true);
            for (int i = 0; i < stackFrame.FrameCount; i++)
            {
                StackFrame sf = stackFrame.GetFrame(i);
                Type theType = sf.GetMethod().DeclaringType;
                result = string.Format("{0} || {1} -> {2}", sf.GetFileName(), sf.GetMethod().ToString(), sf.GetFileLineNumber());
                a += typeof(LogProj).ToString();
                if ((--numframe) < 0 && theType != typeof(MyBiblioCDsAudio.LogProj))
                    break;
            }
            return result;
        }
    }
}
#endregion
