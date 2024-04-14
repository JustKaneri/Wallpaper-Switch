using System.Windows.Forms;
using System.Linq;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtnSource = new System.Windows.Forms.Label();
            this.BtnPropeties = new System.Windows.Forms.Label();
            this.PnlSource = new System.Windows.Forms.Panel();
            this.DgvSource = new System.Windows.Forms.DataGridView();
            this.ClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BtnDelSource = new System.Windows.Forms.PictureBox();
            this.BtnEditSource = new System.Windows.Forms.PictureBox();
            this.BtnAddSource = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PbxOld1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PbxOld2 = new System.Windows.Forms.PictureBox();
            this.PbxOld3 = new System.Windows.Forms.PictureBox();
            this.PbxOld4 = new System.Windows.Forms.PictureBox();
            this.PbxCurrent = new System.Windows.Forms.PictureBox();
            this.mainContolPanel1 = new Wallpaper_Switch.Custom_components.MainContolPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PnlSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSource
            // 
            this.BtnSource.AutoSize = true;
            this.BtnSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSource.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSource.ForeColor = System.Drawing.Color.CornflowerBlue;
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
            this.BtnPropeties.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.BtnPropeties.Location = new System.Drawing.Point(137, 66);
            this.BtnPropeties.Name = "BtnPropeties";
            this.BtnPropeties.Size = new System.Drawing.Size(120, 24);
            this.BtnPropeties.TabIndex = 2;
            this.BtnPropeties.Text = "Настройки";
            this.BtnPropeties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnPropeties.Click += new System.EventHandler(this.BtnPropeties_Click);
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
            this.DgvSource.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
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
            this.DgvSource.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSource_CellValueChanged);
            // 
            // ClmName
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClmName.DefaultCellStyle = dataGridViewCellStyle9;
            this.ClmName.HeaderText = "Column1";
            this.ClmName.MinimumWidth = 6;
            this.ClmName.Name = "ClmName";
            this.ClmName.ReadOnly = true;
            this.ClmName.Width = 125;
            // 
            // ClmActive
            // 
            this.ClmActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Constantia", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle10.NullValue = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClmActive.DefaultCellStyle = dataGridViewCellStyle10;
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
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(372, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Текущие обои";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSelect
            // 
            this.BtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSelect.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.BtnSelect.FlatAppearance.BorderSize = 2;
            this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelect.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSelect.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.BtnSelect.Location = new System.Drawing.Point(400, 398);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(406, 46);
            this.BtnSelect.TabIndex = 6;
            this.BtnSelect.Text = "Выбрать";
            this.BtnSelect.UseVisualStyleBackColor = false;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Constantia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(70, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 42);
            this.label3.TabIndex = 7;
            this.label3.Text = "История:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PbxOld1
            // 
            this.PbxOld1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbxOld1.BackgroundImage")));
            this.PbxOld1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxOld1.ContextMenuStrip = this.contextMenuStrip1;
            this.PbxOld1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxOld1.Location = new System.Drawing.Point(141, 494);
            this.PbxOld1.Name = "PbxOld1";
            this.PbxOld1.Size = new System.Drawing.Size(192, 108);
            this.PbxOld1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxOld1.TabIndex = 8;
            this.PbxOld1.TabStop = false;
            this.PbxOld1.Tag = "3";
            this.PbxOld1.Click += new System.EventHandler(this.HistoryElement_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(238, 28);
            // 
            // TsmDelete
            // 
            this.TsmDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.TsmDelete.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.TsmDelete.Name = "TsmDelete";
            this.TsmDelete.Size = new System.Drawing.Size(237, 24);
            this.TsmDelete.Text = "Удалить изображение";
            this.TsmDelete.Click += new System.EventHandler(this.TsmDelete_Click);
            // 
            // PbxOld2
            // 
            this.PbxOld2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbxOld2.BackgroundImage")));
            this.PbxOld2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxOld2.ContextMenuStrip = this.contextMenuStrip1;
            this.PbxOld2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxOld2.Location = new System.Drawing.Point(383, 495);
            this.PbxOld2.Name = "PbxOld2";
            this.PbxOld2.Size = new System.Drawing.Size(192, 108);
            this.PbxOld2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxOld2.TabIndex = 9;
            this.PbxOld2.TabStop = false;
            this.PbxOld2.Tag = "2";
            this.PbxOld2.Click += new System.EventHandler(this.HistoryElement_Click);
            // 
            // PbxOld3
            // 
            this.PbxOld3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbxOld3.BackgroundImage")));
            this.PbxOld3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxOld3.ContextMenuStrip = this.contextMenuStrip1;
            this.PbxOld3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxOld3.Location = new System.Drawing.Point(625, 495);
            this.PbxOld3.Name = "PbxOld3";
            this.PbxOld3.Size = new System.Drawing.Size(192, 108);
            this.PbxOld3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxOld3.TabIndex = 10;
            this.PbxOld3.TabStop = false;
            this.PbxOld3.Tag = "1";
            this.PbxOld3.Click += new System.EventHandler(this.HistoryElement_Click);
            // 
            // PbxOld4
            // 
            this.PbxOld4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbxOld4.BackgroundImage")));
            this.PbxOld4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxOld4.ContextMenuStrip = this.contextMenuStrip1;
            this.PbxOld4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxOld4.Location = new System.Drawing.Point(868, 495);
            this.PbxOld4.Name = "PbxOld4";
            this.PbxOld4.Size = new System.Drawing.Size(192, 108);
            this.PbxOld4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxOld4.TabIndex = 11;
            this.PbxOld4.TabStop = false;
            this.PbxOld4.Tag = "0";
            this.PbxOld4.Click += new System.EventHandler(this.HistoryElement_Click);
            // 
            // PbxCurrent
            // 
            this.PbxCurrent.BackgroundImage = global::Wallpaper_Switch.Properties.Resources.TmpImage;
            this.PbxCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbxCurrent.Location = new System.Drawing.Point(378, 136);
            this.PbxCurrent.Name = "PbxCurrent";
            this.PbxCurrent.Size = new System.Drawing.Size(448, 252);
            this.PbxCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxCurrent.TabIndex = 4;
            this.PbxCurrent.TabStop = false;
            // 
            // mainContolPanel1
            // 
            this.mainContolPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainContolPanel1.Location = new System.Drawing.Point(0, 0);
            this.mainContolPanel1.Name = "mainContolPanel1";
            this.mainContolPanel1.Size = new System.Drawing.Size(1200, 55);
            this.mainContolPanel1.TabIndex = 2;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Wallpaper Switch";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1200, 638);
            this.Controls.Add(this.mainContolPanel1);
            this.Controls.Add(this.PbxOld1);
            this.Controls.Add(this.PbxOld2);
            this.Controls.Add(this.PbxOld3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PbxOld4);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PbxCurrent);
            this.Controls.Add(this.PnlSource);
            this.Controls.Add(this.BtnPropeties);
            this.Controls.Add(this.BtnSource);
            this.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallpaper Switch";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.PnlSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxOld4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCurrent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label BtnSource;
        private System.Windows.Forms.Label BtnPropeties;
        private System.Windows.Forms.Panel PnlSource;
        private System.Windows.Forms.PictureBox BtnAddSource;
        private System.Windows.Forms.PictureBox BtnDelSource;
        private System.Windows.Forms.PictureBox BtnEditSource;
        private System.Windows.Forms.DataGridView DgvSource;
        private System.Windows.Forms.PictureBox PbxCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PbxOld1;
        private System.Windows.Forms.PictureBox PbxOld2;
        private System.Windows.Forms.PictureBox PbxOld3;
        private System.Windows.Forms.PictureBox PbxOld4;
        private Custom_components.MainContolPanel mainContolPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClmActive;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem TsmDelete;
        private NotifyIcon notifyIcon1;
        private Timer timer1;
    }
}

