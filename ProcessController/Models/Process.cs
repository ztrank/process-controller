using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Models
{
    public enum ProcessStatus
    {
        Unknown,
        Running,
        Crashed,
        Shutdown
    }

    public class ProcessStatusChangeEventArgs
    {
        public int Id { get; }
        public ProcessStatus Status { get; }
        public ProcessStatus Old { get; }
        public ProcessStatusChangeEventArgs(int Id, ProcessStatus status, ProcessStatus old)
        {
            this.Id = Id;
            this.Status = status;
            this.Old = old;
        }
    }

    public class ProcessExitEventArgs
    {
        public int Id { get; }
        public int ExitCode { get; }

        public ProcessExitEventArgs(int id, int exitCode)
        {
            this.Id = id;
            this.ExitCode = exitCode;
        }
    }

    public class ProcessOutputEventArgs
    {
        public int Id { get; }
        public string Data { get; }

        public ProcessOutputEventArgs(int id, string data)
        {
            this.Id = id;
            this.Data = data;
        }
    }

    public class Process
    {
        public event EventHandler<ProcessOutputEventArgs> StandardOutput;
        public event EventHandler<ProcessOutputEventArgs> StandardError;
        public event EventHandler<ProcessExitEventArgs> Exited;
        public event EventHandler<ProcessStatusChangeEventArgs> StatusChange;
        private readonly System.Diagnostics.Process process;
        private ProcessStatus status;
        private int exitCode;

        public Process(System.Diagnostics.Process process)
        {
            this.process = process;
            this.Id = process.Id;
            this.Name = process.ProcessName;
            this.Status = process.HasExited ? process.ExitCode != 0 ? ProcessStatus.Crashed : ProcessStatus.Shutdown : ProcessStatus.Running;
            this.process.EnableRaisingEvents = true;
            this.process.Exited += this.HandleExit;
            this.process.OutputDataReceived += this.HandleOutput;
            this.process.ErrorDataReceived += this.HandleError;
            this.process.Disposed += this.HandleDisposed;
        }

        ~Process()
        {
            this.Unsubscribe();
        }

        public int Id { get; }
        public string Name { get; }
        public int ExitCode
        {
            get
            {
                return this.exitCode;
            }
            private set
            {
                this.exitCode = value;
                this.Exited?.Invoke(this, new ProcessExitEventArgs(this.Id, this.exitCode));
            }
        }
        public ProcessStatus Status { 
            get
            {
                return this.status;
            }
            private set
            {
                ProcessStatus old = this.status;
                this.status = value;
                this.StatusChange?.Invoke(this, new ProcessStatusChangeEventArgs(this.Id, this.status, old));
            }
        }

        public bool HasExited
        {
            get
            {
                return this.process.HasExited;
            }
        }

        public System.Diagnostics.Process SystemProcess
        {
            get
            {
                return this.process;
            }
        }

        public void Unsubscribe()
        {
            this.RemoveRunningHandlers();
            this.RemoveDisposeHandler();
        }

        private void HandleExit(object sender, EventArgs e)
        {
            this.ExitCode = this.process.ExitCode;

            if (this.ExitCode > 0)
            {
                this.Status = ProcessStatus.Crashed;
            }
            else
            {
                this.Status = ProcessStatus.Shutdown;
            }

            this.RemoveRunningHandlers();
        }

        private void HandleOutput(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.StandardOutput?.Invoke(this, new ProcessOutputEventArgs(this.Id, e.Data));
        }

        private void HandleError(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            this.StandardError?.Invoke(this, new ProcessOutputEventArgs(this.Id, e.Data));
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            this.process.EnableRaisingEvents = false;
            this.RemoveRunningHandlers();
            this.RemoveDisposeHandler();
        }

        private void RemoveRunningHandlers()
        {
            try
            {
                this.process.Exited -= this.HandleExit;
                this.process.OutputDataReceived -= this.HandleOutput;
                this.process.ErrorDataReceived -= this.HandleError;
            }
            finally
            {

            }
        }

        private void RemoveDisposeHandler()
        {
            try
            {
                this.process.Disposed -= this.HandleDisposed;
            }
            finally
            {

            }
        }
    }
}
