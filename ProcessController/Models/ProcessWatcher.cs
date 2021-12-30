using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public enum WatcherStatus
    {
        Ok,
        Warning,
        Error
    }

    public class ProcessLogEntry
    {
        public LogLevel Level { get; }
        public int Id { get; }
        public string Message { get; }

        public ProcessLogEntry(LogLevel level, int id, string message)
        {
            this.Level = level;
            this.Id = id;
            this.Message = message;
        }
    }

    public class ProcessWatcher
    {
        [JsonIgnore]
        private readonly Dictionary<int, Process> processes = new Dictionary<int, Process>();
        
        [JsonIgnore]
        private readonly List<ProcessLogEntry> processLog = new List<ProcessLogEntry>();

        public event EventHandler ProcessCountChange;

        public ProcessWatcher()
        {
        }

        public ProcessWatcher(int Id)
        {
            this.Id = Id;
        }

        ~ProcessWatcher()
        {
            this.processes.Values.ToList().ForEach(p =>
            {
                p.Unsubscribe();
                this.Unsubscribe(p);
            });
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public int ProcessTargetCount { get; set; }

        [JsonIgnore]
        public int ProcessCount
        {
            get
            {
                return this.processes.Count;
            }
        }

        [JsonIgnore]
        public int RunningProcessCount
        {
            get
            {
                return this.processes.Values.Where(p => !p.HasExited).Count();
            }
        }

        public WatcherStatus Status { get; private set; } = WatcherStatus.Ok;

        [JsonIgnore]
        public Dictionary<int, Process> Processes
        {
            get
            {
                return this.processes;
            }
        }

        public bool TryAddProcess(Process process)
        {
            if (this.processes.ContainsKey(process.Id))
            {
                return false;
            }

            process.Exited += this.HandleProcessExit;
            process.StandardError += this.HandleProcessOutput;
            process.StandardOutput += this.HandleProcessError;
            process.StatusChange += this.HandleProcessStatusChange;
            this.processes.Add(process.Id, process);
            this.processLog.Add(new ProcessLogEntry(LogLevel.Info, process.Id, "Connected to process: " + process.Id.ToString()));

            int running = this.processes.Values.Where(p => !p.HasExited).ToList().Count;

            if (running >= this.ProcessTargetCount)
            {
                this.Status = WatcherStatus.Ok;
            }

            this.ProcessCountChange?.Invoke(this, new EventArgs());

            return true;
        }

        private void HandleProcessExit(object sender, ProcessExitEventArgs e)
        {
            this.processLog.Add(new ProcessLogEntry(LogLevel.Info, e.Id, string.Format("Process {0} exited with exit code: {1}", e.Id.ToString(), e.ExitCode.ToString())));
            this.Unsubscribe(this.processes[e.Id]);
            this.Status = e.ExitCode == 0 ? WatcherStatus.Warning : WatcherStatus.Error;
            this.ProcessCountChange?.Invoke(this, new EventArgs());
        }

        private void HandleProcessOutput(object sender, ProcessOutputEventArgs e)
        {
            this.processLog.Add(new ProcessLogEntry(LogLevel.Info, e.Id, e.Data));
        }

        private void HandleProcessError(object sender, ProcessOutputEventArgs e)
        {
            this.processLog.Add(new ProcessLogEntry(LogLevel.Info, e.Id, e.Data));
            this.Status = WatcherStatus.Error;
        }

        private void HandleProcessStatusChange(object sender, ProcessStatusChangeEventArgs e)
        {
            this.processLog.Add(new ProcessLogEntry(LogLevel.Info, e.Id, string.Format("Status Change {0} -> {1}",e.Old.ToString(), e.Status.ToString())));
        }

        private void Unsubscribe(Process process)
        {
            process.Exited -= this.HandleProcessExit;
            process.StandardError -= this.HandleProcessError;
            process.StandardOutput -= this.HandleProcessOutput;
            process.StatusChange -= this.HandleProcessStatusChange;
        }
    }
}
