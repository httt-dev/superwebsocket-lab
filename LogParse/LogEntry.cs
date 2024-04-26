using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParse
{
    public class LogEntry
    {
        public string Timestamp { get; set; }
        public string LogLevel { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }

        public LogEntry(string timestamp, string logLevel, string method, string message)
        {
            Timestamp = timestamp;
            LogLevel = logLevel;
            Method = method;
            Message = message;
        }

        public override string ToString()
        {
            return $"Timestamp: {Timestamp}\nLogLevel: {LogLevel}\nMethod: {Method}\nMessage: {Message}";
        }
    }
}
