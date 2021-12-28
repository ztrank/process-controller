using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;
using ProcessController.Models;

namespace ProcessController.Services
{
    public class WatcherStatusService : IWatcherStatusService
    {
        private readonly IProcessService processService;
        private readonly ILogService<WatcherStatusService> logService;

        public WatcherStatusService(IProcessService processService, ILogService<WatcherStatusService> logService)
        {
            this.processService = processService;
            this.logService = logService;
        }

        public WatcherStatus GetStatus(Watcher watcher)
        {
            List<Process> processes = this.processService.Get(watcher.ProcessName);

            if (processes.Count == 0)
            {
                return WatcherStatus.Warning;
            }
            else
            {
                int runningCount = 0;
                int errorCount = 0;
                int exitCount = 0;
                int unknownCount = 0;
                processes.ForEach(p =>
                {
                    runningCount = p.Status == ProcessStatus.Running ? runningCount + 1 : runningCount;
                    errorCount = p.Status == ProcessStatus.Crashed ? errorCount + 1 : errorCount;
                    exitCount = p.Status == ProcessStatus.Shutdown ? exitCount + 1 : exitCount;
                    unknownCount = p.Status == ProcessStatus.Unknown ? unknownCount + 1 : unknownCount;
                });

                if (runningCount == watcher.ProcessCount)
                {
                    return WatcherStatus.Ok;
                }
                else if (errorCount > 0)
                {
                    return WatcherStatus.Error;
                }
                else
                {
                    return WatcherStatus.Warning;
                }
            }
        }
    }
}
