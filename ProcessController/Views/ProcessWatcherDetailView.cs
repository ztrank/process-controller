using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Events;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController.Views
{
    public partial class ProcessWatcherDetailView : UserControl
    {
        private ILogService<ProcessWatcherDetailView> logService;
        private IApplicationService applicationService;
        private IProcessWatcherService processWatcherService;
        private IEventBus eventBus;
        private ProcessWatcher processWatcher;
        public event EventHandler<bool> Dirty;
        public event EventHandler<int> ProcessSelectChange;
        private bool watchForSave = false;
        private int selectedProcess = -1;
        private bool isDirty = false;

        private ProcessWatcher ProcessWatcher
        {
            get
            {
                return this.processWatcher;
            }
            set
            {
                int oldId = this.processWatcher == null ? -1 : this.processWatcher.Id;
                int newId = value == null ? -1 : value.Id;

                this.StopListening();
                if (this.processWatcher != null)
                {
                    this.processWatcher.ProcessCountChange -= this.HandleProcessCountChange;
                }

                this.processWatcher = value;

                if (oldId != newId)
                {
                    this.RefreshProcessView();
                }

                this.processWatcher.ProcessCountChange += this.HandleProcessCountChange;
                this.nameField.Value = this.processWatcher.Name;
                this.processNameField.Value = this.processWatcher.ProcessName;
                this.targetCountField.Value = this.processWatcher.ProcessTargetCount;
                this.descriptionField.Value = this.processWatcher.Description;
                
                this.StartListening();
            }
        }

        public ProcessWatcherDetailView()
        {
            InitializeComponent();
        }

        public void Save()
        {
            this.HandleSaveClick(this, new EventArgs());
        }

        public void Provide(
            ILogServiceFactory logServiceFactory,
            IApplicationService applicationService,
            IProcessWatcherService processWatcherService,
            IEventBus eventBus)
        {
            this.eventBus = eventBus;
            this.logService = logServiceFactory.Create<ProcessWatcherDetailView>();
            this.applicationService = applicationService;
            this.processWatcherService = processWatcherService;
            this.eventBus.Subscriptions += this.HandleEventBus;
            this.saveBtn.Click += this.HandleSaveClick;
            this.undoBtn.Click += this.HandleResetClick;
            this.applicationService.Tick += this.HandleTick;
            this.processListView.SelectedIndexChanged += this.HandleProcessSelect;
            this.deleteBtn.Click += this.HandleDeleteClick;
            this.Dirty += (sender, isDirty) => this.isDirty = isDirty;

            this.Dirty += (object sender, bool isDirty) =>
            {
                if (isDirty)
                {
                    this.saveBtn.Enabled = true;
                    this.undoBtn.Enabled = true;
                }
                else
                {
                    this.saveBtn.Enabled = false;
                    this.undoBtn.Enabled = false;
                }
            };
        }

        public void SetWatcher(int id)
        {
            if (this.isDirty)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes, would you like save before continuing?", "", MessageBoxButtons.YesNoCancel);

                if(result == DialogResult.Yes)
                {
                    this.HandleSaveClick(this, new EventArgs());
                }
                else if(result == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.logService.Debug(string.Format("Setting watcher {0}", id.ToString()));
            if (id > -1)
            {
                this.ProcessWatcher = this.processWatcherService.Get(id);
                this.logService.Debug(string.Format("Setting to existing watcher {0}", id.ToString()), this.ProcessWatcher);
            }
            else
            {
                this.ProcessWatcher = this.processWatcherService.Get(null);
                this.logService.Debug(string.Format("Setting to new watcher {0}", this.ProcessWatcher.Id.ToString()), this.ProcessWatcher);
            }
            this.Dirty?.Invoke(this, false);
        }

        private void HandleTick(object sender, EventArgs e)
        {
            this.RefreshProcessView();
        }

        private void HandleDeleteClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this Process Watcher?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.processWatcherService.Delete(this.processWatcher);
                this.processWatcher = null;
            }
        }

        private void HandleProcessSelect(object sender, EventArgs e)
        {
            ListViewItem selected = this.processListView.SelectedItems.Count > 0 ? this.processListView.SelectedItems[0] : null;

            if (selected == null)
            {
                this.ProcessSelectChange?.Invoke(this, -1);
                this.selectedProcess = -1;
            }
            else
            {
                this.selectedProcess = int.Parse(selected.Name);
                this.ProcessSelectChange?.Invoke(this, this.selectedProcess);
            }
        }

        private void RefreshProcessView()
        {
            int selected = this.selectedProcess;
            this.processListView.Items.Clear();
            if (this.processWatcher != null && this.processWatcher.Processes.Count > 0)
            {
                List<ListViewItem> items = new List<ListViewItem>();
                List<ListViewItem> stopped = new List<ListViewItem>();
                foreach(Process process in this.processWatcher.Processes.Values.OrderByDescending(p => p.SystemProcess.StartTime))
                {
                    ListViewItem item = this.CreateProcessListViewItem(process);
                    if (selected == process.Id)
                    {
                        item.Selected = true;
                    }

                    if (process.Status == ProcessStatus.Running)
                    {
                        items.Add(item);
                    }
                    else
                    {
                        stopped.Add(item);
                    }
                }

                this.processListView.Items.AddRange(items.ToArray());
                this.processListView.Items.AddRange(stopped.ToArray());
                this.SetProcessCount(items.Count);
            }
            else
            {
                this.SetProcessCount(0);
            }
        }

        private ListViewItem CreateProcessListViewItem(Process process)
        {
            ListViewItem item = new ListViewItem(process.Id.ToString());
            item.ForeColor = this.GetForeColor(process);
            item.Name = process.Id.ToString();
            item.SubItems.Add(process.Status.ToString());
            item.SubItems.Add(process.SystemProcess.HasExited ? "" : process.SystemProcess.StartTime.ToString());
            item.SubItems.Add(process.SystemProcess.HasExited ? process.SystemProcess.ExitTime.ToString() : "");
            item.SubItems.Add(process.HasExited ? process.ExitCode.ToString() : "");
            item.SubItems.Add(process.SystemProcess.Responding.ToString());

            return item;   
        }

        private Color GetForeColor(Process process)
        {
            return process.Status switch
            {
                ProcessStatus.Crashed => Color.Red,
                ProcessStatus.Shutdown => Color.Orange,
                _ => Color.Black
            };
        }
        delegate void SetNumericCallback(int number);

        private void HandleProcessCountChange(object sender, EventArgs e)
        {
            int runningProcesses = this.processWatcher.RunningProcessCount;
            this.SetProcessCount(runningProcesses);
        }

        private void SetProcessCount(int count)
        {
            if (this.processCountField.NumberBox.InvokeRequired)
            {
                SetNumericCallback callback = new SetNumericCallback(SetProcessCount);
                this.Invoke(callback, new object[] { count });
            }
            else
            {
                this.processCountField.Value = count;
            }
        }

        private void HandleSaveClick(object sender, EventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.undoBtn.Enabled = false;

            string name = this.processWatcher.Name;
            string description = this.processWatcher.Description;
            int count = this.processWatcher.ProcessTargetCount;
            string processName = this.processWatcher.ProcessName;

            this.processWatcher.Name = this.nameField.Value;
            this.processWatcher.Description = this.descriptionField.Value;
            this.processWatcher.ProcessTargetCount = decimal.ToInt16(this.targetCountField.Value);
            this.processWatcher.ProcessName = this.processNameField.Value;
            this.watchForSave = true;
            try
            {
                this.processWatcherService.Save(this.processWatcher);
            }
            catch (Exception ex)
            {
                this.watchForSave = false;
                if (ex.Message.StartsWith("Invalid Name"))
                {
                    MessageBox.Show("Name is required. Enter a name and try again.");
                }
                else if (ex.Message.StartsWith("Invalid Process Name"))
                {
                    MessageBox.Show("Process Name is required. Enter a name and try again.");
                }
                else if(ex.Message.StartsWith("Invalid Process Count"))
                {
                    MessageBox.Show("Process Count must be greater than 0");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

                this.processWatcher.Name = name;
                this.processWatcher.Description = description;
                this.processWatcher.ProcessTargetCount = count;
                this.processWatcher.ProcessName = processName;
                this.saveBtn.Enabled = true;
                this.undoBtn.Enabled = true;
            }
            
        }

        private void HandleEventBus(object sender, ApplicationEvent @event)
        {
            if (this.watchForSave && @event is SaveCompleteEvent)
            {
                this.Dirty?.Invoke(this, false);
                this.watchForSave = false;
            }
        }

        private void HandleResetClick(object sender, EventArgs e)
        {
            this.StopListening();
            if (this.ProcessWatcher != null)
            {
                this.nameField.Value = this.ProcessWatcher.Name;
                this.processNameField.Value = this.ProcessWatcher.ProcessName;
                this.targetCountField.Value = this.ProcessWatcher.ProcessTargetCount;
                this.descriptionField.Value = this.ProcessWatcher.Description;
            }
            else
            {
                this.nameField.Value = "";
                this.processNameField.Value = "";
                this.targetCountField.Value = 0;
                this.descriptionField.Value = "";
            }
            this.StartListening();
        }

        private void DirtyHandler(object sender, EventArgs e)
        {
            this.Dirty?.Invoke(this, true);
        }

        private void StopListening()
        {
            this.nameField.TextBox.TextChanged -= this.DirtyHandler;
            this.processNameField.TextBox.TextChanged -= this.DirtyHandler;
            this.targetCountField.NumberBox.ValueChanged -= this.DirtyHandler;
            this.descriptionField.TextBox.TextChanged -= this.DirtyHandler;
        }

        private void StartListening()
        {
            this.nameField.TextBox.TextChanged += this.DirtyHandler;
            this.processNameField.TextBox.TextChanged += this.DirtyHandler;
            this.targetCountField.NumberBox.ValueChanged += this.DirtyHandler;
            this.descriptionField.TextBox.TextChanged += this.DirtyHandler;
        }
    }
}
