using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace XNote
{
    class SQLiteHelper
    {
        private readonly string _connectionString;

        public SQLiteHelper(string databasePath)
        {
            // 检查数据库是否存在
            if (!File.Exists(databasePath))
            {
                throw new FileNotFoundException("数据库不存在!", databasePath);
            }

            _connectionString = "Data Source=" + databasePath + "; Version=3";
        }

        public DataTable ExecuteQuery(string sqlString)
        {
            // DataAdapter是DataBase与DataTable或DataSet之间的桥梁
            using (var sda = new SQLiteDataAdapter(sqlString, _connectionString))
            {
                var dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }
        }

        public void SaveImage(string tableName, string columName, string idName, string idValue, byte[] buffer)
        {
            var conn = new SQLiteConnection(_connectionString);
            var cmd = conn.CreateCommand();
            cmd.CommandText = String.Format("UPDATE {0} SET {1}=(@0) WHERE {2}='{3}'", tableName, columName, idName, idValue);
            var param = new SQLiteParameter("@0", DbType.Binary) {Value = buffer};
            cmd.Parameters.Add(param);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }
    }
}

