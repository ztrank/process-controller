
namespace ProcessController.Services
{
    using ProcessController.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IProcessMonitorService
    {
        Task<List<Process>> GetAll(List<Monitor> monitors);
    }
}
