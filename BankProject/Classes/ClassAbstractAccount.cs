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



        public void Deposit (ClassTransaction t) {
            
        }


        public void Withdraw (ClassTransaction t) {
            
        }


        public void CheckBalance () {
            
        }


        public void CheckStatement () {
            
        }


        public void Transfer (ClassTransaction t, int IdAccountTarget) {
            
        }


        public int CompareTo(ClassAbstractAccount otherAccount) {
            return this.Balance.CompareTo(otherAccount.Balance);
        }
    }
}
