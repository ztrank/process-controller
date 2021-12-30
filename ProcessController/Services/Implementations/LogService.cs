using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services.Implementations
{
    public class LogService<T> : ILogService<T> where T : class
    {
        private readonly ILogWatcher logWatcher;
        private readonly string Name;
        public LogService(ILogWatcher logWatcher)
        {
            this.logWatcher = logWatcher;
            this.Name = typeof(T).Name;
        }

        public void Debug(string message)
        {
            this.Debug(message, null);
        }

        public void Debug(string message, object data)
        {
            this.logWatcher.Publish(LogEntry.Debug(this.Name, message, data));
        }

        public void Error(string message)
        {
            this.Error(message, null, null);
        }

        public void Error(string message, Exception exception)
        {
            this.Error(message, exception, null);
        }

        public void Error(string message, object data)
        {
            this.Error(message, null, data);
        }

        public void Error(string message, Exception exception, object data)
        {
            this.logWatcher.Publish(LogEntry.Error(this.Name, message, exception, data));
        }

        public void Info(string message)
        {
            this.Info(message, null);
        }

        public void Info(string message, object data)
        {
            this.logWatcher.Publish(LogEntry.Info(this.Name, message, data));
        }

        public void Warn(string message)
        {
            this.Warn(message, null);
        }

        public void Warn(string message, object data)
        {
            this.logWatcher.Publish(LogEntry.Warn(this.Name, message, data));
        }
    }
}
