using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface ILogWatcher
    {
        event EventHandler<LogEntry> Log;
        void Publish(LogEntry entry);
    }
}
