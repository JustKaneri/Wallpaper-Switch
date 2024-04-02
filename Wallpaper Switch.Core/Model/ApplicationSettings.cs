using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Model
{
    public class ApplicationSettings
    {
        /// <summary>
        /// Время изменения обоев минуты
        /// </summary>
        public int PeriodСhange { get; set; } = 5;

        /// <summary>
        /// Менять ли обои автоматически
        /// </summary>
        public bool IsChange { get; set; } = false;

        /// <summary>
        /// Автозапуск приложения
        /// </summary>
        public bool IsAutoLoader { get; set; } = false;

        public void Reset()
        {
            PeriodСhange = 5;
            IsChange = false;
            IsAutoLoader = false;
        }
    }
}
