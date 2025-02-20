﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Model
{
    public class Wallpaper : WallpaperBase, IComparable<Wallpaper>
    {
        public string SourcName { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }

        public Wallpaper()
        {
                
        }

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

        /// <summary>
        /// Получить изображение из файла 
        /// и уменьшить разрешение
        /// </summary>
        /// <returns></returns>
        public Image Init()
        {
            SetImage(Image.FromFile(Path));

            return GetImage();
        }

        public int CompareTo(Wallpaper other)
        {
            return Path.CompareTo(other.Path);
        }
    }
}
