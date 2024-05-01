using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.History;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Setting;
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Controllers.Wallpaper;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Tools;

namespace Wallpaper_Switch
{
    public partial class MainForm : Form
    {
        private const int _maxCountSource = 4;

        private readonly SourceController _sourceController;
        private readonly WallpaperController _wallpaperController;
        private readonly HistoryController _historyController;
        private readonly SettingsController _settingsController;

        private List<PictureBox> historyElements = new List<PictureBox>();

        public MainForm()
        {
            InitializeComponent();

            this.historyElements.Add(PbxOld1);
            this.historyElements.Add(PbxOld2);
            this.historyElements.Add(PbxOld3);
            this.historyElements.Add(PbxOld4);

            _sourceController = new SourceController(Application.StartupPath + "\\");
            FillSource();

            _wallpaperController = new WallpaperController(_sourceController.GetSources());
            _wallpaperController.OnFindBrokenImage += _wallpaperController_OnFindBrokenImage;
            PbxCurrent.Image = _wallpaperController.GetCurrentWallpaper();

            _historyController = new HistoryController(Application.StartupPath + "\\");
            FillHistory();

            _settingsController = new SettingsController(Application.StartupPath + "\\");


            TimerManager();
        }

        private void FillHistory()
        {
            var history = _historyController.GetHistory();

            history.Reverse();

            for (int i = 0; i < history.Count; i++)
            {
                historyElements[i].Image = history[i].GetImage();
            }
        }

        private void _wallpaperController_OnFindBrokenImage(object sender, EventArgs e)
        {
            var brokenWallpaper = (sender as Wallpaper);

            Notification.Show(NotificationForm.NotificationStatus.Error, 
                     $"Сломанный файл: {brokenWallpaper.FileName} " +
                     $"был перемещен в {WallpaperCollector.GetFullPath()}");
        }

        #region Source
        private void FillSource()
        {
            DgvSource.Rows.Clear();

            var sources = _sourceController.GetSources();

            if (sources.Count == 0)
            {
                Logger.AppednLog(LogLevel.Info, "No sources were found during the launch");
                return;
            }

            foreach (var source in sources)
            {
                DgvSource.Rows.Add(source.Name, source.IsActive);
            }
        }

        private void BtnSource_Click(object sender, EventArgs e)
        {
            //Включение и выключение видимсти панели
            PnlSource.Visible = !PnlSource.Visible;
        }

        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            if(DgvSource.RowCount == _maxCountSource)
            {
                return;
            }

            SourceForm sourceForm = new SourceForm(_sourceController,SourceForm.FormMode.Create);
            var result = sourceForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                FillSource();
                _wallpaperController.UpdateSource(_sourceController.GetSources());
                Notification.Show(NotificationForm.NotificationStatus.Info, $"Добавлен новый источнк");
            }
        }

        private void BtnEditSource_Click(object sender, EventArgs e)
        {
            if (DgvSource.SelectedRows.Count > 0)
            {
                int rowIndex = DgvSource.CurrentCell.RowIndex;

                var oldSource = _sourceController.GetSources()[rowIndex];

                SourceForm sourceForm = new SourceForm(_sourceController, oldSource ,SourceForm.FormMode.Edit);
                var result = sourceForm.ShowDialog();

                if(result == DialogResult.OK)
                {
                    FillSource();

                    DgvSource.CurrentCell = DgvSource[0, rowIndex];
                    DgvSource.Rows[rowIndex].Selected = true;

                    _wallpaperController.UpdateSource(_sourceController.GetSources());
                }
            }
        }

        private void BtnDelSource_Click(object sender, EventArgs e)
        {
            if (DgvSource.SelectedRows.Count > 0)
            {
                var resulDialog = MessageBox.Show("Удалить источник ?","Удаление",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                if (resulDialog == DialogResult.Cancel)
                    return;

                int index = DgvSource.CurrentCell.RowIndex;

                _sourceController.DeleteSource(index);

                FillSource();

                _wallpaperController.UpdateSource(_sourceController.GetSources());
            }
        }

        private void DgvSource_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                bool value = (bool)DgvSource[e.ColumnIndex, e.RowIndex].Value;
                bool result;

                if (value)
                {
                    result = _sourceController.AcitvateSource(e.RowIndex);
                }
                else
                {
                    result = _sourceController.DiacitvateSource(e.RowIndex);
                }

                if (result == false)
                    DgvSource[e.ColumnIndex, e.RowIndex].Value = !value;

                _wallpaperController.UpdateSource(_sourceController.GetSources());
            }
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
            PropertiesForm propertiesForm = new PropertiesForm(_settingsController);
            propertiesForm.ShowDialog();
            TimerManager();
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

            if (newImage == null && _sourceController.GetSources().Count > 0)
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Не удалось найти изображения");
                _settingsController.DisableAutoChange();
                return;
            }

            if (newImage == null)
                return;

            PbxCurrent.Image = newImage;

            AddToHistory();
        }

        private void HistoryElement_Click(object sender, EventArgs e)
        {
            int historyIndex = int.Parse((sender as PictureBox).Tag.ToString());

            if (historyIndex > _historyController.GetHistory().Count)
                return;

            var result = _wallpaperController.SwitchOldWallpaper(_historyController.GetHistory()[historyIndex]);

            if (result == null)
                return;

            PbxCurrent.Image = result;

            AddToHistory();
         
        }

        private void AddToHistory()
        {
            _historyController.Push(_wallpaperController.GetOldWallpaper());
            FillHistory();
        }

        private void TsmDelete_Click(object sender, EventArgs e)
        {
            var resulDialog = MessageBox.Show("Удалить файл ?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resulDialog == DialogResult.Cancel)
                return;

            int historyIndex = int.Parse((((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as PictureBox).Tag.ToString());

            if (historyIndex > _historyController.GetHistory().Count)
                return;

            string path = _historyController.GetHistory()[historyIndex].Path;

            try
            {
                System.IO.File.Delete(path);
            }
            catch
            {
                Notification.Show(NotificationForm.NotificationStatus.Error, "Не удалось удалить изображение");
                Logger.AppednLog(LogLevel.Error, $"Failed delete file {path}");
            }
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
        private void TimerManager()
        {
            int time = _settingsController.AutoChangeStatus().time;
            bool isActive = _settingsController.AutoChangeStatus().isChange;

            timer1.Interval = int.Parse(time.ToString()) * 60000;
            timer1.Enabled = isActive;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var sources = _sourceController.GetSources();
            
            if(sources.Count == 0)
            {
                _settingsController.DisableAutoChange();
                TimerManager();
                return;
            }

            GetNewWallpaper();
        }
        #endregion


    }
}
