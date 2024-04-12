using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper_Switch.Core.Model
{
    public abstract class WallpaperBase : IDisposable
    {
        private Image _sourceImage { get; set; }
        private Image _processedImage { get; set; }

        private const int _width = 448; 
        private const int _height = 252;

        public Image GetImage()
        {
            return _processedImage;
        }

        public void SetImage(Image value)
        {
            _sourceImage = value;

            ResizeImage();
        }

        private void ResizeImage()
        {
            if (_sourceImage.Width > _width && _sourceImage.Height > _height)
                _processedImage = new Bitmap(_sourceImage, _width, _height);
            else
                _processedImage = new Bitmap(_sourceImage);

            _sourceImage.Dispose();
        }

        public void Dispose()
        {
            _processedImage.Dispose();
        }
    }
}
