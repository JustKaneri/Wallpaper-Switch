using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Logger;

namespace Wallpaper_Switch.Manager
{
    public class AutoLoadManager
    {
        public static void AutoLoad(MainForm form)
        {
            string[] arg = Environment.GetCommandLineArgs();

            if (arg.Length > 1)
            {

                if (arg[1].Trim() == "background")
                {
                    form.Hide();
                    form.ShowInTaskbar = false;
                    form.WindowState = FormWindowState.Minimized;
                    Logger.AppednLog(LogLevel.Info, "The application was launched at system startup");
                }

            }
        }
    }
}
