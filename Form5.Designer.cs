namespace DEMO
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSMS = new System.Windows.Forms.TextBox();
            this.textBoxNumberZakaz = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Обращение";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номер заказа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // textBoxSMS
            // 
            this.textBoxSMS.Location = new System.Drawing.Point(114, 305);
            this.textBoxSMS.Multiline = true;
            this.textBoxSMS.Name = "textBoxSMS";
            this.textBoxSMS.Size = new System.Drawing.Size(192, 70);
            this.textBoxSMS.TabIndex = 3;
            this.textBoxSMS.TextChanged += new System.EventHandler(this.textBoxSMS_TextChanged);
            // 
            // textBoxNumberZakaz
            // 
            this.textBoxNumberZakaz.Location = new System.Drawing.Point(114, 137);
            this.textBoxNumberZakaz.Name = "textBoxNumberZakaz";
            this.textBoxNumberZakaz.Size = new System.Drawing.Size(192, 22);
            this.textBoxNumberZakaz.TabIndex = 4;
            this.textBoxNumberZakaz.TextChanged += new System.EventHandler(this.textBoxNumberZakaz_TextChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(114, 222);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(193, 22);
            this.textBoxEmail.TabIndex = 5;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(400, 205);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(183, 39);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "Отправить обращение";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(711, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNumberZakaz);
            this.Controls.Add(this.textBoxSMS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSMS;
        private System.Windows.Forms.TextBox textBoxNumberZakaz;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button button2;
    }
}