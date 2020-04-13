namespace XNote
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DgvMain = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtKeyWord = new System.Windows.Forms.TextBox();
            this.menuDataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.杂项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenCurrentDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.备份数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuZIP = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于本软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMain)).BeginInit();
            this.menuDataGridView.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvMain
            // 
            this.DgvMain.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            this.DgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvMain.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvMain.ColumnHeadersHeight = 27;
            this.DgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5});
            this.DgvMain.Location = new System.Drawing.Point(0, 53);
            this.DgvMain.MultiSelect = false;
            this.DgvMain.Name = "DgvMain";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DgvMain.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvMain.RowTemplate.Height = 23;
            this.DgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMain.Size = new System.Drawing.Size(904, 509);
            this.DgvMain.TabIndex = 0;
            this.DgvMain.TabStop = false;
            this.DgvMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMain_CellMouseDown);
            this.DgvMain.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMain_ColumnHeaderMouseClick);
            this.DgvMain.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvMain_RowPostPaint);
            this.DgvMain.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvMain_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Content";
            this.Column2.FillWeight = 109.0662F;
            this.Column2.HeaderText = "记录";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Standard";
            this.Column4.FillWeight = 20F;
            this.Column4.HeaderText = "标准规范";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Clause";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.FillWeight = 13F;
            this.Column3.HeaderText = "条目";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "ImageFlag";
            this.Column5.FillWeight = 19.09604F;
            this.Column5.HeaderText = "图片";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "检索记录";
            // 
            // TxtKeyWord
            // 
            this.TxtKeyWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtKeyWord.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtKeyWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtKeyWord.Location = new System.Drawing.Point(67, 27);
            this.TxtKeyWord.Name = "TxtKeyWord";
            this.TxtKeyWord.Size = new System.Drawing.Size(835, 23);
            this.TxtKeyWord.TabIndex = 0;
            this.TxtKeyWord.TextChanged += new System.EventHandler(this.TxtKeyWord_TextChanged);
            // 
            // menuDataGridView
            // 
            this.menuDataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDeleteRow,
            this.mnuViewImage,
            this.toolStripSeparator1,
            this.mnuAbout});
            this.menuDataGridView.Name = "contextMenuStrip1";
            this.menuDataGridView.Size = new System.Drawing.Size(137, 76);
            // 
            // MnuDeleteRow
            // 
            this.MnuDeleteRow.Name = "MnuDeleteRow";
            this.MnuDeleteRow.Size = new System.Drawing.Size(136, 22);
            this.MnuDeleteRow.Text = "删除记录";
            this.MnuDeleteRow.Click += new System.EventHandler(this.MnuDeleteRow_Click);
            // 
            // mnuViewImage
            // 
            this.mnuViewImage.Name = "mnuViewImage";
            this.mnuViewImage.Size = new System.Drawing.Size(136, 22);
            this.mnuViewImage.Text = "显示图片";
            this.mnuViewImage.Click += new System.EventHandler(this.MnuViewImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(136, 22);
            this.mnuAbout.Text = "关于本软件";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.图片ToolStripMenuItem,
            this.杂项ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 图片ToolStripMenuItem
            // 
            this.图片ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示图片ToolStripMenuItem,
            this.保存图片ToolStripMenuItem,
            this.删除图片ToolStripMenuItem});
            this.图片ToolStripMenuItem.Name = "图片ToolStripMenuItem";
            this.图片ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.图片ToolStripMenuItem.Text = "图片";
            // 
            // 显示图片ToolStripMenuItem
            // 
            this.显示图片ToolStripMenuItem.Name = "显示图片ToolStripMenuItem";
            this.显示图片ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示图片ToolStripMenuItem.Text = "显示图片";
            this.显示图片ToolStripMenuItem.Click += new System.EventHandler(this.MnuViewImage_Click);
            // 
            // 保存图片ToolStripMenuItem
            // 
            this.保存图片ToolStripMenuItem.Name = "保存图片ToolStripMenuItem";
            this.保存图片ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存图片ToolStripMenuItem.Text = "保存图片";
            this.保存图片ToolStripMenuItem.Click += new System.EventHandler(this.MnuSaveImage_Click);
            // 
            // 删除图片ToolStripMenuItem
            // 
            this.删除图片ToolStripMenuItem.Name = "删除图片ToolStripMenuItem";
            this.删除图片ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除图片ToolStripMenuItem.Text = "删除图片";
            this.删除图片ToolStripMenuItem.Click += new System.EventHandler(this.MnuDeleteImage_Click);
            // 
            // 杂项ToolStripMenuItem
            // 
            this.杂项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenCurrentDirectory,
            this.备份数据库ToolStripMenuItem,
            this.MnuZIP});
            this.杂项ToolStripMenuItem.Name = "杂项ToolStripMenuItem";
            this.杂项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.杂项ToolStripMenuItem.Text = "杂项";
            // 
            // mnuOpenCurrentDirectory
            // 
            this.mnuOpenCurrentDirectory.Name = "mnuOpenCurrentDirectory";
            this.mnuOpenCurrentDirectory.Size = new System.Drawing.Size(136, 22);
            this.mnuOpenCurrentDirectory.Text = "打开目录";
            this.mnuOpenCurrentDirectory.Click += new System.EventHandler(this.MnuOpenCurrentDirectory_Click);
            // 
            // 备份数据库ToolStripMenuItem
            // 
            this.备份数据库ToolStripMenuItem.Name = "备份数据库ToolStripMenuItem";
            this.备份数据库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.备份数据库ToolStripMenuItem.Text = "备份数据库";
            this.备份数据库ToolStripMenuItem.Click += new System.EventHandler(this.MnuBackUp_Click);
            // 
            // MnuZIP
            // 
            this.MnuZIP.Name = "MnuZIP";
            this.MnuZIP.Size = new System.Drawing.Size(136, 22);
            this.MnuZIP.Text = "压缩数据库";
            this.MnuZIP.Click += new System.EventHandler(this.MnuZIP_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于本软件ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于本软件ToolStripMenuItem
            // 
            this.关于本软件ToolStripMenuItem.Name = "关于本软件ToolStripMenuItem";
            this.关于本软件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于本软件ToolStripMenuItem.Text = "关于本软件";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 562);
            this.ContextMenuStrip = this.menuDataGridView;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TxtKeyWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvMain);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMain)).EndInit();
            this.menuDataGridView.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtKeyWord;
        private System.Windows.Forms.ContextMenuStrip menuDataGridView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewImage;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 杂项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于本软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenCurrentDirectory;
        private System.Windows.Forms.ToolStripMenuItem 备份数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuDeleteRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem MnuZIP;
    }
}

