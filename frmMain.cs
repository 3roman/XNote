using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XNote.Class;

namespace XNote
{
    public partial class frmMain : Form
    {
        private readonly SQLiteHelper _sqLiteHelper;
        private const string DatabasePath = "XNote.db";

        public frmMain()
        {
            // 为窗体及所有控件启用双缓冲
            //SetStyle(ControlStyles.ResizeRedraw, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();

            // 释放资源
            //Common.ReleaseResource("XNote.System.Data.SQLite.dll", "System.Data.SQLite.dll");
            Common.ReleaseResource("XNote.XNote.db", DatabasePath);

            _sqLiteHelper = new SQLiteHelper(DatabasePath);

            // 延时（InitializeComponent之后）订阅事件
            dgvDataBase.CellValueChanged += dgvDataBase_CellValueChanged;
            
            // 禁止自动创建列
            dgvDataBase.AutoGenerateColumns = false;

            // datagridview启用双缓冲
            Common.SetDoubleBuffered(dgvDataBase);

            LoadAllDatas();
        }

        private void LoadAllDatas()
        {
            dgvDataBase.DataSource = _sqLiteHelper.ExecuteQuery("SELECT DISTINCT * FROM xnote");
            dgvDataBase.CurrentCell = dgvDataBase.Rows[dgvDataBase.Rows.Count - 1].Cells[1];
        }

