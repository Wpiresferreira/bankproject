using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Input;
using BankProject.Classes;

namespace BankProject {
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window {

        private ClassCustomSqlClient MySqlClient {  get; set; }


        public WindowRegister() {
            InitializeComponent();
            MySqlClient = new ClassCustomSqlClient();
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.ChangedButton==MouseButton.Left) {
                this.DragMove();
            }
        }


        private void ImageClose_MouseUp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }


        private void ImageMinimize_MouseUp(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e) {
            this.Hide();
            this.Owner.Show();
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e) {
            //Build Insert Query
            string inputFirstName = myTextBoxFirstName.textBox.Text;
            string inputLastName = myTextBoxLastName.textBox.Text;
            string inputEmail = myTextBoxEmail.textBox.Text;
            string inputPhone = myTextBoxPhone.textBox.Text;
            string inputPositionId = "3";
            string inputPassword = myTextBoxPassword.Password;

            string insertQuery = "INSERT INTO dbo.Employees (firstName, lastName, email, phone, positionId, password) ";
            insertQuery += $"VALUES ('{inputFirstName}', '{inputLastName}', '{inputEmail}', '{inputPhone}', {inputPositionId}, '{inputPassword}'); ";

            if(MySqlClient.CreateNewEmployee(insertQuery)) {
                MessageBox.Show($"[New User Added] New User {inputFirstName} {inputLastName} was registered!");
                
                //Switch windows
                this.Close();
                this.Owner.Show();
            }
            else {
                MessageBox.Show($"[ERROR] Something went wrong...");
            }


        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
            //Switch windows
            this.Hide();
            this.Owner.Show();
        }
    }
}
