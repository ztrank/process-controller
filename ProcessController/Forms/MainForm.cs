using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Components.Interfaces;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController.Forms
{
    public partial class MainForm : Form
    {
        private readonly IWatcherService watcherService;
        private readonly IWatcherDataGridController watcherDataGridController;
        private bool suspended = false;

        public event EventHandler OnAddRequest;
        public event EventHandler<Watcher> OnRemoveRequest;

        public MainForm(IWatcherService watcherService, IWatcherDataGridController watcherDataGridController)
        {
            InitializeComponent();
            this.watcherDataGridController = watcherDataGridController;
            this.watcherService = watcherService;

            this.watcherDataGridController.Initialize(this.WatcherDataGridView);
        }

        public void AddBtn_Click(object sender, EventArgs e)
        {
            if (!this.suspended)
            {
                this.OnAddRequest?.Invoke(sender, e);
            }
        }

        public void HandleLoadWatchers(List<Watcher> watchers)
        {
            this.watcherDataGridController.SetData(watchers);
        }

        public void HandleAddWatcher(Watcher watcher)
        {
            this.watcherDataGridController.HandleAdd(watcher);
        }

        public void HandleRemoveWatcher(Watcher watcher)
        {
            this.watcherDataGridController.HandleRemove(watcher);
        }

        public void Suspend()
        {
            this.suspended = true;
        }

        public void Resume()
        {
            this.suspended = false;
        }
    }
}
