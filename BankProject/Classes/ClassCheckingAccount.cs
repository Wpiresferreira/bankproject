using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassCheckingAccount : ClassAbstractAccount {

        public bool IsOverdrafted { get; set; }
        public List<ClassCheckingTransaction> MyListCheckingTransactions { get; set; }
        public float MontlhyFee { get; set; }
        

        public bool CheckIsOverdrafted() {
            return IsOverdrafted;
        }


        public override string ToString() {
            string _result = $"IdAccount: {IdAccount}";
            _result += $" | Balance: {Balance}";
            _result += $" | MostRecentActivity: {MostRecentActivity}";
            _result += $" | IsOverdrafted: {IsOverdrafted}";

            return _result;
        }
    }
}
