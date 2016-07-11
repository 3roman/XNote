using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace XNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //设置窗体的双缓冲
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            
            InitializeComponent();

            // 释放资源
            ReleaseResource("System.Data.SQLite.dll", "XNote.System.Data.SQLite.dll");
            ReleaseResource("XNote.db", "XNote.XNote.db");

            // 在控件初始化(InitializeComponent)后才订阅CellValueChanged事件
            dgv.CellValueChanged += dgv_CellValueChanged;

            // 设置表头背景色
            var cellStyle = new DataGridViewCellStyle {BackColor = Color.FromArgb(237, 125, 49)};
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style = cellStyle;
            }
           
            // 设置奇数行背景色
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);

            // 禁止自动创建列
            dgv.AutoGenerateColumns = false;
            // 绑定列数据源属性
            dgv.Columns[0].DataPropertyName = "序号";
            dgv.Columns[1].DataPropertyName = "记录";
            dgv.Columns[2].DataPropertyName = "分类";
            dgv.Columns[3].DataPropertyName = "来源";
 
            //利用反射设置DataGridView的双缓冲
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);

            // 初始化datagridview控件
            dgv_Initial();
        }


        // 初始化datagridview控件内容
        private void dgv_Initial()
        {
            txt.Clear();
            var dt = Query("SELECT * FROM xnote");
            // 装载数据源
            dgv.DataSource = dt;
            // 一拉到底
            dgv.CurrentCell = dgv.Rows[dgv.Rows.Count-1].Cells[1];
        }

        // 增+改
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            var idx = dgv.Rows[e.RowIndex].Cells[0].Value + "";
            var record = dgv.Rows[e.RowIndex].Cells[1].Value + "";
            var catg = dgv.Rows[e.RowIndex].Cells[2].Value + "";
            var from = dgv.Rows[e.RowIndex].Cells[3].Value + "";

            if ("" == idx)
            {
                // 新增记录
                sql = string.Format("INSERT INTO xnote(记录, 分类, 来源) VALUES('{0}','{1}','{2}')",
                    record,
                    catg,
                    from);
                Query(sql);

                // 获取新增记录的行号
                var dt = Query("SELECT MAX(序号) FROM xnote");
                dgv.Rows[e.RowIndex].Cells[0].Value = dt.Rows[0][0] + "";
            }
            else
            {
                // 更新记录
                sql = string.Format("UPDATE xnote SET 记录='{0}', 分类='{1}', 来源='{2}' where 序号='{3}'",
                    record,
                    catg,
                    from,
                    idx);
                Query(sql);
            }
        }

        // 删
        private void dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idx = dgv.SelectedRows[0].Cells[0].Value + "";
            if (DialogResult.OK ==
                MessageBox.Show("确认删除当前记录", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                var sql = string.Format("DELETE FROM xnote WHERE 序号={0}", idx);
                Query(sql);
            }
            else
            {
                e.Cancel = true;
            }
        }

        // 查
        private void txt_TextChanged(object sender, EventArgs e)
        {
            var keywords = txt.Text.Split(' ');
            var sql = string.Format("SELECT * FROM xnote WHERE 记录 LIKE '%{0}%'", keywords[0]);
            if (2 == keywords.Length)
            {
                // 支持两个关键字搜索
                sql = string.Format("SELECT * FROM xnote WHERE 记录 LIKE '%{0}%' AND 记录 LIKE '%{1}%'", keywords[0],
                    keywords[1]);
            }
            var dt = Query(sql);
            dgv.DataSource = dt;
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    dgv.ClearSelection();
                    dgv.Rows[e.RowIndex].Selected = true;
                    break;
            }
        }
    
        // 显示行号
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rownum = e.RowIndex;
            var rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4,
                ((DataGridView)sender).RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rownum + "", ((DataGridView)sender).RowHeadersDefaultCellStyle.Font,
                rct, ((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor, Color.Transparent,
                TextFormatFlags.Right);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys.Escape == e.KeyCode && txt.Focused) || Keys.F5 == e.KeyCode)
            {
                dgv_Initial();
            }
            else if ((Keys.D | Keys.Control) == e.KeyData)
            {
                dgv.CurrentCell.Value = dgv.Rows[dgv.CurrentCell.RowIndex - 1].Cells[dgv.CurrentCell.ColumnIndex].Value;
                dgv.BeginEdit(false);
            }
        }


        private void mnuNewItem_Click(object sender, EventArgs e)
        {
           dgv_Initial();
        }

        private void mnuOpenStandrad_Click(object sender, EventArgs e)
        {
            const string sql = "SELECT 标准目录 FROM config";
            var standardDirectory = Query(sql).Rows[0][0] + "";
            if (!Directory.Exists(standardDirectory))
            {
                MessageBox.Show("请设置标准规范所在目录", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var standards = new Dictionary<string, string>();
                FindFiles(standardDirectory, standards);
                var standard = dgv.SelectedRows[0].Cells[3].Value + "";
                standard = standard.Substring(0, standard.LastIndexOf(' '));
                foreach (var item in standards.Where(item => item.Key.Contains(standard)))
                {
                    Process.Start(item.Value);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("打开文件失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void mnuSetDirectory_Click(object sender, EventArgs e)
        {
            var standardDirectory = SelectPath("请选择标准文件目录");
            if (!Directory.Exists(standardDirectory)) return;
            var sql = string.Format("UPDATE config SET 标准目录='{0}'", standardDirectory);
            Query(sql);
        }

        private void mnuViewPicture_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void mnuBackUP_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            var filename = dt.ToString("yyyy-MM-dd") + ".db";
            File.Copy("XNote.db", filename, true);
            if (File.Exists(filename))
            {
                MessageBox.Show("备份成功");
            }
        }

        /// <summary>
        /// 执行SQL语句，返回datatable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        private static DataTable Query(string sql)
        {
            using (var conn = new SQLiteConnection("Data Source=XNote.db"))
            {
                conn.Open();
                var cmd = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                cmd.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        ///  选择文件夹
        /// </summary>
        /// <param name="description">选择文件夹对话框说明</param>
        /// <returns></returns>
        public static string SelectPath(string description)
        {
            var fbd = new FolderBrowserDialog {Description = description};
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }

        /// <summary>
        /// 释放资源（资源属性映射为嵌入式的资源）
        /// </summary>
        /// <param name="filePath">释放到的路径</param>
        /// <param name="resourceName">资源全名“命名空间.+资源名”</param>
        public static void ReleaseResource(string filePath, string resourceName)
        {
            // 针对所有流文件
            // 获取当前正在执行的程序集
            var assembly = Assembly.GetExecutingAssembly();
            //foreach (var file in assembly.GetManifestResourceNames())
            // // 辅助方法：获取资源在程序集内部的名称
            // MessageBox.Show(file);
            var stream = assembly.GetManifestResourceStream(resourceName);
            // 将流读取到二进制数组中
            if (stream == null) return;
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            // 将二进制写入文件
            if (File.Exists(filePath)) return;
            var fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Close();
        }

        /// <summary>
        /// 遍历目录及其子目录下的所有文件
        /// </summary>
        /// <param name="baseDirectory">起始目录</param>
        /// <param name="files">存放返回值的字典（文件名-文件路径对）</param>
        public static void FindFiles(string baseDirectory, Dictionary<string, string> files)
        {
            //在指定目录及子目录下查找文件
            var directoryInfo = new DirectoryInfo(baseDirectory);

            // 查找子目录
            foreach (var d in directoryInfo.GetDirectories())
            {
                FindFiles(directoryInfo + "\\" + d + "\\", files);
            }

            // 查找文件
            foreach (var f in directoryInfo.GetFiles().Where(f => !files.Keys.Contains(f.Name)))
            {
                files.Add(f.Name, f.FullName);
            }
        }
    }

}