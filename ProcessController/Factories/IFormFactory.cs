using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessController.Forms;

namespace ProcessController.Factories
{
    public interface IFormFactory
    {
        MainForm GetMainForm();
        AddWatcherForm GetAddForm();
    }
}
