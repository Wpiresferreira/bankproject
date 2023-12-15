using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassTransaction {

        public int TransactionId {  get; set; }
        public int AccountId { get; set; }
        public DateTime DatetimeTransaction { get; set; }
        public float AmountDebit {  get; set; }
        public float AmountCredit {  get; set; }
        public int OtherAccountId { get; set; }

        public string TypeTransaction {  get; set; }

        

        public override string ToString() {
            string _result = $"[TRANSACTION]";
            _result += $" TransactionId: {TransactionId}";
            _result += $" | AccountId: {AccountId}";
            _result += $" | DatetimeTransaction: {DatetimeTransaction}";
            _result += $" | AmountDebit: {AmountDebit}";
            _result += $" | AmountCredit: {AmountCredit}";
            _result += $" | OtherAccountId: {OtherAccountId}";
            _result += $" | TypeTransaction: {TypeTransaction}";

            return _result;
        }
    }
}
