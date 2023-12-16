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
    /// Interaction logic for UcMakeTransfer.xaml
    /// </summary>
    public partial class UcMakeTransfer : UserControl {

        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcMakeTransfer(ClassController myController) {
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }


        private void ButtonMakeTransfer_Click(object sender, RoutedEventArgs e) {

            int _accountId;
            int _otherAccountId;
            float _amountToTransfer;

            //Check that inputs are filled
            if( !(int.TryParse(myTextBoxAccountId.textBox.Text, out _accountId) && int.TryParse(myTextBoxOtherAccountId.textBox.Text, out _otherAccountId) && float.TryParse(myTextBoxAmountToTransfer.textBox.Text, out _amountToTransfer)) ) {
                MessageBox.Show($"[ERROR] Please verify that all fields have been correctly filled!");
                return;
            }


            if(MyController.MakeTransfer(_accountId, _otherAccountId, _amountToTransfer)) {
                MessageBox.Show($"[Transfer Done] AccountId From: {_accountId}\nAccountId To: {_otherAccountId}\nAmount Transfered: {_amountToTransfer}");
            }
            else {
                MessageBox.Show($"[ERROR] There was a problem making the transfer transaction...");
            }

        }
    }
}
