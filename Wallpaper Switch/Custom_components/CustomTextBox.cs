using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallpaper_Switch.Custom_components
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            this.BackColor = Color.FromArgb(20,19,22);
            this.Font = new Font("Constantia", 15);
            this.BorderStyle = BorderStyle.None;
            this.ForeColor = Color.White;
            this.TextAlign = HorizontalAlignment.Center;

            HandleCreated += CustomTextBox_HandleCreated;
            
        }

        private void CustomTextBox_HandleCreated(object sender, EventArgs e)
        {
            if (Created)
            {
                MessageBox.Show("Created");

                Pen pen = new Pen(Color.Wheat, 2);

                Graphics g = this.Parent.CreateGraphics();

                g.DrawLine(pen, this.Left, this.Top - this.Height - 5, this.Left + this.Width, this.Top - this.Height - 5);
            }
            
        }
    }
}
