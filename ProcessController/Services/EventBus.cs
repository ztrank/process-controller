using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public class EventBus : IEventBus
    {
        public event EventHandler<ApplicationEvent> OnEvent;

        public void Publish<T>(object sender, T @event) where T : ApplicationEvent
        {
            this.OnEvent?.Invoke(sender, @event);
        }
    }
}
