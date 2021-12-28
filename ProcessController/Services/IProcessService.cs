﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface IProcessService
    {
        void Monitor(string processName);
        Process Get(int id);
        List<Process> Get(string name);
        void CleanUp();
    }
}
