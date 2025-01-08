using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DEMO
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNumberZakaz_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSMS_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string number = textBoxNumberZakaz.Text;
            string sms = textBoxSMS.Text;
            string recipientEmail = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(recipientEmail) || !IsValidEmail(recipientEmail))
            {
                MessageBox.Show("Пожалуйста, введите корректный адрес электронной почты.");
                return;
            }

            string subject = "Изменение заказа";
            string body = $"Вопрос по заказу {number} \nCообщение:{sms}  \nОтправитель: {recipientEmail}";

            try
            {
                SendEmail(recipientEmail, subject, body);

                string adminEmail = "dzolotarev@cchgeu.ru"; 
                SendEmail(adminEmail, subject, body);

                MessageBox.Show("Email отправлен успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке: {ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void SendEmail(string recipientEmail, string subject, string body)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
