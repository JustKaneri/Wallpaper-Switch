using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Properties;

namespace Wallpaper_Switch
{
    public partial class NotificationForm : Form
    {
        public enum NotificationStatus
        {
            Info,
            Warning,
            Error
        }

        private Color _borderColor;

        public NotificationForm(NotificationStatus status,string message)
        {
            InitializeComponent();

            SetImage(status);
            SetStartPosition();

            LbxNotification.Text = message; 
            LbxNotification.ForeColor = _borderColor;

            this.ShowInTaskbar = false;
        }

        private void SetStartPosition()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            screenWidth -= (this.Width + 10);
            screenHeight -= (this.Height + 50);

            this.Location = new Point(screenWidth,screenHeight);
        }

        private void SetImage(NotificationStatus status)
        {
            switch (status)
            {
                case NotificationStatus.Info:
                        PbxStatus.Image = Resources.Info;
                        _borderColor = Color.FromArgb(100, 149, 237);
                    break;
                case NotificationStatus.Warning:
                        PbxStatus.Image = Resources.Warning;
                        _borderColor = Color.FromArgb(227, 227, 78);
                    break;
                case NotificationStatus.Error:
                        PbxStatus.Image = Resources.Error;
                        _borderColor = Color.FromArgb(247, 96, 96);
                    break;
                default:
                    break;
            }
        }

        private void NotificationForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(_borderColor, 1);

            e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);

            e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);

            e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);

            e.Graphics.DrawLine(pen, this.Width-1, 0 , this.Width-1, this.Height);

        }

        private async void ClosedForm()
        {
            await Task.Delay(2000);

            do
            {
                this.Opacity -= 0.1f;
                await Task.Delay(50);

            } while (this.Opacity > 0);

            this.Close();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
           ClosedForm();
        }
    }
}
