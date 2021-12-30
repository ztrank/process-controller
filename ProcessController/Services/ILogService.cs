using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessController.Services
{
    public interface ILogService<T> where T : class
    {
        void Debug(string message);
        void Debug(string message, object data);
        void Info(string message);
        void Info(string message, object data);
        void Warn(string message);
        void Warn(string message, object data);
        void Error(string message);
        void Error(string message, Exception exception);
        void Error(string message, object data);
        void Error(string message, Exception exception, object data);
    }
}
