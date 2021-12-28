using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public class Process
    {
        public string Name { get; }
        public int Id { get; }
        public bool HasExited
        {
            get
            {
                return this.process.HasExited;
            }
        }
        public int ExitCode
        {
            get
            {
                return this.process.ExitCode;
            }
        }
        public ProcessStatus Status
        {
            get
            {
                if (this.HasExited)
                {
                    if (this.ExitCode > 0)
                    {
                        return ProcessStatus.Crashed;
                    }
                    else
                    {
                        return ProcessStatus.Shutdown;
                    }
                }
                else
                {
                    return ProcessStatus.Running;
                }
            }
        }
        private System.Diagnostics.Process process;

        public Process(System.Diagnostics.Process process)
        {
            this.Name = process.ProcessName;
            this.Id = process.Id;
            this.process = process;
        }
    }
}
