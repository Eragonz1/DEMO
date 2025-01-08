using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DEMO
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text;
            string date = textBox2.Text;
            string name = textBox3.Text;
            string description = textBox4.Text;
            string priority = comboBox1.Text;
            string executor = textBox5.Text;
            string status = comboBox2.Text;
            using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=DEMO;User Id=postgres;Password=2005"))
            {
                try
                {
                    conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO \"tasks\" (number, date, name, description, priority, executor, status) VALUES (@number, @date, @name, @description, @priority, @executor, @status)", conn))
                {
                    cmd.Parameters.AddWithValue("number", number);
                    cmd.Parameters.AddWithValue("date", date);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("priority", priority);
                    cmd.Parameters.AddWithValue("executor", executor);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.ExecuteNonQuery();
                }
                    MessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
