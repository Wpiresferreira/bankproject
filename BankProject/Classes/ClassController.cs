using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BankProject.Classes {
    public class ClassController {

        private ClassCustomSqlClient MySqlClient { get; set; }
        public ClassUserLogged? MyUserLogged { get; set; }
        public List<ClassBranch>? MyListBranches { get; set; }


        public ClassController() {
            MySqlClient = new ClassCustomSqlClient();
            MyUserLogged = null;
            MyListBranches = new List<ClassBranch>();
        }


        public void LoginUser(string inputEmail, string inputPassword) {
            MyUserLogged = MySqlClient.AuthenticateLogin(inputEmail, inputPassword);
            
            if (MyUserLogged != null) {
                //Populate MyController.MyListBranches
                PopulateMyListBranches();
                
                DisplayAllBranches();
            }
        }


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------- BRANCH METHODS -----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public void PopulateMyListBranches() {
            MyListBranches = MySqlClient.GetListOfBranches();

            foreach (ClassBranch b in MyListBranches) {
                int _branchId = b.BranchId;
                b.MyListCustomers = MySqlClient.GetListCustomersOfSpecificBranch(_branchId);
                b.MyListEmployees = MySqlClient.GetListEmployeesOfSpecificBranch(_branchId);

                foreach (ClassCustomer c in b.MyListCustomers) {
                    int _customerId = c.CustomerId;
                    c.MyListAccounts = MySqlClient.GetListAccountsOfSpecificCustomer(_customerId);

                    foreach (ClassAbstractAccount aa in c.MyListAccounts) {
                        int _accountId = aa.AccountId;
                        aa.MyListTransactions = MySqlClient.GetListTransactionsOfSpecificAccount(_accountId);
                    }
                }
            }
        }


        public bool CreateNewBranch(string inputName, string inputCity) {
            
            //Create new Branch in the database
            ClassBranch _newBranch = MySqlClient.InsertNewBranch(inputName, inputCity);
            
            if(_newBranch!=null) {
                //Add new Branch in the model
                MyListBranches.Add(_newBranch);

                return true;
            }
            else {
                return false;
            }
        }


        public void DisplayAllBranches() {
            foreach(ClassBranch b in MyListBranches) {
                Debug.WriteLine($"{b}");
            }
        }


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------ EMPLOYEE METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public bool CreateNewEmployee(
            string firstName, string lastName, string emailAddress, string phoneNumber, int positionId,
            string password, int branchId, DateOnly startDate, DateOnly dateOfBirth, string zipCode,
            string line1, string line2, string city, string province, string country,
            string documentType, string documentNumber, string documentIssuedDate, string documentExpirationDate) {
            
            //Create new Employee in the database
            ClassEmployee _newEmployee = MySqlClient.InsertNewEmployee(
                firstName, lastName, emailAddress, phoneNumber, positionId,
                password, branchId, startDate, dateOfBirth, zipCode,
                line1, line2, city, province, country,
                documentType, documentNumber, documentIssuedDate, documentExpirationDate);
            
            if(_newEmployee!=null) {
                //Add new Employee in the model
                foreach (ClassBranch b in MyListBranches) {
                    if(b.BranchId == branchId) {
                        b.MyListEmployees.Add(_newEmployee);
                        Debug.WriteLine($"[New Employee Created] {_newEmployee}");
                        return true;
                    }
                }
                return false;
            }
            else {
                return false;
            }
        }


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------ CUSTOMER METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */



        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------- ACCOUNT METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
       


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ---------------------------------------------------- TRANSACTION METHODS ---------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public bool MakeDeposit(int inputAccountIdDestination, float inputAmountToCredit) {

             int _accountIdOrigin = 9; //Account INTERNAL BANK

            //Check input data
            if (inputAmountToCredit <= 0) {
                MessageBox.Show($"[ERROR] Amount to Credit must be a positive number!");
                return false;
            }
            else if (inputAccountIdDestination <= 0) {
                MessageBox.Show($"[ERROR] Invalid Account Id!");
                return false;
            }

            //Create Transaction
             if(MySqlClient.CreateTransaction(inputAccountIdDestination, 0, inputAmountToCredit, _accountIdOrigin, "DEPOSIT")) {
                PopulateMyListBranches(); //TODO: REFACTOR LATER
                return true;
            };

             return false;
        }


        public bool MakeWithdraw(int inputAccountIdOrigin, float inputAmountToDebit) {

             int _accountIdDestination = 9; //Account INTERNAL BANK

            //Check input data
            if (inputAmountToDebit <= 0) {
                MessageBox.Show($"[ERROR] Amount to Debit must be a positive number!");
                return false;
            }
            else if (inputAccountIdOrigin <= 0) {
                MessageBox.Show($"[ERROR] Invalid Account Id!");
                return false;
            }

            //Create Transaction
             if(MySqlClient.CreateTransaction(inputAccountIdOrigin, inputAmountToDebit, 0, _accountIdDestination, "WITHDRAW")) {
                PopulateMyListBranches(); //TODO: REFACTOR LATER
                return true;
            };

             return false;
        }


        public bool MakeTransfer(int inputAccountIdOrigin, int inputAccountIdDestination, float inputAmountToTransfer) {

            //Check input data
            if (inputAmountToTransfer <= 0) {
                MessageBox.Show($"[ERROR] Amount to Transfer must be a positive number!");
                return false;
            }
            else if (inputAccountIdOrigin <= 0) {
                MessageBox.Show($"[ERROR] Invalid Account Id Origin!");
                return false;
            }
            else if (inputAccountIdDestination <= 0) {
                MessageBox.Show($"[ERROR] Invalid Account Id Destination!");
                return false;
            }

            //Create Transaction
             if(MySqlClient.CreateTransaction(inputAccountIdOrigin, inputAmountToTransfer, 0, inputAccountIdDestination, "TRANSFER")) {
                PopulateMyListBranches(); //TODO: REFACTOR LATER
                return true;
            };

             return false;
        }
        public List<ClassTransaction> GetStatment(int accountId, DateTime startDate, DateTime endDate)
        {
            return MySqlClient.GetListTransactionsBetweenDates(accountId, startDate, endDate);
        }
        public List<ClassTransaction> GetListTransactionsOfSpecificAccount(int accountId)
        {
            return MySqlClient.GetListTransactionsOfSpecificAccount(accountId);
        }

    }
}
