using ProcessController.Models;
using ProcessController.Services;
using ProcessController.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessController
{
    public partial class MainForm : Form
    {
        private readonly IMonitorService monitorService;
        private readonly IProcessMonitorService processMonitorService;
        private bool suspended = false;
        private List<Process> processes;
        private Process selectedRow;
        private int selectedIndex;

        public MainForm(IMonitorService monitorService, IProcessMonitorService processMonitorService)
        {
            InitializeComponent();
            
            this.monitorService = monitorService;
            this.processMonitorService = processMonitorService;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Suspend();
            AddProcess addForm = new AddProcess(this.monitorService);
            addForm.complete += (object sender, Monitor monitor) =>
            {
                addForm.Close();
                //this.Show();
                this.Resume();
                this.DisplayData();
            };
            addForm.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!this.suspended)
            {
                return;
            }

            this.monitorService.RemoveMonitor(this.selectedRow.Monitor).Wait();
            this.DisplayData();
        }

        public MainForm SetupDataGrid()
        {
            this.ProcessMonitorGrid.ColumnCount = 3;
            this.ProcessMonitorGrid.Columns[0].Name = "PID";
            this.ProcessMonitorGrid.Columns[1].Name = "Process Name";
            this.ProcessMonitorGrid.Columns[2].Name = "Status";

            this.ProcessMonitorGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ProcessMonitorGrid.MultiSelect = false;
            this.ProcessMonitorGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ProcessMonitorGrid.RowHeadersVisible = false;

            this.ProcessMonitorGrid.Columns[0].DisplayIndex = 0;
            this.ProcessMonitorGrid.Columns[1].DisplayIndex = 1;
            this.ProcessMonitorGrid.Columns[2].DisplayIndex = 2;
            this.ProcessMonitorGrid.SelectionChanged += new EventHandler(this.SelectedRowButtonClick);
            this.DisplayData();
            return this;
        }

        public void OnTick()
        {
            if (!this.suspended)
            {
                this.DisplayData();
            }
        }

        public void Suspend()
        {
            this.suspended = true;
        }

        public void Resume()
        {
            this.suspended = false;
        }

        private void DisplayData()
        {
            List<Monitor> monitors = this.monitorService.GetAll().Result;
            this.processes = this.processMonitorService.GetAll(monitors).Result;
            this.ProcessMonitorGrid.Rows.Clear();
            foreach(Process process in this.processes)
            {
                if (process.PID != null)
                {
                    this.ProcessMonitorGrid.Rows.
                }
                // this.ProcessMonitorGrid.Rows.Add(new string[] { process.PID == null ? "" : process.PID.ToString(), process.Name, process.Status });
            }

            if (this.selectedIndex > -1 && this.ProcessMonitorGrid.Rows.Count - 1 >= this.selectedIndex)
            {
                this.ProcessMonitorGrid.Rows[this.selectedIndex].Selected = true;
            } 
        }

        public void SelectedRowButtonClick(object sender, EventArgs e)
        {
            if(this.processes == null)
            {
                return;
            }

            int selectedRowCount = this.ProcessMonitorGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                this.removeProcess.Enabled = true;
                this.selectedRow = this.processes[this.ProcessMonitorGrid.SelectedRows[0].Index];
                this.selectedIndex = this.ProcessMonitorGrid.SelectedRows[0].Index;
            }
            else
            {
                this.removeProcess.Enabled = false;
                this.selectedRow = null;
                this.selectedIndex = -1;
            }
        }
    }
}
