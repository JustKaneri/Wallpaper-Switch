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
            fileSaved.Save(value, path);
        }

        public T Load<T>(string path, IFileLoader<T> fileLoader) where T : class
        {
            T value;

            value = fileLoader.Load(path);

            return value;
        }
    }
}
