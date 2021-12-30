using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProcessController.Models;

namespace ProcessController.Services.Implementations
{
    public class SettingsService : ISettingsService
    {
        private ApplicationSettings applicationSettings;
        private readonly IFileSystem fileSystem;
        private readonly ILogService<SettingsService> logService;
        private string baseDirectory;
        private readonly ApplicationSettings defaultSettings;

        public SettingsService(
            IFileSystem fileSystem, 
            ILogServiceFactory logServiceFactory,
            ApplicationSettings defaultSettings)
        {
            this.fileSystem = fileSystem;
            this.logService = logServiceFactory.Create<SettingsService>();
            this.defaultSettings = defaultSettings;
        }

        public void Init(string baseDirectory)
        {
            this.baseDirectory = baseDirectory;
            this.Load();
        }

        public ApplicationSettings GetSettings()
        {
            return this.applicationSettings;
        }

        public bool HasPendingChanges()
        {
            return this.applicationSettings.PendingChanges;
        }

        public void UpdateSettings()
        {
            throw new NotImplementedException();
        }

        public string GetBaseDirectory()
        {
            return this.baseDirectory;
        }

        private string GetSettingsPath()
        {
            return Path.Combine(this.GetBaseDirectory(), "configs", "settings.config");
        }

        private void Load()
        {
            if (string.IsNullOrWhiteSpace(this.baseDirectory))
            {
                throw new Exception("Setting service not initialized. Did you forget to call Init(string) in your main method?");
            }

            if (this.applicationSettings == null)
            {
                if (this.fileSystem.File.Exists(this.GetSettingsPath()))
                {
                    try
                    {
                        byte[] bytes = this.fileSystem.File.ReadAllBytes(this.GetSettingsPath());
                        string json = Encoding.ASCII.GetString(bytes);
                        this.applicationSettings = JsonConvert.DeserializeObject<ApplicationSettings>(json);
                    }
                    catch
                    {
                        this.applicationSettings = this.defaultSettings.Clone();
                    }
                }
                else
                {
                    this.applicationSettings = this.defaultSettings.Clone();
                }
            }
        }

        public void Save()
        {
            if (!this.fileSystem.Directory.Exists(Path.Combine(this.GetBaseDirectory(), "configs")))
            {
                this.fileSystem.Directory.CreateDirectory(Path.Combine(this.GetBaseDirectory(), "configs"));
            }

            string backupPath = Path.ChangeExtension(this.GetSettingsPath(), "bak");
            if (this.fileSystem.File.Exists(this.GetSettingsPath()))
            {
                this.fileSystem.File.Copy(this.GetSettingsPath(), backupPath, true);
            }

            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(this.applicationSettings));
                this.fileSystem.File.WriteAllBytes(this.GetSettingsPath(), bytes);
                this.fileSystem.File.Delete(backupPath);
                this.logService.Info("Settings updated");
            }
            catch (Exception ex)
            {
                this.logService.Error(string.Format("Unable to save settings: {0}", ex.Message), ex, this.applicationSettings);
                if (this.fileSystem.File.Exists(backupPath))
                {
                    this.fileSystem.File.Copy(backupPath, this.GetSettingsPath(), true);
                }
            }
        }
    }
}
