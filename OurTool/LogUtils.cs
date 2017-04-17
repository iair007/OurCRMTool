using System;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.Xml;
using System.Security.Principal;
using System.Data;

namespace OurCRMTool
{
    public class LogUtils
    {
        static string _logPath = null;
        public static string LogPath
        {
            get
            {
                if (_logPath == null)
                {
                    string runningPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    _logPath = runningPath + "\\Logs";
                }
                return _logPath;
            }
        }

        #region Constractor
        public LogUtils()
        {
            m_ApplicationLogLevel = Convert.ToInt16(ConfigurationManager.AppSettings["logLevel"]);
            string timeformat = ConfigurationManager.AppSettings["logTimeFormat"];
            string filename = LogPath + "\\log.txt";// ConfigurationManager.AppSettings["logFileName"];
            DirectoryInfo di = Directory.CreateDirectory(LogPath);
            m_LogFileName = Convert.ToString(filename.Insert(filename.LastIndexOf("."), DateTime.Now.ToString("dd-MM-yyyy")));
        }
        #endregion

        #region Fields
        private string m_LogFileName = "";
        private int m_ApplicationLogLevel = 0;
        #endregion

        #region General Methods to write to file
        public static void WriteInformationLog(string logName, string message)
        {
            WriteLog(logName, message, "information", 0);
        }

        public static void WriteErrorLog(string logName, string message, int errorID)
        {
            WriteLog(logName, message, "error", errorID);
        }

        public static void WriteLog(string logName, string message, string logType, int eventID)
        {
            try
            {
                if (logType == "")
                    logType = "information";
                if (!MatchDelimitedValue(logType, "information,error,warning"))
                    throw new Exception("Invalid log type '" + logType + "' specified for writeLog method");
                if (logName == "")
                    logName = "Effect-General";
                if (!EventLog.SourceExists(logName))
                {
                    EventLog.CreateEventSource(logName, "Effect");
                    Thread.Sleep(100);
                }
                EventLog log = new EventLog("Effect");
                log.Source = logName;
                EventLogEntryType entryType = EventLogEntryType.Information;
                switch (logType)
                {
                    case "information":
                        entryType = EventLogEntryType.Information;
                        break;
                    case "error":
                        entryType = EventLogEntryType.Error;
                        break;
                    case "warning":
                        entryType = EventLogEntryType.Warning;
                        break;
                }
                log.WriteEntry(message, entryType, eventID);
                log.Close();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Methods to write Exception + comments


        private void IfFileExist()
        {
            if (m_LogFileName == "")
            {
                m_ApplicationLogLevel = Convert.ToInt16(ConfigurationManager.AppSettings["logLevel"]);
                string timeformat = ConfigurationManager.AppSettings["logTimeFormat"];
                string filename = LogPath + "\\log.txt";
                DirectoryInfo di = Directory.CreateDirectory(LogPath);
                if (timeformat != null && timeformat != string.Empty && timeformat.ToLower() == "true")
                    m_LogFileName = Convert.ToString(filename.Insert(filename.LastIndexOf("."), DateTime.Now.ToString(timeformat)));
                else
                    m_LogFileName = Convert.ToString(filename);
            }
        }

        public virtual void HandleException(Exception exception, int level, string errorDescription, params object[] args)
        {
            errorDescription += " Error: " + GetStringException(exception);
            errorDescription += " Stack: " + exception.StackTrace;
            WriteToLog(level, errorDescription, args);
            Error errorForm = new Error(errorDescription, m_LogFileName);
            errorForm.ShowDialog();
        }

        public virtual string GetStringException(Exception exception)
        {
            if (exception.GetType() == typeof(SoapException) || exception.GetType().IsSubclassOf(typeof(SoapException)))
                return ((SoapException)exception).Detail.OuterXml;
            else
                return exception.Message;
        }

        public virtual void WriteToLog(int logLevel, string src, params object[] args)
        {
            IfFileExist();
            if (logLevel <= m_ApplicationLogLevel)
                WriteToLog("[" + logLevel + "] " + src, args);
        }

        public virtual string ReadLogFile()
        {
            if (m_LogFileName == "")
                return "";
            WindowsImpersonationContext impersonation = WindowsIdentity.Impersonate(IntPtr.Zero);
            try
            {
                lock (this)
                {
                    using (StreamReader sr = new StreamReader(m_LogFileName))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                impersonation.Undo();
            }
            return "";
        }
        public virtual void WriteToLog(string src, params object[] args)
        {
            if (m_LogFileName == "")
                return;
            WindowsImpersonationContext impersonation = WindowsIdentity.Impersonate(IntPtr.Zero);
            try
            {
                lock (this)
                {
                    src = "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "] " + String.Format(src, args);
                    using (StreamWriter sw = File.AppendText(m_LogFileName))
                    {
                        sw.WriteLine(src);
                    }
                    // TextFileWriter.AppendToTextFile(m_LogFileName, src + Environment.NewLine + Environment.NewLine);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                impersonation.Undo();
            }
        }

        public virtual void ClearLog()
        {
            if (m_LogFileName == "")
                return;
            string errorRecordsName = ConfigurationManager.AppSettings["ErrorRecords"];
            WindowsImpersonationContext impersonation = WindowsIdentity.Impersonate(IntPtr.Zero);
            try
            {
                lock (this)
                {
                    using (StreamWriter sw = new StreamWriter(m_LogFileName))
                    {
                        sw.Write("");
                    }
                    File.Delete(errorRecordsName);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                impersonation.Undo();
            }
        }

        public string GetFilePath()
        {
            return m_LogFileName;
        }

        public static bool MatchDelimitedValue(string value, string values)
        {
            return MatchDelimitedValue(value, values, false);
        }

        public static bool MatchDelimitedValue(string value, string values, bool ignoreCase)
        {
            string[] matches = values.Split(',');
            for (int i = 0; i < matches.Length; i++)
                if (value == matches[i] || (ignoreCase && value.ToUpper() == matches[i].ToUpper()))
                    return true;
            return false;
        }

        public static bool MatchDelimitedValueArray(string valueArray, string values, bool ignoreCase)
        {
            string[] s = valueArray.Split(',');
            for (int i = 0; i < s.Length; i++)
                if (!MatchDelimitedValue(s[i], values, ignoreCase))
                    return false;
            return true;
        }

        #endregion
    }
}

