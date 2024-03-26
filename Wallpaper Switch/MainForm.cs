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
        private Point mouseOffset;
        private bool isMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Control Panel
        private void BtnControl_MouseEnter(object sender, EventArgs e)
        {
            var btn = ((Label)sender);

            btn.Font = new Font(btn.Font.FontFamily,btn.Font.Size+2,btn.Font.Style);
        }

        private void BtnControl_MouseLeave(object sender, EventArgs e)
        {
            var btn = ((Label)sender);

            btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size - 2, btn.Font.Style);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void ControlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y+ControlPanel.Height/2);
                Location = mousePos;
            }
        }

        private void ControlPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        #endregion

    }
}
