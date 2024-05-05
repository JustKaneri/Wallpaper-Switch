using System;
using System.Collections.Generic;
using System.Drawing;
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
        private readonly SourceMananger _sourceMananger;
        private readonly HistoryManager _historyManager;
        private readonly SettingManager _settingManager;
        private readonly WallpaperManager _wallpaperManager;

        public MainForm()
        {
            InitializeComponent();

            _historyManager = new HistoryManager(new List<PictureBox>() { PbxOld1, PbxOld2, PbxOld3, PbxOld4 });
            _settingManager = new SettingManager(timer1);
            _sourceMananger = new SourceMananger(DgvSource);
            _wallpaperManager = new WallpaperManager(_sourceMananger);

            PbxCurrent.Image = _wallpaperManager.GetCurrentWallpaper();
        }

        #region Source
        private void BtnSource_Click(object sender, EventArgs e)
        {
            //Включение и выключение видимсти панели
            PnlSource.Visible = !PnlSource.Visible;
        }

        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            bool isAdd = _sourceMananger.AddNewSource();
            if(isAdd)
                _wallpaperManager.UpdateSource(_sourceMananger.GetSources());
        }

        private void BtnEditSource_Click(object sender, EventArgs e)
        {
            bool isEdit = _sourceMananger.EditSource();
            if(isEdit)
                _wallpaperManager.UpdateSource(_sourceMananger.GetSources());

        }

        private void BtnDelSource_Click(object sender, EventArgs e)
        {
           bool isDel = _sourceMananger.DeleteSource();
           if(isDel)
                _wallpaperManager.UpdateSource(_sourceMananger.GetSources());
        }

        private void DgvSource_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           bool? isChange = _sourceMananger?.ChangeSource(e);

           if(isChange??false)
                _wallpaperManager.UpdateSource(_sourceMananger.GetSources());
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
            Image newImage = _wallpaperManager.GetNewWallpaper();

            if(newImage == null)
            {
                _settingManager.DisableTimer();
                return;
            }
               
            SetWallpapaer(newImage);
        }

        private void HistoryElement_Click(object sender, EventArgs e)
        {
            var historyWallpaper = _historyManager.GetHistoryElementData((sender as PictureBox));

            var result = _wallpaperManager.SwitchWallpaper(historyWallpaper);

            if (result == null)
                return;

            SetWallpapaer(result);
        }

        private void SetWallpapaer(Image image)
        {
            PbxCurrent.Image = image;

            _historyManager.AddToHistory(_wallpaperManager.GetOldWallpaper());
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
