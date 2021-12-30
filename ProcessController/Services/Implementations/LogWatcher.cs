using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services.Implementations
{
    public class LogWatcher : ILogWatcher
    {
        public event EventHandler<LogEntry> Log;

        public void Publish(LogEntry entry) => this.Log?.Invoke(null, entry);
    }
}
