using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Events;
using ProcessController.Models;

namespace ProcessController.Services
{
    /// <summary>
    /// Watcher Service
    /// </summary>
    public class WatcherService : IWatcherService
    {
        /// <summary>
        /// Save Service
        /// </summary>
        private readonly ISaveService saveService;

        /// <summary>
        /// Log Service
        /// </summary>
        private readonly ILogService<WatcherService> logService;

        /// <summary>
        /// Event Bus
        /// </summary>
        private readonly IEventBus eventBus;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveService"></param>
        /// <param name="logService"></param>
        public WatcherService(
            IEventBus eventBus,
            ISaveService saveService,
            ILogService<WatcherService> logService)
        {
            this.eventBus = eventBus;
            this.saveService = saveService;
            this.logService = logService;
        }

        /// <summary>
        /// Gets all watchers
        /// </summary>
        /// <returns>List of all watchers</returns>
        public List<Watcher> Get()
        {
            return this.saveService.Load().Watchers;
        }

        /// <summary>
        /// Gets a watcher by name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Watcher, new if not found</returns>
        public Watcher Get(string name)
        {
            Watcher watcher = this.saveService.Load().Watchers.Find(w => w.Name == name);

            if (watcher == null)
            {
                this.logService.Info("Watcher not found: " + name + ", creating new watcher");
                watcher = new Watcher()
                {
                    Name = name
                };
            }

            return watcher;
        }

        /// <summary>
        /// Gets a watcher by the process name
        /// </summary>
        /// <param name="processName">Process Name</param>
        /// <returns>Watcher, new if not found</returns>
        public Watcher GetByProcessName(string processName)
        {
            Watcher watcher = this.saveService.Load().Watchers.Find(w => w.ProcessName == processName);

            if (watcher == null)
            {
                this.logService.Debug("Watcher not found for process: " + processName + ", creating new watcher");
                watcher = new Watcher()
                {
                    ProcessName = processName
                };
            }

            return watcher;
        }

        /// <summary>
        /// Inserts a new Watcher
        /// </summary>
        /// <param name="watcher">New Watcher to add</param>
        public void Create(Watcher watcher)
        {
            this.Validate(watcher);
            Watcher existingByName = this.Get(watcher.Name);
            Watcher existingByProcess = this.GetByProcessName(watcher.ProcessName);
            
            if (existingByName != null)
            {
                this.logService.Error("Duplicate Watcher Name: " + watcher.Name);
                throw new Exception("Duplicate Name");
            }

            if (existingByProcess != null)
            {
                this.logService.Error("Duplicate Process Name: " + watcher.ProcessName);
                throw new Exception("Duplicate Process Name");
            }

            this.saveService.Save(watcher);
            this.eventBus.Publish(this, new WatcherServiceCreateEvent(watcher));
        }

        /// <summary>
        /// Updates an existing watcher
        /// </summary>
        /// <param name="watcher">Watcher to update</param>
        public void Update(Watcher watcher)
        {
            this.Validate(watcher);
            Watcher existingByName = this.Get(watcher.Name);

            if (existingByName == null)
            {
                this.logService.Error("Unknown Watcher: " + watcher.Name);
                throw new Exception("Unknown Watcher");
            }

            this.saveService.Save(watcher);
        }

        /// <summary>
        /// Validates the watcher's fields
        /// </summary>
        /// <param name="watcher">Watcher to validate</param>
        private void Validate(Watcher watcher)
        {
            if (string.IsNullOrWhiteSpace(watcher.Name))
            {
                this.logService.Error("Watcher Name canot be blank");
                throw new ArgumentException("Name cannot be blank", nameof(watcher));
            }

            if (string.IsNullOrWhiteSpace(watcher.ProcessName))
            {
                this.logService.Error("Watcher Process Name cannot be blank");
                throw new ArgumentException("Process Name cannot be blank", nameof(watcher));
            }

            if (watcher.ProcessCount <= 0)
            {
                this.logService.Error("Watcher Process Count cannot be less than 1");
                throw new ArgumentException("Process Count cannot be less than 1", nameof(watcher));
            }
        }
    }
}
