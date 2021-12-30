using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessController.Models;

namespace ProcessController.Services
{
    public interface ISettingsService
    {
        ApplicationSettings GetSettings();
        void UpdateSettings();
        bool HasPendingChanges();
        string GetBaseDirectory();
        void Save();
        void Init(string baseDirectory);
    }
}
