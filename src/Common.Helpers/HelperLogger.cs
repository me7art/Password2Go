using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

using Common.Interfaces;

namespace Common.Helpers
{
    public class HelperLogger : IHelperLogger
    {
        string _loggerName = string.Empty;
        string _logFilename = string.Empty;

        TextWriter _tw = null;

        public void SetName(string name)
        {
            _loggerName = name;
        }

        private void Init(string logFilename)
        {
            _logFilename = logFilename;
            try
            {
                if (_tw == null)
                {
                    _tw = TextWriter.Synchronized(File.AppendText(_logFilename));
                }
            }
            catch //(Exception e)
            {
                //Console.Write("Error open(creating) log file: " + e.Message);
            }
        }

        public HelperLogger(string name, string filename)
        {
            SetName(name);
            Init(filename);
            return;
        }

        private string LogFormatOutput(string message, string from, int type)
        {
            return DateTime.Now + " " +
                    "[" + Enum.GetName(typeof(eLOG), type) + "] " +
                    "Thread(" + Thread.CurrentThread.ManagedThreadId.ToString() + ") " +
                    "[" + from + "]" + "\t" +
                    message + "\r\n";
        }

        private void LogWriteToFile(string output)
        {
            try
            {
                _tw.Write(output);
                _tw.Flush();
            }
            catch
            {
                // do nothing
            }
            return;
        }

        public void Log(string message, string from, eLOG a)
        {
            int aa = (int)a;
            string output = LogFormatOutput(message, from, aa);

            if (_tw != null)
            {
                LogWriteToFile(output);
            }
        }

        public void Log(string message, eLOG a)
        {
            Log(message, _loggerName, a);
        }

        private void Heartbeat(string dot)
        {
            LogWriteToFile(dot);
        }

        public void Heartbeatmark(string ch)
        {
            Heartbeat(ch);
        }

        private DateTime _lastHBTime = DateTime.Now;
        private object _lastHBTimeLocker = new object();

        public void Heartbeat()
        {
            lock (_lastHBTimeLocker)
            {
                DateTime now = DateTime.Now;
                if (now - _lastHBTime > TimeSpan.FromSeconds(59))
                {
                    _lastHBTime = now;
                    Heartbeat(".");
                }
            }
        }
    }
}
