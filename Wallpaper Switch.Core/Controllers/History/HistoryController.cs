using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.File;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.History
{
    public class HistoryController
    {
        private const string _fileName = "history";

        private readonly string _path;
        private readonly FileController _fileController;

        private List<Model.Wallpaper> _wallpapersHistory = new List<Model.Wallpaper>();

        public HistoryController(string Path)
        {
            _path = Path;

            _fileController = new FileController();

            Load();

            if (_wallpapersHistory.Count > 0)
                Init();

            Logger.Logger.AppednLog(Logger.LogLevel.Info, "History Controller Init");
        }

        private void Load()
        {
            _wallpapersHistory = _fileController.Load(_path, new XmlFileLoader<List<Model.Wallpaper>>(_fileName)) ?? new List<Model.Wallpaper>();
        }

        private void Init()
        {
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

            Save();
        }

        public List<Model.Wallpaper> GetHistory()
        {
            return _wallpapersHistory.ToList();
        }

        public void Push(Model.Wallpaper wallpaper)
        {
            _wallpapersHistory.Insert(0, wallpaper);

            if (_wallpapersHistory.Count > 4)
                _wallpapersHistory.RemoveAt(_wallpapersHistory.Count - 1);

            Save();

            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Add file {wallpaper.Path} into history");
        }

        private void Save()
        {
            _fileController.Save(_wallpapersHistory,_path, new XmlFileSaver<List<Model.Wallpaper>>(_fileName));
        }

        public void Remove(int historyIndex)
        {
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Remove file {_wallpapersHistory[historyIndex].Path}");
            _wallpapersHistory.RemoveAt(historyIndex);
            Save();
        }

        public List<int> Remove(Model.Wallpaper wallpaper)
        {
            List<int> indexes = _wallpapersHistory.
                               Select((p, i) => new { Index = i, Element = p }).
                               Where(wp => wp.Element.Path == wallpaper.Path).
                               Select(wp => wp.Index).ToList();


            indexes.Reverse();

            foreach (var item in indexes)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Remove file {_wallpapersHistory[item].Path}");
                _wallpapersHistory.RemoveAt(item);
            }

            Save();

            return indexes;
        }
    }
}
