using System.Windows;


namespace BankProject
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public string ConnectionString { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public WindowMain(string connectionString, ClassUserLogged userLogged)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            MyUserLogged = userLogged;
        }


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ManageUsersBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
