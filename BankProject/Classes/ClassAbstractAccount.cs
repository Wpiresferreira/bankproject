using System;
using System.Collections.Generic;

namespace BankProject.Classes
{
    // Class representing an abstract bank account
    public class ClassAbstractAccount : IComparable<ClassAbstractAccount>
    {

        // Properties of the account
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public float Balance { get; set; }
        public DateTime MostRecentActivity { get; set; }
        public List<ClassTransaction> MyListTransactions { get; set; }


        // Constructor to initialize the account
        public ClassAbstractAccount() {

        }


        // Method required by the IComparable interface to compare accounts based on balance
        public int CompareTo(ClassAbstractAccount otherAccount) {
            return this.Balance.CompareTo(otherAccount.Balance);
        }
    }
}
