using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Factories;
using ProcessController.Forms;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController
{
    public class ApplicationController
    {
        private readonly IFormFactory formFactory;
        private readonly IWatcherService watcherService;
        private MainForm mainForm;

        public MainForm AppForm
        {
            get
            {
                if (this.mainForm == null)
                {
                    this.mainForm = this.formFactory.GetMainForm();
                }

                return this.mainForm;
            }
        }

        public ApplicationController(IFormFactory formFactory, IWatcherService watcherService)
        {
            this.formFactory = formFactory;
            this.watcherService = watcherService;
        }

        public void Initialize()
        {
            this.AppForm.OnAddRequest += this.HandleAddRequest;
            this.AppForm.OnRemoveRequest += this.HandleRemoveRequest;
            this.watcherService.OnLoadSuccess += this.HandleLoadSuccess;
            this.watcherService.OnRemoveError += this.HandleRemoveWatcherError;
            this.watcherService.OnRemoveSuccess += this.HandleRemoveWatcherSuccess;
            this.watcherService.LoadAll();
        }

        public Form GetForm()
        {
            return this.formFactory.GetMainForm();
        }

        private void HandleAddRequest(object sender, EventArgs e)
        {
            this.AppForm.Suspend();
            AddWatcherForm addForm = this.formFactory.GetAddForm();
            addForm.Show();
            addForm.OnAddSuccess += this.HandleAddSuccess;
            addForm.FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                addForm.OnAddSuccess -= this.HandleAddSuccess;
                this.AppForm.Resume();
            };
        }

        private Watcher pendingRemove;

        private void HandleRemoveRequest(object sender, Watcher watcher)
        {
            this.pendingRemove = watcher;
            this.watcherService.Remove(watcher);
            this.AppForm.HandleRemoveWatcher(watcher);
            
        }

        private void HandleAddSuccess(object sender, Watcher watcher)
        {
            this.AppForm.HandleAddWatcher(watcher);
        }

        private void HandleLoadSuccess(object sender, List<Watcher> watchers)
        {
            this.AppForm.HandleLoadWatchers(watchers);
        }

        private void HandleRemoveWatcherError(object sender, string error)
        {
            if (this.pendingRemove != null)
            {
                this.AppForm.HandleAddWatcher(pendingRemove);
            }
        }

        private void HandleRemoveWatcherSuccess(object sender, EventArgs e)
        {
            this.pendingRemove = null;
        }
    }
}
