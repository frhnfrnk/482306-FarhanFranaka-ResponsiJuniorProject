using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS.Class
{
    class Karyawan
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Departemen { get; set; }

        public static NpgsqlCommand cmd;
        private string sql = null;
        public DataTable dt;

        public Karyawan() { }

        public Karyawan(string id, string name, string departemen)
        {
            this.Id = id;
            this.Name = name;
            this.Departemen = departemen;
        }

        public void AddKaryawan(string nama, string department)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                dbConnection.OpenConnection();

                sql = @"select * from kar_insert(:_name, :_dep)";
                cmd = new NpgsqlCommand(sql, dbConnection.Connection);
                cmd.Parameters.AddWithValue("_name", nama);
                cmd.Parameters.AddWithValue("_dep", department);
                if((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Berhasil menambah karyawan", "Berhasil", MessageBoxButtons.OK);
                }
            }
            catch {
                MessageBox.Show("Gagal menambah karyawan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteKaryawan(string id)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                dbConnection.OpenConnection();

                sql = @"select * from kar_delete(:_id)";
                cmd = new NpgsqlCommand(sql, dbConnection.Connection);
                cmd.Parameters.AddWithValue("_id", id);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Berhasil menghapus karyawan", "Berhasil", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Gagal menghapus karyawan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateKaryawan(string id, string name, string department)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                dbConnection.OpenConnection();

                sql = @"select * from kar_update(:_id, :_name, :_dep)";
                cmd = new NpgsqlCommand(sql, dbConnection.Connection);
                cmd.Parameters.AddWithValue("_id", id);
                cmd.Parameters.AddWithValue("_name", name);
                cmd.Parameters.AddWithValue("_dep", department);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Berhasil mengubah karyawan", "Berhasil", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Gagal mengubah karyawan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetKaryawan()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            sql = "SELECT karyawan.nama, karyawan.id_karyawan, departemen.nama_dep, departemen.id_dep FROM karyawan JOIN departemen ON karyawan.id_dep = departemen.id_dep;";
            cmd = new NpgsqlCommand(sql, dbConnection.Connection);
            dt = new DataTable();
            NpgsqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            dbConnection.CloseConnection();
            return dt;
        }

    }
}
