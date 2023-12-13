﻿using BankProject.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcCustomerSearch.xaml
    /// </summary>
    public partial class UcCustomerSearch : UserControl {

        private ClassCustomSqlClient MySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcCustomerSearch(ClassController myController) {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }


        private void ButtonSearch_Click(object sender, RoutedEventArgs e) {
            string _customerId = myTextBoxCustomerID.textBox.Text;
            string _firstName = myTextBoxFirstName.textBox.Text;
            string _lastName = myTextBoxLastName.textBox.Text;
            string _dateOfBirth = myTextBoxDataOfBirth.textBox.Text;
            string _dateOfBirthFormatted;
            if (_dateOfBirth != "") {
                _dateOfBirthFormatted =$"{_dateOfBirth.Substring(6, 4)}-{_dateOfBirth.Substring(3,2)}-{_dateOfBirth.Substring(0,2)}";
            }
            else {
                _dateOfBirthFormatted = "";
            }

            ClassCustomer foundCustomer = MySqlClient.SearchCustomer(_customerId, _firstName, _lastName, _dateOfBirthFormatted);
            if(foundCustomer != null) {
                MessageBox.Show($"{foundCustomer}");
            }
            else {
                MessageBox.Show($"[ERROR] Customer not found!");
            }
        }


        private void ButtonNew_Click(object sender, RoutedEventArgs e) {

        }

        private void myTextBoxCustomerID_KeyDown(object sender, KeyEventArgs e) {
            if(e.Key == Key.Enter) {
                ButtonSearch_Click(sender, e);
            }
        }

        private void myTextBoxFirstName_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                myTextBoxLastName.Focus();
            }
        }

        private void myTextBoxLastName_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                myTextBoxDataOfBirth.Focus();
            }
            MessageBox.Show(e.Key.ToString());
        }

        private void myTextBoxDataOfBirth_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                ButtonSearch_Click(sender, e);
            }
        }
    }
}
