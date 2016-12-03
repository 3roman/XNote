namespace XNote
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSavePicture1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSavePicture2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeletePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBackUP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SandyBrown;
            this.dgvDataBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataBase.ColumnHeadersHeight = 27;
            this.dgvDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDataBase.Location = new System.Drawing.Point(0, 34);
            this.dgvDataBase.MultiSelect = false;
            this.dgvDataBase.Name = "dgvDataBase";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkBlue;
            this.dgvDataBase.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDataBase.RowTemplate.Height = 23;
            this.dgvDataBase.Size = new System.Drawing.Size(814, 434);
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
            this.txtKeyWord.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtKeyWord.Location = new System.Drawing.Point(66, 5);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(745, 21);
            this.txtKeyWord.TabIndex = 0;
            this.txtKeyWord.TextChanged += new System.EventHandler(this.txtKeyWord_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewPicture,
            this.toolStripMenuItem1,
            this.mnuDeletePicture,
            this.toolStripSeparator1,
            this.mnuBackUP,
            this.mnuAbout});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 120);
            // 
            // mnuViewPicture
            // 
            this.mnuViewPicture.Name = "mnuViewPicture";
            this.mnuViewPicture.Size = new System.Drawing.Size(136, 22);
            this.mnuViewPicture.Text = "查看图片";
            this.mnuViewPicture.Click += new System.EventHandler(this.mnuViewPicture_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSavePicture1,
            this.mnuSavePicture2});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "保存图片";
            // 
            // mnuSavePicture1
            // 
            this.mnuSavePicture1.Name = "mnuSavePicture1";
            this.mnuSavePicture1.Size = new System.Drawing.Size(136, 22);
            this.mnuSavePicture1.Text = "来自剪切板";
            this.mnuSavePicture1.Click += new System.EventHandler(this.mnuSavePicture1_Click);
            // 
            // mnuSavePicture2
            // 
            this.mnuSavePicture2.Name = "mnuSavePicture2";
            this.mnuSavePicture2.Size = new System.Drawing.Size(136, 22);
            this.mnuSavePicture2.Text = "来自文件";
            // 
            // mnuDeletePicture
            // 
            this.mnuDeletePicture.Name = "mnuDeletePicture";
            this.mnuDeletePicture.Size = new System.Drawing.Size(136, 22);
            this.mnuDeletePicture.Text = "删除图片";
            this.mnuDeletePicture.Click += new System.EventHandler(this.mnuDeletePicture_Click);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
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
            // Column3
            // 
            this.Column3.DataPropertyName = "分类";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 19.49239F;
            this.Column3.HeaderText = "分类";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "来源";
            this.Column4.FillWeight = 19.49239F;
            this.Column4.HeaderText = "来源";
            this.Column4.Name = "Column4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 468);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.txtKeyWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDataBase);
            this.Font = new System.Drawing.Font("SimSun", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuBackUP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuViewPicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSavePicture1;
        private System.Windows.Forms.ToolStripMenuItem mnuSavePicture2;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletePicture;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

