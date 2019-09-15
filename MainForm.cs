using Dapper;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XNote
{
    public partial class MainForm : Form
    {
        private readonly string ConnectionString = "Data Source=XNote.db";

        public MainForm()
        {
            InitializeComponent();

            // 加载所有条目
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                // list数据源必须先转换再绑定
                var bs  = new BindingSource {
                    DataSource = conn.Query<Record>("SELECT DISTINCT * FROM record")
                };
                DgvMain.DataSource = bs;
            }
            DgvMain.CurrentCell = DgvMain.Rows[DgvMain.Rows.Count -1 ].Cells[1];

            // 延时订阅CellValueChanged事件
            DgvMain.CellValueChanged += DgvMain_CellValueChanged;
        }

        // 查
        private void TxtKeyWord_TextChanged(object sender, EventArgs e)
        {
            // 构造多关键字SQL语句
            var keywords = TxtKeyWord.Text.Trim().Split(new[] { ' ' });
            var sql = "SELECT DISTINCT * FROM record WHERE ";
            foreach (var keyword in keywords)
            {
                if (string.Empty != keyword)
                {
                    sql = sql + string.Format("Content LIKE '%{0}%' AND ", keyword);
                }
            }
            sql = sql.Substring(0, sql.Length - 4);

            // 查询
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                var bs = new BindingSource
                {
                    DataSource = conn.Query<Record>(sql)
                };
                DgvMain.DataSource = bs;
            }
            DgvMain.CurrentCell = DgvMain.Rows[DgvMain.Rows.Count - 1].Cells[1];
        }

        // 删
        private void DgvMain_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var id = DgvMain.CurrentRow.Cells[0].Value + string.Empty;
            if (DialogResult.OK ==
                MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Execute("DELETE FROM record WHERE id=@ID",
                        new
                        {
                            ID = id,
                        });
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        // 增+改
        private void DgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var id = DgvMain.CurrentRow.Cells[0].Value + string.Empty;
            var content = DgvMain.CurrentRow.Cells[1].Value + string.Empty;
            var standard = DgvMain.CurrentRow.Cells[2].Value + string.Empty;
            var clause = DgvMain.CurrentRow.Cells[3].Value + string.Empty;

            if ("0" == id)
            {
                // 新增记录
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Execute("INSERT INTO record(content, standard, clause)VALUES(@Content,@Standard,@Clause)",
                        new 
                        {
                            Content = content,
                            Standard = standard,
                            Clause = clause
                        });
                    var newID = conn.Query<int>("SELECT MAX(id) FROM record").First<int>();
                    DgvMain.CurrentRow.Cells[0].Value = newID;
                }
            }
            else
            {
                // 更新记录
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Execute("UPDATE record SET content=@Content,standard=@Standard,clause=@Clause WHERE id=@ID",
                        new
                        {
                            ID = id,
                            Content = content,
                            Standard = standard,
                            Clause = clause
                        });
                }
            }
        }

        // 显示行号
        private void DgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var rownum = e.RowIndex;
            var rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4,
                ((DataGridView)sender).RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rownum + string.Empty, ((DataGridView)sender).RowHeadersDefaultCellStyle.Font,
                rct, ((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor, Color.Transparent,
                TextFormatFlags.Right);
        }

        // 右键菜单
        private void DgvMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DgvMain.ClearSelection();
                DgvMain.Rows[e.RowIndex].Selected = true;
                DgvMain.CurrentCell = DgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
                menuDataGridView.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void MnuBackUp_Click(object sender, EventArgs e)
        {
            var filename = DateTime.Now.ToShortDateString().Replace("/", "") + ".db";
            File.Copy("XNote.db", filename, true);
            if (File.Exists(filename))
            {
                MessageBox.Show("备份成功^_^");
            }
        }

        private void MnuOpenCurrentDirectory_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory());
        }

        private void MnuDeleteRow_Click(object sender, EventArgs e)
        {
            var id = DgvMain.CurrentRow.Cells[0].Value + string.Empty;
            if (DialogResult.OK ==
                MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Execute("DELETE FROM record WHERE id=@ID",
                        new
                        {
                            ID = id,
                        });
                }
                DgvMain.Rows.RemoveAt(DgvMain.CurrentRow.Index);
            }
            else
            {
                return;
            }
        }

        private void MnuViewImage_Click(object sender, EventArgs e)
        {
            // 构造图片路径
            var temp = Environment.GetEnvironmentVariable("TEMP");
            var imagePath = string.Format("{0}\\XNOTE_{1}.png",
                temp,
                DgvMain.CurrentRow.Cells[0].Value + string.Empty);

            // 读取图片
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                var data = conn.Query<byte[]>("SELECT image FROM record WHERE id=@ID",
                    new{ID = DgvMain.CurrentRow.Cells[0].Value}).First<byte[]>();
                if (null == data)
                {
                    return;
                }
                ImageHelper.BytesToImage(data, imagePath, false);
            }

            System.Diagnostics.Process.Start(imagePath);
        }

        private void MnuSaveImage_Click(object sender, EventArgs e)
        {
            var id = DgvMain.CurrentRow.Cells[0].Value;
            var img = Clipboard.GetImage();
            var buffer = ImageHelper.ImageToBytes(img, ImageFormat.Png);

            using (var conn = new SQLiteConnection(ConnectionString))
            {
                // 设置图片标志
                conn.Execute("UPDATE record SET imageflag='1' WHERE id=@ID", new { ID = id });
                // 保存图片
                conn.Execute("UPDATE record SET image=@Image WHERE id=@ID", new { ID = id, Image=buffer});
                MessageBox.Show("图片保存成功^_^");
            }
        }

        private void MnuDeleteImage_Click(object sender, EventArgs e)
        {
            var id = DgvMain.CurrentRow.Cells[0].Value;
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                // 设置图片标志
                conn.Execute("UPDATE record SET imageflag=null  WHERE id=@ID", new { ID = id });
                // 保存图片
                conn.Execute("UPDATE record SET image=null  WHERE id=@ID", new { ID = id});
                MessageBox.Show("图片删除成功^_^");
            }
        }

        private void MnuZIP_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("VACUUM", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("压缩数据库成功^_^");
                    }
                    catch (SQLiteException)
                    {
                        conn.Close();
                    }
                }
            }
        }

        // 定义快捷键
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys.Escape == e.KeyCode && TxtKeyWord.Focused))
            {
                TxtKeyWord.Clear();
            }
            else if ((Keys.D | Keys.Control) == e.KeyData && DgvMain.Focused)
            {
                DgvMain.CurrentCell.Value = DgvMain.Rows[DgvMain.CurrentCell.RowIndex - 1].Cells[DgvMain.CurrentCell.ColumnIndex].Value;
                DgvMain.BeginEdit(false);
            }
            else if ((Keys.V | Keys.Control) == e.KeyData && DgvMain.Focused && !DgvMain.CurrentCell.IsInEditMode)
            {
                DgvMain.CurrentCell.Value = Clipboard.GetData(DataFormats.Text);
                DgvMain.BeginEdit(false);
            }
            else if ((Keys.F | Keys.Control) == e.KeyData)
            {
                TxtKeyWord.Focus();
            }
        }

       
    }
}
