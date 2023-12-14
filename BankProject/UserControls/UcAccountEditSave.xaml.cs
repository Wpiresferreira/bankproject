using BankProject.Classes;
using BankProject.UserControls;
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

namespace BankProject.UserControls
{
    /// <summary>
    /// Interaction logic for UcAccountEditSave.xaml
    /// </summary>
    public partial class UcAccountEditSave : UserControl
    {
        private ClassCustomSqlClient MySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }

        public ClassCustomer MyCustomerSelected { get; set; }

        public UcAccountEditSave(ClassController myController)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
            myTextBoxAccountId.IsEnabled = false;
        }

        public UcAccountEditSave(ClassController myController, ClassCheckingAccount myCheckingAccount)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();

            myTextBoxAccountId.textBox.Text = myCheckingAccount.AccountId.ToString();
            myTextBoxCustomerId.textBox.Text = myCheckingAccount.CustomerId.ToString();
            myTextBoxAccountType.textBox.Text = "CHECKING";
            myTextBoxMonthlyFee.textBox.Text = myCheckingAccount.MonthlyFee.ToString("0.00");
            myTextBoxInterestRate.textBox.Text = "0.00";
            myTextBoxAccountId.textBox.IsEnabled = false;
            myTextBoxCustomerId.textBox.IsEnabled = false;
            myTextBoxAccountType.textBox.IsEnabled = false;
            myTextBoxInterestRate.textBox.IsEnabled = false;

        }

        public UcAccountEditSave(ClassController myController, ClassSavingsAccount mySavingsAccount)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();

            myTextBoxAccountId.textBox.Text = mySavingsAccount.AccountId.ToString();
            myTextBoxCustomerId.textBox.Text = mySavingsAccount.CustomerId.ToString();
            myTextBoxAccountType.textBox.Text = "SAVINGS";
            myTextBoxMonthlyFee.textBox.Text = "0.00";
            myTextBoxInterestRate.textBox.Text = mySavingsAccount.InterestRate.ToString("0.00");
            myTextBoxAccountId.textBox.IsEnabled = false;
            myTextBoxCustomerId.textBox.IsEnabled = false;
            myTextBoxAccountType.textBox.IsEnabled = false;
            myTextBoxMonthlyFee.textBox.IsEnabled = false;

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Build Insert / Update Queries
            string accountId = myTextBoxAccountId.textBox.Text;
            string customerId = myTextBoxCustomerId.textBox.Text;
            string accountType = myTextBoxAccountType.textBox.Text;
            string monthlyFee = myTextBoxMonthlyFee.textBox.Text;
            string interestRate = myTextBoxInterestRate.textBox.Text;


            // If there is no ID, try Insert.

            if (accountId == "")
            {


                int returnInsert = MySqlClient.CreateNewAccount(customerId, accountType, monthlyFee, interestRate);

                if (returnInsert != 0)
                {
                    MessageBox.Show($"[New Account Added] New Account was registered! \nAccountId: {returnInsert}");

                    myTextBoxAccountId.textBox.Text = returnInsert.ToString();

                    //Switch windows
                    //var newUcCustomerSearch = new UcCustomerSearch(MyController);
                    //WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
                    //parentWindow.SwitchTabs(newUcCustomerSearch);

                    // this.Close();
                    // this.Owner.Show();
                }
                else
                {
                    MessageBox.Show($"[ERROR] Something went wrong...");
                }

            }
            else  // try UPDATE
            {
                bool update = MySqlClient.UpdateAccount(accountId, customerId, accountType, monthlyFee, interestRate);

                if (update)
                {
                    MessageBox.Show($"[Account Updated] Account {accountId} was updated!");


                }
                else
                {
                    MessageBox.Show($"[ERROR] Something went wrong...");
                }


            }
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //Switch windows
            var newUcAccountSearch = new UcAccountSearch(MyController);
            WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            parentWindow.SwitchTabs(newUcAccountSearch);
        }
    }
}
