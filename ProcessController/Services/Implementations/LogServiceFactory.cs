using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Services.Implementations
{
    public class LogServiceFactory : ILogServiceFactory
    {
        private readonly ILogWatcher watcher;

        public LogServiceFactory(ILogWatcher watcher)
        {
            this.watcher = watcher;
        }

        public ILogService<T> Create<T>() where T : class
        {
            return new LogService<T>(this.watcher);
        }
    }
}
