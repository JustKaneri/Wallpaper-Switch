using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Setting;
using Timer = System.Windows.Forms.Timer;

namespace Wallpaper_Switch.Manager
{
    public class SettingManager
    {
        private readonly SettingsController _settingsController;
        private readonly Timer _timer;

        public SettingManager(Timer timer)
        {
            _settingsController = new SettingsController(Application.StartupPath + "\\");
            _timer = timer;

            ConfiguringTimer();
        }
        

        public SettingsController GetSettings()
        {
            return _settingsController;
        }

        public void ConfiguringTimer()
        {
            int time = _settingsController.AutoChangeStatus().time;
            bool isActive = _settingsController.AutoChangeStatus().isChange;

            _timer.Interval = int.Parse(time.ToString()) * 60000;
            _timer.Enabled = isActive;
        }

        public void DisableTimer()
        {
            _settingsController.DisableAutoChange();
            ConfiguringTimer();
        }
    }
}
