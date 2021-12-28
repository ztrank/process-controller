using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessController.Events;
using ProcessController.Models;

namespace ProcessController.Services
{
    /// <summary>
    /// Save Service
    /// </summary>
    public class SaveService : ISaveService
    {
        /// <summary>
        /// Save State 
        /// </summary>
        private SaveState state;

        /// <summary>
        /// File System 
        /// </summary>
        private readonly IFileSystem fileSystem;

        /// <summary>
        /// Log Service
        /// </summary>
        private readonly ILogService<SaveService> logService;

        /// <summary>
        /// Path to save file
        /// </summary>
        private readonly string saveFilePath;

        /// <summary>
        /// Path to backup file
        /// </summary>
        private readonly string backupFilePath;

        /// <summary>
        /// Event Bus
        /// </summary>
        private readonly IEventBus eventBus;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="saveFileName"></param>
        public SaveService(
            IEventBus eventBus,
            ILogService<SaveService> logService,
            AppSettings appSettings)
            : this(new FileSystem(), eventBus, logService, appSettings)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="directory"></param>
        /// <param name="saveFileName"></param>
        public SaveService(
            IFileSystem fileSystem, 
            IEventBus eventBus,
            ILogService<SaveService> logService,
            AppSettings appSettings)
        {
            this.fileSystem = fileSystem;
            this.eventBus = eventBus;
            this.logService = logService;
            this.saveFilePath = Path.Combine(appSettings.SaveDirectory, appSettings.SaveFile);
            this.backupFilePath = Path.Combine(appSettings.SaveDirectory, Path.ChangeExtension(appSettings.SaveFile, "bak"));
        }

        /// <summary>
        /// Gets the current state, loading it if necessary
        /// </summary>
        /// <returns></returns>
        public SaveState Load()
        {
            if (this.state == null)
            {
                if (this.fileSystem.File.Exists(this.saveFilePath))
                {
                    this.logService.Info("Loading Save File");
                    byte[] bytes = this.fileSystem.File.ReadAllBytes(this.saveFilePath);
                    string json = Encoding.ASCII.GetString(bytes);
                    this.state = JsonConvert.DeserializeObject<SaveState>(json);
                    this.state.Watchers.ForEach(watcher => watcher.IsSaved = true);
                }
                else
                {
                    this.logService.Info("Creating Save File");
                    this.state = new SaveState();
                    this.SaveState();
                }

                this.eventBus.Publish(this, new SaveServiceLoadEvent(this.state));
            }

            return this.state;
        }

        /// <summary>
        /// Removes the watcher and saves the state
        /// </summary>
        /// <param name="watcher">Watcher to remove</param>
        public void Remove(Watcher watcher)
        {
            this.Load();

            int index = this.FindWatcherIndex(watcher);

            if (index > -1)
            {
                this.state.Watchers.RemoveAt(index);
                this.SaveState();
            }
        }

        /// <summary>
        /// Removes the action and saves the state
        /// </summary>
        /// <param name="action">Action to remove</param>
        public void Remove(Models.Action action)
        {
            this.Load();
            int index = this.FindActionIndex(action);

            if(index > -1)
            {
                this.state.Actions.RemoveAt(index);
                this.SaveState();
            }
        }

        /// <summary>
        /// Updates or Inserts the watcher
        /// </summary>
        /// <param name="watcher">Watcher to save</param>
        public void Save(Watcher watcher)
        {
            this.Load();
            watcher.IsSaved = true;
            int index = this.FindWatcherIndex(watcher);
            if (index > -1)
            {
                this.state.Watchers[index] = watcher;
            }
            else
            {
                this.state.Watchers.Add(watcher);
            }
            
            this.SaveState();
        }

        /// <summary>
        /// Updates or inserts the action
        /// </summary>
        /// <param name="action">Action to save</param>
        public void Save(Models.Action action)
        {
            this.Load();
            int index = this.FindActionIndex(action);

            if (index > -1)
            {
                this.state.Actions[index] = action;
            }
            else
            {
                this.state.Actions.Add(action);
            }

            this.SaveState();
        }

        /// <summary>
        /// Copies the current save file to a backup, then saves the state and invokes the OnChange event
        /// </summary>
        private void SaveState()
        {
            this.logService.Info("Saving Changes...");

            if (this.fileSystem.File.Exists(this.saveFilePath)) {
                this.fileSystem.File.Copy(this.saveFilePath, this.backupFilePath, true);
            }
            
            this.fileSystem.File.WriteAllBytes(this.saveFilePath, Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(this.state)));
            this.logService.Info("Save complete!");
            this.eventBus.Publish(this, new SaveServiceChangeEvent(this.state));
        }

        /// <summary>
        /// Gest the index for the given watcher
        /// </summary>
        /// <param name="watcher">Watcher to find</param>
        /// <returns>Index of the watcher, -1 if it doesn't exist in the list</returns>
        private int FindWatcherIndex(Watcher watcher)
        {
            return this.state.Watchers.FindIndex(w => w.Name == watcher.Name);
        }


        /// <summary>
        /// Gest the index for the given action
        /// </summary>
        /// <param name="action">Action to find</param>
        /// <returns>Index of the action, -1 if it doesn't exist in the list</returns>
        private int FindActionIndex(Models.Action action)
        {
            return this.state.Actions.FindIndex(a => a.Name == action.Name);
        }
    }
}
