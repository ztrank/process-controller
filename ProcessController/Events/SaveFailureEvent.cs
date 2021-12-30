using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Events
{
    public class SaveFailureEvent : ApplicationEvent
    {
        public override string Type => nameof(SaveFailureEvent);
        public Exception error { get; set; }
        public SaveFailureEvent(Exception exception)
        {
            this.error = exception;
        }
    }
}
