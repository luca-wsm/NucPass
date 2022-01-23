using NucPass.Constants;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace NucPass.SQL
{
    public class SqlService : IDisposable
    {
        private const string databaseCombined = FileConstants.DATABASE_FILE_COMBINED;
        private static SQLiteConnection conn;
        private static SQLiteCommand cmd;

        public SqlService()
        {
            if (!File.Exists(databaseCombined))
            {
                InitSQL();
                InitDatabase();
            } else
            {
                conn = new SQLiteConnection($"data source={databaseCombined}");
                cmd = new SQLiteCommand(conn);
                conn.Open();
            }
        }

        private void InitSQL()
        {
            Directory.CreateDirectory(FileConstants.GENERAL_FOLDER);
            SQLiteConnection.CreateFile(databaseCombined);
            conn = new SQLiteConnection($"data source={databaseCombined}");
            cmd = new SQLiteCommand(conn);
            conn.Open();
        }

        private void InitDatabase()
        {
            var query = @"CREATE TABLE IF NOT EXISTS
                           [Passwords] (
                           [Name] TEXT UNIQUE,
                           [Password] TEXT,
                           [Timestamp] DATETIME DEFAULT CURRENT_TIMESTAMP);";
            Update(query);
        }

        public void Update(string update)
        {
            try
            {
                cmd.CommandText = update;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("sql error >");
            }
        }

        public void Dispose()
        {
            cmd.Dispose();
            cmd = null;
            conn.Close();
            conn = null;
            GC.Collect();
        }
    }
}
