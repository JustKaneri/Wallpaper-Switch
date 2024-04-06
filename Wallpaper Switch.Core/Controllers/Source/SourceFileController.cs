using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Interface;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Source
{
    public class SourceFileController
    {
        private List<Model.Source> _sources;

        public SourceFileController(List<Model.Source> sources)
        {
            _sources = sources;
        }

        public void Save(string path, IFileSaver<List<Model.Source>> fileSaved)
        {
            try
            {
                fileSaved.Save(_sources, path);
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }
        }

        public List<Model.Source> Load(string path, IFileLoader<List<Model.Source>> fileLoader)
        {

            try
            {
                _sources = fileLoader.Load(path);
            }
            catch (Exception ex)
            {
                _sources = null;
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }


            return _sources;
        }
    }
}
