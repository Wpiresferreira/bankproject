using System;
using System.Windows;
using System.Windows.Input;


namespace BankProject {
    /// <summary>
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window {

        public string ConnectionString { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public WindowAdmin(string connectionString, ClassUserLogged userLogged) {
            InitializeComponent();
            ConnectionString = connectionString;
            MyUserLogged = userLogged;

            nameMenu.Text = $"{MyUserLogged.FirstName} {MyUserLogged.LastName}";
            nameHeader.Text = $"Good Afternoon, {MyUserLogged.FirstName}";
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


        private void ButtonLogout_Click(object sender, RoutedEventArgs e) {
            this.Close();
            this.Owner.Show();
        }
    }
}
