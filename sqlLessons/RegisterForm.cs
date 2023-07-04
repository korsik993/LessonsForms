using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlLessons
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            PassFill.AutoSize = false;
            PassFill.Size = new Size(PassFill.Size.Width, LoginFill.Size.Height);

            UserName.Text = "Введите имя";
            UserName.ForeColor = Color.Gray;

            UserSurname.Text = "Введите фамилию";
            UserSurname.ForeColor = Color.Gray;

            LoginFill.Text = "Введите логин";
            LoginFill.ForeColor = Color.Gray;

            PassFill.Text = "Введите пароль";
            PassFill.ForeColor = Color.Gray;
            PassFill.UseSystemPasswordChar = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        Point lastPoint;

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void UserName_Enter(object sender, EventArgs e)
        {
            if (UserName.Text == "Введите имя")
            {
                UserName.Text = "";
                UserName.ForeColor = Color.Black;
            }
        }

        private void UserName_Leave(object sender, EventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = "Введите имя";
                UserName.ForeColor = Color.Gray;
            }
        }

        private void UserSurname_Enter(object sender, EventArgs e)
        {
            if (UserSurname.Text == "Введите фамилию")
            {
                UserSurname.Text = "";
                UserSurname.ForeColor = Color.Black;
            }
        }

        private void UserSurname_Leave(object sender, EventArgs e)
        {
            if (UserSurname.Text == "")
            {
                UserSurname.Text = "Введите фамилию";
                UserSurname.ForeColor= Color.Gray;
            }
        }

        private void LoginFill_Enter(object sender, EventArgs e)
        {
            if (LoginFill.Text == "Введите логин") ;
            {
                LoginFill.Text = "";
                LoginFill.ForeColor = Color.Black;
            }
        }

        private void LoginFill_Leave(object sender, EventArgs e)
        {
            if (LoginFill.Text == "")
            {
                LoginFill.Text = "Введите логин";
                LoginFill.ForeColor = Color.Gray;
            }
        }

        private void PassFill_Enter(object sender, EventArgs e)
        {
            if (PassFill.Text == "Введите пароль")
            {
                PassFill.UseSystemPasswordChar = true;
                PassFill.Text = "";
                PassFill.ForeColor = Color.Black;
            }
        }

        private void PassFill_Leave(object sender, EventArgs e)
        {
            if (PassFill.Text == "")
            {
                PassFill.UseSystemPasswordChar = false;
                PassFill.Text = "Введите пароль";
                PassFill.ForeColor = Color.Gray;
            }
        }
    }
}
