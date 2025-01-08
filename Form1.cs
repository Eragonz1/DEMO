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
    public partial class Form1 : Form
    {
        private readonly Database databaseManager;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=2005;Database=DEMO";
            databaseManager = new Database(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            string rol = databaseManager.ValidateUser(login, password);
            if (rol != null)
            {
                if (rol == "admin")
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else if (rol == "user")
                {
                    User user = new User();
                    user.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неизвестная роль пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
