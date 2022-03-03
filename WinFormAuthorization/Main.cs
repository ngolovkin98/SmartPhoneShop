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
    public partial class Main : Form
    {
        
        
        DataBase dataBase = new DataBase();
        public static double userBalance; 
        public Main()
        {

            InitializeComponent();
          

        }

        private void buttonMoveBack_Click(object sender, EventArgs e)
        {
            AuthorizationForm auth = new AuthorizationForm();
            this.Hide();
            auth.ShowDialog();
            this.Show();
            
        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
           SqlCommand command = new SqlCommand(
           $"SELECT user_login FROM Registration  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
           string userLogin = command.ExecuteScalar().ToString();
            labelLogin.Text= userLogin;
           
            SqlCommand command2 = new SqlCommand(
          $"SELECT Balance FROM Registration  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
            string balance = command2.ExecuteScalar().ToString();
            labelBalance.Text = balance;

            SqlCommand command3 = new SqlCommand(
          $"SELECT ItemsIphone FROM Registration  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
            string ItemsIphone = command3.ExecuteScalar().ToString();
            labelIPhoneCount.Text = ItemsIphone;
            
            SqlCommand command4 = new SqlCommand(
         $"SELECT ItemsSamsung FROM Registration  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
            string ItemsSamsung = command4.ExecuteScalar().ToString();
            labelSamsungCount.Text = ItemsSamsung;
            
            SqlCommand command5 = new SqlCommand(
         $"SELECT ItemsLG FROM Registration  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
            string ItemsLG = command5.ExecuteScalar().ToString();
            labelLGCount.Text = ItemsLG;




            dataBase.closeConnection();
           
           
        }

        private void balanceUpdateBtn_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            dataBase.openConnection();
           
            double updateBalance = double.Parse(textBoxUpdateBalance.Text);
           
            
            SqlCommand command = new SqlCommand(
          $"UPDATE Registration SET Balance=Balance+'{updateBalance}'  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Баланс успешно пополнен!", "Успех!");
            SqlCommand command2 = new SqlCommand(
         $"SELECT Balance FROM Registration  where Id = '{AuthorizationForm.userId}'", dataBase.getConnection());
            string balance = command2.ExecuteScalar().ToString();
            labelBalance.Text = balance;
            userBalance = double.Parse(balance);

            dataBase.closeConnection();

        }

        private void labelGoToShop_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            this.Hide();
            shop.ShowDialog();
            this.Show();
        }
       
    }
}
