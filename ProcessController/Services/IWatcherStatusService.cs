using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IWatcherStatusService
    {
        WatcherStatus GetStatus(Watcher watcher);
    }
}
