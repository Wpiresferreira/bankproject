using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassSavingsAccount : ClassAbstractAccount {

        private float InterestRate { get; set; }
        public List<ClassSavingsTransaction> MyListSavingsTransactions { get; set; }


        public void SetInterestRate(float newInterestRate) {
            InterestRate = newInterestRate;
        }


        public override string ToString() {
            string _result = $"IdAccount: {IdAccount}";
            _result += $" | Balance: {Balance}";
            _result += $" | MostRecentActivity: {MostRecentActivity}";
            _result += $" | InterestRate: {InterestRate}";

            return _result;
        }
    }
}
