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

namespace BankProject.UserControls {
    /// <summary>
    /// Interaction logic for UcListCustomersFromMyBranch.xaml
    /// </summary>
    public partial class UcListCustomersFromMyBranch : UserControl {
        
        ClassController MyController { get; set; }
        
        public UcListCustomersFromMyBranch(ClassController myController) {
            MyController = myController;
            InitializeComponent();

            textBlockBranchId.Text = $"Current Branch: {MyController.MyUserLogged.BranchId}";

            //Find Branch data that corresponds to Branch of Logged User
            foreach(ClassBranch b in MyController.MyListBranches) {
                if(b.BranchId==MyController.MyUserLogged.BranchId) {
                    //Bind Data
                    listViewListCustomersFromMyBranch.ItemsSource = b.MyListCustomers;
                    break;
                }
            }
        }
    }
}
