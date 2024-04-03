using Wallpaper_Switch.Core.Controllers.File;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Setting
{
    public class SettingsController
    {
        private AutoStartController _autoStartController;
        private SettingsFileController _settingsFileController;
        private AutoChangeController _changeController;

        private ApplicationSettings _settings;

        private string _path;
        private const string _fileName = "settings";

        public SettingsController(string Path)
        {
            _path = Path;
            _settingsFileController = new SettingsFileController(_settings);

            _settings = _settingsFileController.LoadSetting(_path, new XmlFileLoader<ApplicationSettings>(_fileName));


            if (_settings == null)
            {
                _settings = new ApplicationSettings();
                _settingsFileController = new SettingsFileController(_settings);
                _settingsFileController.SaveSettings(Path, new XmlFileSaver<ApplicationSettings>(_fileName));
            }


            _autoStartController = new AutoStartController(_settings);
            _changeController = new AutoChangeController(_settings);
        }

        /// <summary>
        /// Запустить автоматическую смену обоев каждые TIME минут
        /// </summary>
        /// <param name="time"></param>
        public void StartAutoChange(int time)
        {
            Logger.Logger.AppednLog(LogLevel.Info, $"Enabling automatic wallpaper change every {time} minutes");

            _changeController.StartChange(time);
            _settingsFileController.SaveSettings(_path, new XmlFileSaver<ApplicationSettings>(_fileName));
        }

        /// <summary>
        /// Остановить автоматическую смену обоев
        /// </summary>
        public void StopAutoChange()
        {
            Logger.Logger.AppednLog(LogLevel.Info, $"Disabling automatic wallpaper change every {_settings.PeriodСhange} minutes");

            _changeController.StopChange();
            _settingsFileController.SaveSettings(_path, new XmlFileSaver<ApplicationSettings>(_fileName));
        }

        public (int time,bool isChange) AutoChangeStatus()
        {
            return (_settings.PeriodСhange, _settings.IsChange);
        }
    }
}
