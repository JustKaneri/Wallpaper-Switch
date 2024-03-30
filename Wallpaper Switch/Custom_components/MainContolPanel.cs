using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wallpaper_Switch.Properties;

namespace Wallpaper_Switch.Custom_components
{
    public class MainContolPanel : Panel
    {
        private Label BtnMinWindow;
        private Label BtnClose;
        private Label label1;
        private PictureBox pictureBox1;

        private Point mouseOffset;
        private bool isMouseDown = false;

        public MainContolPanel()
        {
            BtnMinWindow = new Label();
            BtnClose = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

            this.Controls.Add(this.BtnMinWindow);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(1161, 55);
            this.TabIndex = 2;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseUp);

            // 
            // BtnMinWindow
            // 
            this.BtnMinWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMinWindow.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnMinWindow.ForeColor = System.Drawing.Color.White;
            this.BtnMinWindow.Location = new System.Drawing.Point(1045, 0);
            this.BtnMinWindow.Name = "BtnMinWindow";
            this.BtnMinWindow.Size = new System.Drawing.Size(58, 55);
            this.BtnMinWindow.TabIndex = 4;
            this.BtnMinWindow.Text = "_";
            this.BtnMinWindow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnMinWindow.Click += new System.EventHandler(this.BtnMinWindow_Click);
            this.BtnMinWindow.MouseEnter += new System.EventHandler(this.BtnControl_MouseEnter);
            this.BtnMinWindow.MouseLeave += new System.EventHandler(this.BtnControl_MouseLeave);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(1103, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(58, 55);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "X";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.MouseEnter += new System.EventHandler(this.BtnControl_MouseEnter);
            this.BtnClose.MouseLeave += new System.EventHandler(this.BtnControl_MouseLeave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wallpaper Switch";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(Resources.MainIcon));
            this.pictureBox1.Location = new System.Drawing.Point(20, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;

        }


        private void BtnControl_MouseEnter(object sender, EventArgs e)
        {
            var btn = ((Label)sender);

            btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size + 2, btn.Font.Style);
        }

        private void BtnControl_MouseLeave(object sender, EventArgs e)
        {
            var btn = ((Label)sender);

            btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size - 2, btn.Font.Style);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            (this.Parent as Form).Close();
        }

        private void BtnMinWindow_Click(object sender, EventArgs e)
        {
            (this.Parent as Form).WindowState = FormWindowState.Minimized;
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
                mousePos.Offset(mouseOffset.X, mouseOffset.Y + this.Height / 2);
                (this.Parent as Form).Location = mousePos;
            }
        }

        private void ControlPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }


    }
}
