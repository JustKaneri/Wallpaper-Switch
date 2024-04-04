using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Controllers.Logger
{
    public enum LogLevel
    {
        Error,
        Warning,
        Info
    }

    public class Logger
    {
        private static string _path { get; set; }

        private const string _fileName = "log.txt";

        public Logger(string Path) 
        {
            if(_path == null)
                _path = Path;
        }

        public static void AppednLog(LogLevel level,string message, Type type = null)
        {
            if (_path == null)
                return;

            using (StreamWriter writer = new StreamWriter(_path + _fileName, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("dd_MM_yyyy HH:mm:ss")}  |  " + 
                                 $"{FormateTypeLog(level)}  |  " +
                                 (type != null ? type.FullName+ "  |  " : "")+ 
                                 $"{message}");
            }
        }

        private static string FormateTypeLog(LogLevel level)
        {
            string name = Enum.GetName(typeof(LogLevel), level);

            if(name.Length < 7)
            {
                int need = 7 - name.Length;

                for (int i = 0; i < need; i++)
                {
                    name += " ";
                }
            }

            return name;
        }
    }
}
