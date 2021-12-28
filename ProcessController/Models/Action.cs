using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public class Action
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ActionCommand> Commands { get; set; }
    }
}
