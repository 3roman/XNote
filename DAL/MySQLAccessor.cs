using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using XNote.Model;
using System.Configuration;

namespace XNote.DAL
{
    public class MySQLAccessor
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        public static IEnumerable<Record> RetrieveAllRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                IEnumerable<Record> records = conn.Query<Record>("SELECT Id, Content, Code, Clause, Catalog, ImageFlag FROM xnote");
                conn.Close();

                return records;
            }
        }

        public static IEnumerable<Record> SearchRecordByContent(string[] keywords)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM xnote WHERE ";
                foreach (string keyword in keywords)
                {
                    sql += $"content LIKE '%{keyword}%' AND ";
                }
                sql = sql.Substring(0, sql.Length - 4);
                IEnumerable<Record> records = conn.Query<Record>(sql);
                conn.Close();

                return records;
            }
        }

        public static bool DeleteRecordById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = $"DELETE FROM xnote WHERE id={id}";
                int succeed = conn.Execute(sql);
                conn.Close();

                return succeed > 0;
            }
        }

        public static int AddEmptyRecord()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = $"INSERT INTO xnote VALUES(NULL, NULL, NULL, NULL, NULL ,NULL, 0)";
                conn.Execute(sql);
                sql = "SELECT MAX(id) FROM xnote";
                int maxRecordId = conn.QueryFirst<int>(sql);
                conn.Close();

                return maxRecordId;
            }
        }

        public static bool UpdateRecord(Record record)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = $"UPDATE xnote set content='{record.Content}', code='{record.Code}', clause='{record.Clause}', catalog='{record.Catalog}' WHERE id={record.Id}";
                int succeed = conn.Execute(sql);
                conn.Close();

                return succeed > 0;
            }
        }

        public static void SaveImage(int id, byte[] buffer)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = $"UPDATE xnote set image=@Image, imageflag=1 WHERE id={id}";
                conn.Execute(sql, new { Image = buffer });
                conn.Close();
            }
        }

        public static void CleanImage(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = $"UPDATE xnote set image=NULL, imageflag=0 WHERE id={id}";
                conn.Execute(sql);
                conn.Close();
            }
        }

        public static byte[] ViewImage(int id)
        {
            byte[] buffer;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = $"SELECT image FROM xnote WHERE id={id}";
                buffer = conn.QueryFirst<byte[]>(sql);
                conn.Close();
            }

            return buffer;
        }
    }
}
