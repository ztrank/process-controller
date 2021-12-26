using System;
using System.IO.Abstractions;
using System.Windows.Forms;
using ProcessController.Components;
using ProcessController.Factories;
using ProcessController.Forms;
using ProcessController.Services;

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
            IWatcherService watcherService = new WatcherService(AppDomain.CurrentDomain.BaseDirectory, "/saved/monitors.db");
            IFormFactory formFactory = new FormFactory(watcherService);
            ApplicationController controller = new ApplicationController(formFactory, watcherService);
            controller.Initialize();
            //IProcessMonitorService processMonitorService = new ProcessMonitorService();
            
            /*Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler((object sender, EventArgs args) => mainForm.OnTick());
            timer.Enabled = true;*/
            Application.Run(controller.GetForm());
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
