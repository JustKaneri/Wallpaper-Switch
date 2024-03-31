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

namespace Wallpaper_Switch
{
    public partial class SourceForm : Form
    {
        public SourceForm()
        {
            InitializeComponent();
        }

        private void FormSource_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 0.1f);

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
                TbxName.Text = new DirectoryInfo(folderDialog.SelectedPath).Name;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
