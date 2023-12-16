using BankProject.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
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
using System.Xml.Linq;

namespace BankProject.UserControls
{
    /// <summary>
    /// Interaction logic for UcCustomerEditSave.xaml
    /// </summary>
    /// 

    public partial class UcCustomerEditSave : UserControl
    {

        private ClassCustomSqlClient MySqlClient;
        public ClassController MyController { get; set; }
        public ClassUserLogged MyUserLogged { get; set; }

        public ClassCustomer MyCustomerSelected { get; set; }


        public UcCustomerEditSave(ClassController myController)
        {
            InitializeComponent();
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            myTextBoxCustomerId.textBox.IsEnabled = false;
        }

        public UcCustomerEditSave(ClassController myController, ClassCustomer myCustomerSelected)
        {
            MySqlClient = new ClassCustomSqlClient();
            MyController = myController;
            MyUserLogged = myController.MyUserLogged;
            MyCustomerSelected = myCustomerSelected;
            InitializeComponent();

            myTextBoxCustomerId.textBox.Text = myCustomerSelected.CustomerId.ToString();
            myTextBoxFirstName.textBox.Text = myCustomerSelected.FirstName;
            myTextBoxLastName.textBox.Text = myCustomerSelected.LastName;
            myTextBoxDateOfBirth.textBox.Text = myCustomerSelected.DateOfBirth.ToString();
            myTextBoxDocumentType.textBox.Text = myCustomerSelected.Document.DocumentType.ToString();
            myTextBoxDocNumber.textBox.Text = myCustomerSelected.Document.DocumentNumber.ToString();
            myTextBoxIssuedDate.textBox.Text = myCustomerSelected.Document.DocumentIssuedDate.ToString();
            myTextBoxExpDate.textBox.Text = myCustomerSelected.Document.DocumentExpirationDate.ToString();
            myTextBoxZipCode.textBox.Text = myCustomerSelected.Address.ZipCode.ToString();
            myTextBoxLine1.textBox.Text = myCustomerSelected.Address.Line1.ToString();
            myTextBoxLine2.textBox.Text = myCustomerSelected.Address.Line2.ToString();
            myTextBoxCity.textBox.Text = myCustomerSelected.Address.City.ToString();
            myTextBoxProvince.textBox.Text = myCustomerSelected.Address.Province.ToString();
            myTextBoxCountry.textBox.Text = myCustomerSelected.Address.Country.ToString();
            myTextBoxPhone.textBox.Text = myCustomerSelected.Phone.ToString();
            myTextBoxEmail.textBox.Text = myCustomerSelected.Email.ToString();

        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Build Insert / Update Queries
            string customerIdText = myTextBoxCustomerId.textBox.Text;
            int customerId = int.Parse(customerIdText);
            string firstName = myTextBoxFirstName.textBox.Text;
            string lastName = myTextBoxLastName.textBox.Text;
            DateOnly dateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(myTextBoxDateOfBirth.textBox.Text));
            string documentType = myTextBoxDocumentType.textBox.Text;
            string documentNumber = myTextBoxDocNumber.textBox.Text;
            DateOnly documentIssuedDate = DateOnly.FromDateTime(Convert.ToDateTime(myTextBoxIssuedDate.textBox.Text));
            DateOnly documentExpirationDate = DateOnly.FromDateTime(Convert.ToDateTime(myTextBoxExpDate.textBox.Text));
            string zipCode = myTextBoxZipCode.textBox.Text;
            string line1 = myTextBoxLine1.textBox.Text;
            string line2 = myTextBoxLine2.textBox.Text;
            string city = myTextBoxCity.textBox.Text;
            string province = myTextBoxProvince.textBox.Text;
            string country = myTextBoxCountry.textBox.Text;
            string phoneNumber = myTextBoxPhone.textBox.Text;
            string emailAddress = myTextBoxEmail.textBox.Text;
            int branchId = 2;
            int financialAdvisorId = 2;

            // If there is no ID, try Insert.

            if (customerIdText == "")
            {


                ClassCustomer? _newCustomer = MyController.CreateNewCustomer(
                    firstName, lastName, dateOfBirth, documentType, documentNumber,
                    documentIssuedDate, documentExpirationDate, zipCode, line1, line2,
                    city, province, country, phoneNumber, emailAddress,
                    branchId, financialAdvisorId
                );

                if (_newCustomer != null)
                {
                    MessageBox.Show($"[New Customer Added] New Customer {firstName} {lastName} was registered! \nCustomerId: {_newCustomer.CustomerId}");

                    myTextBoxCustomerId.textBox.Text = _newCustomer.CustomerId.ToString();

                    //Switch windows
                    //var newUcCustomerSearch = new UcCustomerSearch(MyController);
                    //WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
                    //parentWindow.SwitchTabs(newUcCustomerSearch);

                    // this.Close();
                    // this.Owner.Show();
                }
                else
                {
                    MessageBox.Show($"[ERROR] Something went wrong...");
                }

            }
            else  // try UPDATE
            {
                ClassCustomer? _updatedCustomer = MyController.EditCustomer(
                    customerId, firstName, lastName, dateOfBirth, documentType,
                    documentNumber, documentIssuedDate, documentExpirationDate, zipCode, line1,
                    line2, city, province, country, phoneNumber,
                    emailAddress, branchId, financialAdvisorId);

                if (_updatedCustomer!=null)
                {
                    MessageBox.Show($"[Customer Updated] Customer {firstName} {lastName} was updated! \nCustomerId: {customerId}");


                }
                else {
                    MessageBox.Show($"[ERROR] Something went wrong...");
                }


            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //Switch windows
            var newUcCustomerSearch = new UcCustomerSearch(MyController);
            WindowFrame parentWindow = (WindowFrame)Window.GetWindow(this);
            parentWindow.SwitchTabs(newUcCustomerSearch);

        }

       

        private void myTextBoxZipCode_LostFocus(object sender, RoutedEventArgs e)
        {

            string inputZipCode = myTextBoxZipCode.textBox.Text;
            ClassZipCode MyZipCode = MySqlClient.UpdateZipCode(inputZipCode);

            if (MyZipCode == null)
            {
                MessageBox.Show("Invalid Zip Code.");
            }
            else
            {
                myTextBoxCity.textBox.Text = MyZipCode.City;
                myTextBoxProvince.textBox.Text = MyZipCode.Province;
                myTextBoxCountry.textBox.Text = MyZipCode.Country;
                myTextBoxZipCode.textBox.Text = MyZipCode.ZipCode;
            }
        }
    }
}
