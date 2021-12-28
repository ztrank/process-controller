using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Enums
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warn = 4,
        Error = 8
    }
}
