using BankProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for UcAccountSearch.xaml
    /// </summary>
    public partial class UcAccountSearch : UserControl
    {
        private ClassCustomSqlClient MySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcAccountSearch(ClassController myController)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }


        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            string _accountId = myTextBoxAccountId.textBox.Text;

            // Search the type of account
            string typeOfAccount = MySqlClient.TypeOfAccount(_accountId);


            if (typeOfAccount == "CHECKING")
            {
                ClassCheckingAccount newCheckingAccount = MySqlClient.SearchCheckingAccount(_accountId);

                if (newCheckingAccount != null)
                {
                    //MessageBox.Show($"{foundCustomer}");
                    var newUcAccountEditSave = new UcAccountEditSave(MyController, newCheckingAccount);
                    WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
                    parentWindow.SwitchTabs(newUcAccountEditSave);

                }
                else
                {
                    MessageBox.Show($"[ERROR] Customer not found!");
                }

            }
            else if (typeOfAccount == "SAVINGS")
            {
                ClassSavingsAccount newSavingsAccount = MySqlClient.SearchSavingsAccount(_accountId);

                if (newSavingsAccount != null)
                {
                    //MessageBox.Show($"{foundCustomer}");
                    var newUcAccountEditSave = new UcAccountEditSave(MyController, newSavingsAccount);
                    WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
                    parentWindow.SwitchTabs(newUcAccountEditSave);

                }
                else
                {
                    MessageBox.Show($"[ERROR] Customer not found!");
                }



            }
        }


        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

            //test newTest= new test();
            //WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            //parentWindow.SwitchTabs(newTest);

            var newUcAccountEditSave = new UcAccountEditSave(MyController);
            WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            parentWindow.SwitchTabs(newUcAccountEditSave);

        }

        private void myTextBoxAccountId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonEdit_Click(sender, e);
            }

        }
    }
}

