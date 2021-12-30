using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Events
{
    public class SaveCompleteEvent : ApplicationEvent
    {
        public override string Type => nameof(SaveCompleteEvent);

        public List<SaveState.ProcessWatcherEntry> Watchers { get; set; }
        public int[] WatchersDeleted { get; set; }
    }
}
