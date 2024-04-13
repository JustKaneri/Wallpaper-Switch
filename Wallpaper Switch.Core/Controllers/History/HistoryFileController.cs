using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Interface;

namespace Wallpaper_Switch.Core.Controllers.History
{
    public class HistoryFileController
    {
        private List<Model.Wallpaper> _wallpapersHistory;

        public HistoryFileController(List<Model.Wallpaper> wallpapers)
        {
            _wallpapersHistory = wallpapers;
        }

        public void Save(string path, IFileSaver<List<Model.Wallpaper>> fileSaved)
        {
            try
            {
                fileSaved.Save(_wallpapersHistory, path);
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }
        }

        public List<Model.Wallpaper> Load(string path, IFileLoader<List<Model.Wallpaper>> fileLoader)
        {

            try
            {
                _wallpapersHistory = fileLoader.Load(path);
            }
            catch (Exception ex)
            {
                _wallpapersHistory = null;
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }


            return _wallpapersHistory;
        }
    }
}
