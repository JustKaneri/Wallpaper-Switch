using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Source;

namespace Wallpaper_Switch
{
    public partial class MainForm : Form
    {
        private const int _maxCountSource = 4;

        private readonly SourceController _sourceController;

        public MainForm()
        {
            InitializeComponent();

            DgvSource.CellBorderStyle = DataGridViewCellBorderStyle.None;

            _sourceController = new SourceController(Application.StartupPath + "\\");
            FillSource();
        }

        private void FillSource()
        {
            DgvSource.Rows.Clear();

            var sources = _sourceController.GetSources();

            if(sources.Count == 0)
            {
                Logger.AppednLog(LogLevel.Info, "No sources were found during the launch");
                return;
            }

            foreach (var source in sources) 
            {
                DgvSource.Rows.Add(source.Name, source.IsActive);
            }
        }

        #region Source
        private void BtnSource_Click(object sender, EventArgs e)
        {
            //Включение и выключение видимсти панели
            PnlSource.Visible = !PnlSource.Visible;
        }

        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            SourceForm sourceForm = new SourceForm(_sourceController,SourceForm.FormMode.Create);
            sourceForm.ShowDialog();
            FillSource();
        }

        private void BtnEditSource_Click(object sender, EventArgs e)
        {
            if (DgvSource.SelectedRows.Count > 0)
            {
                int rowIndex = DgvSource.CurrentCell.RowIndex;

                var oldSource = _sourceController.GetSources()[rowIndex];

                SourceForm sourceForm = new SourceForm(_sourceController, oldSource ,SourceForm.FormMode.Edit);
                sourceForm.ShowDialog();

                FillSource();

                DgvSource.CurrentCell = DgvSource[0, rowIndex];
                DgvSource.Rows[rowIndex].Selected = true;

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
            }
        }
        #endregion

        private void BtnPropeties_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm();
            propertiesForm.ShowDialog();
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
            }
        }
    }
}
