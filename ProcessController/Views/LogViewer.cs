using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProcessController.Enums;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController.Views
{
    public partial class LogViewer : UserControl
    {
        private ILogWatcher logWatcher;
        private LogLevel levels;

        public LogViewer()
        {
            InitializeComponent();
        }

        ~LogViewer()
        {
            this.logWatcher.Log -= this.HandleLogEvent;
        }

        public void Provide(ILogWatcher logWatcher, LogLevel levels)
        {
            this.logWatcher = logWatcher;
            this.levels = levels;
            this.logWatcher.Log += this.HandleLogEvent;
        }

        private void HandleLogEvent(object sender, LogEntry logEvent)
        {
            if (this.levels.HasFlag(logEvent.Level))
            {
                ListViewItem item = new ListViewItem(logEvent.Source);
                item.ForeColor = this.GetForeColor(logEvent);
                item.SubItems.Add(logEvent.Message);
                item.SubItems.Add(logEvent.Data == null ? "" : JsonConvert.SerializeObject(logEvent.Data));
                this.listView1.Items.Insert(0, item);
            }
        }

        private Color GetForeColor(LogEntry log)
        {
            return log.Level switch
            {
                LogLevel.Debug => Color.Blue,
                LogLevel.Warn => Color.Orange,
                LogLevel.Error => Color.Red,
                _ => Color.Black
            };
        }
    }
}
