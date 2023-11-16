using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Input;


namespace BankProject {
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window {

        public string ConnectionString {  get; set; }


        public WindowRegister(string connectionString) {
            InitializeComponent();
            ConnectionString = connectionString;
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
            //Build Select Query
            string inputFirstName = myTextBoxFirstName.textBox.Text;
            string inputLastName = myTextBoxLastName.textBox.Text;
            string inputEmail = myTextBoxEmail.textBox.Text;
            string inputPhone = myTextBoxPhone.textBox.Text;
            string inputPositionId = "3";
            string inputPassword = myTextBoxPassword.textBox.Text;

            string insertQuery = "INSERT INTO dbo.Employees (firstName, lastName, email, phone, positionId, password) ";
            insertQuery += $"VALUES ('{inputFirstName}', '{inputLastName}', '{inputEmail}', '{inputPhone}', {inputPositionId}, '{inputPassword}'); ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn)) {
                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        //Switch windows
                        this.Close();
                        this.Owner.Show();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Cannot open connection!\n{ex.Message}");
            }
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
            //Switch windows
            this.Hide();
            this.Owner.Show();
        }
    }
}
