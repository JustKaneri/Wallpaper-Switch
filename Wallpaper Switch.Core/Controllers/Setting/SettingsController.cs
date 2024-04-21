﻿using Wallpaper_Switch.Core.Controllers.File;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Setting
{
    public class SettingsController
    {
        private AutoStartController _autoStartController;
        private readonly FileXMLControllerExpansion<ApplicationSettings> _fileController;
        private AutoChangeController _changeController;

        private ApplicationSettings _settings;

        private string _path;
        private const string _fileName = "settings";

        public SettingsController(string Path)
        {
            _path = Path;
            _fileController = new FileXMLControllerExpansion<ApplicationSettings>(_settings, _fileName);

            _settings = _fileController.LoadOne(_path);


            if (_settings == null)
            {
                _settings = new ApplicationSettings();
                _fileController = new FileXMLControllerExpansion<ApplicationSettings>(_settings, _fileName);
                Save();
            }


            _autoStartController = new AutoStartController(_settings);
            _changeController = new AutoChangeController(_settings);
        }

        /// <summary>
        /// Запустить автоматическую смену обоев каждые TIME минут
        /// </summary>
        /// <param name="time"></param>
        public void EnableAutoChange(int time)
        {
            Logger.Logger.AppednLog(LogLevel.Info, $"Enabling automatic wallpaper change every {time} minutes");

            _changeController.StartChange(time);
            Save();
        }

        /// <summary>
        /// Остановить автоматическую смену обоев
        /// </summary>
        public void DisableAutoChange()
        {
            Logger.Logger.AppednLog(LogLevel.Info, $"Disabling automatic wallpaper change every {_settings.PeriodСhange} minutes");

            _changeController.StopChange();
            Save();
        }

        public (int time,bool isChange) AutoChangeStatus()
        {
            return (_settings.PeriodСhange, _settings.IsChange);
        }

        /// <summary>
        /// Добавить в автозагрузку
        /// </summary>
        /// <returns></returns>
        public bool EnableAutoStart()
        {
            var res = _autoStartController.Enable(_path);
            Save();

            return res;
        }

        /// <summary>
        /// Удалить из автозагрузки
        /// </summary>
        /// <returns></returns>
        public bool DisableAutoStart()
        {
            var res = _autoStartController.Disable();
            Save();

            return res; 
        }

        public bool AutoStartStatus()
        {
            return _autoStartController.Status();
        }

        private void Save()
        {
            _fileController.SaveOne(_path);
        }
    }
}
