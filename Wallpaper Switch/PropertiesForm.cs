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
            Pen pen = new Pen(Color.FromArgb(100, 149, 237), 0.1f);
           
            e.Graphics.DrawLine(pen,0,this.Height-1,this.Width,this.Height-1);


            e.Graphics.DrawLine(pen, TbxTimeChange.Left,
                                     TbxTimeChange.Top + TbxTimeChange.Height + 5,
                                     TbxTimeChange.Left + TbxTimeChange.Width,
                                     TbxTimeChange.Top + TbxTimeChange.Height + 5);
        }
    }
}
