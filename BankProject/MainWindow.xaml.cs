﻿using System;
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
        Login myLogin;

        public MainWindow()
        {
            InitializeComponent();
            
            //Initialize program with Login page
            this.Show();
            myLogin = Login.GetInstance;
            myLogin.Owner = this;
            this.Hide();
            
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
