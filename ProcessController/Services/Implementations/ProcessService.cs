using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services.Implementations
{
    public class ProcessService : IProcessService
    {
        public List<Process> Get(string processName)
        {
            return System.Diagnostics.Process.GetProcessesByName(processName).Select(p => new Process(p)).ToList();
        }
    }
}
