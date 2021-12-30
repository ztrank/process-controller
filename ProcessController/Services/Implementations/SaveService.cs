using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;
using ProcessController.Constants;
using Newtonsoft.Json;
using ProcessController.Events;

namespace ProcessController.Services.Implementations
{
    public class SaveService : ISaveService
    {
        private readonly IEventBus eventBus;
        private readonly ILogService<SaveService> logService;
        private readonly IFileSystem fileSystem;
        private readonly ISettingsService settings;
        private bool IsSaving = false;

        public event EventHandler SaveComplete;
        public event EventHandler<Exception> SaveFailure;

        private Dictionary<int, ProcessWatcher> watcherQueue = new Dictionary<int, ProcessWatcher>();
        private Dictionary<int, ProcessWatcher> watcherDeleteQueue = new Dictionary<int, ProcessWatcher>();
        public SaveService(
            IFileSystem fileSystem,
            ISettingsService settings,
            IEventBus eventBus, 
            ILogServiceFactory logServiceFactory, 
            IApplicationService applicationService)
        {
            this.fileSystem = fileSystem;
            this.settings = settings;
            this.eventBus = eventBus;
            this.logService = logServiceFactory.Create<SaveService>();
            applicationService.Tick += this.HandleTick;
        }

        public void QueueForSave(ProcessWatcher watcher)
        {
            if (!this.watcherQueue.ContainsKey(watcher.Id))
            {
                this.watcherQueue.Add(watcher.Id, watcher);
            }
        }

        public void QueueForDelete(ProcessWatcher watcher)
        {
            if (!this.watcherDeleteQueue.ContainsKey(watcher.Id))
            {
                this.watcherDeleteQueue.Add(watcher.Id, watcher);
            }
        }

        public List<ProcessWatcher> LoadWatchers()
        {
            SaveState currentState;

            if (this.fileSystem.File.Exists(this.GetSavePath()))
            {
                byte[] saveStateBytes = this.fileSystem.File.ReadAllBytes(this.GetSavePath());
                string saveStateJson = Encoding.ASCII.GetString(saveStateBytes);
                currentState = JsonConvert.DeserializeObject<SaveState>(saveStateJson);

                this.fileSystem.File.Copy(this.GetSavePath(), this.GetSaveBackup(), true);
            }
            else
            {
                currentState = new SaveState();
            }

            if (currentState.Watchers == null)
            {
                currentState.Watchers = new List<SaveState.ProcessWatcherEntry>();
            }

            return currentState.Watchers.Select(w => w.ToWatcher()).ToList();
        }

        private async void HandleTick(object sender, EventArgs e)
        {
            if (!this.IsSaving && this.HasPendingSaves())
            {
                this.IsSaving = true;
                await this.Save(
                    this.watcherQueue.Values.Select(x => new SaveState.ProcessWatcherEntry(x)),
                    this.watcherDeleteQueue.Keys.ToArray());
            }
        }

        private bool HasPendingSaves()
        {
            return this.watcherQueue.Count > 0 || this.watcherDeleteQueue.Count > 0;
        }
        private async Task Save(IEnumerable<SaveState.ProcessWatcherEntry> watchersToSave, int[] watcherIdsToDelete)
        {
            try
            {
                IEnumerable<SaveState.ProcessWatcherEntry> watchers = watchersToSave.Where(w => !watcherIdsToDelete.Contains(w.Id));
                SaveState currentState;

                if (this.fileSystem.File.Exists(this.GetSavePath()))
                {
                    byte[] saveStateBytes = await this.fileSystem.File.ReadAllBytesAsync(this.GetSavePath());
                    string saveStateJson = Encoding.ASCII.GetString(saveStateBytes);
                    currentState = JsonConvert.DeserializeObject<SaveState>(saveStateJson);

                    this.fileSystem.File.Copy(this.GetSavePath(), this.GetSaveBackup(), true);
                }
                else
                {
                    currentState = new SaveState();
                }

                this.UpsertProcessWatchers(ref currentState, watchers);
                this.DeleteProcessWatchers(ref currentState, watcherIdsToDelete);

                byte[] newSaveBytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(currentState));

                await this.fileSystem.File.WriteAllBytesAsync(this.GetSavePath(), newSaveBytes);
                this.logService.Debug("Save complete");
                this.SaveComplete?.Invoke(this, new EventArgs());
                this.eventBus.Publish(this, new SaveCompleteEvent()
                {
                    Watchers = watchers.ToList(),
                    WatchersDeleted = watcherIdsToDelete
                });
                this.watcherQueue.Clear();
                this.watcherDeleteQueue.Clear();
            }
            catch (Exception ex)
            {
                this.logService.Error("Save failed: " + ex.Message, ex);
                this.SaveFailure?.Invoke(this, ex);
                this.eventBus.Publish(this, new SaveFailureEvent(ex));
            }
            finally
            {
                this.IsSaving = false;
            }
        }

        private void DeleteProcessWatchers(ref SaveState state, int[] watcherIdsToDelete)
        {
            if(state.Watchers == null)
            {
                state.Watchers = new List<SaveState.ProcessWatcherEntry>();
            }

            state.Watchers = state.Watchers.Where(w => !watcherIdsToDelete.Contains(w.Id)).ToList();
        }

        private void UpsertProcessWatchers(ref SaveState state, IEnumerable<SaveState.ProcessWatcherEntry> watchers)
        {
            if (state.Watchers == null)
            {
                state.Watchers = new List<SaveState.ProcessWatcherEntry>();
            }

            foreach(SaveState.ProcessWatcherEntry watcher in watchers)
            {
                int index = state.Watchers.FindIndex(w => w.Id == watcher.Id);
                
                if (index == -1)
                {
                    state.Watchers.Add(watcher);
                }
                else
                {
                    state.Watchers[index] = watcher;
                }
            }
        }

        private string GetSavePath()
        {
            if (!this.fileSystem.Directory.Exists(Path.Combine(this.settings.GetBaseDirectory(), DataFiles.SaveDirectory))) 
            {
                this.fileSystem.Directory.CreateDirectory(Path.Combine(this.settings.GetBaseDirectory(), DataFiles.SaveDirectory));
            }

            return Path.Combine(this.settings.GetBaseDirectory(), DataFiles.SaveDirectory, DataFiles.SaveFile);
        }

        private string GetSaveBackup()
        {
            return Path.ChangeExtension(this.GetSavePath(), "bak");
        }
    }
}
