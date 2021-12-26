using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Models
{
    public class Process
    {
        public int? PID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Monitor Monitor { get; set; }
    }
}
