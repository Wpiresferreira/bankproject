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
    /// Interaction logic for UcCreateNewEmployee.xaml
    /// </summary>
    public partial class UcCreateNewEmployee : UserControl {

        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }


        public UcCreateNewEmployee(ClassController myController) {
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            InitializeComponent();
        }


        private void ButtonCreateNewEmployee_Click(object sender, RoutedEventArgs e) {
            string _firstName = myTextBoxFirstName.textBox.Text;
            string _lastName = myTextBoxLastName.textBox.Text;
            string _emailAddress = myTextBoxEmailAddress.textBox.Text;
            string _phoneNumber = myTextBoxPhoneNumber.textBox.Text;
            int _positionId = int.Parse(myTextBoxPositionId.textBox.Text);
            string _password = myTextBoxPassword.textBox.Text;
            int _branchId = int.Parse(myTextBoxBranchId.textBox.Text);
            DateTime _startDate = Convert.ToDateTime(myTextBoxStartDate.textBox.Text);
            DateTime _dateOfBirth = Convert.ToDateTime(myTextBoxDateOfBirth.textBox.Text);
            string _zipCode = myTextBoxZipCode.textBox.Text;
            string _line1 = myTextBoxLine1.textBox.Text;
            string _line2 = myTextBoxLine2.textBox.Text;
            string _city = myTextBoxCity.textBox.Text;
            string _province = myTextBoxProvince.textBox.Text;
            string _country = myTextBoxCountry.textBox.Text;
            string _documentType = myTextBoxDocumentType.textBox.Text;
            string _documentNumber = myTextBoxDocumentNumber.textBox.Text;
            string _documentIssuedDate = myTextBoxDocumentIssuedDate.textBox.Text;
            string _documentExpirationDate = myTextBoxDocumentExpirationDate.textBox.Text;

            //Check that inputs are filled
            if (_firstName == "" || _lastName == "" || _emailAddress == "" || _phoneNumber == "" || _positionId <= 0 ||
                _password == "" || _branchId <= 0 || _zipCode == "" ||
                _line1 == "" || _line2 == "" || _city == "" || _province == "" || _country == "" || 
                _documentType == "" || _documentNumber == "" || _documentIssuedDate == "" || _documentExpirationDate == "") {
                MessageBox.Show($"[ERROR] Please verify that all fields have been filled!");
                return;
            }

            bool _successCreatingNewEmployee = MyController.CreateNewEmployee(
                _firstName, _lastName, _emailAddress, _phoneNumber, _positionId,
                _password, _branchId, _startDate, _dateOfBirth, _zipCode,
                _line1, _line2, _city, _province, _country,
                _documentType, _documentNumber, _documentIssuedDate, _documentExpirationDate);
            if (_successCreatingNewEmployee) {
                MessageBox.Show($"[New Employee Created]  First Name: {_firstName} | Last Name: {_lastName}");
            }
            else {
                MessageBox.Show($"[ERROR] There was a problem creating a new Employee...");
            }

        }
    }
}
