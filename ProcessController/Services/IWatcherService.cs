using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IWatcherService
    {
        List<Watcher> Get();
        Watcher Get(string name);
        Watcher GetByProcessName(string processName);
        void Create(Watcher watcher);
        void Update(Watcher watcher);
    }
}
