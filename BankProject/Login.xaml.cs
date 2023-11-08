﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string userLogged = null;
        private static Login instance = null;
        public static Login Instance {
            get {
                if (instance == null) {
                    instance = new Login();
                }
                else
                {
                instance.ShowDialog();
                   

                }
                return instance;
            }
        }
        private Login()
        {
            InitializeComponent();
            Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserIDLoginBox.Focus();

            //string connetionString = "Server=localhost/SQLE; Database= bankproject;User Id=test;Password=123;";
            var connetionString = "Server=tcp:137.186.165.104,49172; Database= bankproject;User Id=test;Password=123;";
            SqlConnection cnn = new SqlConnection(connetionString) ;
            try
            {
                cnn.Open();
                string selectquery = "SELECT[employeeID],[password], [firstName] ,[lastName] FROM[bankproject].[dbo].[Employees] WHERE [employeeID] = " + UserIDLoginBox.Text + " AND [password] = '" + PasswordLoginBox.Password + "'";
                SqlCommand cmd = new SqlCommand(selectquery, cnn);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();

                if (reader1.Read())
                {
                    MessageBox.Show("Login Sucessful");
                    LoginScreen.Hide();
                    userLogged = reader1.GetValue(2).ToString() + " " + reader1.GetValue(3).ToString();

                    //foreach (Window window in Application.Current.Windows)
                    //{
                    //    if (window.GetType() == typeof(MainWindow))
                    //    {
                    //        (window as MainWindow).StatusTextBox.Text = userLogged;
                    //    }
                    //}
                    MainWindow.UpdateStatus(userLogged);

                }
                else
                {
                    MessageBox.Show("Incorrect Credentials");
                }

               
            UserIDLoginBox.Text = string.Empty;
            PasswordLoginBox.Password = string.Empty;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            
                    MessageBox.Show(ex.Message);
            }
        }
    }
}
