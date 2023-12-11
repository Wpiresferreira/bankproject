using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassCheckingTransaction : ClassAbstractTransaction {

        public bool IsTransactionInOverdraft { get; set; }
        public float AmountInOverdraft { get; set; }


        public override string ToString() {
            string _result = $"[CHECKING TRANSACTION]";
            _result += $" IdTransaction: {IdTransaction}";
            _result += $" | Amount: {Amount}";
            _result += $" | DatetimeTransaction: {DatetimeTransaction}";
            _result += $" | IsTransactionInOverdraft: {IsTransactionInOverdraft}";
            _result += $" | AmountInOverdraft: {AmountInOverdraft}";

            return _result;
        }
    }
}
