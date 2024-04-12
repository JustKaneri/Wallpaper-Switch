using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Model
{
    public class Wallpaper : WallpaperBase
    {
        public string SourcName { get; }
        public string Path { get; }
        public string FileName { get;}

        public Wallpaper(Source source, string path)
        {
            SourcName = source.Name;
            Path = path;
            FileName= System.IO.Path.GetFileName(path);
        }

        public Wallpaper(string path)
        {
            SourcName = "";
            Path = path;
            FileName = System.IO.Path.GetFileName(path);
        }

        public Image Init()
        {
            SetImage(Image.FromFile(Path));

            return GetImage();
        }
    }
}
