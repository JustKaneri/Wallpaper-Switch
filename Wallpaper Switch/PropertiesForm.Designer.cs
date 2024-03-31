namespace Wallpaper_Switch
{
    partial class PropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customCheckBox1 = new Wallpaper_Switch.Custom_components.CustomCheckBox();
            this.CbxAutoLoad = new Wallpaper_Switch.Custom_components.CustomCheckBox();
            this.mainContolPanel1 = new Wallpaper_Switch.Custom_components.MainContolPanel();
            this.customTextBox1 = new Wallpaper_Switch.Custom_components.CustomTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 67);
            this.label1.TabIndex = 3;
            this.label1.Text = "Автозагрузка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 67);
            this.label2.TabIndex = 4;
            this.label2.Text = "Автоматическая смена обоев";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(512, 67);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cradle of Desires 2024";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // customCheckBox1
            // 
            this.customCheckBox1.Location = new System.Drawing.Point(303, 337);
            this.customCheckBox1.Name = "customCheckBox1";
            this.customCheckBox1.Size = new System.Drawing.Size(107, 49);
            this.customCheckBox1.TabIndex = 7;
            // 
            // CbxAutoLoad
            // 
            this.CbxAutoLoad.Location = new System.Drawing.Point(207, 164);
            this.CbxAutoLoad.Name = "CbxAutoLoad";
            this.CbxAutoLoad.Size = new System.Drawing.Size(107, 49);
            this.CbxAutoLoad.TabIndex = 6;
            // 
            // mainContolPanel1
            // 
            this.mainContolPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainContolPanel1.Location = new System.Drawing.Point(0, 0);
            this.mainContolPanel1.Name = "mainContolPanel1";
            this.mainContolPanel1.Size = new System.Drawing.Size(536, 62);
            this.mainContolPanel1.TabIndex = 2;
            // 
            // customTextBox1
            // 
            this.customTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.customTextBox1.Location = new System.Drawing.Point(127, 360);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(100, 26);
            this.customTextBox1.TabIndex = 8;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(536, 539);
            this.Controls.Add(this.customTextBox1);
            this.Controls.Add(this.customCheckBox1);
            this.Controls.Add(this.CbxAutoLoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainContolPanel1);
            this.Font = new System.Drawing.Font("Constantia", 9F);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallpaper Switch";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PropertiesForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_components.MainContolPanel mainContolPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Custom_components.CustomCheckBox CbxAutoLoad;
        private Custom_components.CustomCheckBox customCheckBox1;
        private Custom_components.CustomTextBox customTextBox1;
    }
}