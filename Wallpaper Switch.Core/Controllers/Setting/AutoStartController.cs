﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string Exect = $"\"{path}\" background";

            try
            {
                using (var reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\"))
                {
                    reg.SetValue(path, Exect);

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
