using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Controllers.Extension
{
    public static class WallpaperExtension
    {
        public static List<string> GetImagesPath(this string[] files)
        {
            List<string> extension = new List<string>() { ".png", ".jpg", ".jpeg" };

            return files.Where(f => extension.Contains(System.IO.Path.GetExtension(f))).ToList();
        }
    }
}
