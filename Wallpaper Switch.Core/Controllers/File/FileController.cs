using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Interface;

namespace Wallpaper_Switch.Core.Controllers.File
{
    public class FileController
    {
        public void Save<T>(T value,string path, IFileSaver<T> fileSaved) where T:class
        {
            try
            {
                fileSaved.Save(value, path);
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }
            
        }

        public T Load<T>(string path, IFileLoader<T> fileLoader) where T : class
        {
            T value;

            try
            {
                value = fileLoader.Load(path);

                return value;
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }

            return null;
        }
    }
}
