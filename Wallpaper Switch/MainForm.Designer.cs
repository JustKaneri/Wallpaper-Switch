namespace Wallpaper_Switch
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.BtnMinWindow = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnSource = new System.Windows.Forms.Label();
            this.BtnPropeties = new System.Windows.Forms.Label();
            this.PnlSource = new System.Windows.Forms.Panel();
            this.DgvSource = new System.Windows.Forms.DataGridView();
            this.ClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BtnDelSource = new System.Windows.Forms.PictureBox();
            this.BtnEditSource = new System.Windows.Forms.PictureBox();
            this.BtnAddSource = new System.Windows.Forms.PictureBox();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.BtnMinWindow);
            this.ControlPanel.Controls.Add(this.BtnClose);
            this.ControlPanel.Controls.Add(this.label1);
            this.ControlPanel.Controls.Add(this.pictureBox1);
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(1198, 55);
            this.ControlPanel.TabIndex = 0;
            this.ControlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseDown);
            this.ControlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseMove);
            this.ControlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseUp);
            // 
            // BtnMinWindow
            // 
            this.BtnMinWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinWindow.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnMinWindow.ForeColor = System.Drawing.Color.White;
            this.BtnMinWindow.Location = new System.Drawing.Point(1071, 0);
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
            this.BtnClose.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(1135, 0);
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
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BtnSource
            // 
            this.BtnSource.AutoSize = true;
            this.BtnSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSource.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSource.ForeColor = System.Drawing.Color.White;
            this.BtnSource.Location = new System.Drawing.Point(9, 66);
            this.BtnSource.Name = "BtnSource";
            this.BtnSource.Size = new System.Drawing.Size(122, 24);
            this.BtnSource.TabIndex = 1;
            this.BtnSource.Text = "Источники";
            this.BtnSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSource.Click += new System.EventHandler(this.BtnSource_Click);
            this.BtnSource.DoubleClick += new System.EventHandler(this.BtnSource_Click);
            // 
            // BtnPropeties
            // 
            this.BtnPropeties.AutoSize = true;
            this.BtnPropeties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPropeties.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnPropeties.ForeColor = System.Drawing.Color.White;
            this.BtnPropeties.Location = new System.Drawing.Point(137, 66);
            this.BtnPropeties.Name = "BtnPropeties";
            this.BtnPropeties.Size = new System.Drawing.Size(120, 24);
            this.BtnPropeties.TabIndex = 2;
            this.BtnPropeties.Text = "Настройки";
            this.BtnPropeties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlSource
            // 
            this.PnlSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlSource.Controls.Add(this.DgvSource);
            this.PnlSource.Controls.Add(this.BtnDelSource);
            this.PnlSource.Controls.Add(this.BtnEditSource);
            this.PnlSource.Controls.Add(this.BtnAddSource);
            this.PnlSource.Location = new System.Drawing.Point(13, 103);
            this.PnlSource.Name = "PnlSource";
            this.PnlSource.Size = new System.Drawing.Size(211, 259);
            this.PnlSource.TabIndex = 3;
            this.PnlSource.Visible = false;
            // 
            // DgvSource
            // 
            this.DgvSource.AllowUserToAddRows = false;
            this.DgvSource.AllowUserToDeleteRows = false;
            this.DgvSource.AllowUserToResizeColumns = false;
            this.DgvSource.AllowUserToResizeRows = false;
            this.DgvSource.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.DgvSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvSource.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSource.ColumnHeadersVisible = false;
            this.DgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmName,
            this.ClmActive});
            this.DgvSource.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.DgvSource.Location = new System.Drawing.Point(0, -1);
            this.DgvSource.MultiSelect = false;
            this.DgvSource.Name = "DgvSource";
            this.DgvSource.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvSource.RowHeadersVisible = false;
            this.DgvSource.RowHeadersWidth = 51;
            this.DgvSource.RowTemplate.Height = 45;
            this.DgvSource.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSource.Size = new System.Drawing.Size(210, 193);
            this.DgvSource.TabIndex = 4;
            // 
            // ClmName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClmName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ClmName.HeaderText = "Column1";
            this.ClmName.MinimumWidth = 6;
            this.ClmName.Name = "ClmName";
            this.ClmName.ReadOnly = true;
            this.ClmName.Width = 125;
            // 
            // ClmActive
            // 
            this.ClmActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Constantia", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.NullValue = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClmActive.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClmActive.HeaderText = "Column1";
            this.ClmActive.MinimumWidth = 6;
            this.ClmActive.Name = "ClmActive";
            this.ClmActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BtnDelSource
            // 
            this.BtnDelSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelSource.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelSource.Image")));
            this.BtnDelSource.Location = new System.Drawing.Point(161, 210);
            this.BtnDelSource.Name = "BtnDelSource";
            this.BtnDelSource.Size = new System.Drawing.Size(25, 25);
            this.BtnDelSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnDelSource.TabIndex = 6;
            this.BtnDelSource.TabStop = false;
            this.BtnDelSource.Click += new System.EventHandler(this.BtnDelSource_Click);
            // 
            // BtnEditSource
            // 
            this.BtnEditSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditSource.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditSource.Image")));
            this.BtnEditSource.Location = new System.Drawing.Point(91, 210);
            this.BtnEditSource.Name = "BtnEditSource";
            this.BtnEditSource.Size = new System.Drawing.Size(25, 25);
            this.BtnEditSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditSource.TabIndex = 5;
            this.BtnEditSource.TabStop = false;
            this.BtnEditSource.Click += new System.EventHandler(this.BtnEditSource_Click);
            // 
            // BtnAddSource
            // 
            this.BtnAddSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddSource.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddSource.Image")));
            this.BtnAddSource.Location = new System.Drawing.Point(26, 210);
            this.BtnAddSource.Name = "BtnAddSource";
            this.BtnAddSource.Size = new System.Drawing.Size(25, 25);
            this.BtnAddSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddSource.TabIndex = 4;
            this.BtnAddSource.TabStop = false;
            this.BtnAddSource.Click += new System.EventHandler(this.BtnAddSource_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1197, 605);
            this.Controls.Add(this.PnlSource);
            this.Controls.Add(this.BtnPropeties);
            this.Controls.Add(this.BtnSource);
            this.Controls.Add(this.ControlPanel);
            this.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallpaper Switch";
            this.ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BtnClose;
        private System.Windows.Forms.Label BtnMinWindow;
        private System.Windows.Forms.Label BtnSource;
        private System.Windows.Forms.Label BtnPropeties;
        private System.Windows.Forms.Panel PnlSource;
        private System.Windows.Forms.PictureBox BtnAddSource;
        private System.Windows.Forms.PictureBox BtnDelSource;
        private System.Windows.Forms.PictureBox BtnEditSource;
        private System.Windows.Forms.DataGridView DgvSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClmActive;
    }
}

