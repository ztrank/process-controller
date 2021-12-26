using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Models;

namespace ProcessController.Components.Interfaces
{
    public interface IWatcherDataGridController : IComponentController<DataGridView>
    {
        void SetData(List<Watcher> watchers);
        void HandleAdd(Watcher watcher);
        void HandleUpdate(Watcher watcher);
        void HandleRemove(Watcher watcher);
    }
}
