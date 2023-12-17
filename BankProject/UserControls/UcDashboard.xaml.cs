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
using System.Xml.Schema;
using BankProject.Classes;

namespace BankProject.UserControls
{
    /// <summary>
    /// Interaction logic for UcDashboard.xaml
    /// </summary>
    public partial class UcDashboard : UserControl {

        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcDashboard(ClassController myController) {
            InitializeComponent();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;

            nameHeader.Text = $"Greetings, {MyUserLogged.FirstName}!";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Card1.Title = "Savings Total Balance";
            Card1.Number = MyController.GetSavingsBalance(MyUserLogged.EmployeeId);

            Card2.Title = "Chequing Total Balance";
            Card2.Number = MyController.GetChequingBalance(MyUserLogged.EmployeeId);

            Card3.Title = "Customers Total";
            Card3.Number = MyController.GetCountCustomers(MyUserLogged.EmployeeId);

        }
    }
}
