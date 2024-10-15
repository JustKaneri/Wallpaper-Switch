namespace Wallpaper_Switch
{
    partial class NotificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            this.LbxNotification = new System.Windows.Forms.Label();
            this.PbxStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // LbxNotification
            // 
            this.LbxNotification.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbxNotification.ForeColor = System.Drawing.Color.White;
            this.LbxNotification.Location = new System.Drawing.Point(127, 9);
            this.LbxNotification.Name = "LbxNotification";
            this.LbxNotification.Size = new System.Drawing.Size(242, 86);
            this.LbxNotification.TabIndex = 0;
            this.LbxNotification.Text = "label1";
            this.LbxNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbxStatus
            // 
            this.PbxStatus.Location = new System.Drawing.Point(22, 12);
            this.PbxStatus.Name = "PbxStatus";
            this.PbxStatus.Size = new System.Drawing.Size(85, 75);
            this.PbxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxStatus.TabIndex = 1;
            this.PbxStatus.TabStop = false;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(381, 105);
            this.Controls.Add(this.PbxStatus);
            this.Controls.Add(this.LbxNotification);
            this.Font = new System.Drawing.Font("Constantia", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wallpaper Switch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NotificationForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.PbxStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbxNotification;
        private System.Windows.Forms.PictureBox PbxStatus;
    }
}