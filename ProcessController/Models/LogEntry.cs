using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Models
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warn = 4,
        Error = 8
    }

    public class LogEntry
    {
        public static LogEntry Debug(string source, string message, object data) => new LogEntry(LogLevel.Debug, source, message, data);
        public static LogEntry Info(string source, string message, object data) => new LogEntry(LogLevel.Info, source, message, data);
        public static LogEntry Warn(string source, string message, object data) => new LogEntry(LogLevel.Warn, source, message, data);
        public static LogEntry Error(string source, string message, Exception exception, object data) => new LogEntry(LogLevel.Error, source, message, new { exception = exception, data = data });
        
        public LogLevel Level { get; }
        public string Source { get; }
        public string Message { get; }
        public object Data { get; }

        private LogEntry(LogLevel level, string source, string message, object data)
        {
            this.Source = source;
            this.Level = level;
            this.Message = message;
            this.Data = data;
        }
    }
}
