using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using XNote.Model;

namespace XNote.DAL
{
    public class MySQLAccessor
    {
        public static string ConnectionString => "server=;User Id=xnote;password=;Database=xnote";

        public static  IEnumerable<Record>  RetrieveAllRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                IEnumerable<Record> records =  conn.Query<Record>("SELECT Id,Content,Code,Clause,Catalog,ImageFlag FROM record");
                conn.Close();

                return records;
            }
        }

        public static IEnumerable<Record> RetrieveSpecificRecords(string[] keywords)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM record WHERE ";
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
    }
}
