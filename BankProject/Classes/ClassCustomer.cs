using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassCustomer : ClassAbstractPerson {

        public int IdCustomer { get; set; }
        public ClassEmployee? FinancialAdvisor { get; set; }
        public List<ClassAbstractAccount>? MyListAccounts { get; set; }


        public string DetailsAllMyAccounts() {
            string _result = string.Empty;
            return _result;
        }

        public void SetFinancialAdvisor(ClassEmployee newFinancialAdvisor) {
            FinancialAdvisor = newFinancialAdvisor;
        }


        public override string ToString() {
            string _result = $"IdCustomer: {IdCustomer}";
            _result += $" | First Name: {FirstName}";
            _result += $" | Last Name: {LastName}";
            _result += $" | Email: {Email}";

            return _result;
        }
    }
}
