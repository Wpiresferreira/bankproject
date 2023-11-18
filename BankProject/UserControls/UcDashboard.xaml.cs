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

namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcDashboard.xaml
    /// </summary>
    public partial class UcDashboard : UserControl {

        public string ConnectionString { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcDashboard(string connectionString, ClassUserLogged userLogged) {
            InitializeComponent();
            ConnectionString = connectionString;
            MyUserLogged = userLogged;

            nameHeader.Text = $"Good Afternoon, {MyUserLogged.FirstName}";
        }

    }
}
