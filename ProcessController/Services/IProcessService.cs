using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IProcessService
    {
        List<Process> Get(string processName);
    }
}
