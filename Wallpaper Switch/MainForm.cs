using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Setting;
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Controllers.Wallpaper;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Manager;
using Wallpaper_Switch.Tools;

namespace Wallpaper_Switch
{
    public partial class MainForm : Form
    {

        private readonly WallpaperController _wallpaperController;

        private readonly SourceMananger _sourceMananger;
        private readonly HistoryManager _historyManager;
        private readonly SettingManager _settingManager;

        public MainForm()
        {
            InitializeComponent();

            _historyManager = new HistoryManager(new List<PictureBox>() { PbxOld1, PbxOld2, PbxOld3, PbxOld4 });
            _settingManager = new SettingManager(timer1);
            _sourceMananger = new SourceMananger(DgvSource);

            _wallpaperController = new WallpaperController(_sourceMananger.GetSources());
            _wallpaperController.OnFindBrokenImage += _wallpaperController_OnFindBrokenImage;
            PbxCurrent.Image = _wallpaperController.GetCurrentWallpaper();
        }

        private void _wallpaperController_OnFindBrokenImage(object sender, EventArgs e)
        {
            var brokenWallpaper = (sender as Wallpaper);

            Notification.Show(NotificationForm.NotificationStatus.Error, 
                     $"Сломанный файл: {brokenWallpaper.FileName} " +
                     $"был перемещен в {WallpaperCollector.GetFullPath()}");
        }

        #region Source
        private void BtnSource_Click(object sender, EventArgs e)
        {
            //Включение и выключение видимсти панели
            PnlSource.Visible = !PnlSource.Visible;
        }

        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            _sourceMananger.AddNewSource();
        }

        private void BtnEditSource_Click(object sender, EventArgs e)
        {
            _sourceMananger.EditSource();
        }

        private void BtnDelSource_Click(object sender, EventArgs e)
        {
            _sourceMananger.DeleteSource();
        }

        private void DgvSource_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _sourceMananger?.ChangeSource(e);
        }

        private void DgvSource_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvSource.IsCurrentCellDirty)
            {
                DgvSource.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion

        private void BtnPropeties_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm(_settingManager.GetSettings());
            propertiesForm.ShowDialog();
            _settingManager.ConfiguringTimer();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            BtnSelect.Enabled = false;

            GetNewWallpaper();

            BtnSelect.Enabled = true;
        }

        private void GetNewWallpaper()
        {
            var newImage = _wallpaperController.SwitchOnRandomWallpaper();

            if (newImage == null)
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Не удалось найти изображения");
                _settingManager.DisableTimer();
                return;
            }

            if (newImage == null)
                return;

            PbxCurrent.Image = newImage;

            _historyManager.AddToHistory(_wallpaperController.GetOldWallpaper());
        }

        private void HistoryElement_Click(object sender, EventArgs e)
        {
            var oldWallpaper = _historyManager.GetHistoryElementData((sender as PictureBox));

            var result = _wallpaperController.SwitchOldWallpaper(oldWallpaper);

            if (result == null)
                return;

            PbxCurrent.Image = result;

            _historyManager.AddToHistory(_wallpaperController.GetOldWallpaper());
        }

        private void TsmDelete_Click(object sender, EventArgs e)
        {
            var resulDialog = MessageBox.Show("Удалить файл ?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resulDialog == DialogResult.Cancel)
                return;

            var historyElement = (((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as PictureBox);

            var result = _historyManager.HistoryElemenDelete(historyElement);

            if(result == false)
                Notification.Show(NotificationForm.NotificationStatus.Error, "Не удалось удалить изображение");
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                Notification.Show(NotificationForm.NotificationStatus.Info, "Приложение свернуто в системный трей");
                Logger.AppednLog(LogLevel.Info, "The application is minimized to the system tray");
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                return;

            this.Show();
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        #region Таймер
        private void timer1_Tick(object sender, EventArgs e)
        {
            var sources = _sourceMananger.GetSources();
            
            if(sources.Count == 0)
            {
                _settingManager.DisableTimer();
                return;
            }

            GetNewWallpaper();
        }
        #endregion

    }
}
