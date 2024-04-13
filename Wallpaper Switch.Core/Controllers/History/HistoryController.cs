using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.File;

namespace Wallpaper_Switch.Core.Controllers.History
{
    public class HistoryController
    {
        private const string _fileName = "history";

        private readonly string _path;
        private readonly HistoryFileController _fileController;

        private List<Model.Wallpaper> _wallpapersHistory = new List<Model.Wallpaper>();

        public HistoryController(string Path)
        {
            _path = Path;

            _fileController = new HistoryFileController(_wallpapersHistory);

            _wallpapersHistory = _fileController.Load(_path, new XmlFileLoader<List<Model.Wallpaper>>(_fileName));

            if (_wallpapersHistory == null)
            {
                _wallpapersHistory = new List<Model.Wallpaper>();
                _fileController = new HistoryFileController(_wallpapersHistory);
            }
            else
            {
                Init();
            }

        }

        private void Init()
        {
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"HistoryController init");

            for (int i = _wallpapersHistory.Count-1; i >= 0; i--)
            {
                try
                {
                    _wallpapersHistory[i].Init();
                }
                catch
                {
                    Logger.Logger.AppednLog(Logger.LogLevel.Error, $"Failed load file {_wallpapersHistory[i].Path} from history");
                    _wallpapersHistory.RemoveAt(i);
                }
            }

            _fileController.Save(_path, new XmlFileSaver<List<Model.Wallpaper>>(_fileName));
        }

        public List<Model.Wallpaper> GetHistory()
        {
            return _wallpapersHistory.ToList();
        }

        public void Push(Model.Wallpaper wallpaper)
        {
            _wallpapersHistory.Add(wallpaper);

            if (_wallpapersHistory.Count > 4)
                _wallpapersHistory.RemoveAt(0);

            _fileController.Save(_path, new XmlFileSaver<List<Model.Wallpaper>>(_fileName));

            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Add file {wallpaper.Path} into history");
        }
    }
}
