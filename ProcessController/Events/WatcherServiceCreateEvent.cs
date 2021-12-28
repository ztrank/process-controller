using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Events
{
    public class WatcherServiceCreateEvent : ApplicationEvent
    {
        public override string Type => nameof(WatcherServiceCreateEvent);

        public Watcher Watcher { get; }

        public WatcherServiceCreateEvent(Watcher watcher)
        {
            this.Watcher = watcher;
        }
    }
}
