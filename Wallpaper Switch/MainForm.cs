using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallpaper_Switch
{
    public partial class MainForm : Form
    {
        private const int _maxCountSource = 4;

        private PictureBox[] _oldPictireBoxs = new PictureBox[4];

        public MainForm()
        {
            InitializeComponent();

            DgvSource.CellBorderStyle = DataGridViewCellBorderStyle.None;
            
            _oldPictireBoxs[0] = PbxOld1;
            _oldPictireBoxs[1] = PbxOld2;
            _oldPictireBoxs[2] = PbxOld3;
            _oldPictireBoxs[3] = PbxOld4;
        }

        #region Source
        private void BtnSource_Click(object sender, EventArgs e)
        {
            //Включение и выключение видимсти панели
            PnlSource.Visible = !PnlSource.Visible;
        }

        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add source");
        }

        private void BtnEditSource_Click(object sender, EventArgs e)
        {
            if (DgvSource.SelectedRows.Count > 0)
                MessageBox.Show("Edit source" + DgvSource.CurrentRow.Cells[0].Value);
        }

        private void BtnDelSource_Click(object sender, EventArgs e)
        {
            if (DgvSource.SelectedRows.Count > 0)
                MessageBox.Show("Delete source "+ DgvSource.CurrentRow.Cells[0].Value);
        }
        #endregion

        private void BtnPropeties_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm();
            propertiesForm.ShowDialog();
        }
    }
}
