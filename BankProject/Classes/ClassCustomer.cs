using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BankProject.Classes
{
    public class ClassCustomer : ClassAbstractPerson
    {
        public int CustomerId { get; set; }
        public ClassEmployee? FinancialAdvisor { get; set; }
        public List<ClassAbstractAccount>? MyListAccounts { get; set; }


        public ClassCustomer() {

        }



        public override string ToString()
        {
            string _result = $"CustomerId: {CustomerId}\n";
            _result += $"FirstName: {FirstName}\n";
            _result += $"LastName: {LastName}\n";
            _result += $"DateOfBirth: {DateOfBirth}\n";
            _result += $"Document: {Document}\n";
            _result += $"Address: {Address}\n";
            _result += $"Phone: {Phone}\n";
            _result += $"Email: {Email}\n";
            return _result;
        }


        public string DetailsAllMyAccounts()
        {
            string _result = string.Empty;
            return _result;
        }

    }


    
}
