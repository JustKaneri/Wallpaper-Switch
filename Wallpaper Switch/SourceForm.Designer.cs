namespace Wallpaper_Switch
{
    partial class SourceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TbxPath = new Wallpaper_Switch.Custom_components.CustomTextBox();
            this.TbxName = new Wallpaper_Switch.Custom_components.CustomTextBox();
            this.mainContolPanel1 = new Wallpaper_Switch.Custom_components.MainContolPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Constantia", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "Название";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Constantia", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Путь";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSelect
            // 
            this.BtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSelect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSelect.FlatAppearance.BorderSize = 2;
            this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelect.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSelect.ForeColor = System.Drawing.Color.White;
            this.BtnSelect.Location = new System.Drawing.Point(330, 317);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(245, 31);
            this.BtnSelect.TabIndex = 7;
            this.BtnSelect.Text = "Выбрать";
            this.BtnSelect.UseVisualStyleBackColor = false;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCancel.FlatAppearance.BorderSize = 2;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(12, 403);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(258, 49);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Отмена";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSave.FlatAppearance.BorderSize = 2;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(630, 403);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(258, 49);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "Сохранить";
            this.BtnSave.UseVisualStyleBackColor = false;
            // 
            // TbxPath
            // 
            this.TbxPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.TbxPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxPath.Font = new System.Drawing.Font("Constantia", 15F);
            this.TbxPath.ForeColor = System.Drawing.Color.White;
            this.TbxPath.IsOnlyNumbers = false;
            this.TbxPath.Location = new System.Drawing.Point(187, 263);
            this.TbxPath.Name = "TbxPath";
            this.TbxPath.ReadOnly = true;
            this.TbxPath.Size = new System.Drawing.Size(533, 31);
            this.TbxPath.TabIndex = 4;
            this.TbxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbxName
            // 
            this.TbxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.TbxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxName.Font = new System.Drawing.Font("Constantia", 15F);
            this.TbxName.ForeColor = System.Drawing.Color.White;
            this.TbxName.IsOnlyNumbers = false;
            this.TbxName.Location = new System.Drawing.Point(187, 159);
            this.TbxName.Name = "TbxName";
            this.TbxName.Size = new System.Drawing.Size(533, 31);
            this.TbxName.TabIndex = 3;
            this.TbxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainContolPanel1
            // 
            this.mainContolPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainContolPanel1.Location = new System.Drawing.Point(0, 0);
            this.mainContolPanel1.Name = "mainContolPanel1";
            this.mainContolPanel1.Size = new System.Drawing.Size(900, 55);
            this.mainContolPanel1.TabIndex = 2;
            // 
            // SourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(900, 476);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbxPath);
            this.Controls.Add(this.TbxName);
            this.Controls.Add(this.mainContolPanel1);
            this.Font = new System.Drawing.Font("Constantia", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallpaper Switch";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSource_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_components.MainContolPanel mainContolPanel1;
        private Custom_components.CustomTextBox TbxName;
        private Custom_components.CustomTextBox TbxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}