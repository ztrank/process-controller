﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessController.Enums;

namespace ProcessController.Models
{
    public class Watcher
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProcessName { get; set; }
        public int ProcessCount { get; set; }
        [JsonIgnore]
        public bool IsSaved { get; set; } = false;
        public List<WatcherAction> Actions { get; set; }
    }
}
