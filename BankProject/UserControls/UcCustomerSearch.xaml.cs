using BankProject.Classes;
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

namespace BankProject.UserControls
{
    /// <summary>
    /// Interaction logic for UcCustomerSearch.xaml
    /// </summary>
    public partial class UcCustomerSearch : UserControl
    {

        private ClassCustomSqlClient MySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcCustomerSearch(ClassController myController)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }


        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string _customerId = myTextBoxCustomerID.textBox.Text;
            string _firstName = myTextBoxFirstName.textBox.Text;
            string _lastName = myTextBoxLastName.textBox.Text;
            string _dateOfBirth = myTextBoxDataOfBirth.Text;
            

            ClassCustomer foundCustomer = MySqlClient.SearchCustomer(_customerId, _firstName, _lastName, _dateOfBirth);
            if (foundCustomer != null)
            {
                var newUcCustomerEditSave = new UcCustomerEditSave(MyController, foundCustomer);
                WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
                parentWindow.SwitchTabs(newUcCustomerEditSave);

            }
            else
            {
                MessageBox.Show($"[ERROR] Customer not found!");
            }
        }


        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

            //test newTest= new test();
            //WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            //parentWindow.SwitchTabs(newTest);

            var newUcCustomerEditSave = new UcCustomerEditSave(MyController);
            WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            parentWindow.SwitchTabs(newUcCustomerEditSave);

            //var newUcCustomerEdit = new UcCustomerEdit(MyController);
            //WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            //parentWindow.SwitchTabs(newUcCustomerEdit);
        }




        private void myTextBoxCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonSearch_Click(sender, e);
            }
        }

        private void myTextBoxFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                myTextBoxLastName.Focus();
            }
        }

        private void myTextBoxLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                myTextBoxDataOfBirth.Focus();
            }
        }

        private void myTextBoxDataOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonSearch_Click(sender, e);
            }
        }
    }
}
