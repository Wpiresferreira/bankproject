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

        string ConnectionString;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcCustomerSearch(ClassController myController)
        {
            ConnectionString = myController.ConnectionString;
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
                selectQuery = $"SELECT * FROM dbo.Customers WHERE  customerID = '{myTextBoxCustomerID.textBox.Text}'";
            }
            else
            {
                string dateFormated = $"{myTextBoxDataOfBirth.textBox.Text.Substring(6, 4)}-{myTextBoxDataOfBirth.textBox.Text.Substring(3,2)}-{myTextBoxDataOfBirth.textBox.Text.Substring(0,2)}";
                MessageBox.Show(dateFormated);
                selectQuery = $"SELECT * FROM dbo.Customers WHERE firstName = '{myTextBoxFirstName.textBox.Text}' AND lastName = '{myTextBoxLastName.textBox.Text}' AND dateOfBirth = '{dateFormated}'";
            };


            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        ClassDocument customerDocument = new ClassDocument(reader.GetString(4), reader.GetString(5), DateOnly.FromDateTime(reader.GetDateTime(6)), DateOnly.FromDateTime(reader.GetDateTime(7)));
                        ClassAddress customerAddress = new ClassAddress(reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13));
                        ClassEmployee financialAdvisor = null;
                        ClassBranch branch = null;
                        var listOfAccounts = new List<ClassAbstractAccount>();

                        ClassCustomer customer = new ClassCustomer(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            DateOnly.FromDateTime(reader.GetDateTime(3)),
                            customerDocument,
                            customerAddress,
                            reader.GetString(14),
                            reader.GetString(15),
                            financialAdvisor,
                            branch,
                            listOfAccounts);

                        MessageBox.Show(customer.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
            }
        }


        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
