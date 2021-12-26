using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text.Json;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public class WatcherService : IWatcherService
    {
        /// <summary>
        /// File System
        /// </summary>
        private readonly IFileSystem fileSystem;

        /// <summary>
        /// Base Directory
        /// </summary>
        private readonly string baseDirectory;

        /// <summary>
        /// Path from base directory to watcher file
        /// </summary>
        private readonly string watcherFilePath;

        /// <summary>
        /// Event fired when the list of watchers is loaded successfully
        /// </summary>
        public event EventHandler<List<Watcher>> OnLoadSuccess;

        /// <summary>
        /// Event fired when loading watchers fails
        /// </summary>
        public event EventHandler<string> OnLoadError;

        /// <summary>
        /// Event fired when saving all is successful
        /// </summary>
        public event EventHandler OnSaveAllSuccess;

        /// <summary>
        /// Event Fired when saving all errors
        /// </summary>
        public event EventHandler<string> OnSaveAllError;

        /// <summary>
        /// Event fired when removing a watcher is sucessful
        /// </summary>
        public event EventHandler OnRemoveSuccess;

        /// <summary>
        /// Event fired when removing a watcher errors
        /// </summary>
        public event EventHandler<string> OnRemoveError;

        /// <summary>
        /// Event fired when updating a watcher is successful
        /// </summary>
        public event EventHandler OnUpdateSuccess;

        /// <summary>
        /// Event fired when updating a watcher errors
        /// </summary>
        public event EventHandler<string> OnUpdateError;

        /// <summary>
        /// Event fired for all errors
        /// </summary>
        public event EventHandler<string> OnError;

        /// <summary>
        /// Event fired when adding a watcher errors
        /// </summary>
        public event EventHandler<string> OnAddError;

        /// <summary>
        /// Event fired when adding a watcher is successful
        /// </summary>
        public event EventHandler<Watcher> OnAddSuccess;

        /// <summary>
        /// Instantiates the Watcher Service
        /// </summary>
        /// <param name="baseDirectory">Base Directory</param>
        /// <param name="watcherFilePath">Path to watcher file</param>
        public WatcherService(string baseDirectory, string watcherFilePath) 
            : this(new FileSystem(), baseDirectory, watcherFilePath)
        {

        }

        /// <summary>
        /// Instantiates the Watcher Service
        /// </summary>
        /// <param name="fileSystem">File System implementation</param>
        /// <param name="baseDirectory">Base Directory</param>
        /// <param name="watcherFilePath">Path to watcher file</param>
        public WatcherService(IFileSystem fileSystem, string baseDirectory, string watcherFilePath)
        {
            this.fileSystem = fileSystem;
            this.baseDirectory = baseDirectory;
            this.watcherFilePath = watcherFilePath;
        }

        /// <summary>
        /// Begins loading all watchers
        /// </summary>
        public async void LoadAll()
        {
            await this.LoadAllWatchers();
        }

        /// <summary>
        /// Adds the watcher
        /// </summary>
        /// <param name="watcher">Watcher to add</param>
        public async void Add(Watcher watcher)
        {
            await this.AddWatcher(watcher);
        }

        /// <summary>
        /// Updates the watcher
        /// </summary>
        /// <param name="watcher">Watcher to update</param>
        public async void Update(Watcher watcher)
        {
            await this.UpdateWatcher(watcher);
        }

        /// <summary>
        /// Saves the list of watchers
        /// </summary>
        /// <param name="watchers">List of watchers to save</param>
        public async void SaveAll(List<Watcher> watchers)
        {
            await this.SaveAllWatchers(watchers);
        }

        /// <summary>
        /// Removes the watcher
        /// </summary>
        /// <param name="watcher">Watcher to remove</param>
        public async void Remove(Watcher watcher)
        {
            await this.RemoveWatcher(watcher);
        }

        /// <summary>
        /// Loads all watchers and invokes success or error events
        /// </summary>
        /// <returns>Empty Task</returns>
        private async Task LoadAllWatchers()
        {
            try
            {
                List<Watcher> watchers = await this.GetWatchers();
                this.OnLoadSuccess?.Invoke(this, watchers);
            }
            catch (Exception ex)
            {
                this.OnLoadError?.Invoke(this, ex.Message);
                this.OnError?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Adds the watcher and invokes success or error events
        /// </summary>
        /// <param name="watcher">Watcher to add</param>
        /// <returns>Empty Task</returns>
        private async Task AddWatcher(Watcher watcher)
        {
            try
            {
                List<Watcher> watchers = await this.GetWatchers();
                int index = watchers.FindIndex(w => w.Name == watcher.Name);
                
                if (index > -1)
                {
                    throw new Exception("A watcher named " + watcher.Name + " already exists");
                }

                watcher.Order = watchers.Count;
                watchers.Add(watcher);
                await this.SaveWatchers(watchers);
                this.OnAddSuccess?.Invoke(this, watcher);
            } 
            catch (Exception ex)
            {
                this.OnAddError?.Invoke(this, ex.Message);
                this.OnError?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Updates the watcher and invokes success or error events
        /// </summary>
        /// <param name="watcher">Watcher to update</param>
        /// <returns>Empty Task</returns>
        private async Task UpdateWatcher(Watcher watcher)
        {
            try
            {
                List<Watcher> watchers = await this.GetWatchers();
                int index = watchers.FindIndex(w => w.Name == watcher.Name);

                if (index < 0)
                {
                    throw new Exception("Unable to update watcher. No matching name.");
                }

                watchers[index] = watcher;

                await this.SaveWatchers(watchers);
                this.OnUpdateSuccess?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                this.OnUpdateError?.Invoke(this, ex.Message);
                this.OnError?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Saves all the watchers and invokes success or error event
        /// </summary>
        /// <param name="watchers">Watchers to save</param>
        /// <returns>Empty Task</returns>
        private async Task SaveAllWatchers(List<Watcher> watchers)
        {
            try
            {
                await this.SaveWatchers(watchers);
                this.OnSaveAllSuccess?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                this.OnSaveAllError?.Invoke(this, ex.Message);
                this.OnError?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Removes watcher and invokes success or error event
        /// </summary>
        /// <param name="watcher">Watcher to remove</param>
        /// <returns>Empty Task</returns>
        private async Task RemoveWatcher(Watcher watcher)
        {
            try
            {
                List<Watcher> watchers = await this.GetWatchers();
                int index = watchers.FindIndex(w => w.Name == watcher.Name);
                
                if (index > -1)
                {
                    watchers.RemoveAt(index);
                }

                await this.SaveAllWatchers(watchers);
                this.OnRemoveSuccess?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                this.OnRemoveError?.Invoke(this, ex.Message);
                this.OnError?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Serializes the watchers into a json and writes to the file
        /// </summary>
        /// <param name="watchers">Watchers to save</param>
        /// <returns>Empty Task</returns>
        private async Task SaveWatchers(List<Watcher> watchers)
        {
            string watchersJson = JsonSerializer.Serialize(watchers);
            await this.fileSystem.File.WriteAllTextAsync(this.baseDirectory + this.watcherFilePath, watchersJson);
        }

        /// <summary>
        /// Reads the file and deserializes the list of watchers
        /// </summary>
        /// <returns>Task with a list of saved watchers</returns>
        private async Task<List<Watcher>> GetWatchers()
        {
            string watchersJson = await this.fileSystem.File.ReadAllTextAsync(this.baseDirectory + this.watcherFilePath);
            if (string.IsNullOrWhiteSpace(watchersJson))
            {
                watchersJson = "[]";
            }

            return JsonSerializer.Deserialize<List<Watcher>>(watchersJson);
        }
    }
}
