using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public class LogEvent
    {
        public string Source { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public StatusColor Color { get; set; }
        public LogLevel Level { get; set; } = 0;
    }
}
