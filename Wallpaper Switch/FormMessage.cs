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
    public partial class FormMessage : Form
    {
        public FormMessage(string message):this(message,"Ok")
        {
        }

        public FormMessage(string message,string buttonText)
        {
            InitializeComponent();
            LbxMessage.Text = message;
            BtnOk.Text = buttonText;
        }

        private void FormMessage_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(100, 149, 237), 3);

            e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);

            e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);

            e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);

            e.Graphics.DrawLine(pen, this.Width - 1, 0, this.Width - 1, this.Height);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
