using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Wallpaper_Switch.Core.Controllers.Extension;
using Wallpaper_Switch.Core.Controllers.File;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Source
{
    public class SourceController
    {
        [XmlArray]
        private List<Model.Source> _sources;

        private SourceFileController _fileController;
        private readonly string _path;


        public SourceController(string Path) 
        {
            _path = Path;

            _fileController = new SourceFileController(_sources);

            _sources = _fileController.Load(_path, new XmlFileLoader<List<Model.Source>>("source"));

            if(_sources == null)
            {
                _sources = new List<Model.Source>();
                _fileController = new SourceFileController(_sources);
            }
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
                return null;
            }

            var files = Directory.GetFiles(source.Path).GetImagesPath();

            if(files.Count == 0)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, "The directory does not contain images");
                error = "Источник не содержит изображений";
                return null;
            }

            _sources.Add(source);

            _fileController.Save(_path, new XmlFileSaver<List<Model.Source>>("source"));
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Add new source {source.Name} Paht: {source.Path}");

            return _sources;
            
        }

        public List<Model.Source> DeleteSource(int index)
        {
            if(_sources.Count < index)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Warning, $"Failed try delete source by {index} index");
                return null;
            }

            var source = _sources[index];
            _sources.RemoveAt(index);

            _fileController.Save(_path, new XmlFileSaver<List<Model.Source>>("source"));
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

            _fileController.Save(_path, new XmlFileSaver<List<Model.Source>>("source"));
            

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

            _fileController.Save(_path, new XmlFileSaver<List<Model.Source>>("source"));
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

            _fileController.Save(_path, new XmlFileSaver<List<Model.Source>>("source"));
            Logger.Logger.AppednLog(Logger.LogLevel.Info, $"Source diactivated {_sources[index].Name}");

            return true;
        }
    }
}
