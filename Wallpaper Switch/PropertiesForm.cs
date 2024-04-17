using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Core.Controllers.Setting;

namespace Wallpaper_Switch
{
    public partial class PropertiesForm : Form
    {
        private readonly SettingsController _settingsController;

        public PropertiesForm(SettingsController settingsController)
        {
            InitializeComponent();
            _settingsController = settingsController;

            
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            CbxAutoLoad.CheckChanged(_settingsController.AutoStartStatus());
            CbxAutoChange.CheckChanged(_settingsController.AutoChangeStatus().isChange);
            TbxTimeChange.Text = _settingsController.AutoChangeStatus().time.ToString();

            CbxAutoLoad.CheckedChanged += CbxAutoLoad_CheckedChanged;
        }

        private void CbxAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (!CbxAutoLoad.Checked)
                _settingsController.DisableAutoStart();
            else
                _settingsController.EnableAutoStart();
        }

        private void PropertiesForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(100, 149, 237), 0.1f);
           
            e.Graphics.DrawLine(pen,0,this.Height-1,this.Width,this.Height-1);


            e.Graphics.DrawLine(pen, TbxTimeChange.Left,
                                     TbxTimeChange.Top + TbxTimeChange.Height + 5,
                                     TbxTimeChange.Left + TbxTimeChange.Width,
                                     TbxTimeChange.Top + TbxTimeChange.Height + 5);
        }
    }
}
