using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IProcessWatcherService
    {
        ProcessWatcher Get(int? id);
        ObservableCollection<ProcessWatcher> Get();
        void Save(ProcessWatcher watcher);
        void Delete(ProcessWatcher watcher);
    }
}
