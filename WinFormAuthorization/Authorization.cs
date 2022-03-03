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
    public partial class AuthorizationForm : Form
    {
        DataBase dataBase = new DataBase();
        public static int userId;
        public AuthorizationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            textBoxPass.PasswordChar = '⚫';
            textBoxLogin.MaxLength = 50;
            textBoxPass.MaxLength = 50;
            
        }

        public void buttonLogin_Click(object sender, EventArgs e)
        {
            var userLogin = textBoxLogin.Text;
            var userPass = textBoxPass.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select Id, user_login, user_password from Registration where user_login = '{userLogin}' and user_password = '{userPass}' ";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                
                dataBase.openConnection();
                MessageBox.Show("Вы успешно авторизовались!", "Успех!");
                
                SqlCommand command2 = new SqlCommand(
             $"SELECT Id FROM Registration  where user_login = '{userLogin}' and user_password = '{userPass}'", dataBase.getConnection());
                string execute = command2.ExecuteScalar().ToString();
                int currentUserId = Int32.Parse(execute);
                userId = currentUserId;
                Main mainForm = new Main();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
                dataBase.closeConnection();



            }
            else 
            MessageBox.Show("Такого аккаунта не существует. Проверьте данные или зарегистрируйтесь.", "Ошибка!");
            
        
        }

        private void labelRegistration_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }
       
       
       
        
       
    }
}

