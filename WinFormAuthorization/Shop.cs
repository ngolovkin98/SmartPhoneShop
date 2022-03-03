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
    public partial class Shop : Form
    {
       
        DataBase dataBase = new DataBase();
        Main main = new Main();
        public static double IphonePrice;
        public static double LGPrice;
        public static double SamsungPrice;


        public Shop()
        {
            InitializeComponent();
            dataBase.openConnection();

        }

        private void labelBuySamsung_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            SqlTransaction transaction = dataBase.getConnection().BeginTransaction();
            SqlCommand command = dataBase.getConnection().CreateCommand();
            command.Transaction = transaction;
            try
            {
                command.CommandText = $"UPDATE Registration SET Balance=Balance-'{SamsungPrice}', ItemsSamsung=ItemsSamsung+1 WHERE Id = '{AuthorizationForm.userId}';";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE StoreInformation SET Samsung_Count=Samsung_Count-1 WHERE Id = '{1}';";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE StoreInformation SET Store_Balance=Store_Balance+'{SamsungPrice}'  WHERE Id = '{1}';";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO TransactionInfo (UserId,TransactionTime,ProductName, ProductPrice) VALUES ('{AuthorizationForm.userId}','{DateTime.Now.ToString()}', 'Samsung','{SamsungPrice}'  )";
                command.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Покупка выполнена успешно!");
                updateInfo();


            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
                dataBase.closeConnection();
            }

        }

        private void labelBuyLG_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            SqlTransaction transaction = dataBase.getConnection().BeginTransaction();
            SqlCommand command = dataBase.getConnection().CreateCommand();
            command.Transaction = transaction;
            try
            {
                command.CommandText = $"UPDATE Registration SET Balance=Balance-'{LGPrice}', ItemsLG=ItemsLG+1 WHERE Id = '{AuthorizationForm.userId}';";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE StoreInformation SET LG_Count=LG_Count-1 WHERE Id = '{1}';";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE StoreInformation SET Store_Balance=Store_Balance+'{LGPrice}'  WHERE Id = '{1}';";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO TransactionInfo (UserId,TransactionTime,ProductName, ProductPrice) VALUES ('{AuthorizationForm.userId}','{DateTime.Now.ToString()}', 'LG','{LGPrice}'  )";
                command.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Покупка выполнена успешно!");
               
                updateInfo();
               
                dataBase.closeConnection();


            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
                dataBase.closeConnection();
            }
        }

        private void labelBuyIPhone_Click(object sender, EventArgs e)
        {

            dataBase.openConnection();
            SqlTransaction transaction = dataBase.getConnection().BeginTransaction();
            SqlCommand command = dataBase.getConnection().CreateCommand();
            command.Transaction = transaction;
            try
            {
                command.CommandText = $"UPDATE Registration SET Balance=Balance-'{IphonePrice}', ItemsIphone=ItemsIphone+1 WHERE Id = '{AuthorizationForm.userId}';";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE StoreInformation SET Iphone_Count=Iphone_Count-1 WHERE Id = '{1}';";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE StoreInformation SET Store_Balance=Store_Balance+'{IphonePrice}'  WHERE Id = '{1}';";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO TransactionInfo (UserId,TransactionTime,ProductName, ProductPrice) VALUES ('{AuthorizationForm.userId}','{DateTime.Now.ToString()}', 'Iphone','{IphonePrice}'  )";
                command.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Покупка выполнена успешно!");

                updateInfo();

                dataBase.closeConnection();


            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
                dataBase.closeConnection();
            }
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
            
            SqlCommand command = new SqlCommand(
            $"SELECT Iphone_Count FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Iphone_Count = command.ExecuteScalar().ToString();
            labelIPhone_Count.Text = Iphone_Count;
            SqlCommand command2 = new SqlCommand(
            $"SELECT LG_Count FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string LG_Count = command2.ExecuteScalar().ToString();
            labelLG_Count.Text = LG_Count;
            SqlCommand command3 = new SqlCommand(
            $"SELECT Samsung_Count FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Samsung_Count = command3.ExecuteScalar().ToString();
             labelSamsungCount.Text = Samsung_Count;
            SqlCommand command4 = new SqlCommand(
            $"SELECT Iphone_Price FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Iphone_Price = command4.ExecuteScalar().ToString();
            IphonePrice = double.Parse(Iphone_Price);
            labelIPhonePrice.Text = Iphone_Price;
            SqlCommand command5 = new SqlCommand(
            $"SELECT LG_Price FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string LG_Price = command5.ExecuteScalar().ToString();
            LGPrice = double.Parse(LG_Price);
            labelLGPrice.Text = LG_Price;
            SqlCommand command6 = new SqlCommand(
            $"SELECT Samsung_Price FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Samsung_Price = command6.ExecuteScalar().ToString();
            SamsungPrice = double.Parse(Samsung_Price);
            labelSamsungPrice.Text = Samsung_Price;




            dataBase.closeConnection();

        }

        private void buttonMoveBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Show();
        }
        public   void updateInfo ()
        {
            dataBase.openConnection();
            SqlCommand command = new SqlCommand(
            $"SELECT Iphone_Count FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Iphone_Count = command.ExecuteScalar().ToString();
            labelIPhone_Count.Text = Iphone_Count;
            SqlCommand command2 = new SqlCommand(
            $"SELECT LG_Count FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string LG_Count = command2.ExecuteScalar().ToString();
            labelLG_Count.Text = LG_Count;
            SqlCommand command3 = new SqlCommand(
            $"SELECT Samsung_Count FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Samsung_Count = command3.ExecuteScalar().ToString();
            labelSamsungCount.Text = Samsung_Count;
            SqlCommand command4 = new SqlCommand(
            $"SELECT Iphone_Price FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Iphone_Price = command4.ExecuteScalar().ToString();
            IphonePrice = double.Parse(Iphone_Price);
            labelIPhonePrice.Text = Iphone_Price;
            SqlCommand command5 = new SqlCommand(
            $"SELECT LG_Price FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string LG_Price = command5.ExecuteScalar().ToString();
            LGPrice = double.Parse(LG_Price);
            labelLGPrice.Text = LG_Price;
            SqlCommand command6 = new SqlCommand(
            $"SELECT Samsung_Price FROM StoreInformation  where Id = '{1}'", dataBase.getConnection());
            string Samsung_Price = command6.ExecuteScalar().ToString();
            SamsungPrice = double.Parse(Samsung_Price);
            labelSamsungPrice.Text = Samsung_Price;
            dataBase.closeConnection();
        }
    }
}
