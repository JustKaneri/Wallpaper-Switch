using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Model;
using Wallpaper_Switch.Tools;

namespace Wallpaper_Switch
{
    public partial class SourceForm : Form
    {
        public enum FormMode
        {
            Create,
            Edit
        }

        private readonly SourceController _sourceController;
        private readonly FormMode _mode;
        private readonly Source _oldSource;

        public SourceForm(SourceController sourceController,FormMode mode)
        {
            InitializeComponent();
            _sourceController = sourceController;
            _mode = mode;
        }

        public SourceForm(SourceController sourceController, Source oldSource, FormMode mode)
        {
            InitializeComponent();
            _sourceController = sourceController;
            _mode = mode;
            _oldSource = oldSource;

            TbxName.Text = oldSource.Name;
            TbxPath.Text = oldSource.Path;
        }

        private void FormSource_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(100, 149, 237), 0.1f);

            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(TbxName);
            textBoxes.Add(TbxPath);

            foreach (var item in textBoxes)
            {
                e.Graphics.DrawLine(pen, item.Left,
                                    item.Top + item.Height + 5,
                                    item.Left + item.Width,
                                    item.Top + item.Height + 5);
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                TbxPath.Text = folderDialog.SelectedPath;

                if(string.IsNullOrWhiteSpace(TbxName.Text))
                    TbxName.Text = new DirectoryInfo(folderDialog.SelectedPath).Name;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case FormMode.Create:
                        CreateSource();
                    break;
                case FormMode.Edit:
                        EditSource();
                    break;
            }
        }

        private void EditSource()
        {
            Source source = new Source();

            if (string.IsNullOrWhiteSpace(TbxName.Text))
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Введите название");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbxPath.Text))
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Выберете директорию с изображениями");
                return;
            }

            source.Name = TbxName.Text.Trim();
            source.Path = TbxPath.Text.Trim();
            source.IsActive = _oldSource.IsActive;

            var result = _sourceController.EditSource(source, _oldSource);

            if (result == null)
            {
                Notification.Show(NotificationForm.NotificationStatus.Error, "Не удалось обновить источник");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void CreateSource()
        {
            Source source = new Source();

            if (string.IsNullOrWhiteSpace(TbxName.Text))
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Введите название");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbxPath.Text))
            {
                Notification.Show(NotificationForm.NotificationStatus.Warning, "Выберете директорию с изображениями");
                return;
            }

            source.Name = TbxName.Text.Trim();
            source.Path = TbxPath.Text.Trim();
            source.IsActive = true;

            string error = "";

            _sourceController.AddSource(source, ref error);

            if (error != "")
            {
                Notification.Show(NotificationForm.NotificationStatus.Error, error);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
