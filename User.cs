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

namespace DEMO
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=DEMO;User Id=postgres;Password=2005");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text; comm.CommandText = " SELECT date, name, description, status FROM \"tasks\"";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr); dataGridView1.DataSource = dt;
            }
            comm.Dispose(); conn.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
