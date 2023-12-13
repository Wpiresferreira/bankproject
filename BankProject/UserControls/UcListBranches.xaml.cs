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
    /// Interaction logic for UcListBranches.xaml
    /// </summary>
    public partial class UcListBranches : UserControl {

        ClassController MyController { get; set; }


        public UcListBranches(ClassController myController) {
            MyController = myController;
            InitializeComponent();

            //Bind Data
            listViewListBranches.ItemsSource = MyController.MyListBranches;
        }



    }
}
