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
            int _accountId = int.Parse(myTextBoxAccountId.textBox.Text);
            int _otherAccountId = int.Parse(myTextBoxOtherAccountId.textBox.Text);
            float _amountToTransfer = float.Parse(myTextBoxAmountToTransfer.textBox.Text);

            //Check that inputs are filled
            if(_accountId==null || _otherAccountId==null || _amountToTransfer==null) {
                MessageBox.Show($"[ERROR] Please verify that all fields have been filled!");
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