        // 查
        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            var keywords = txtKeyWord.Text.Trim().Split(new[] { ' ' });
            var sql = "SELECT DISTINCT * FROM xnote WHERE ";
            foreach (var keyword in keywords)
            {
                if (string.Empty != keyword)
                {
                    sql = sql + string.Format("记录 LIKE '%{0}%' OR ", keyword);
                }

            }
            sql = sql.Substring(0, sql.Length - 4);
            dgvDataBase.DataSource = _sqLiteHelper.ExecuteQuery(sql);
            foreach (var row in dgvDataBase.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToBoolean(row.Cells[4].Value)))
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(221, 235, 247);
            }
            dgvDataBase.CurrentCell = dgvDataBase.Rows[dgvDataBase.Rows.Count - 1].Cells[1];
        }

        // 增+改
        private void dgvDataBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            var idx = dgvDataBase.CurrentRow.Cells[0].Value + "";
            var record = dgvDataBase.CurrentRow.Cells[1].Value + "";
            var catg = dgvDataBase.CurrentRow.Cells[2].Value + "";
            var from = dgvDataBase.CurrentRow.Cells[3].Value + "";

            if (string.Empty == idx)
            {
                // 新增记录
                sql = string.Format("INSERT INTO xnote(记录, 分类, 来源) VALUES('{0}','{1}','{2}')",
                    record,
                    catg,
                    from);
                _sqLiteHelper.ExecuteQuery(sql);
                // 获取新增记录的行号
                var dt = _sqLiteHelper.ExecuteQuery("SELECT MAX(序号) FROM xnote");
                dgvDataBase.CurrentRow.Cells[0].Value = dt.Rows[0][0] + "";
            }
            else
            {
                // 更新记录
                sql = string.Format("UPDATE xnote SET 记录='{0}', 分类='{1}', 来源='{2}' where 序号='{3}'",
                    record,
                    catg,
                    from,
                    idx);
                _sqLiteHelper.ExecuteQuery(sql);
            }
        }

        // 删
        private void dgvDataBase_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idx = dgvDataBase.CurrentRow.Cells[0].Value + "";
            if (DialogResult.OK ==
                MessageBox.Show("真的要删除当前记录吗", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                var sql = string.Format("DELETE FROM xnote WHERE 序号={0}", idx);
                _sqLiteHelper.ExecuteQuery(sql);
            }
            else
            {
                e.Cancel = true;
            }
        }

        // 显示行号
        private void dgvDataBase_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rownum = e.RowIndex;
            var rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4,
                ((DataGridView)sender).RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rownum + "", ((DataGridView)sender).RowHeadersDefaultCellStyle.Font,
                rct, ((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor, Color.Transparent,
                TextFormatFlags.Right);
        }

        // 右键弹出菜单
        private void dgvDataBase_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvDataBase.ClearSelection();
                dgvDataBase.Rows[e.RowIndex].Selected = true;
                dgvDataBase.CurrentCell = dgvDataBase.Rows[e.RowIndex].Cells[e.ColumnIndex];
                menuDataGridView.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void mnuBackUp_Click(object sender, EventArgs e)
        {
            var filename = DateTime.Now.ToShortDateString().Replace("/", "") + ".db";
            File.Copy("XNote.db", filename, true);
            if (File.Exists(filename))
            {
                MessageBox.Show("备份成功");
            }
        }

        private void mnuViewImage_Click(object sender, EventArgs e)
        {
            // 构造图片路径
            var temp = Environment.GetEnvironmentVariable("TEMP");
            var imagePath = string.Format("{0}\\XNOTE_{1}.png", 
                temp,
                dgvDataBase.CurrentRow.Cells[0].Value + "");

            // 读取图片
            var sql = string.Format("SELECT 图片 FROM xnote WHERE 序号='{0}'",
                dgvDataBase.CurrentRow.Cells[0].Value + "");
            var dt = _sqLiteHelper.ExecuteQuery(sql);
            if (dt.Rows[0]["图片"] is DBNull)
            {
                return;
            }
            // 保存图片
            ImageHelper.BytesToImage((Byte[])dt.Rows[0]["图片"], imagePath, false);
            Process.Start(imagePath);
        }

        private void mnuSaveImage_Click(object sender, EventArgs e)
        {
            var img = Clipboard.GetImage();
            var buffer = ImageHelper.ImageToBytes(img, ImageFormat.Png);
            _sqLiteHelper.SaveImage("xnote", "图片", "序号", dgvDataBase.CurrentRow.Cells[0].Value + "", buffer);
            var sql = string.Format("UPDATE xnote SET 图片标记='1'  WHERE 序号='{0}'",
                dgvDataBase.CurrentRow.Cells[0].Value + "");
            _sqLiteHelper.ExecuteQuery(sql);

        }

        private void mnuDeleteImage_Click(object sender, EventArgs e)
        {
            var sql = string.Format("UPDATE xnote SET 图片=null WHERE 序号='{0}'",
                dgvDataBase.CurrentRow.Cells[0].Value + "");
            _sqLiteHelper.ExecuteQuery(sql);
            sql = string.Format("UPDATE xnote SET 图片标记='0' WHERE 序号='{0}'",
                dgvDataBase.CurrentRow.Cells[0].Value + "");
            _sqLiteHelper.ExecuteQuery(sql);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys.Escape == e.KeyCode && txtKeyWord.Focused))
            {
                txtKeyWord.Clear();
            }
            else if ((Keys.D | Keys.Control) == e.KeyData && dgvDataBase.Focused)
            {
                dgvDataBase.CurrentCell.Value = dgvDataBase.Rows[dgvDataBase.CurrentCell.RowIndex - 1].Cells[dgvDataBase.CurrentCell.ColumnIndex].Value;
                dgvDataBase.BeginEdit(false);
            }
            else if ((Keys.C | Keys.Control) == e.KeyData && dgvDataBase.Focused && !dgvDataBase.CurrentCell.IsInEditMode)
            {
                Common.Copy2Clipboard(dgvDataBase.SelectedCells[0].Value + "");
            }
            else if ((Keys.V | Keys.Control) == e.KeyData && dgvDataBase.Focused && !dgvDataBase.CurrentCell.IsInEditMode)
            {
                dgvDataBase.CurrentCell.Value = Clipboard.GetData(DataFormats.Text);
                dgvDataBase.BeginEdit(false);
            }
            else if ((Keys.F | Keys.Control) == e.KeyData)
            {
                txtKeyWord.Focus();
            }
        }
    }
}
