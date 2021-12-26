
namespace ProcessController.Services
{
    using ProcessController.Models;
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Text.Json;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MonitorService : IMonitorService
    {
        private readonly IFileSystem fileSystem;
        private readonly string filePath;
        private List<Monitor> monitors;

        public MonitorService(string filePath) : 
            this(new FileSystem(), filePath)
        {

        }

        public MonitorService(IFileSystem fs, string filePath)
        {
            this.fileSystem = fs;
            this.filePath = filePath;
        }

        public async Task AddMonitor(Monitor monitor)
        {

            if (this.monitors == null)
            {
                await this.GetAll();
            }

            if (this.monitors.FindIndex(m => m.Name == monitor.Name) > -1)
            {
                throw new Exception("Monitor Name must be uniqe");
            }

            this.monitors.Add(monitor);
            await this.Write();
        }

        public Task<List<Monitor>> GetAll()
        {
            string file = this.fileSystem.File.ReadAllText(this.filePath);
            this.monitors = JsonSerializer.Deserialize<List<Monitor>>(string.IsNullOrWhiteSpace(file) ? "[]" : file);

            
            return Task.FromResult(this.monitors);
        }

        public async Task RemoveMonitor(Monitor monitor)
        {
            if (this.monitors == null)
            {
                await this.GetAll();
            }
            this.monitors.Remove(monitor);
            await this.Write();
        }

        public async Task UpdateMonitor(Monitor monitor)
        {
            if (this.monitors == null)
            {
                await this.GetAll();
            }

            int index = this.monitors.FindIndex(m => m.ProcessName == monitor.ProcessName);
            if (index != -1)
            {
                this.monitors[index] = monitor;
            }

            await this.Write();
        }

        private async Task Write()
        {
            await this.fileSystem.File.WriteAllTextAsync(this.filePath, JsonSerializer.Serialize(this.monitors, typeof(List<Monitor>)));
        }
    }
}
