using System;
using System.IO;
using System.IO.Abstractions;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ProcessController.Models;
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection container = new ServiceCollection();
            ConfigureServices(container);
            ConfigureFactories(container);
            ConfigureForms(container);
            ConfigureSettings(container);

            using(ServiceProvider provider = container.BuildServiceProvider())
            {
                IApplicationTimer timer = provider.GetRequiredService<IApplicationTimer>();
                timer.Start(2000);
                Form main = provider.GetRequiredService<Forms.MainForm>();
                Application.Run(main);
            }   
        }

        static void ConfigureSettings(ServiceCollection container)
        {
            container.AddSingleton(new AppSettings()
            {
                SaveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saved"),
                SaveFile = "saved.db"
            });
        }

        static void ConfigureServices(ServiceCollection container)
        {
            container.AddSingleton<ISaveService, SaveService>()
                .AddSingleton(typeof(ILogService<>), typeof(LogService<>))
                .AddSingleton<ILogWatcher, LogWatcher>()
                .AddSingleton<IProcessService, ProcessService>()
                .AddSingleton<ApplicationTimer>()
                .AddSingleton<IApplicationTick>(x => x.GetRequiredService<ApplicationTimer>())
                .AddSingleton<IApplicationTimer>(x => x.GetRequiredService<ApplicationTimer>())
                .AddSingleton<IWatcherService, WatcherService>()
                .AddSingleton<IEventBus, EventBus>()
                .AddScoped<IWatcherStatusService, WatcherStatusService>();
                
            /*container.AddSingleton<IEventBus, EventBus>()
                .AddSingleton<IWatcherService, WatcherService>()
                .AddScoped<IProcessService, ProcessService>();*/
        }

        static void ConfigureFactories(ServiceCollection container)
        {
            /*container.AddSingleton<IMonitorListViewFactory, MonitorListViewFactory>()
                .AddSingleton<IMonitorDetailFactory, MonitorDetailFactory>();*/
        }

        static void ConfigureForms(ServiceCollection container)
        {
            container.AddScoped<Forms.MainForm>();
        }

        static void ConfigureCommands(ServiceCollection container)
        {
            
        }
    }
}
