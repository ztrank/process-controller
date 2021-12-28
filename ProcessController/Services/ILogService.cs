using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface ILogService<T>
    {
        void Debug(string message);
        void Debug(object data);
        void Debug(string message, object data);
        void Info(string message);
        void Info(object data);
        void Warn(string message);
        void Warn(object data);
        void Error(string message);
        void Error(Exception exception);
        void Error(string message, Exception exception);
        void Error(object data);
        void Error(string message, object data);
    }
}
