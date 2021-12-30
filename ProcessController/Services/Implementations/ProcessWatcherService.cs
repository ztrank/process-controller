using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessController.Events;
using ProcessController.Models;
using ProcessController.Extensions;

namespace ProcessController.Services.Implementations
{
    public class ProcessWatcherService : IProcessWatcherService
    {
        private ObservableCollection<ProcessWatcher> watchers;
        private readonly IProcessService processService;
        private readonly ISaveService saveService;
        private readonly IEventBus eventBus;
        private readonly ILogService<ProcessWatcherService> logService;

        public ProcessWatcherService(
            IApplicationService applicationService, 
            IProcessService processService,
            ISaveService saveService,
            IEventBus eventBus,
            ILogServiceFactory logServiceFactory)
        {
            this.processService = processService;
            this.saveService = saveService;
            this.eventBus = eventBus;
            this.logService = logServiceFactory.Create<ProcessWatcherService>();
            this.eventBus.Subscriptions += this.HandleEventBus;
            applicationService.Tick += this.Tick;
        }

        public ProcessWatcher Get(int? id)
        {
            this.Load();
            if (id != null && this.watchers.FindIndex(w => w.Id == (int)id) != -1)
            {
                return this.watchers[(int)id];
            }
            else
            {
                return new ProcessWatcher(this.NewId());
            }
        }

        public void Save(ProcessWatcher watcher)
        {
            if (string.IsNullOrWhiteSpace(watcher.Name))
            {
                throw new ArgumentException("Invalid Name", nameof(watcher));
            }

            if (string.IsNullOrWhiteSpace(watcher.ProcessName))
            {
                throw new ArgumentException("Invalid Process Name", nameof(watcher));
            }

            if (watcher.ProcessTargetCount <= 0)
            {
                throw new ArgumentException("Invalid Process Count", nameof(watcher));
            }

            this.saveService.QueueForSave(watcher);

            if(this.watchers.FindIndex(w => w.Id == watcher.Id) == -1)
            {
                this.watchers.Add(watcher);
            }
        }

        public void Delete(ProcessWatcher watcher)
        {
            this.saveService.QueueForDelete(watcher);
            int index = this.watchers.FindIndex(w => w.Id == watcher.Id);

            if (index > -1)
            {
                this.watchers.RemoveAt(index);
            }
        }

        public ObservableCollection<ProcessWatcher> Get()
        {
            this.Load();

            return this.watchers;
        }

        private void HandleEventBus(object sender, ApplicationEvent @event)
        {
            if (@event is SaveCompleteEvent save && save.Watchers != null)
            {
                foreach(SaveState.ProcessWatcherEntry entry in save.Watchers)
                {
                    int index = this.watchers.FindIndex(w => w.Id == entry.Id);
                    if(index == -1)
                    {
                        this.watchers.Add(entry.ToWatcher());
                    }
                }
            }
        }

        private void Load()
        {
            if (this.watchers == null)
            {
                this.logService.Debug("Loading watchers from save file...");
                this.watchers = new ObservableCollection<ProcessWatcher>(this.saveService.LoadWatchers());
                this.logService.Debug("Watchers loaded from save file!", this.watchers);
            }
            else
            {
                this.logService.Debug("Watchers already loaded", this.watchers);
            }
        }

        private int NewId()
        {
            return this.watchers.Select(w => w.Id).Max() + 1;
        }

        private void Tick(object sender, EventArgs e)
        {
            if(this.watchers != null)
            {
                this.watchers
                    .Where(w => w.ProcessTargetCount != 0 && !string.IsNullOrWhiteSpace(w.ProcessName) && w.ProcessTargetCount > w.RunningProcessCount)
                    .ToList()
                    .ForEach(w => this.processService.Get(w.ProcessName).ForEach(p => w.TryAddProcess(p)));
            }
        }
    }
}
