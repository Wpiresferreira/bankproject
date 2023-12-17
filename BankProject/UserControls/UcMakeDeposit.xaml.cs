using BankProject.Classes;
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

        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcMakeDeposit(ClassController myController) {
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }

        private void ButtonMakeDeposit_Click(object sender, RoutedEventArgs e) {

            int _accountId;
            float _amountToDeposit;

            //Check that inputs are filled
            if( !(int.TryParse(myTextBoxAccountId.textBox.Text, out _accountId) && float.TryParse(myTextBoxAmountToDeposit.textBox.Text, out _amountToDeposit)) ) {
                MessageBox.Show($"[ERROR] Please verify that all fields have been correctly filled!");
                return;
            }

            if(MyController.MakeDeposit(_accountId, _amountToDeposit)) {
                MessageBox.Show($"[Deposit Done] AccountId: {_accountId} | Amount Deposited: {_amountToDeposit}");
            }
            else {
                MessageBox.Show($"[ERROR] There was a problem making the deposit transaction...");
            }

        }
    }
}
