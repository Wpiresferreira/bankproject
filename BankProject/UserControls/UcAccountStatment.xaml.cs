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

namespace BankProject.UserControls
{
    /// <summary>
    /// Interaction logic for UcAccountStatment.xaml
    /// </summary>
    public partial class UcAccountStatment : UserControl
    {
        ClassController MyController { get; set; }

        public UcAccountStatment(ClassController myController, string accountId)
        {
            MyController = myController;
            InitializeComponent();

            textBlockBranchId.Text = $"Current Branch: {MyController.MyUserLogged.BranchId}";

            // filling StartDate and EndDate
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;

            textBoxStartDate.textBox.Text = startDate.ToString();
            textBoxEndDate.textBox.Text = endDate.ToString();



            //Find Branch data that corresponds to Branch of Logged User

            int accountIdint = Int32.Parse(accountId);
            //List<ClassTransaction> MyListTransactions = MyController.GetListTransactionsOfSpecificAccount(accountIdint);
            List<ClassTransaction> MyListTransactions = MyController.GetStatment(accountIdint, startDate, endDate);


            listTransactions.ItemsSource = MyListTransactions;
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}