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
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.menuDataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBackUP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.menuDataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(214)))));
            this.dgvDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataBase.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(125)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataBase.ColumnHeadersHeight = 27;
            this.dgvDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5});
            this.dgvDataBase.EnableHeadersVisualStyles = false;
            this.dgvDataBase.Location = new System.Drawing.Point(0, 34);
            this.dgvDataBase.MultiSelect = false;
            this.dgvDataBase.Name = "dgvDataBase";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDataBase.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDataBase.RowTemplate.Height = 23;
            this.dgvDataBase.Size = new System.Drawing.Size(868, 499);
            this.dgvDataBase.TabIndex = 0;
            this.dgvDataBase.TabStop = false;
            this.dgvDataBase.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDataBase_UserDeletingRow);
            this.dgvDataBase.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDataBase_CellMouseDown);
            this.dgvDataBase.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDataBase_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "检索记录";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtKeyWord.Location = new System.Drawing.Point(66, 5);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(799, 21);
            this.txtKeyWord.TabIndex = 0;
            this.txtKeyWord.TextChanged += new System.EventHandler(this.txtKeyWord_TextChanged);
            // 
            // menuDataGridView
            // 
            this.menuDataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewImage,
            this.mnuSaveImage,
            this.mnuDeleteImage,
            this.toolStripSeparator1,
            this.mnuBackUP,
            this.mnuAbout});
            this.menuDataGridView.Name = "contextMenuStrip1";
            this.menuDataGridView.Size = new System.Drawing.Size(137, 120);
            // 
            // mnuViewImage
            // 
            this.mnuViewImage.Name = "mnuViewImage";
            this.mnuViewImage.Size = new System.Drawing.Size(136, 22);
            this.mnuViewImage.Text = "查看图片";
            this.mnuViewImage.Click += new System.EventHandler(this.mnuViewImage_Click);
            // 
            // mnuSaveImage
            // 
            this.mnuSaveImage.Name = "mnuSaveImage";
            this.mnuSaveImage.Size = new System.Drawing.Size(136, 22);
            this.mnuSaveImage.Text = "保存图片";
            this.mnuSaveImage.Click += new System.EventHandler(this.mnuSaveImage_Click);
            // 
            // mnuDeleteImage
            // 
            this.mnuDeleteImage.Name = "mnuDeleteImage";
            this.mnuDeleteImage.Size = new System.Drawing.Size(136, 22);
            this.mnuDeleteImage.Text = "删除图片";
            this.mnuDeleteImage.Click += new System.EventHandler(this.mnuDeleteImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuBackUP
            // 
            this.mnuBackUP.Name = "mnuBackUP";
            this.mnuBackUP.Size = new System.Drawing.Size(136, 22);
            this.mnuBackUP.Text = "备份数据库";
            this.mnuBackUP.Click += new System.EventHandler(this.mnuBackUp_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(136, 22);
            this.mnuAbout.Text = "关于本软件";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "序号";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "记录";
            this.Column2.FillWeight = 155.9391F;
            this.Column2.HeaderText = "记录";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "来源";
            this.Column4.FillWeight = 25F;
            this.Column4.HeaderText = "来源";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "分类";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.FillWeight = 15F;
            this.Column3.HeaderText = "分类";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "图片标记";
            this.Column5.HeaderText = "图片标记";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 533);
            this.ContextMenuStrip = this.menuDataGridView;
            this.Controls.Add(this.txtKeyWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDataBase);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.menuDataGridView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.ContextMenuStrip menuDataGridView;
        private System.Windows.Forms.ToolStripMenuItem mnuBackUP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuViewImage;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveImage;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteImage;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}

