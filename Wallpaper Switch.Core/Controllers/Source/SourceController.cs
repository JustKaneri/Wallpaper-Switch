using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Wallpaper_Switch.Core.Controllers.Extension;
using Wallpaper_Switch.Core.Controllers.File;

namespace Wallpaper_Switch.Core.Controllers.Source
{
    public class SourceController
    {
        [XmlArray]
        private List<Model.Source> _sources;

        private FileXMLControllerExpansion<Model.Source> _fileController;
        private readonly string _path;

        private const string _fileName = "source";

        public SourceController(string Path) 
        {
            _path = Path;

            _fileController = new FileXMLControllerExpansion<Model.Source>(_sources, _fileName);

            _sources = _fileController.LoadMany(_path);
        }

        public List<Model.Source> GetSources()
        {
            return _sources;
        }

        public List<Model.Source> AddSource(Model.Source source,ref string error)
        {
            var exist = _sources.Where(s => s.Name == source.Name || s.Path == source.Path).FirstOrDefault();

            if(exist != null)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, "Attempt to add an existing source");
                error = "Источник с таким именем или дерикторией уже существует";
                return _sources;
            }

            var files = Directory.GetFiles(source.Path).GetImagesPath();

            if(files.Count == 0)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, "The directory does not contain images");
                error = "Источник не содержит изображений";
                return _sources;
            }

            _sources.Add(source);

            Save();
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Add new source {source.Name} Paht: {source.Path}");

            return _sources;
            
        }

        public List<Model.Source> DeleteSource(int index)
        {
            if(_sources.Count < index)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, $"Failed try delete source by {index} index");
                return _sources;
            }

            var source = _sources[index];
            _sources.RemoveAt(index);

            Save();
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Deleted source {source.Name} Paht: {source.Path}");

            return _sources;

        }

        public List<Model.Source> EditSource(Model.Source newSource,Model.Source oldSource)
        {
            var sourceOriginal = _sources.Where(sr => sr.Path == oldSource.Path).FirstOrDefault();

            if (_sources.Where(sc => sc.Path == newSource.Path && sc.Path != oldSource.Path).FirstOrDefault() != null)
                return null;

            if (_sources.Where(sc => sc.Name == newSource.Name && sc.Name != oldSource.Name).FirstOrDefault() != null)
                return null;

            var index = _sources.IndexOf(sourceOriginal);

            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Edit source {oldSource.Name} on {newSource.Name} Paht: {oldSource.Path} on {newSource.Path}");

            _sources[index].Name = newSource.Name;
            _sources[index].Path = newSource.Path;
            _sources[index].IsActive = newSource.IsActive;

            Save();
            

            return _sources;
        }

        public bool AcitvateSource(int index)
        {
            if (_sources.Count < index)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, $"Failed try activate source by {index} index");
                return false;
            }

            _sources[index].IsActive = true;

            Save();
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Source activated {_sources[index].Name}");

            return true;
        }

        public bool DiacitvateSource(int index)
        {
            if (_sources.Count < index)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, $"Failed try diactivate source by {index} index");
                return false;
            }

            _sources[index].IsActive = false;

            Save();
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Source diactivated {_sources[index].Name}");

            return true;
        }

        private void Save()
        {
            _fileController.SaveMany(_path);
        }
    }
}
