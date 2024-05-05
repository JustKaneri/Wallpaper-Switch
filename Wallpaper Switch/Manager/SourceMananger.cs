using System.Collections.Generic;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Tools;

namespace Wallpaper_Switch.Manager
{
    public class SourceMananger
    {
        private readonly SourceController _sourceController;
        private readonly DataGridView _dataGrid;
        private const int _maxCountSource = 4;

        public SourceMananger(DataGridView dataGrid)
        {
            _sourceController = new SourceController(Application.StartupPath + "\\");
            _dataGrid = dataGrid;

            FillSource();
        }

        private void FillSource()
        {
            _dataGrid.Rows.Clear();

            var sources = _sourceController.GetSources();

            if (sources.Count == 0)
            {
                Logger.AppednLog(LogLevel.Info, "No sources were found during the launch");
                return;
            }

            foreach (var source in sources)
            {
                _dataGrid.Rows.Add(source.Name, source.IsActive);
            }
        }

        public List<Source> GetSources()
        {
            return _sourceController.GetSources();
        }

        /// <summary>
        /// Добавить новый источник
        /// </summary>
        public bool AddNewSource()
        {
            if (_dataGrid.RowCount == _maxCountSource)
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, $"Достигнут лимит источников");
                return false;
            }

            SourceForm sourceForm = new SourceForm(_sourceController, SourceForm.FormMode.Create);
            var result = sourceForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                FillSource();
                //_wallpaperController.UpdateSource(_sourceController.GetSources());
                Notification.Show(NotificationForm.NotificationStatus.Info, $"Добавлен новый источнк");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Редактирование источника
        /// </summary>
        public bool EditSource()
        {
            if (_dataGrid.SelectedRows.Count <= 0)
                return false;

            int rowIndex = _dataGrid.CurrentCell.RowIndex;

            var oldSource = _sourceController.GetSources()[rowIndex];

            SourceForm sourceForm = new SourceForm(_sourceController, oldSource, SourceForm.FormMode.Edit);
            var result = sourceForm.ShowDialog();

            if (result != DialogResult.OK)
                return false;

            FillSource();

            _dataGrid.CurrentCell = _dataGrid[0, rowIndex];
            _dataGrid.Rows[rowIndex].Selected = true;

            //_wallpaperController.UpdateSource(_sourceController.GetSources());
            return true;
        }

        /// <summary>
        /// Удалить источник
        /// </summary>
        public bool DeleteSource()
        {
            if (_dataGrid.SelectedRows.Count <= 0)
                return false;

            var resulDialog = MessageBox.Show("Удалить источник ?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resulDialog == DialogResult.Cancel)
                return false;

            int index = _dataGrid.CurrentCell.RowIndex;

            _sourceController.DeleteSource(index);

            FillSource();

            //_wallpaperController.UpdateSource(_sourceController.GetSources());

            return true;

        }

        /// <summary>
        /// Изменить статус источника включить/выключить
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ChangeSource(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                bool value = (bool)_dataGrid[e.ColumnIndex, e.RowIndex].Value;
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
                    _dataGrid[e.ColumnIndex, e.RowIndex].Value = !value;

                return true;
                //_wallpaperController.UpdateSource(_sourceController.GetSources());
            }

            return false;
        }
    }
}
