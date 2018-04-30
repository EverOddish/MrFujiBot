using System.Data;
using Mono.Data.Sqlite;

namespace MrFujiBot
{
    class FujiDatabase
    {
        private IDbConnection dbcon;

        public FujiDatabase()
        {
            string connectionString = "URI=file:Resources/MrFujiBot.db";
            dbcon = new SqliteConnection(connectionString);
            dbcon.Open();
        }

        ~FujiDatabase()
        {
            dbcon.Close();
        }

        public delegate void QueryCallback(IDataReader reader);

        public void Query(string query, QueryCallback cb)
        {
            IDbCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                cb(reader);
            }
            reader.Dispose();
            dbcmd.Dispose();
        }
    }
}