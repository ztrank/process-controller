using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Events;

namespace ProcessController.Services.Implementations
{
    public class EventBus : IEventBus
    {
        public event EventHandler<ApplicationEvent> Subscriptions;

        public void Publish(object sender, ApplicationEvent @event)
        {
            this.Subscriptions?.Invoke(sender, @event);
        }
    }
}
