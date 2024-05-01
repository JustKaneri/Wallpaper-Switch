using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Extension;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Wallpaper
{
    public class WallpaperController
    {
        private List<Model.Source> _sources;
        private List<Model.Wallpaper> _wallpapers;
        private Model.Wallpaper _currentWallpaper;
        private Model.Wallpaper _oldWallpaper;

        public event EventHandler OnFindBrokenImage;

        public WallpaperController(List<Model.Source> sources) 
        { 
            _sources = sources;

            WallpaperInit();

            Logger.Logger.AppednLog(Logger.LogLevel.Info, "Wallpaper Controller Init");
        }

        private void WallpaperInit()
        {
            _wallpapers = new List<Model.Wallpaper>();

            foreach (var item in _sources)
            {
                if (!item.IsActive)
                    continue;

                var files = System.IO.Directory.GetFiles(item.Path).GetImagesPath();

                Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Source {item.Name} init with {files.Count} images");

                foreach (var file in files) 
                {
                    Model.Wallpaper wallpaper = new Model.Wallpaper(item, file);

                    _wallpapers.Add(wallpaper); 
                }
            }
        }

        public void UpdateSource(List<Model.Source> sources)
        {
            _sources = sources;

            WallpaperInit();
        }

        public Image GetCurrentWallpaper()
        {
            string fullPath = "";
           
            using (var key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true))
            {
                fullPath = key.GetValue("WallPaper").ToString();
            }

            try
            {
                var source = _sources.Where(ph => fullPath.Contains(ph.Path)).FirstOrDefault();

                if (source == null)
                    _currentWallpaper = new Model.Wallpaper(fullPath);
                else
                    _currentWallpaper = new Model.Wallpaper(source, fullPath);

                _currentWallpaper.Init();
            }
            catch
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, "Failed get current wallpaper path: " + fullPath);
                return null;
            }

            return _currentWallpaper.GetImage();
        }

        /// <summary>
        /// Получить новые случайные обои
        /// </summary>
        /// <returns></returns>
        public Image SwitchOnRandomWallpaper()
        {
            Random rnd = new Random();
            Model.Wallpaper result = null;

            do
            {
                if (_wallpapers.Count == 0)
                {
                    Logger.Logger.AppednLog(LogLevel.Warning, $"Not images for wallaper");
                    return null;
                }

                result = _wallpapers[rnd.Next(_wallpapers.Count)];

                if(!System.IO.File.Exists(result.Path))
                {
                    Logger.Logger.AppednLog(LogLevel.Warning, $"Wallpaper not exist {result.Path}");
                    _wallpapers.Remove(result);
                    continue;
                }

                try
                {
                    result.Init();

                    break;
                }
                catch
                {
                    CathBrokenFile(result);
                    _wallpapers.Remove(result);
                    continue;
                }

            } while (true);

            SetWallpaper(result);

            _oldWallpaper = _currentWallpaper;
            _currentWallpaper = result;

            return result.GetImage();
        }

        /// <summary>
        /// Получить предыдущие обои
        /// </summary>
        /// <returns></returns>
        public Model.Wallpaper GetOldWallpaper()
        {
            return _oldWallpaper;
        }

        /// <summary>
        /// Сменить текущие обои на выбранные
        /// </summary>
        /// <returns></returns>
        public Image SwitchOldWallpaper(Model.Wallpaper wallpaper)
        {
            if(_currentWallpaper.CompareTo(wallpaper) == 0)
            {
                return null;
            }

            try
            {
                _oldWallpaper = _currentWallpaper;
                _currentWallpaper = wallpaper;

                _currentWallpaper.Init();
            }
            catch 
            {
                CathBrokenFile(_currentWallpaper);

                _currentWallpaper = _oldWallpaper;
            }

            SetWallpaper(_currentWallpaper);

            return _currentWallpaper.GetImage();
        }

        private void SetWallpaper(Model.Wallpaper wallpaper)
        {
            WallpaperSeter.SetImageOnWallpaper(wallpaper.Path);
            Logger.Logger.AppednLog(LogLevel.Info, $"Set wallpaper {wallpaper.Path}");
        }

        private void CathBrokenFile(Model.Wallpaper wallpaper)
        {
            var IsAdd = WallpaperCollector.IsolationOfBrokenFile(wallpaper.Path);

            if (IsAdd)
                OnFindBrokenImage?.Invoke(wallpaper, EventArgs.Empty);

            Logger.Logger.AppednLog(LogLevel.Error, $"A broken file path {wallpaper.Path}");
        }
    }
}
