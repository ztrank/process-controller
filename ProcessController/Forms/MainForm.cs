using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Services;
using ProcessController.Views;
using ProcessController.Enums;

namespace ProcessController.Forms
{
    public partial class MainForm : Form
    {
        public MainForm(
            IWatcherService watcherService, 
            IWatcherStatusService watcherStatusService, 
            IApplicationTick timer,
            ILogWatcher logWatcher,
            ISaveService saveService,
            ILogService<WatcherList> watcherListLogService)
        {
            InitializeComponent();
            this.logViewer1.Provide(logWatcher, LogLevel.Debug | LogLevel.Info | LogLevel.Warn | LogLevel.Error);
            this.watcherList1.Provide(watcherService, watcherStatusService, timer, watcherListLogService);

            saveService.Load();
        }
    }
}
