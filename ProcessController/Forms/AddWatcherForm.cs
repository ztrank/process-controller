using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController.Forms
{
    public partial class AddWatcherForm : Form
    {
        private readonly IWatcherService watcherService;

        public event EventHandler<Watcher> OnAddSuccess;

        public AddWatcherForm(IWatcherService watcherService)
        {
            InitializeComponent();
            this.watcherService = watcherService;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.watcherNameBox, "");
            this.errorProvider1.SetError(this.processNameBox, "");

            if (string.IsNullOrWhiteSpace(this.watcherNameBox.Text))
            {
                this.errorProvider1.SetError(this.watcherNameBox, "Watcher Name is required");
            }

            if (string.IsNullOrWhiteSpace(this.processNameBox.Text))
            {
                this.errorProvider1.SetError(this.processNameBox, "Process Name is required");
            }

            if (string.IsNullOrWhiteSpace(this.watcherNameBox.Text) || string.IsNullOrWhiteSpace(this.processNameBox.Text))
            {
                return;
            }

            Watcher watcher = new Watcher()
            {
                Name = this.watcherNameBox.Text,
                ProcessName = this.processNameBox.Text
            };

            this.watcherService.OnAddSuccess += this.HandleAddSuccess;
            this.watcherService.OnAddError += this.HandleAddError;
            this.watcherService.Add(watcher);
            
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.watcherService.OnAddSuccess -= this.HandleAddSuccess;
                this.watcherService.OnAddError -= this.HandleAddError;
            }
            finally
            {
                this.Close();
            }
        }

        private void HandleAddSuccess(object sender, Watcher watcher)
        {
            this.watcherService.OnAddSuccess -= this.HandleAddSuccess;
            this.watcherService.OnAddError -= this.HandleAddError;
            this.OnAddSuccess?.Invoke(this, watcher);
            this.Close();
        }

        private void HandleAddError(object sender, string message)
        {
            if (message.StartsWith("A watcher named"))
            {
                this.errorProvider1.SetError(this.watcherNameBox, message);
            }
            else
            {
                this.errorProvider1.SetError(this.addWatcherGroupBox, message);
            }
        }
    }
}
