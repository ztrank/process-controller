

namespace ProcessController.Services
{
    using ProcessController.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProcessMonitorService : IProcessMonitorService
    {
        public Task<List<Process>> GetAll(List<Monitor> monitors)
        {
            List<Process> processes = new List<Process>();
            foreach(Monitor monitor in monitors)
            {
                System.Diagnostics.Process[] systemProcesses = System.Diagnostics.Process.GetProcessesByName(monitor.ProcessName);
                if (systemProcesses.Length > 0)
                {
                    foreach (System.Diagnostics.Process p in systemProcesses)
                    {
                        processes.Add(new Process()
                        {
                            PID = p.Id,
                            Name = p.ProcessName,
                            Status = "Running",
                            Monitor = monitor
                        });
                    }
                }
                else
                {
                    processes.Add(new Process()
                    {
                        Name = monitor.ProcessName,
                        Status = "Offline",
                        Monitor = monitor
                    });
                }
            }

            return Task.FromResult(processes);
        }
    }
}
