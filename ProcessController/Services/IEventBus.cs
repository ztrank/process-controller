using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Events;

namespace ProcessController.Services
{
    public interface IEventBus
    {
        event EventHandler<ApplicationEvent> Subscriptions;

        void Publish(object sender, ApplicationEvent @event);
    }
}
