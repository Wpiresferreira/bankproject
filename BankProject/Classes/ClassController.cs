using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject.Classes {
    public class ClassController {

        private ClassCustomSqlClient MySqlClient { get; set; }
        public ClassUserLogged? MyUserLogged { get; set; }
        public List<ClassBranch>? MyListBranches { get; set; }


        public ClassController()
        {
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


        public bool CreateNewBranch(string _nameNewBranch, string _cityNewBranch) {
            
            //Create new Branch on the database
            if(MySqlClient.InsertNewBranch(_nameNewBranch, _cityNewBranch)) {
                //Refresh list of branches in the model (needs to be updated from the database to get the branchId of the new branch created)
                PopulateMyListBranches();
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
             if(MySqlClient.CreateTransaction(inputAccountIdDestination, 0, inputAmountToCredit, _accountIdOrigin)) {
                PopulateMyListBranches();
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
             if(MySqlClient.CreateTransaction(inputAccountIdOrigin, inputAmountToDebit, 0, _accountIdDestination)) {
                PopulateMyListBranches();
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
             if(MySqlClient.CreateTransaction(inputAccountIdOrigin, inputAmountToTransfer, 0, inputAccountIdDestination)) {
                PopulateMyListBranches();
                return true;
            };

             return false;
        }
    }
}
