using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Wallpaper;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Tools;

namespace Wallpaper_Switch.Manager
{
    public class WallpaperManager
    {
        private readonly WallpaperController _wallpaperController;

        public WallpaperManager(SourceMananger sourceMananger)
        {
            _wallpaperController = new WallpaperController(sourceMananger.GetSources());
            _wallpaperController.OnFindBrokenImage += _wallpaperController_OnFindBrokenImage;
        }

        public Image GetCurrentWallpaper()
        {
            return _wallpaperController.GetCurrentWallpaper();
        }

        public Wallpaper GetOldWallpaper()
        {
            return _wallpaperController.GetOldWallpaper();
        }

        public Image GetNewWallpaper()
        {
            var newImage = _wallpaperController.SwitchOnRandomWallpaper();

            if (newImage == null)
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Не удалось найти изображения");
                return null;
            }

            return newImage;
        }

        public Image SwitchWallpaper(Wallpaper newWallpaper)
        {
            return _wallpaperController.SwitchOldWallpaper(newWallpaper);
        }

        public void UpdateSource(List<Source> sources) 
        {
            _wallpaperController.UpdateSource(sources);
        }

        private void _wallpaperController_OnFindBrokenImage(object sender, EventArgs e)
        {
            var brokenWallpaper = (sender as Wallpaper);

            Notification.Show(NotificationForm.NotificationStatus.Error,
                     $"Сломанный файл: {brokenWallpaper.FileName} " +
                     $"был перемещен в {WallpaperCollector.GetFullPath()}");
        }
    }
}
