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

namespace BankProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = "Server=tcp:137.186.165.104,49172; Database= bankproject;User Id=test;Password=123;";
            SqlConnection cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();

                MessageBox.Show("SqlConnection Open");
                
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");

                MessageBox.Show(ex.Message);
            }





























        }
    }
}
