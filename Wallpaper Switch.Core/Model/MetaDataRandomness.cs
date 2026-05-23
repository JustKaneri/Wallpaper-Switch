using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Model
{
    public class MetaDataRandomness
    {
        public float Priority { get; private set; }

        public MetaDataRandomness(float priority)
        {
            Priority = priority;
        }

        public void ResetPriority(float priority)
        {
            Priority = priority;
        }

        public void LowerPriority(float steep)
        {
            if (Priority - steep > 0)
                Priority -= steep;
        }
    }
}
