using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Controllers.Setting
{
    public class AutoChangeController
    {
        private readonly ApplicationSettings _settings;

        public AutoChangeController(ApplicationSettings settings)
        {
            _settings = settings;
        }

        public void StartChange(int time)
        {
            _settings.IsChange = true;
            _settings.PeriodСhange = time;
        }

        public void StopChange()
        {
            _settings.IsChange = false;
        }
    }
}
