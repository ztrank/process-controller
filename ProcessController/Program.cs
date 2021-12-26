using ProcessController.Services;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessController
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IFileSystem fileSystem = new FileSystem();
            Setup(fileSystem, AppDomain.CurrentDomain.BaseDirectory);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMonitorService monitorService = new MonitorService(AppDomain.CurrentDomain.BaseDirectory + "/saved/monitors.db");
            IProcessMonitorService processMonitorService = new ProcessMonitorService();
            MainForm mainForm = new MainForm(monitorService, processMonitorService).SetupDataGrid();
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler((object sender, EventArgs args) => mainForm.OnTick());
            timer.Enabled = true;
            Application.Run(mainForm);
        }

        static void Setup(IFileSystem fileSystem, string basePath)
        {
            if (!fileSystem.Directory.Exists(basePath + "/saved"))
            {
                fileSystem.Directory.CreateDirectory(basePath + "/saved");
            } 

            if (!fileSystem.File.Exists(basePath + "/saved/monitors.db"))
            {
                fileSystem.File.WriteAllText(basePath + "/saved/monitors.db", "[]");
            }
        }
    }
}
