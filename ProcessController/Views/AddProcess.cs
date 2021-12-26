using ProcessController.Models;
using ProcessController.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessController.Views
{
    public partial class AddProcess : Form
    {
        private readonly IMonitorService monitorService;
        public event EventHandler<Monitor> complete;

        public AddProcess(IMonitorService monitorService)
        {
            InitializeComponent();
            this.monitorService = monitorService;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        public void Add_click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(monitorName.Text))
            {
                MessageBox.Show(this, "You must enter a Monitor Name");
                return;
            }

            if(string.IsNullOrWhiteSpace(processName.Text))
            {
                MessageBox.Show(this, "You must enter a Process Name");
                return;
            }

            Monitor monitor = new Monitor()
            {
                Name = monitorName.Text,
                ProcessName = processName.Text,
                RestartOnCrash = restartOnCrash.Checked
            };

            try
            {
                this.monitorService.AddMonitor(monitor).Wait();
                this.onComplete(monitor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        public void Cancel_click(object sender, EventArgs e)
        {
            this.onComplete(null);
        }

        public virtual void onComplete(Monitor arg)
        {
            EventHandler<Monitor> handler = this.complete;
            handler?.Invoke(this, arg);
        }
    }
}
