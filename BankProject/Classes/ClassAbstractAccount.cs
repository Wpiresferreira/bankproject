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
        public List<ClassTransaction> MyListAbstractTransactions { get; set; }

        // Constructor to initialize the account
        public ClassAbstractAccount()
        {
            MyListAbstractTransactions = new List<ClassTransaction>();
        }

        // Method to deposit money into the account
        public string Deposit(float amount)
        {
            if (amount > 0)
            {
                // Update balance and record transaction
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

        // Method to withdraw money from the account
        public string Withdraw(float amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                // Update balance and record transaction
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

        // Method to check the account balance
        public string CheckBalance()
        {
            return $"Account Balance: {Balance:C}";
        }

        // Method to generate a statement of all transactions
        public string CheckStatement()
        {
            string statement = "";
            foreach (var transaction in MyListAbstractTransactions)
            {
                statement += transaction.ToString() + "\n";
            }
            return statement;
        }

        // Method to transfer money to another account
        public string Transfer(float amount, int targetAccountId)
        {
            if (amount > 0 && amount <= Balance)
            {
                // Update balances and record transactions for both accounts
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

        // Method required by the IComparable interface to compare accounts based on balance
        public int CompareTo(ClassAbstractAccount otherAccount)
        {
            return this.Balance.CompareTo(otherAccount.Balance);
        }
    }
}
