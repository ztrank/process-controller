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
using ProcessController.Services;
using ProcessController.Views;

namespace ProcessController.Forms
{
    public partial class MainForm : Form
    {
        private readonly ILogService<MainForm> logService;
        private readonly IEventBus eventBus;
        private readonly IApplicationService applicationService;
        private bool isDirty = false;

        public MainForm(
            IProcessWatcherService processWatcherService, 
            ILogWatcher logWatcher,
            ILogServiceFactory logServiceFactory,
            IApplicationService applicationService,
            IEventBus eventBus)
        {
            this.logService = logServiceFactory.Create<MainForm>();
            this.applicationService = applicationService;
            this.eventBus = eventBus;
            InitializeComponent();
            this.processWatcherSidebarView.Provide(processWatcherService, logServiceFactory, applicationService);
            this.processWatcherSidebarView.SelectionChange += this.HandleWatcherSelectionChange;
            this.logViewer.Provide(logWatcher, Models.LogLevel.Debug | Models.LogLevel.Info | Models.LogLevel.Warn | Models.LogLevel.Error);
            this.processWatcherDetailView.Provide(logServiceFactory, applicationService, processWatcherService, eventBus);
            this.processWatcherDetailView.Dirty += (sender, isDirty) =>
            {
                this.isDirty = isDirty;
            };
        }

        private void HandleWatcherSelectionChange(object sender, int Id)
        {
            this.logService.Debug("Process Watcher Selection Change: " + Id);
            this.processWatcherDetailView.SetWatcher(Id);
        }

        private void newWatcherMenuItem_Click(object sender, EventArgs e)
        {
            this.processWatcherDetailView.SetWatcher(-1);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (this.isDirty)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Would you like to save before exiting?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.eventBus.Subscriptions += this.SaveOnExitComplete;
                    this.processWatcherDetailView.Save();
                }
                else if(result == DialogResult.No)
                {
                    this.applicationService.Close();
                }
            }
            else
            {
                this.applicationService.Close();
            }
        }

        private void SaveOnExitComplete(object sender, ApplicationEvent @event)
        {
            if(@event is SaveCompleteEvent)
            {
                this.applicationService.Close();
            }
            else if(@event is SaveFailureEvent)
            {
                this.eventBus.Subscriptions -= this.SaveOnExitComplete;
            }
        }
    }
}
