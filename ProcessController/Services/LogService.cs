using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessController.Models;

namespace ProcessController.Services
{
    public class LogService<T> : ILogService<T>
    {
        private readonly ILogWatcher logWatcher;

        public string Name { get; private set; }

        public LogService(ILogWatcher logWatcher)
        {
            this.logWatcher = logWatcher;
            this.Name = typeof(T).Name;
        }

        public void Debug(string message)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Blue,
                Source = this.Name,
                Message = message,
                Level = Enums.LogLevel.Debug
            });
        }

        public void Debug(object data)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Blue,
                Source = this.Name,
                Data = JsonConvert.SerializeObject(data),
                Level = Enums.LogLevel.Debug
            });
        }

        public void Debug(string message, object data)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Blue,
                Source = this.Name,
                Data = JsonConvert.SerializeObject(data),
                Message = message,
                Level = Enums.LogLevel.Debug
            });
        }

        public void Info(string message)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.White,
                Source = this.Name,
                Message = message,
                Level = Enums.LogLevel.Info
            });
        }

        public void Info(object data)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.White,
                Source = this.Name,
                Data = JsonConvert.SerializeObject(data),
                Level = Enums.LogLevel.Info
            });
        }

        public void Warn(string message)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Orange,
                Source = this.Name,
                Message = message,
                Level = Enums.LogLevel.Warn
            });
        }

        public void Warn(object data)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Orange,
                Source = this.Name,
                Data = JsonConvert.SerializeObject(data),
                Level = Enums.LogLevel.Warn
            });
        }

        public void Error(string message)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Red,
                Source = this.Name,
                Message = message,
                Level = Enums.LogLevel.Error
            });
        }

        public void Error(Exception exception)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Red,
                Source = this.Name,
                Data = JsonConvert.SerializeObject(exception),
                Level = Enums.LogLevel.Error
            });
        }

        public void Error(string message, Exception exception)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Red,
                Source = this.Name,
                Message = message,
                Data = JsonConvert.SerializeObject(exception),
                Level = Enums.LogLevel.Error
            });
        }

        public void Error(object data)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Red,
                Source = this.Name,
                Data = JsonConvert.SerializeObject(data),
                Level = Enums.LogLevel.Error
            });
        }

        public void Error(string message, object data)
        {
            this.logWatcher.Log(new LogEvent()
            {
                Color = Enums.StatusColor.Red,
                Source = this.Name,
                Message = message,
                Data = JsonConvert.SerializeObject(data),
                Level = Enums.LogLevel.Error
            });
        }
    }
}
