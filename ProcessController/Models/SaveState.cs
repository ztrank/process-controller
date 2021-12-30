using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Models
{
    public class SaveState
    {
        public List<ProcessWatcherEntry> Watchers { get; set; }

        public class ProcessWatcherEntry
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ProcessName { get; set; }
            public int ProcessTargetCount { get; set; }
            public string Description { get; set; }

            public ProcessWatcherEntry()
            {
            }

            public ProcessWatcherEntry(ProcessWatcher watcher)
            {
                this.Id = watcher.Id;
                this.Name = watcher.Name;
                this.ProcessName = watcher.ProcessName;
                this.ProcessTargetCount = watcher.ProcessTargetCount;
                this.Description = watcher.Description;
            }

            public ProcessWatcher ToWatcher()
            {
                return new ProcessWatcher(this.Id)
                {
                    Name = this.Name,
                    ProcessName = this.ProcessName,
                    ProcessTargetCount = this.ProcessTargetCount,
                    Description = this.Description
                };
            }
        }
    }


    
}
