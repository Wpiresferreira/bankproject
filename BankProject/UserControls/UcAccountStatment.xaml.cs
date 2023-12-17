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

            textBlockBranchId.Text = MyController.MyUserLogged.BranchId.ToString("0000");
            textBlockAccountId.Text = accountId.ToString();

            // filling StartDate and EndDate
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;

            textBoxStartDate.Text = startDate.ToString("yyyy-MM-dd");
            textBoxEndDate.Text = endDate.ToString("yyyy-MM-dd");
            int accountIdint = Int32.Parse(accountId);
            List<ClassTransaction> MyListTransactions = MyController.GetStatement(accountIdint, startDate, endDate);

            var statement = new List<ClassLineStatment>();

            foreach (ClassTransaction transaction in MyListTransactions)
            {
                var _lineStatement = new ClassLineStatment();
                _lineStatement.DatetimeTransaction = transaction.DatetimeTransaction.ToString("yyyy-MM-dd");
                _lineStatement.TransactionId = transaction.TransactionId.ToString("000000");
                _lineStatement.TypeTransaction = transaction.TypeTransaction;
                if (transaction.AmountDebit == 0)
                {
                    _lineStatement.Amount = transaction.AmountCredit.ToString("#,##0.00");
                    _lineStatement.DebitOrCredit = "C";
                }
                else
                {
                    _lineStatement.Amount = transaction.AmountDebit.ToString("#,##0.00");
                    _lineStatement.DebitOrCredit = "D";

                }

                statement.Add(_lineStatement);
            }
            statement.Sort((a, b) => a.DatetimeTransaction.CompareTo(b.DatetimeTransaction));
            listTransactions.ItemsSource = statement;
        }


        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.ParseExact(textBoxStartDate.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(textBoxEndDate.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);


            //string startDate = textBoxStartDate.Text;
            //string endDate = textBoxEndDate.Text;
            int accountIdint = Int32.Parse(textBlockAccountId.Text);
            List<ClassTransaction> MyListTransactions = MyController.GetStatement(accountIdint, startDate, endDate);

            var statement = new List<ClassLineStatment>();

            foreach (ClassTransaction transaction in MyListTransactions)
            {
                var _lineStatement = new ClassLineStatment();
                _lineStatement.DatetimeTransaction = transaction.DatetimeTransaction.ToString("yyyy-MM-dd");
                _lineStatement.TransactionId = transaction.TransactionId.ToString("000000");
                _lineStatement.TypeTransaction = transaction.TypeTransaction;
                if (transaction.AmountDebit == 0)
                {
                    _lineStatement.Amount = transaction.AmountCredit.ToString("#,##0.00");
                    _lineStatement.DebitOrCredit = "C";
                }
                else
                {
                    _lineStatement.Amount = transaction.AmountDebit.ToString("#,##0.00");
                    _lineStatement.DebitOrCredit = "D";

                }
                statement.Add(_lineStatement);
            }

            statement.Sort((a, b) => a.DatetimeTransaction.CompareTo(b.DatetimeTransaction));
            listTransactions.ItemsSource = statement;
        }


    }
}