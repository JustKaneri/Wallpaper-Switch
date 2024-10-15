using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Properties;

namespace Wallpaper_Switch.Custom_components
{
    public class CustomCheckBox : Panel
    {
        public bool Checked { get; private set; }
       
        private PictureBox imageBox;
        private int timePause = 10;

        public event EventHandler CheckedChanged;

        public CustomCheckBox()
        {
            this.Size = new System.Drawing.Size(130, 60);
            imageBox = new PictureBox();

            this.Controls.Add(imageBox);

            imageBox.Dock = DockStyle.Fill;
            imageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imageBox.Image = Resources.statusOFF;
            imageBox.Cursor = Cursors.Hand;
            imageBox.Click += ImageBox_Click;
            
        }

        public void Changed(bool value)
        {
            Checked = value;

            if (Checked)
                imageBox.Image = Resources.statusOn;
            else
                imageBox.Image = Resources.statusOFF;
        }

        private async void ImageBox_Click(object sender, EventArgs e)
        {
            if (Checked)
            {
                await StateOff();
            }
            else
            {
                await StateOn();
            }
        }

        private async Task StateOn()
        {
            Checked = true;
            imageBox.Image = Resources.statusMiddle;
            await Task.Delay(timePause);
            imageBox.Image = Resources.statusOn;
            CheckedChanged?.Invoke(this, EventArgs.Empty);
            
        }

        private async Task StateOff()
        {
            Checked = false;
            imageBox.Image = Resources.statusMiddle;
            await Task.Delay(timePause);
            imageBox.Image = Resources.statusOFF;
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
