using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Enums;
using ProcessController.Events;
using ProcessController.Models;

namespace ProcessController.Services
{
    public class ProcessService : IProcessService
    {
        private readonly List<Process> processes = new List<Process>();
        private readonly Dictionary<int, int> processMap = new Dictionary<int, int>();
        private readonly Dictionary<string, List<int>> processNameMap = new Dictionary<string, List<int>>();
        private readonly IApplicationTick ticker;
        private readonly IEventBus eventBus;
        public ProcessService(IApplicationTick ticker, IEventBus eventBus)
        {
            this.ticker = ticker;
            this.ticker.OnTick += this.Tick;
            this.eventBus = eventBus;
            this.eventBus.OnEvent += this.HandleBusEvents;
        }

        ~ProcessService()
        {
            this.ticker.OnTick -= this.Tick;
            this.eventBus.OnEvent -= this.HandleBusEvents;
        }

        private void HandleBusEvents(object sender, ApplicationEvent @event)
        {
            if (@event is SaveServiceLoadEvent onLoad)
            {
                onLoad.State.Watchers.ForEach(watcher => this.Monitor(watcher.ProcessName));
            }
            else if(@event is WatcherServiceCreateEvent onCreate)
            {
                this.Monitor(onCreate.Watcher.ProcessName);
            }
        }

        public void CleanUp()
        {
            List<Process> keep = this.processes.Where(p => !p.HasExited).ToList();
            List<string> retries = this.processNameMap.Keys.ToList().Where(key => this.processNameMap[key] == null).ToList();
            

            processes.Clear();
            processes.AddRange(keep);
            processMap.Clear();
            processNameMap.Clear();
            
            for(int i = 0; i < this.processes.Count; i++)
            {
                Process process = this.processes[i];
                this.processMap.Add(process.Id, i);
                
                if (!this.processNameMap.ContainsKey(process.Name))
                {
                    this.processNameMap.Add(process.Name, new List<int>());
                }

                this.processNameMap[process.Name].Add(process.Id);
            }
        }

        public void Monitor(string processName)
        {
            if (!this.processNameMap.ContainsKey(processName))
            {
                this.processNameMap.Add(processName, null);
            }

            System.Diagnostics.Process.GetProcessesByName(processName).ToList().ForEach(process =>
            {
                if (!this.processMap.ContainsKey(process.Id))
                {
                    this.processes.Add(new Process(process));
                    this.processMap.Add(process.Id, this.processes.Count - 1);
                    if (this.processNameMap[processName] == null)
                    {
                        this.processNameMap.Remove(processName);
                        this.processNameMap.Add(processName, new List<int>());
                    }

                    this.processNameMap[processName].Add(process.Id);
                }
            });
        }

        public Process Get(int id)
        {
            if (this.processMap.ContainsKey(id))
            {
                return this.processes[this.processMap[id]];
            }

            return null;
        }

        public List<Process> Get(string name)
        {
            return this.processes.FindAll(p => p.Name == name);
        }

        private void Tick(object sender, IApplicationTick e)
        {
            this.Retry();
        }

        private void Retry()
        {
            foreach (string name in processNameMap.Keys)
            {
                this.Monitor(name);
            }
        }
    }
}
