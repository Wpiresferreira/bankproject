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
            ButtonStatment.Visibility = Visibility.Collapsed;
        }

        public UcAccountEditSave(ClassController myController, ClassCheckingAccount myCheckingAccount)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();

            myTextBoxAccountId.textBox.Text = myCheckingAccount.AccountId.ToString();
            myTextBoxCustomerId.textBox.Text = myCheckingAccount.CustomerId.ToString();
            myTextBoxAccountType.Text = "CHEQUING";
            myTextBoxMonthlyFee.textBox.Text = myCheckingAccount.MonthlyFee.ToString("0.00");
            myTextBoxInterestRate.textBox.Text = "0.00";
            myTextBoxBalance.textBox.Text = myCheckingAccount.Balance.ToString("0.00");
            myTextBoxAccountId.textBox.IsEnabled = false;
            myTextBoxCustomerId.textBox.IsEnabled = false;
            myTextBoxAccountType.IsEnabled = false;
            myTextBoxInterestRate.textBox.IsEnabled = false;
            myTextBoxBalance.textBox.IsEnabled = false;

            ClassCustomer myCustomer = MySqlClient.GetCustomerById((int)myCheckingAccount.CustomerId);

            MyTextBlockCustomerName.Text = myCustomer.FirstName + " " + myCustomer.LastName;

        }

        public UcAccountEditSave(ClassController myController, ClassSavingsAccount mySavingsAccount)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();

            myTextBoxAccountId.textBox.Text = mySavingsAccount.AccountId.ToString();
            myTextBoxCustomerId.textBox.Text = mySavingsAccount.CustomerId.ToString();
            myTextBoxAccountType.Text = "SAVINGS";
            myTextBoxMonthlyFee.textBox.Text = "0.00";
            myTextBoxInterestRate.textBox.Text = mySavingsAccount.InterestRate.ToString("0.00");
            myTextBoxBalance.textBox.Text = mySavingsAccount.Balance.ToString("#,##0.00");
            myTextBoxAccountId.textBox.IsEnabled = false;
            myTextBoxCustomerId.textBox.IsEnabled = false;
            myTextBoxAccountType.IsEnabled = false;
            myTextBoxMonthlyFee.textBox.IsEnabled = false;
            myTextBoxBalance.textBox.IsEnabled = false;


            ClassCustomer myCustomer = MySqlClient.GetCustomerById((int)mySavingsAccount.CustomerId);
            MyTextBlockCustomerName.Text = myCustomer.FirstName + " " + myCustomer.LastName;


        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Build Insert / Update Queries
            string accountIdText = myTextBoxAccountId.textBox.Text;
            int accountId;
            Int32.TryParse(accountIdText, out accountId);
            int customerId = int.Parse(myTextBoxCustomerId.textBox.Text);
            string accountType = myTextBoxAccountType.Text;
            float monthlyFee = float.Parse(myTextBoxMonthlyFee.textBox.Text);
            float interestRate = float.Parse(myTextBoxInterestRate.textBox.Text);


            // If there is no ID, try Insert.

            if (accountIdText == "")
            {


                ClassAbstractAccount _newAccount = MyController.CreateNewAccount(customerId, accountType, monthlyFee, interestRate);

                if (_newAccount != null)
                {
                    MessageBox.Show($"[New Account Added] New Account was registered! Account Id: {_newAccount.AccountId}");

                    myTextBoxAccountId.textBox.Text = _newAccount.AccountId.ToString();

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
                ClassAbstractAccount? _editedAccount = MyController.EditAccount(accountId, customerId, accountType, monthlyFee, interestRate);

                if (_editedAccount != null)
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

        private void ButtonStatment_Click(object sender, RoutedEventArgs e)
        {
            var newUcAccountStatment = new UcAccountStatment(MyController, myTextBoxAccountId.textBox.Text);
            WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            parentWindow.SwitchTabs(newUcAccountStatment);
        }

        private void myTextBoxCustomerId_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int _customerId = Int32.Parse(myTextBoxCustomerId.textBox.Text);
                ClassCustomer customer = MySqlClient.GetCustomerById(_customerId);
                MyTextBlockCustomerName.Text = $"{customer.FirstName} {customer.LastName}";
            }
            catch { }
        }
    }
}
