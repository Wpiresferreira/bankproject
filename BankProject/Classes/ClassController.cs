using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
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


        public async void LoginUser(string inputEmail, string inputPassword) {
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
        public ClassCustomer? CreateNewCustomer(string firstName, string lastName, DateOnly dateOfBirth, string documentType, string documentNumber,
                    DateOnly documentIssuedDate, DateOnly documentExpirationDate, string zipCode, string line1, string line2,
                    string city, string province, string country, string phoneNumber, string emailAddress,
                    int branchId, int financialAdvisorId) {
            
            //Create new Customer in the database
            ClassCustomer _newCustomer = MySqlClient.InsertNewCustomer(
                firstName, lastName, dateOfBirth, documentType, documentNumber,
                documentIssuedDate, documentExpirationDate, zipCode, line1, line2,
                city, province, country, phoneNumber, emailAddress,
                branchId, financialAdvisorId);
            
            if(_newCustomer!=null) {
                //Add new Customer in the model
                foreach (ClassBranch b in MyListBranches) {
                    if(b.BranchId == branchId) {
                        b.MyListCustomers.Add(_newCustomer);
                        Debug.WriteLine($"[New Customer Created] {_newCustomer}");
                        return _newCustomer;
                    }
                }
                return null;
            }
            else {
                return null;
            }
        }


        public ClassCustomer? EditCustomer(int customerId, string firstName, string lastName, DateOnly dateOfBirth, string documentType,
            string documentNumber, DateOnly documentIssuedDate, DateOnly documentExpirationDate, string zipCode, string line1,
            string line2, string city, string province, string country, string phoneNumber,
            string emailAddress, int branchId, int financialAdvisorId) {

            //Check input data
            if (customerId <= 0) {
                MessageBox.Show($"[ERROR]  Invalid Customer Id!");
                return null;
            }
            else if (branchId <= 0) {
                MessageBox.Show($"[ERROR]  Invalid Branch Id!");
                return null;
            }
            else if (financialAdvisorId <= 0) {
                MessageBox.Show($"[ERROR]  Invalid Financial Advisor Id!");
                return null;
            }

            ClassCustomer? _editedCustomer = null;

            _editedCustomer = MySqlClient.UpdateCustomer(
                customerId, firstName, lastName, dateOfBirth, documentType,
                documentNumber, documentIssuedDate, documentExpirationDate, zipCode, line1,
                line2, city, province, country, phoneNumber,
                emailAddress, branchId, financialAdvisorId
            );

            //Check if new account was created
             if(_editedCustomer!=null) {
                PopulateMyListBranches(); //TODO: REFACTOR LATER
                return _editedCustomer;
            };

             return null;
        }



        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------- ACCOUNT METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
       public ClassAbstractAccount? CreateNewAccount(int customerId, string accountType, float monthlyFee, float interestRate) {
            //Check input data
            if (customerId <= 0) {
                MessageBox.Show($"[ERROR]  Invalid Customer Id!");
                return null;
            }
            else if ( !(accountType=="CHECKING" || accountType=="SAVINGS") ) {
                MessageBox.Show($"[ERROR] Invalid Account Type (Only Allowed CHECKING or SAVINGS)!");
                return null;
            }
            else if (monthlyFee<0) {
                MessageBox.Show($"[ERROR] Invalid Monthly Fee! Negative number");
                return null;
            }
            else if (interestRate<0) {
                MessageBox.Show($"[ERROR] Invalid Interest Rate! Negative number");
                return null;
            }

            ClassAbstractAccount? _newAccount = null;

            //Check type of new Account
            if(accountType=="CHECKING") {
                _newAccount = MySqlClient.InsertNewCheckingAccount(customerId, accountType, monthlyFee, interestRate);
            }
            else if(accountType=="SAVINGS") {
                _newAccount = MySqlClient.InsertNewSavingsAccount(customerId, accountType, monthlyFee, interestRate);
            }

            //Check if new account was created
             if(_newAccount!=null) {
                PopulateMyListBranches(); //TODO: REFACTOR LATER
                return _newAccount;
            };

             return null;
        }


        public ClassAbstractAccount? EditAccount(int accountId, int customerId, string accountType, float monthlyFee, float interestRate) {
            //Check input data
            if (accountId <= 0) {
                MessageBox.Show($"[ERROR]  Invalid Account Id!");
                return null;
            }
            else if (customerId <= 0) {
                MessageBox.Show($"[ERROR]  Invalid Customer Id!");
                return null;
            }
            else if ( !(accountType=="CHECKING" || accountType=="SAVINGS") ) {
                MessageBox.Show($"[ERROR] Invalid Account Type (Only Allowed CHECKING or SAVINGS)!");
                return null;
            }
            else if (monthlyFee<0) {
                MessageBox.Show($"[ERROR] Invalid Monthly Fee! Negative number");
                return null;
            }
            else if (interestRate<0) {
                MessageBox.Show($"[ERROR] Invalid Interest Rate! Negative number");
                return null;
            }

            ClassAbstractAccount? _editedAccount = null;

            //Check type of new Account
            if(accountType=="CHECKING") {
                _editedAccount = MySqlClient.UpdateCheckingAccount(accountId, customerId, accountType, monthlyFee, interestRate);
            }
            else if(accountType=="SAVINGS") {
                _editedAccount = MySqlClient.UpdateSavingsAccount(accountId, customerId, accountType, monthlyFee, interestRate);
            }

            //Check if new account was created
             if(_editedAccount!=null) {
                PopulateMyListBranches(); //TODO: REFACTOR LATER
                return _editedAccount;
            };

             return null;
        }


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


        public List<ClassTransaction> GetStatement(int accountId, DateTime startDate, DateTime endDate)
        {
            return MySqlClient.GetListTransactionsBetweenDates(accountId, startDate, endDate);
        }

        internal string GetSavingsBalance(int employeeId)
        {
            return MySqlClient.GetSavingsBalance(employeeId);
        }

        internal string GetChequingBalance(int employeeId)
        {
            return MySqlClient.GetChequingBalance(employeeId);
        }

        internal string GetCountCustomers(int employeeId)
        {
            return MySqlClient.GetCountCustomers(employeeId);
        }
    }
}
