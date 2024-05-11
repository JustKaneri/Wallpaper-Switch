using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Wallpaper;

namespace Wallpaper_Switch
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger log = new Logger(Application.StartupPath + "\\");
            WallpaperCollector wallpaperCollector = new WallpaperCollector(Application.StartupPath + "\\");

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Logger.AppednLog(LogLevel.Error, $"Application not started {ex}");
            }
            
        }
    }
}
