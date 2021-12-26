using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Components;
using ProcessController.Forms;
using ProcessController.Services;

namespace ProcessController.Factories
{
    public class FormFactory : IFormFactory
    {
        private readonly IWatcherService watcherService;
        private MainForm mainForm;

        public FormFactory(IWatcherService watcherService)
        {
            this.watcherService = watcherService;
        }

        public AddWatcherForm GetAddForm()
        {
            return new AddWatcherForm(this.watcherService);
        }

        public MainForm GetMainForm()
        {
            if (this.mainForm == null)
            {
                this.mainForm = new MainForm(this.watcherService, new WatcherDataGridController());
            }

            return this.mainForm;
        }
    }
}
