using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Events
{
    public abstract class ApplicationEvent
    {
        public abstract string Type { get; }
    }
}
