﻿using System;
using System.IO;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Input;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {

        public string? userLogged = null;
        private static Login? instance = null;
        
        public static Login GetInstance {
            get {
                if (instance == null) {
                    instance = new Login();
                }
                else {
                instance.ShowDialog();
                }

                return instance;
            }
        }


        private Login() {
            InitializeComponent();
            Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e) {

            if( !string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPassword.Password) ) {
                
            }

            //Build Connection String
            string connetionString;
            bool connectToLocalDatabase = true;                                                                                     //Set to false to connect to remote database
            if (connectToLocalDatabase) {
                //string connetionString = "Server=MSI\\SQLEXPRESS; Database= bankproject;User Id=test;Password=123;";              //Old Connection String (DELETE)
                string path_RootFolder = $"{Directory.GetParent(System.IO.Directory.GetCurrentDirectory())?.Parent?.Parent}";
                //Debug.WriteLine(path_RootFolder);                                                                                 //DEBUG (DELETE)
                connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB; ";
                connetionString  += $"AttachDbFilename={path_RootFolder}\\bankproject.mdf; ";
                connetionString  += "Integrated Security=True; ";
            }
            else {
                connetionString = "Server=tcp:137.186.165.104,49172; ";
                connetionString += "Database=bankproject; ";
                connetionString += "User Id=test; ";
                connetionString += "Password=123; ";
            }

            //Build Select Query
            string selectquery = "SELECT employeeID, password, firstName , lastName ";
            selectquery += "FROM dbo.Employees ";
            selectquery += $"WHERE email = '{textBoxEmail.Text}' AND password = '{textBoxPassword.Password}'; ";

            try {
                using (SqlConnection cnn = new SqlConnection(connetionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectquery, cnn)) {
                        cnn.Open();
                        using (SqlDataReader reader1 = cmd.ExecuteReader()) {
                            if (reader1.Read()) {
                                MessageBox.Show("Login Sucessful");
                                LoginScreen.Hide();
                                userLogged = $"{reader1.GetValue(2)} {reader1.GetValue(3)}";

                                ((MainWindow)this.Owner).StatusTextBox.Text = $"User Logged: {userLogged}";
                                ((MainWindow)this.Owner).Show();
                            }
                            else {
                                MessageBox.Show("Incorrect Credentials");
                            }

                            textBoxEmail.Text = string.Empty;
                            textBoxPassword.Password = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Cannot open connection!\n{ex.Message}");
            }
        }


        private void textEmail_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            textBoxEmail.Focus();
        }


        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            if( !string.IsNullOrEmpty(textBoxEmail.Text) && textBoxEmail.Text.Length>0 ) {
                textBlockEmail.Visibility = Visibility.Collapsed;
            }
            else {
                textBlockEmail.Visibility = Visibility.Visible;
            }
        }


        private void textPassword_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            textBoxPassword.Focus();
        }


        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) {
            if( !string.IsNullOrEmpty(textBoxPassword.Password) && textBoxPassword.Password.Length>0 ) {
                textBlockPassword.Visibility = Visibility.Collapsed;
            }
            else {
                textBlockPassword.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if(e.ChangedButton==MouseButton.Left) {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
