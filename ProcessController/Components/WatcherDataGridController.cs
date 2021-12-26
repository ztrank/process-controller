using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Components.Interfaces;
using ProcessController.Models;

namespace ProcessController.Components
{
    public class WatcherDataGridController : IWatcherDataGridController
    {
        private DataGridView gridView;
        private List<Watcher> watchers;
        public List<Watcher> Watchers
        {
            get
            {
                if (this.watchers == null)
                {
                    return new List<Watcher>();
                }

                return this.watchers;
            }
        }

        public void Initialize(DataGridView controller)
        {
            this.gridView = controller;
            this.gridView.ColumnCount = 4;
            this.gridView.RowHeadersVisible = false;
            this.gridView.Columns[0].Name = "Watcher Name";
            this.gridView.Columns[1].Name = "Process Name";
            this.gridView.Columns[2].Name = "Status";
            this.gridView.Columns[3].Name = "PID(s)";

            this.gridView.Columns[0].DisplayIndex = 0;
            this.gridView.Columns[1].DisplayIndex = 1;
            this.gridView.Columns[2].DisplayIndex = 2;
            this.gridView.Columns[3].DisplayIndex = 3;
        }

        public void SetData(List<Watcher> watchers)
        {
            this.watchers = watchers;
            foreach(Watcher watcher in watchers)
            {
                this.gridView.Rows.Add(this.ToRow(watcher));
            }
        }

        public void HandleAdd(Watcher watcher)
        {
            this.gridView.Rows.Add(this.ToRow(watcher));
        }

        public void HandleUpdate(Watcher watcher)
        {
            for(int i = 0; i < this.gridView.Rows.Count; i++)
            {
                if ((string) this.gridView.Rows[i].Cells[0].Value == watcher.Name)
                {
                    this.gridView.Rows[i].SetValues(this.ToRow(watcher));
                }
            }
        }

        public void HandleRemove(Watcher watcher)
        {
            int index = -1;
            for (int i = 0; i < this.gridView.Rows.Count; i++)
            {
                if ((string)this.gridView.Rows[i].Cells[0].Value == watcher.Name)
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                this.gridView.Rows.RemoveAt(index);
            }
        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.gridView.Dispose();
            this.gridView = null;
        }

        private string[] ToRow(Watcher watcher)
        {
            string[] pids = watcher.Processes.Select(p => p.PID.ToString()).ToArray();
            return new string[] { watcher.Name, watcher.ProcessName, watcher.Status, string.Join(",", pids) };
        }
    }
}
