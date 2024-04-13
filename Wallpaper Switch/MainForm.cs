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
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Controllers.Wallpaper;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch
{
    public partial class MainForm : Form
    {
        private const int _maxCountSource = 4;

        private readonly SourceController _sourceController;
        private readonly WallpaperController _wallpaperController;
        private readonly HistoryController _historyController;

        private List<PictureBox> historyElements = new List<PictureBox>();

        public MainForm()
        {
            InitializeComponent();

            _sourceController = new SourceController(Application.StartupPath + "\\");
            FillSource();

            _wallpaperController = new WallpaperController(_sourceController.GetSources());
            _wallpaperController.OnFindBrokenImage += _wallpaperController_OnFindBrokenImage;
            PbxCurrent.Image = _wallpaperController.GetCurrentWallpaper();

            _historyController = new HistoryController(Application.StartupPath + "\\");
            FillHistory();
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

            MessageBox.Show($"Сломанный файл: {brokenWallpaper.FileName}");
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
            SourceForm sourceForm = new SourceForm(_sourceController,SourceForm.FormMode.Create);
            var result = sourceForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                FillSource();
                _wallpaperController.UpdateSource(_sourceController.GetSources());
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
        #endregion

        private void BtnPropeties_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm();
            propertiesForm.ShowDialog();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            BtnSelect.Enabled = false;

            var newImage = _wallpaperController.GetRandomWallpaper();

            if(newImage == null && _sourceController.GetSources().Count > 0)
            {
               MessageBox.Show("Источники не активны","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Warning);
               return;
            }

            PbxCurrent.Image = newImage;

            _historyController.Push(_wallpaperController.GetOldWallpaper());

            FillHistory();

            BtnSelect.Enabled = true;
        }
    }
}
