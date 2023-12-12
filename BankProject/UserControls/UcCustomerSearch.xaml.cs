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

namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcCustomerSearch.xaml
    /// </summary>
    public partial class UcCustomerSearch : UserControl {

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
            //Build Select Query
            string selectQuery = "";
            if (myTextBoxCustomerID.textBox.Text != "")
            {
                selectQuery = $"SELECT * FROM dbo.Customers ";
                selectQuery += $"WHERE customerId = '{myTextBoxCustomerID.textBox.Text}'";
            }
            else
            {
                string dateFormated = $"{myTextBoxDataOfBirth.textBox.Text.Substring(6, 4)}-{myTextBoxDataOfBirth.textBox.Text.Substring(3,2)}-{myTextBoxDataOfBirth.textBox.Text.Substring(0,2)}";
                MessageBox.Show(dateFormated);
                selectQuery = $"SELECT * FROM dbo.Customers ";
                selectQuery += $"WHERE firstName = '{myTextBoxFirstName.textBox.Text}' AND lastName = '{myTextBoxLastName.textBox.Text}' AND dateOfBirth = '{dateFormated}'";
            };

            ClassCustomer foundCustomer = MySqlClient.SearchCustomer(selectQuery);
            if(foundCustomer != null) {
                MessageBox.Show($"{foundCustomer}");
            }
            else {
                MessageBox.Show($"[ERROR] Customer not found!");
            }
        }


        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
