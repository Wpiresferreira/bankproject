using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        internal static void UpdateStatus(string userLogged)
        {

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).StatusTextBox.Text = "User Logged: " + userLogged;
                }
            }
            //StatusTextBox.Text = userLogged;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Instance;
        }

        private void ManageUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            Login login = Login.Instance;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login login = Login.Instance;
        }
    }
}
