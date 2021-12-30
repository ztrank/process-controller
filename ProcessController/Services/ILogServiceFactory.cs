﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Services
{
    public interface ILogServiceFactory
    {
        ILogService<T> Create<T>() where T : class;
    }
}
