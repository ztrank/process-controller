
namespace ProcessController.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Monitor
    {
        public string Name { get; set; }
        public string Order { get; set; }
        public string ProcessName { get; set; }
        public bool RestartOnCrash { get; set; }
        public string WebHookUri { get; set; }
    }
}
