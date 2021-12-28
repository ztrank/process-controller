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
        SaveState Load();
        void Save(Watcher watcher);
        void Save(Models.Action action);
        void Remove(Watcher watcher);
        void Remove(Models.Action action);
    }
}
