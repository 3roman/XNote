using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace XNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();

            var dt = Query("SELECT * FROM xnote");
            //dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 避免dgv加载时也触发changed事件
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 禁止自动创建列
            dataGridView1.AutoGenerateColumns = false;
            // 绑定列数据源属性
            dataGridView1.Columns[0].DataPropertyName = "序号";
            dataGridView1.Columns[1].DataPropertyName = "记录";
            dataGridView1.Columns[2].DataPropertyName = "分类";
            dataGridView1.Columns[3].DataPropertyName = "来源";
            // dgv绑定datatable
            dataGridView1.DataSource = dt;
            // 下拉到最后一行
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2];
            // 设置背景色
            var style = new DataGridViewCellStyle { BackColor = Color.FromArgb(237, 125, 49) };
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style = style;
            }
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
        }

        
        // 增+改
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            var idx      = dataGridView1.Rows[e.RowIndex].Cells[0].Value + "";
            var record   = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
            var catg     = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
            var from     = dataGridView1.Rows[e.RowIndex].Cells[3].Value + "";

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
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = dt.Rows[0][0].ToString();
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
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idx = e.Row.Cells[0].Value + "";
            if (DialogResult.OK == MessageBox.Show("确认删除当前记录", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var keywords = textBox1.Text.Split(' ');
            var sql = string.Format("SELECT * FROM xnote WHERE 记录 LIKE '%{0}%'", keywords[0]);
            if (2 == keywords.Length)
            {
                // 支持两个关键字搜索
                sql = string.Format("SELECT * FROM xnote WHERE 记录 LIKE '%{0}%' AND 记录 LIKE '%{1}%'", keywords[0], keywords[1]);
            }
            var dt = Query(sql);
            dataGridView1.DataSource = dt;
        }

        // 备份数据库
        private void button1_Click(object sender, EventArgs e)
        {
            var dt       = DateTime.Now;
            var filename = dt.ToString("yyyy-MM-dd")+".db";
            File.Copy("hangch.db", filename, true);
            if (File.Exists(filename))
            {
                MessageBox.Show("备份成功!");
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rownum = e.RowIndex;
            var rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4, ((DataGridView)sender).RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rownum.ToString(), ((DataGridView)sender).RowHeadersDefaultCellStyle.Font, rct, ((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor, Color.Transparent, TextFormatFlags.Right);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                textBox1.Clear();
            }
        }

        /// <summary>
        /// 执行SQL语句，返回datatable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        static private DataTable Query(string sql)
        {

            using (var conn = new SQLiteConnection("Data Source=hangch.db"))
            {
                conn.Open();
                var cmd = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                cmd.Fill(dt);

                return dt;
            }
        }

        
    }

     


}
