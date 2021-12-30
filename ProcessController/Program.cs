using System;
using System.IO;
using System.IO.Abstractions;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ProcessController.Models;
using ProcessController.Services;
using ProcessController.Services.Implementations;

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
                // Get Services that need configuring
                ISettingsService settings = provider.GetRequiredService<ISettingsService>();
                ApplicationService applicationService = provider.GetRequiredService<ApplicationService>();

                // Init the settings with the base directory
                settings.Init(AppDomain.CurrentDomain.BaseDirectory);

                // Start the application tick
                Timer timer = new Timer();
                timer.Interval = 2000;
                timer.Start();
                timer.Tick += (sender, e) => applicationService.OnTick(applicationService, e);

                // Set the Idle event
                Application.Idle += applicationService.OnIdle;

                // Create the main form
                Form main = provider.GetRequiredService<Forms.MainForm>();

                // Run the application
                Application.Run(main);
            }   
        }

        static void ConfigureSettings(ServiceCollection container)
        {
            container.AddSingleton(new ApplicationSettings());
        }

        static void ConfigureServices(ServiceCollection container)
        {
            container
                .AddSingleton<ApplicationService>()
                .AddSingleton<IApplicationService>(x => x.GetRequiredService<ApplicationService>())
                .AddSingleton<ILogServiceFactory, LogServiceFactory>()
                .AddSingleton<ILogWatcher, LogWatcher>()
                .AddSingleton<ISettingsService, SettingsService>()
                .AddSingleton<IEventBus, EventBus>()
                .AddSingleton<ISaveService, SaveService>()
                .AddScoped<IProcessService, ProcessService>()
                .AddSingleton<IProcessWatcherService, ProcessWatcherService>()
                .AddSingleton<IFileSystem, FileSystem>();
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
