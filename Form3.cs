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

namespace DEMO
{
    public partial class Form3 : Form
    {
        private readonly Database databaseManager;
        public Form3()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=2005;Database=DEMO";
            databaseManager = new Database(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPass.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (databaseManager.RegisterUser(login, password))
            {
                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User user = new User();
                user.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
