using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessController.Services
{
    public class ApplicationTimer : IApplicationTimer
    {
        public event EventHandler<IApplicationTick> OnTick;

        private readonly Timer timer = new Timer();

        public void Start(int interval)
        {
            timer.Interval = interval;
            timer.Tick += this.Tick;
            timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        private void Tick(object sender, EventArgs e)
        {
            this.OnTick?.Invoke(this, this);
        }
    }
}
