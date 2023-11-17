using System.Windows;
using System.Windows.Input;


namespace BankProject {
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window {
        public string ConnectionString { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public WindowMain(string connectionString, ClassUserLogged userLogged) {
            InitializeComponent();
            ConnectionString = connectionString;
            MyUserLogged = userLogged;

            nameMenu.Text = $"{MyUserLogged.FirstName} {MyUserLogged.LastName}";
            nameCard.Text = $"{MyUserLogged.FirstName} {MyUserLogged.LastName}";
        }


        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
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


        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }


        private void ButtonManageUsers_Click(object sender, RoutedEventArgs e) {

        }


        private void ButtonLogout_Click(object sender, RoutedEventArgs e) {
            this.Close();
            this.Owner.Show();
        }

    }
}
