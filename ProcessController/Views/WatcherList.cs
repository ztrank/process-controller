using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Enums;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController.Views
{
    public partial class WatcherList : UserControl
    {
        public event EventHandler<string> OnSelect;
        
        private string selected;
        private IWatcherService watcherService;
        private IWatcherStatusService watcherStatusService;
        private IApplicationTick timer;
        private ILogService<WatcherList> logService;

        public WatcherList()
        {
            InitializeComponent();
            this.listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView.MultiSelect = false;
            this.listView.View = View.Details;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Columns.Add("Watchers", -2, HorizontalAlignment.Left);

            this.listView.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                var selected = this.listView.SelectedItems;
                
                if (selected.Count > 0)
                {
                    this.OnSelect?.Invoke(this, selected[0].Name);
                    this.selected = selected[0].Name;
                }
                else
                {
                    this.OnSelect?.Invoke(this, null);
                    this.selected = null;
                }
            };
        }

        ~WatcherList()
        {
            this.timer.OnTick -= this.Tick;
        }

        public void Provide(IWatcherService watcherService, IWatcherStatusService watcherStatusService, IApplicationTick tick, ILogService<WatcherList> logService)
        {
            this.watcherService = watcherService;
            this.watcherStatusService = watcherStatusService;
            this.timer = tick;
            this.timer.OnTick += this.Tick;
            this.logService = logService;

            foreach (Watcher watcher in this.watcherService.Get())
            {
                WatcherStatus status = this.watcherStatusService.GetStatus(watcher);
                ListViewItem item = new ListViewItem(watcher.Name)
                {
                    BackColor = this.GetBackColor(status),
                    ForeColor = this.GetForeColor(status),
                    Name = watcher.Name
                };
                this.listView.Items.Add(item);
                this.logService.Debug("Adding watcher to monitor list: " + watcher.Name);
            }
            this.Refresh();
        }

        private Color GetBackColor(WatcherStatus status)
        {
            return status switch
            {
                WatcherStatus.Error => Color.Red,
                WatcherStatus.Warning => Color.Orange,
                _ => Color.White,
            };
        }

        private Color GetForeColor(WatcherStatus status)
        {
            return status switch
            {
                WatcherStatus.Error => Color.White,
                WatcherStatus.Warning => Color.White,
                _ => Color.Black
            };
        }

        private void Tick(object sender, IApplicationTick tick)
        {
            this.RefreshWatchers();
        }

        private void RefreshWatchers()
        {
            foreach(Watcher watcher in this.watcherService.Get())
            {
                WatcherStatus status = this.watcherStatusService.GetStatus(watcher);
                int index = this.listView.Items.IndexOfKey(watcher.Name);
                
                if (index > -1)
                {
                    this.listView.Items[index].ForeColor = this.GetForeColor(status);
                    this.listView.Items[index].BackColor = this.GetBackColor(status);
                }
                else
                {
                    ListViewItem item = new ListViewItem(watcher.Name)
                    {
                        BackColor = this.GetBackColor(status),
                        ForeColor = this.GetForeColor(status),
                        Name = watcher.Name
                    };

                    this.listView.Items.Add(item);
                    this.logService.Debug("Adding watcher to monitor list: " + watcher.Name);
                }
            }
            
            if (this.selected != null && this.listView.Items.ContainsKey(this.selected))
            {
                int index = this.listView.Items.IndexOfKey(this.selected);
                this.listView.Items[index].Selected = true;
            }
        }
    }
}
