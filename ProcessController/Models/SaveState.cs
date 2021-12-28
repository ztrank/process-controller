using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Models
{
    public class SaveState
    {
        public List<Action> Actions { get; set; } = new List<Action>();
        public List<Watcher> Watchers { get; set; } = new List<Watcher>();
    }
}
