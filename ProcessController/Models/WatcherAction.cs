using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public class WatcherAction
    {
        public ProcessHook Hook { get; set; }
        public string ActionName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
