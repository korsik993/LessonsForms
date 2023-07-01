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
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

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
                MessageBox.Show("Авторизация выполнена");
            else
                MessageBox.Show("Авторизация не выполнена");

        }
    }
}
