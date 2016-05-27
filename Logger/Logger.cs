// -------------------------------------------------------
//         Logger.cs
//      Use this project for free
//      bye, bye
//          boschiotto4     
// -------------------------------------------------------
using System;
using System.Diagnostics;
using System.IO;

namespace SimpleLogger
{
    /// <summary>-------
    /// <para>Simply Logger object</para>
    /// </summary>
    public class Logger
    {
        #region GLOBALS
        public enum LEVEL {INFO, CRITICAL, ERROR, WARNING, DEBUG }

        int LOG_ID = 0;

        private static TraceSource mySource = new TraceSource("LOG");
        private object m_lock = new object();
        String fileName = "log.log";
        #endregion

        /// <summary>-------
        /// <para>Simply Logger object</para>
        /// </summary>
        /// <param name="file_name">Filename to be used as log, optional: default name is "log.log"</param>
        public Logger(String file_name = null) 
        {
            if(file_name != null)
                fileName = file_name;

            Trace.AutoFlush = true;
            mySource.Switch = new SourceSwitch("SourceSwitch", "Verbose");
        }

        // Log method
        /// <summary>-------
        /// <para>The log method to write a message to the log file</para>
        /// </summary>
        /// <param name="level">is the LEVEL object used to identify the type of message. Use "Logger.TYPE.*" to choose the log level</param>
        /// <param name="message">is the text of message</param>
        public void log(LEVEL level, String message) 
        {
            // Add the timestamp to the message
            String timeStamp = DateTime.Now.ToString("yyyy-MM-dd|HH:mm:ss:ffff");
            message = timeStamp + "|" + message;
            lock(m_lock)
            {
                mySource.TraceEvent(getFromTypeAnalyzer(level), LOG_ID++, message);
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine(getLine(level, LOG_ID++, message));
                }
            }
        }

        #region HELPERS
        private string getLine(LEVEL type, int p, string message)
        {
            String t = "";
            if (type == LEVEL.CRITICAL)
                t = "Critical";

            if (type == LEVEL.INFO)
                t = "Information";

            if (type == LEVEL.ERROR)
                t = "Error";

            if (type == LEVEL.WARNING)
                t = "Warning";

            if (type == LEVEL.DEBUG)
                t = "Verbose";

            if (p > 99990)
                p = 0;
            return t + "|" + p.ToString("00000") + "|" + message;
        }

        private TraceEventType getFromTypeAnalyzer(LEVEL type)
        {
            TraceEventType t = TraceEventType.Information;
            if (type == LEVEL.CRITICAL)
                t = TraceEventType.Critical;

            if (type == LEVEL.INFO)
                t = TraceEventType.Information;

            if (type == LEVEL.ERROR)
                t = TraceEventType.Error;

            if (type == LEVEL.WARNING)
                t = TraceEventType.Warning;

            if (type == LEVEL.DEBUG)
                t = TraceEventType.Verbose;

            return t;
        }
        #endregion
    }
}
