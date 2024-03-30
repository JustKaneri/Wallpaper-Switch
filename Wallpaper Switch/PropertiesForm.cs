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
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }

        private void PropertiesForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 0.1f);
           
            e.Graphics.DrawLine(pen,0,0,0,this.Height);

            e.Graphics.DrawLine(pen,0,this.Height-1,this.Width,this.Height-1);

            e.Graphics.DrawLine(pen, this.Width-1, 0, this.Width-1, this.Height);
        }
    }
}
