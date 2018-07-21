using SQLite;
using XNote.Model;

namespace XNote.Service
{
    class DataService
    {
        public SQLiteConnection Conn { get; set; }

        public DataService(string databasePath)
        {
            Conn = new SQLiteConnection(databasePath);
        }

        public TableQuery<Record> Retrieve()
        {
            
            return Conn.Table<Record>();
        }

        public TableQuery<Record> Query(string keyword)
        {
            return Conn.Table<Record>().Where(x => x.Content.Contains(keyword));
        }

        public void Delete(int id)
        {
            string sql = string.Format("DELETE FROM Person WHERE ID = {0}", id);
            Conn.Execute(sql);
        }

        public void Update(int id, string content, string reference)
        {
            string sql = string.Format("UPDATE Record SET Content = '{0}', Reference='{1}' WHERE Id = {2}",
               content,
               reference,
               id);
            Conn.Execute(sql);
        }
    }
}