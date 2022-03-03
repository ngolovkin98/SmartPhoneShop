using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SmartPhoneShop
{
    public partial class Registration : Form
    {
        
        DataBase db = new DataBase();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            textBoxPass.PasswordChar = '⚫';
            textBoxLogin.MaxLength = 50;
            textBoxPass.MaxLength = 50;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {

            var login = textBoxLogin.Text;
            var password = textBoxPass.Text;

            string querystring = $"insert into Registration (user_login, user_password) values  ('{login}','{password}')";

            SqlCommand command = new SqlCommand(querystring, db.getConnection());
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                AuthorizationForm auth = new AuthorizationForm();
                this.Hide();
                auth.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан!", "Ошибка!");
            }
            db.closeConnection();


        }

        private Boolean checkUser()
        {
            var loginUser = textBoxLogin.Text;
            var passUser = textBoxPass.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"select *  from Registration where user_login = '{loginUser}' and user_password = '{passUser}'";
            SqlCommand command = new SqlCommand(queryString, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!", "Ошибка!");
                return true;
            }
            else return false;
        }

        private void labelMoveBack_Click(object sender, EventArgs e)
        {
            AuthorizationForm auth = new AuthorizationForm();
            this.Hide();
            auth.Show();
        }
    }
}
