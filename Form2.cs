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
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;
using System.Net.Mail;
using System.Net;

namespace DEMO
{
    public partial class Form2 : Form
    {

        private int selectedRowId = -1;
        public Form2()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=DEMO;User Id=postgres;Password=2005");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text; comm.CommandText = " SELECT * FROM \"tasks\"";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr); dataGridView1.DataSource = dt;
            }
            comm.Dispose(); conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("daniilzoloto2005@yandex.ru", "Даниил");
                const string fromPassword = "xovsavhaizyrwllg";

                var smtp = new SmtpClient
                {
                    Host = "smtp.yandex.ru",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress.Address, recipientEmail)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                MessageBox.Show("Email отправлен успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке: {ex.Message}");
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text;
            string description = textBox4.Text;
            string priority = comboBox1.Text;
            string executor = textBox5.Text;
            string status = comboBox2.Text;
            using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=DEMO;User Id=postgres;Password=2005"))
            {
                conn.Open(); using (var cmd = new NpgsqlCommand("UPDATE \"tasks\" SET description = @description, priority = @priority, executor = @executor, status = @status WHERE number = @number", conn))
                {
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("priority", priority);
                    cmd.Parameters.AddWithValue("executor", executor);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.Parameters.AddWithValue("number", number);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadData();
            MessageBox.Show("Данные успешно обновлены!");
            // Отправка email после успешного обновления данных
            string recipientEmail = "dzolotarev@cchgeu.ru";
            string subject = "Изменение заказа";
            string body = $"Заказ с номером {number} был изменен. Новые данные:\nОписание: {description}\nПриоритет: {priority}\nИсполнитель: {executor}\nСтатус: {status}";
            SendEmail(recipientEmail, subject, body);
        }


        private void LoadData()
        {
            string query = "SELECT * FROM \"tasks\" WHERE 1=1";

            if (!string.IsNullOrEmpty(textBoxSearch.Text))
            {
                query += " AND (number = @number OR description LIKE @keywords)";
            }

            if (!string.IsNullOrEmpty(comboBoxStatus.Text))
            {
                query += " AND status = @status";
            }

            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                query += " AND priority = @priority";
            }

            if (!string.IsNullOrEmpty(textBoxExecutor.Text))
            {
                query += " AND executor = @executor";
            }

            using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=DEMO;User Id=postgres;Password=2005"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(textBoxSearch.Text))
                    {
                        cmd.Parameters.AddWithValue("number", textBoxSearch.Text);
                        cmd.Parameters.AddWithValue("keywords", "%" + textBoxSearch.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(comboBoxStatus.Text))
                    {
                        cmd.Parameters.AddWithValue("status", comboBoxStatus.Text);
                    }

                    if (!string.IsNullOrEmpty(comboBox3.Text))
                    {
                        cmd.Parameters.AddWithValue("priority", comboBox3.Text);
                    }

                    if (!string.IsNullOrEmpty(textBoxExecutor.Text))
                    {
                        cmd.Parameters.AddWithValue("executor", textBoxExecutor.Text);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string number = selectedRow.Cells["number"].Value.ToString(); // Преобразование значения в строку

                using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=DEMO;User Id=postgres;Password=2005"))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM \"tasks\" WHERE number = @number", conn))
                    {
                        cmd.Parameters.AddWithValue("number", number);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Задача успешно удалена!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления.");
            }
        }
    }
}
