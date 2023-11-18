using System;
using System.IO;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Diagnostics;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window {

        private bool ConnectToLocalDatabase {  get; set; }
        private string ConnectionString {  get; set; }
        public ClassUserLogged? MyUserLogged {  get; set; }
        private WindowRegister? MyWindowRegister { get; set; }
        private WindowFrame? MyWindowFrame { get; set; }


        public WindowLogin() {
            InitializeComponent();
            ConnectToLocalDatabase = true;                        //Set to false to connect to remote database
            MyUserLogged = null;
            MyWindowRegister = null;
            MyWindowFrame = null;


            //Build Connection String
            if (ConnectToLocalDatabase) {
                //string connetionString = "Server=MSI\\SQLEXPRESS; Database= bankproject;User Id=test;Password=123;";              //Old Connection String (DELETE)
                string path_RootFolder = $"{Directory.GetParent(System.IO.Directory.GetCurrentDirectory())?.Parent?.Parent}";
                //Debug.WriteLine(path_RootFolder);                                                                                 //DEBUG (DELETE)
                ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; ";
                ConnectionString  += $"AttachDbFilename={path_RootFolder}\\bankproject.mdf; ";
                ConnectionString  += "Integrated Security=True; ";
            }
            else {
                ConnectionString = "Server=tcp:137.186.165.104,49172; ";
                ConnectionString += "Database=bankproject; ";
                ConnectionString += "User Id=test; ";
                ConnectionString += "Password=123; ";
            }

        }


        private void LoginScreen_Loaded(object sender, RoutedEventArgs e) {
            MyUserLogged = null;
            MyWindowRegister = null;
            MyWindowFrame = null;
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.ChangedButton==MouseButton.Left) {
                this.DragMove();
            }
        }


        private void ImageMinimize_MouseUp(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }


        private void ImageClose_MouseUp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }


        private void ButtonSignIn_Click(object sender, RoutedEventArgs e) {
            
            //Build Select Query
            string selectQuery = "SELECT employeeID, firstName , lastName, email, positionId ";
            selectQuery += "FROM dbo.Employees ";
            selectQuery += $"WHERE email = '{textBoxEmail.Text}' AND password = '{textBoxPassword.Password}'; ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        using (SqlDataReader myReader = cmd.ExecuteReader()) {
                            if (myReader.Read()) {

                                //Create MyUserLogged Object
                                MyUserLogged = new ClassUserLogged((int)myReader[0], (string)myReader[1], (string)myReader[2], (string)myReader[3], (int)myReader[4]);
                                Debug.WriteLine($"Login Sucessful\nLogged in as: {MyUserLogged.FirstName} {MyUserLogged.LastName}");

                                ////Switch windows
                                //MyWindowMain = new WindowMain(ConnectionString, MyUserLogged);
                                //MyWindowMain.Owner = this;
                                //LoginScreen.Hide();
                                //MyWindowMain.Show();

                                //Switch windows
                                MyWindowFrame = new WindowFrame(ConnectionString, MyUserLogged);
                                MyWindowFrame.Owner = this;
                                LoginScreen.Hide();
                                MyWindowFrame.Show();
                            }
                            else {
                                MessageBox.Show("Incorrect Credentials!");
                            }

                            textBoxEmail.Text = string.Empty;
                            textBoxPassword.Password = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
            }
        }


        private void TextEmail_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            textBoxEmail.Focus();
        }


        private void TxtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            if( !string.IsNullOrEmpty(textBoxEmail.Text) && textBoxEmail.Text.Length>0 ) {
                textBlockEmail.Visibility = Visibility.Collapsed;
            }
            else {
                textBlockEmail.Visibility = Visibility.Visible;
            }
        }


        private void TextPassword_MouseDown(object sender, MouseButtonEventArgs e) {
            textBoxPassword.Focus();
        }


        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e) {
            if( !string.IsNullOrEmpty(textBoxPassword.Password) && textBoxPassword.Password.Length>0 ) {
                textBlockPassword.Visibility = Visibility.Collapsed;
            }
            else {
                textBlockPassword.Visibility = Visibility.Visible;
            }
        }


        private void ButtonRegister_Click(object sender, RoutedEventArgs e) {
            //Switch windows
            MyWindowRegister = new WindowRegister(ConnectionString);
            MyWindowRegister.Owner = this;
            this.Hide();
            MyWindowRegister.Show();
        }


    }
}
