
namespace ProcessController.Services
{
    using ProcessController.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMonitorService
    {
        Task AddMonitor(Monitor monitor);
        Task RemoveMonitor(Monitor monitor);
        Task UpdateMonitor(Monitor monitor);
        Task<List<Monitor>> GetAll();
    }
}
