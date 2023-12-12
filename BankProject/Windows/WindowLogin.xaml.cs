using System;
using System.IO;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Diagnostics;
using BankProject.Classes;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window {

        private ClassCustomSqlClient MySqlClient { get; set; }
        private ClassController MyController { get; set; }
        private WindowRegister? MyWindowRegister { get; set; }
        private WindowFrame? MyWindowFrame { get; set; }


        public WindowLogin() {

            InitializeComponent();

            //Initialize Objects
            MyController = new ClassController();
            MySqlClient = new ClassCustomSqlClient();
            //Initialize Windows
            MyWindowRegister = null;
            MyWindowFrame = null;
        }


        private void LoginScreen_Loaded(object sender, RoutedEventArgs e) {
            //Reset Objects
            MyController.MyUserLogged = null;
            //Reset Windows
            MyWindowRegister = null;
            MyWindowFrame = null;
            textBoxEmail.Focus();
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
            
            string _emailToAuthenticate = textBoxEmail.Text;
            string _passwordToAuthenticate = textBoxPassword.Password;

            //Try to login
            MyController.MyUserLogged = MySqlClient.AuthenticateLogin(_emailToAuthenticate, _passwordToAuthenticate);

            //Clear TextBoxes
            textBoxEmail.Text = string.Empty;
            textBoxPassword.Password = string.Empty;

            if (MyController.MyUserLogged != null) {
                //Switch windows
                MyWindowFrame = new WindowFrame(MyController);
                MyWindowFrame.Owner = this;
                LoginScreen.Hide();
                MyWindowFrame.Show();
            }
        }


        private void TextEmail_MouseDown(object sender, MouseButtonEventArgs e) {
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
            MyWindowRegister = new WindowRegister();
            MyWindowRegister.Owner = this;
            this.Hide();
            MyWindowRegister.Show();
        }


    }
}
