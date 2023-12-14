using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject.Classes
{
    public class ClassController
    {
        private ClassCustomSqlClient MySqlClient { get; set; }
        public ClassUserLogged? MyUserLogged { get; set; }
        public int? MyUserLoggedBranchId { get; set; }
        public List<ClassBranch>? MyListBranches { get; set; }



        public ClassController()
        {
            MySqlClient = new ClassCustomSqlClient();
            MyUserLogged = null;
            MyListBranches = new List<ClassBranch>();

        }

        public void LoginUser(string inputEmail, string inputPassword) {
            (MyUserLogged, MyUserLoggedBranchId) = MySqlClient.AuthenticateLogin(inputEmail, inputPassword);
            
            if (MyUserLogged != null) {
                //Populate MyController.MyListBranches
                PopulateMyListBranches();
                
                DisplayAllBranches();
            }
        }


        public void PopulateMyListBranches() {
            MyListBranches = MySqlClient.GetListOfBranches();

            foreach (ClassBranch b in MyListBranches) {
                int _branchId = b.IdBranch;
                b.MyListCustomers = MySqlClient.GetListCustomersOfSpecificBranch(_branchId);
                b.MyListEmployees = MySqlClient.GetListEmployeesOfSpecificBranch(_branchId);

                foreach (ClassCustomer c in b.MyListCustomers) {
                    int _customerId = c.CustomerId;
                    c.MyListAccounts = MySqlClient.GetListAccountsOfSpecificCustomer(_customerId);

                    foreach (ClassAbstractAccount aa in c.MyListAccounts) {
                        int _accountId = aa.AccountId;
                        aa.MyListAbstractTransactions = MySqlClient.GetListTransactionsOfSpecificAccount(_accountId);
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
    }
}
