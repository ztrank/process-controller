using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Events
{
    public class SaveServiceChangeEvent : ApplicationEvent
    {
        public override string Type => nameof(SaveServiceChangeEvent);

        public SaveState State { get; }

        public SaveServiceChangeEvent(SaveState state)
        {
            this.State = state;
        }
    }
}
