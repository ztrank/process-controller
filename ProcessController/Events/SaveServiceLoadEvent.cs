using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Events
{
    public class SaveServiceLoadEvent : ApplicationEvent
    {
        public override string Type => nameof(SaveServiceLoadEvent);

        public SaveState State { get; }

        public SaveServiceLoadEvent(SaveState state)
        {
            this.State = state;
        }
    }
}
