using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessController.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        public event EventHandler Tick;
        public event EventHandler Idle;

        public void OnTick(object sender, EventArgs e)
        {
            this.Tick?.Invoke(sender, e);
        }

        public void OnIdle(object sender, EventArgs e)
        {
            this.Idle?.Invoke(sender, e);
        }

        public void Close()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
