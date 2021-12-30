using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Enums
{
    public enum ProcessHook
    {
        Crash,
        Shutdown,
        Exit,
        Starting,
        Startup,
        Output
    }
}
