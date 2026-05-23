using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Core.Service
{
    public class WallpaperRandomService
    {
        private const float _step = 0.1f;
        private float _basePriorety { get; set; }
        private Wallpaper _oldElement { get; set; } = null;

        public WallpaperRandomService(float basePriorety)
        {
            _basePriorety = basePriorety;
        }

        public void ChangeBasePriorety(float basePriorety)
        {
            _basePriorety = basePriorety;
        }

        public Wallpaper GetRandom(List<Wallpaper> wallpapers)
        {
            if (wallpapers.Count == 1)
                return wallpapers.First();

            Random rnd = new Random();

            float maxPriority = wallpapers.Max(x => x.DataRandomness.Priority);

            if (maxPriority == 0)
                wallpapers.ForEach(e => e.DataRandomness.ResetPriority(_basePriorety));

            var sortList = wallpapers.Where(x => x.DataRandomness.Priority == maxPriority).ToList();

            if (sortList.Count == 1)
            {
                sortList[0].DataRandomness.LowerPriority(_step);
                _oldElement = sortList.First();
                return sortList.First();
            }

            int index;
            Wallpaper selectItem = null;

            do
            {
                index = rnd.Next(0, sortList.Count);
                selectItem = sortList[index];

            } while (_oldElement == null || _oldElement.CompareTo(selectItem) == 0);

            sortList[index].DataRandomness.LowerPriority(_step);
            _oldElement = sortList.First();
            return sortList[index];
        }

    }
}
