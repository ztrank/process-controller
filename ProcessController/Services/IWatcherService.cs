using System;
using System.Collections.Generic;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IWatcherService
    {
        /// <summary>
        /// Event fired when the list of watchers is loaded successfully
        /// </summary>
        event EventHandler<List<Watcher>> OnLoadSuccess;

        /// <summary>
        /// Event fired when loading watchers fails
        /// </summary>
        event EventHandler<string> OnLoadError;

        /// <summary>
        /// Event fired when saving all is successful
        /// </summary>
        event EventHandler OnSaveAllSuccess;

        /// <summary>
        /// Event Fired when saving all errors
        /// </summary>
        event EventHandler<string> OnSaveAllError;

        /// <summary>
        /// Event fired when removing a watcher is sucessful
        /// </summary>
        event EventHandler OnRemoveSuccess;

        /// <summary>
        /// Event fired when removing a watcher errors
        /// </summary>
        event EventHandler<string> OnRemoveError;

        /// <summary>
        /// Event fired when updating a watcher is successful
        /// </summary>
        event EventHandler OnUpdateSuccess;

        /// <summary>
        /// Event fired when updating a watcher errors
        /// </summary>
        event EventHandler<string> OnUpdateError;

        /// <summary>
        /// Event fired for all errors
        /// </summary>
        event EventHandler<string> OnError;

        /// <summary>
        /// Event fired when adding a watcher errors
        /// </summary>
        event EventHandler<string> OnAddError;

        /// <summary>
        /// Event fired when adding a watcher is successful
        /// </summary>
        event EventHandler<Watcher> OnAddSuccess;

        /// <summary>
        /// Begins loading all watchers
        /// </summary>
        void LoadAll();

        /// <summary>
        /// Adds the watcher
        /// </summary>
        /// <param name="watcher">Watcher to add</param>
        void Add(Watcher watcher);

        /// <summary>
        /// Updates the watcher
        /// </summary>
        /// <param name="watcher">Watcher to update</param>
        void Update(Watcher watcher);

        /// <summary>
        /// Saves the list of watchers
        /// </summary>
        /// <param name="watchers">List of watchers to save</param>
        void SaveAll(List<Watcher> watchers);

        /// <summary>
        /// Removes the watcher
        /// </summary>
        /// <param name="watcher">Watcher to remove</param>
        void Remove(Watcher watcher);
    }
}
