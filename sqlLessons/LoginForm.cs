using MySql.Data.MySqlClient;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            PassFill.AutoSize = false;
            PassFill.Size = new Size(PassFill.Size.Width, LoginFill.Size.Height);

            LoginFill.Text = "Введите логин";
            LoginFill.ForeColor = Color.Gray;

            PassFill.Text = "Введите пароль";
            PassFill.ForeColor = Color.Gray;
            PassFill.UseSystemPasswordChar = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = LoginFill.Text;
            String passUser = PassFill.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand comm = new MySqlCommand("SELECT * FROM users where Login = @UL and Password = @UP", db.getConn());

            comm.Parameters.Add("@UL", MySqlDbType.VarChar).Value = loginUser;
            comm.Parameters.Add("@UP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = comm;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Hide();
                MainForm MF = new MainForm();
                MF.Show();
            }
            else
                MessageBox.Show("Авторизация не выполнена");

        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            Hide();

            RegisterForm RG = new RegisterForm();
            RG.Show();
        }

        private void RegisterLabel_MouseEnter(object sender, EventArgs e)
        {
            RegisterLabel.ForeColor = Color.Blue;
        }

        private void RegisterLabel_MouseLeave(object sender, EventArgs e)
        {
            RegisterLabel.ForeColor = Color.Black;
        }

        private void LoginFill_Enter(object sender, EventArgs e)
        {
            if (LoginFill.Text == "Введите логин")
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
