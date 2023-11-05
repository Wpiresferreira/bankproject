using System;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace BankProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = "Server= WAGNERLAPTOP\\SQLEXPRESS; Database= bankproject;Integrated Security=SSPI;";
            SqlConnection cnn = new SqlConnection(connetionString) ;
            try
            {
                cnn.Open();
                //MessageBox.Show("Connection Open ! ");
                string selectquery = "SELECT[employeeID],[password] FROM[bankproject].[dbo].[Employees]";
;
                SqlCommand cmd = new SqlCommand(selectquery, cnn);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                    reader1.Read();

                if (reader1.GetValue(0).ToString() == UserIDLoginBox.Text && reader1.GetValue(1).ToString() == PasswordLoginBox.Text)
                {
                    MessageBox.Show("Login Sucessful");

                }
                else
                {
                    MessageBox.Show("Incorrect Credentials");
                }

               
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
    }
}
