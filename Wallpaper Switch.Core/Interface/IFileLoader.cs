using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Interface
{
    public interface IFileLoader <T> where T : class
    {
        T Load(string path);
    }
}
