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
    /// Interaction logic for UcMakeWithdraw.xaml
    /// </summary>
    public partial class UcMakeWithdraw : UserControl {

        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcMakeWithdraw(ClassController myController) {
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }


        private void ButtonMakeWithdraw_Click(object sender, RoutedEventArgs e) {
            int _accountId;
            float _amountToWithdraw;

            //Check that inputs are filled
            if( !(int.TryParse(myTextBoxAccountId.textBox.Text, out _accountId) && float.TryParse(myTextBoxAmountToWithdraw.textBox.Text, out _amountToWithdraw)) ) {
                MessageBox.Show($"[ERROR] Please verify that all fields have been correctly filled!");
                return;
            }


            if(MyController.MakeWithdraw(_accountId, _amountToWithdraw)) {
                MessageBox.Show($"[Withdraw Done] AccountId: {_accountId} | Amount Withdrawn: {_amountToWithdraw}");
            }
            else {
                MessageBox.Show($"[ERROR] There was a problem making the withdraw transaction...");
            }

        }
    }
}
