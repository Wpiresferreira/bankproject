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
    /// Interaction logic for UcCreateNewBranch.xaml
    /// </summary>
    public partial class UcCreateNewBranch : UserControl {

        ClassCustomSqlClient mySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcCreateNewBranch(ClassController myController) {
            mySqlClient = new ClassCustomSqlClient();
            MyController = MyController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e) {
            string _nameNewBranch = myTextBoxNewBranchName.textBox.Text;
            string _cityNewBranch = myTextBoxNewBranchCity.textBox.Text;


            if(mySqlClient.CreateNewBranch(_nameNewBranch, _cityNewBranch)) {
                MessageBox.Show($"[New Branch Created] Branch Name: {_nameNewBranch} | Branch City: {_cityNewBranch}");
            }
            else {
                MessageBox.Show($"[ERROR] There was a problem creating a new Branch...");
            }
        }
    }
}
