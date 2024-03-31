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
        public bool IsOnlyNumbers { get; set; } = false;

        public CustomTextBox()
        {
            this.BackColor = Color.FromArgb(20,19,22);
            this.Font = new Font("Constantia", 15);
            this.BorderStyle = BorderStyle.None;
            this.ForeColor = Color.White;
            this.TextAlign = HorizontalAlignment.Center;


            this.KeyPress += Tbx_KeyPress;
            
        }

        private void Tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsOnlyNumbers)
                return;

            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;

            if ((Keys)e.KeyChar == Keys.Back)
                e.Handled = false;
        }
    }
}
