using Microsoft.Win32;
using System;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Core.Controllers.Logger;

namespace Wallpaper_Switch.Core.Controllers.Setting
{
    public class AutoStartController
    {
        private readonly ApplicationSettings _settings;

        private const string _applicationName = "Wallpaper Switch";

        public AutoStartController(ApplicationSettings settings)
        {
            _settings = settings;
        }

        public bool Disable()
        {
            if (!Status())
            {
                _settings.IsAutoLoader = false;

                Logger.Logger.AppednLog(LogLevel.Info, "The application is not in the startup registry");
                return true;
            }

            try
            {
                using (var reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (reg.GetValue(_applicationName) != null)
                        reg.DeleteValue(_applicationName);

                    _settings.IsAutoLoader = false;

                    Logger.Logger.AppednLog(LogLevel.Info, "The application has been deleted to the startup register");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(LogLevel.Error, ex.Message);
                return false;
            }

            return true;
        }

        public bool Enable(string path)
        {
            string Exect = $"\"{path}Wallpaper Switch.exe\" background";

            if (Status())
            {
                _settings.IsAutoLoader = true;

                Logger.Logger.AppednLog(LogLevel.Info, "The application is already in the startup registry");
                return true;
            }

            try
            {
                using (var reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\"))
                {
                    reg.SetValue(_applicationName, Exect);

                    _settings.IsAutoLoader = true;

                    Logger.Logger.AppednLog(LogLevel.Info, "The application has been added to the startup register");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(LogLevel.Error, ex.Message);
                return false;
            }

            return true;
        }

        public bool Status()
        {
            bool isAutoLoad = false;

            using (var reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"))
            {
                if (reg.GetValue(_applicationName) != null)
                {
                    isAutoLoad = true;
                }
            }

            _settings.IsAutoLoader = isAutoLoad;

            return isAutoLoad;
        }
    }
}
