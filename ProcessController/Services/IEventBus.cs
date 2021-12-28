﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IEventBus
    {
        event EventHandler<ApplicationEvent> OnEvent;
        void Publish<T>(object sender, T @event) where T : ApplicationEvent;
    }
}
