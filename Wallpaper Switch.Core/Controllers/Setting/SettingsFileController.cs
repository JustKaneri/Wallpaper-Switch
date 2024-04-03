using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Interface;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Setting
{
    public class SettingsFileController
    {
        private ApplicationSettings _applicationSettings;

        public SettingsFileController(ApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public void SaveSettings(string path, IFileSaver<ApplicationSettings> fileSaved)
        {
            try
            {
                fileSaved.Save(_applicationSettings, path);
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }
        }

        public ApplicationSettings LoadSetting(string path, IFileLoader<ApplicationSettings> fileLoader)
        {

            try
            {
                _applicationSettings = fileLoader.Load(path);
            }
            catch (Exception ex)
            {
                _applicationSettings = null;
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }


            return _applicationSettings;
        }
    }
}
