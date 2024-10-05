using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.History;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Wallpaper;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Tools;
using Microsoft.VisualBasic;
using Wallpaper_Switch.Core.Controllers.File;

namespace Wallpaper_Switch.Manager
{
    public class HistoryManager
    {
        private List<PictureBox> _historyElements;
        private readonly HistoryController _historyController;

        public HistoryManager(List<PictureBox> pictures)
        {
           _historyElements = pictures;
           _historyController = new HistoryController(Application.StartupPath + "\\");
           FillHistory();
        }

        private void FillHistory()
        {
            Drop();

            var history = _historyController.GetHistory();

            history.Reverse();

            for (int i = 0; i < history.Count; i++)
            {
                _historyElements[i].Image = history[i].GetImage();
            }
        }

        private void Drop()
        {
            foreach (var item in _historyElements)
            {
                item.Image = null;
            }
        }
        

        public void AddToHistory(Wallpaper oldWallpaper)
        {
            _historyController.Push(oldWallpaper);
            FillHistory();
        }

        public Wallpaper GetHistoryElementData(PictureBox pictureBox)
        {
            int historyIndex = int.Parse(pictureBox.Tag.ToString());

            if (historyIndex > _historyController.GetHistory().Count)
                return null;

            return _historyController.GetHistory()[historyIndex];
        }

        public bool HistoryElemenDelete(PictureBox pictureBox)
        {
            int historyIndex = int.Parse(pictureBox.Tag.ToString());

            if (historyIndex > _historyController.GetHistory().Count)
                return false;

            var delWallpaper = _historyController.GetHistory()[historyIndex];
            string path = delWallpaper.Path;

            try
            {

                var resultDelete = FileOperationAPIWrapper.Send(path);

                if (resultDelete == true)
                {
                    var indexes = _historyController.Remove(delWallpaper);

                    foreach (var item in indexes)
                    {
                        _historyElements[item].Image = null;
                    }
                }

                FillHistory();
            }
            catch
            {
                Logger.AppednLog(LogLevel.Error, $"Failed delete file {path}");
                return false;
            }

            return true;
        }
    }
}
