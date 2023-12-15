using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassAbstractAccount : IComparable<ClassAbstractAccount> {

        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public float Balance {  get; set; }
        public DateTime MostRecentActivity { get; set; }
        public List<ClassTransaction> MyListAbstractTransactions { get; set; }

        public ClassAbstractAccount()
        {
            MyListAbstractTransactions = new List<ClassTransaction>();
        }

        public string Deposit(float amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                MostRecentActivity = DateTime.Now;
                var depositTransaction = new ClassTransaction
                {
                    AccountId = this.AccountId,
                    DatetimeTransaction = MostRecentActivity,
                    AmountCredit = amount
                };
                MyListAbstractTransactions.Add(depositTransaction);
                return $"Deposited {amount:C} successfully. New balance: {Balance:C}";
            }
            else
            {
                return "Invalid deposit amount.";
            }
        }



        public string Withdraw(float amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                MostRecentActivity = DateTime.Now;
                var withdrawalTransaction = new ClassTransaction
                {
                    AccountId = this.AccountId,
                    DatetimeTransaction = MostRecentActivity,
                    AmountDebit = amount
                };
                MyListAbstractTransactions.Add(withdrawalTransaction);
                return $"Withdrawal of {amount:C} successful. New balance: {Balance:C}";
            }
            else
            {
                return "Invalid withdrawal amount or insufficient funds.";
            }
        }


        public string  CheckBalance()
        {
            return $"Account Balance: {Balance:C}";
        }



        public string CheckStatement()
        {
            string statement = "";

            foreach (var transaction in MyListAbstractTransactions)
            {
                statement += transaction.ToString() + "\n";
            }

            return statement;
        }


        public string Transfer(float amount, int targetAccountId)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                MostRecentActivity = DateTime.Now;

                var transferDebitTransaction = new ClassTransaction
                {
                    AccountId = this.AccountId,
                    DatetimeTransaction = MostRecentActivity,
                    AmountDebit = amount,
                    OtherAccountId = targetAccountId
                };
                MyListAbstractTransactions.Add(transferDebitTransaction);

                // Simulate credit transaction on the target account
                var transferCreditTransaction = new ClassTransaction
                {
                    AccountId = targetAccountId,
                    DatetimeTransaction = MostRecentActivity,
                    AmountCredit = amount,
                    OtherAccountId = this.AccountId
                };


               return $"Transfer of {amount:C} to Account ID {targetAccountId} successful. New balance: {Balance:C}";
            }
            else
            {
               return "Invalid transfer amount or insufficient funds.";
            }
        }


        public int CompareTo(ClassAbstractAccount otherAccount) {
            return this.Balance.CompareTo(otherAccount.Balance);
        }
    }
}
