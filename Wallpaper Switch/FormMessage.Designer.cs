namespace Wallpaper_Switch
{
    partial class FormMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessage));
            this.LbxMessage = new System.Windows.Forms.Label();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbxMessage
            // 
            this.LbxMessage.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbxMessage.Location = new System.Drawing.Point(12, 9);
            this.LbxMessage.Name = "LbxMessage";
            this.LbxMessage.Size = new System.Drawing.Size(471, 84);
            this.LbxMessage.TabIndex = 0;
            this.LbxMessage.Text = "label1";
            this.LbxMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSelect
            // 
            this.BtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSelect.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.BtnSelect.FlatAppearance.BorderSize = 2;
            this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelect.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSelect.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.BtnSelect.Location = new System.Drawing.Point(12, 105);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(118, 38);
            this.BtnSelect.TabIndex = 7;
            this.BtnSelect.Text = "Отмена";
            this.BtnSelect.UseVisualStyleBackColor = false;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.BtnOk.FlatAppearance.BorderSize = 2;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.BtnOk.Location = new System.Drawing.Point(365, 105);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(118, 33);
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "Ок";
            this.BtnOk.UseVisualStyleBackColor = false;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(495, 159);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.LbxMessage);
            this.Font = new System.Drawing.Font("Constantia", 9F);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMessag";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMessage_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbxMessage;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Button BtnOk;
    }
}