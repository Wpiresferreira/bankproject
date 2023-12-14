﻿using BankProject.Classes;
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

namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcMakeDeposit.xaml
    /// </summary>
    public partial class UcMakeDeposit : UserControl {

        ClassCustomSqlClient MySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcMakeDeposit(ClassController myController) {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;

            InitializeComponent();
        }

        private void ButtonMakeDeposit_Click(object sender, RoutedEventArgs e) {
            int _accountId = int.Parse(myTextBoxAccountId.textBox.Text);
            float _amountToDeposit = float.Parse(myTextBoxAmountToDeposit.textBox.Text);

            //Check that inputs are filled
            if(_accountId==null || _amountToDeposit==null) {
                MessageBox.Show($"[ERROR] Please verify that all fields have been filled!");
                return;
            }

            if(MyController.MakeDeposit(_accountId, _amountToDeposit)) {
                MessageBox.Show($"[Deposit Done] AccountId: {_accountId} | Amount Deposited: {_amountToDeposit}");
            }
            else {
                MessageBox.Show($"[ERROR] There was a problem making ...");
            }

        }
    }
}
