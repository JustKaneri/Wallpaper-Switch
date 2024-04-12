using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Logger;

namespace Wallpaper_Switch.Core.Controllers.Wallpaper
{
    public class WallpaperCollector
    {
        private static string _path;
        private const string _directory = "BrokenWallpaper\\";

        public WallpaperCollector(string path)
        {
            _path = path + _directory;

            if(!System.IO.Directory.Exists(_path))
            {
                System.IO.Directory.CreateDirectory(_path);
            }
        }
        /// <summary>
        /// Удалить сломанный файл и переместить его во временную дирикторию 
        /// </summary>
        /// <param name="path"></param>
        public static bool AddToIgnore(string path)
        {
            if (!System.IO.Directory.Exists(_path))
            {
                System.IO.Directory.CreateDirectory(_path);
            }

            var result = false;

            result = Move(path);

            if (!result)
            {
                Rollback(path);
                return false;
            }

            result = Delete(path);

            if (!result)
            {
                Rollback(path);
                return false;
            }

            return result;
        }

        private static void Rollback(string path)
        {
            string fileName = "";
            try
            {
                fileName = System.IO.Path.GetFileName(path);
                System.IO.File.Delete(_path + fileName);
            }
            catch 
            {
                Logger.Logger.AppednLog(LogLevel.Error, $"Failed rollback add ignore for file {fileName}");
            }

            Logger.Logger.AppednLog(LogLevel.Info, $"Rollback add ignore for file {fileName}");
        }

        private static bool Delete(string path)
        {
            string fileName = "";

            try
            {
                fileName = System.IO.Path.GetFileName(path);
                System.IO.File.Delete(path);

                Logger.Logger.AppednLog(LogLevel.Info, $"File {fileName} deleted in {path}");

            }
            catch
            {
                Logger.Logger.AppednLog(LogLevel.Error, $"Faild file {fileName} deleted in {_path}");
                return false;
            }

            return true;
        }

        private static bool Move(string path)
        {
            string fileName ="";

            try
            {
                fileName =  System.IO.Path.GetFileName(path);
                System.IO.File.Copy(path, _path + fileName);

                Logger.Logger.AppednLog(LogLevel.Info, $"File {fileName} move in {_path}");

            }
            catch
            {
                Logger.Logger.AppednLog(LogLevel.Error, $"Faild file {fileName} move in {_path}");
                return false;
            }

            return true;
        }
    }
}
