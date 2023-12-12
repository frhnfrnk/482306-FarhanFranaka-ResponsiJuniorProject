using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAS.Class;

namespace UAS
{
    public partial class Form1 : Form
    {
        private string sql = null;
        public static NpgsqlCommand cmd;
        public DataTable dt;
        private DataGridViewRow r;
        public string idKaryawan;

        public Form1()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("HR");
            list.Add("DEV");
            list.Add("ENG");
            list.Add("PM");
            list.Add("FIN");

            foreach (string s in list)
            {
                tbDep.AutoCompleteCustomSource.Add(s);
                tbDep.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tbDep.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }


            dgvData.DataSource = null;
            dt = new DataTable();
            Karyawan karyawan = new Karyawan();
            dt = karyawan.GetKaryawan();
            dgvData.DataSource = dt;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.AddKaryawan(tbNama.Text, tbDep.Text);
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            dgvData.DataSource = null;
            dt = new DataTable();
            Karyawan karyawan2 = new Karyawan();
            dt = karyawan2.GetKaryawan();
            dgvData.DataSource = dt;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dgvData.Rows[e.RowIndex];
                idKaryawan = r.Cells["id_karyawan"].Value.ToString();
                tbNama.Text = r.Cells["nama"].Value.ToString();
                tbDep.Text = r.Cells["id_dep"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.UpdateKaryawan(idKaryawan, tbNama.Text, tbDep.Text);

            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.OpenConnection();

            dgvData.DataSource = null;
            dt = new DataTable();
            Karyawan karyawan2 = new Karyawan();
            dt = karyawan2.GetKaryawan();
            dgvData.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.DeleteKaryawan(idKaryawan);

            dgvData.DataSource = null;
            dt = new DataTable();
            Karyawan karyawan2 = new Karyawan();
            dt = karyawan2.GetKaryawan();
            dgvData.DataSource = dt;
        }
    }
}
