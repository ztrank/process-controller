using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public class LogWatcher : ILogWatcher
    {
        public event EventHandler<LogEvent> OnLog;

        public LogWatcher()
        {

        }

        public void Log(LogEvent @event)
        {
            this.OnLog?.Invoke(this, @event);
        }
    }
}
