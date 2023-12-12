using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Class
{
    public class DatabaseConnection
    {
        private NpgsqlConnection connection;
        private string connectionString;

        public DatabaseConnection()
        {
            // Atur properti koneksi
            connectionString = "Host=localhost;Port=5432;Database=hr_uas;Username=postgres;Password=informatika";
            connection = new NpgsqlConnection(connectionString);
        }

        public NpgsqlConnection Connection
        {
            get { return connection; }
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
