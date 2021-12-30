using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface ISaveService
    {
        event EventHandler SaveComplete;
        event EventHandler<Exception> SaveFailure;

        void QueueForSave(ProcessWatcher watcher);
        void QueueForDelete(ProcessWatcher watcher);
        List<ProcessWatcher> LoadWatchers();
    }
}
