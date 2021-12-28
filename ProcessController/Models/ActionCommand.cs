using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public class ActionCommand
    {
        public CommandType Command { get; set; }
        public List<string> Parameters { get; set; }
    }
}
