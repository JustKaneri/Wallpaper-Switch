using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Model
{
    public class Source
    {
        public string Name { get; set; } 

        public string Path { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
