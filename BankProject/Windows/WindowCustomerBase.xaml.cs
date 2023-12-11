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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BankProject.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowCustomerBase : Window
    {

        string ConnectionString;

        public WindowCustomerBase(string connectionString)
        {
            ConnectionString = connectionString;
            InitializeComponent();
        }
        public WindowCustomerBase()
        {
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
                        ClassCustomer customer = new ClassCustomer(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            DateOnly.FromDateTime(reader.GetDateTime(3)),
                            customerDocument,
                            customerAddress,
                            reader.GetString(14),
                            reader.GetString(15));

                        MessageBox.Show(customer.ToString());

                    }


                    //Switch windows
                    //this.Close();
                    //this.Owner.Show();
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
private void ButtonBack_Click(object sender, RoutedEventArgs e)
{
    this.Hide();
    this.Owner.Show();
}

private void ImageMinimize_MouseUp(object sender, MouseButtonEventArgs e)
{
    this.WindowState = WindowState.Minimized;
}
private void ImageClose_MouseUp(object sender, MouseButtonEventArgs e)
{
    Application.Current.Shutdown();
}

private void Border_MouseDown(object sender, MouseButtonEventArgs e)
{
    if (e.ChangedButton == MouseButton.Left)
    {
        this.DragMove();
    }
}
    }
}
