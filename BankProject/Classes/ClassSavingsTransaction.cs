using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassSavingsTransaction : ClassAbstractTransaction {


        public override string ToString() {
            string _result = $"[SAVINGS TRANSACTION]";
            _result += $" IdTransaction: {IdTransaction}";
            _result += $" | Amount: {Amount}";
            _result += $" | DatetimeTransaction: {DatetimeTransaction}";

            return _result;
        }
    }
}
