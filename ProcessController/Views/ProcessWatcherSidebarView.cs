using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Models;
using ProcessController.Services;
using ProcessController.UserControls.DataGridView;

namespace ProcessController.Views
{
    public partial class ProcessWatcherSidebarView : UserControl
    {
        private IProcessWatcherService processWatcherService;
        private ObservableCollection<ProcessWatcher> watchers;
        private IApplicationService applicationService;
        private ILogService<ProcessWatcherSidebarView> logService;
        private bool isViewUpToDate = false;
        private int lastSelected = -1;

        public event EventHandler<int> SelectionChange;

        public ProcessWatcherSidebarView()
        {
            InitializeComponent();
        }

        public void Provide(
            IProcessWatcherService processWatcherService, 
            ILogServiceFactory logServiceFactory,
            IApplicationService applicationService)
        {
            this.processWatcherService = processWatcherService;
            this.applicationService = applicationService;
            this.logService = logServiceFactory.Create<ProcessWatcherSidebarView>();
            this.watchers = this.processWatcherService.Get();
            this.SetupDataGridView();
            this.applicationService.Idle += this.HandleCheckDataGridSelectionView;
        }

        ~ProcessWatcherSidebarView()
        {
            this.applicationService.Idle -= this.HandleCheckDataGridSelectionView;
        }
        private void SetupDataGridView()
        {
            this.processWatcherGridView.SuspendLayout();
            

            this.processWatcherGridView.AutoGenerateColumns = false;
            this.processWatcherGridView.AutoSize = true;
            this.processWatcherGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.processWatcherGridView.Columns.Add(new DataGridViewColumn()
            {
                Name = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                Visible = false
            });
            this.processWatcherGridView.Columns.Add(new DataGridViewColumn()
            {
                Name = "Name",
                CellTemplate = new DataGridViewTextBoxCell()
            });
            this.processWatcherGridView.ReadOnly = true;
            this.processWatcherGridView.ColumnCount = 2;
            this.SetGridViewData(false);
            this.processWatcherGridView.ResumeLayout();

            this.processWatcherGridView.SelectionChanged += this.HandleSelectionChanged;
            this.watchers.CollectionChanged += this.HandleCollectionChanged;
        }

        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.SetGridViewData(e.Action == NotifyCollectionChangedAction.Add);
        }

        private void HandleSelectionChanged(object sender, EventArgs eventArgs)
        {
            this.isViewUpToDate = false;
        }

        private void SetGridViewData(bool isAdd)
        {
            int selectedIndex = this.processWatcherGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if(selectedIndex == -1 && this.watchers.Count > 0)
            {
                selectedIndex = 0;
            }

            selectedIndex = Math.Min(selectedIndex, this.watchers.Count - 1);

            this.processWatcherGridView.Rows.Clear();
            foreach(ProcessWatcher watcher in this.watchers)
            {
                this.processWatcherGridView.Rows.Add(new object[] { watcher.Id, watcher.Name });
            }
            if (isAdd)
            {
                this.processWatcherGridView.Rows[this.processWatcherGridView.RowCount - 1].Selected = true;
                this.isViewUpToDate = true;
            }
            else
            {
                this.processWatcherGridView.Rows[selectedIndex].Selected = true;
            }
            
        }
        public void HandleCheckDataGridSelectionView(object sender, EventArgs e)
        {
            if (this.isViewUpToDate)
            {
                return;
            }

            int selected = this.processWatcherGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (selected != this.lastSelected)
            {
                this.logService.Debug(string.Format("Process Watcher Selection Changed from {0} to {1}", this.lastSelected.ToString(), selected.ToString()));
                if (selected != -1)
                {
                    this.SelectionChange?.Invoke(this, this.watchers[selected].Id);
                }
                else
                {
                    this.SelectionChange?.Invoke(this, -1);
                }
            }

            this.isViewUpToDate = true;
        }
    }
}
