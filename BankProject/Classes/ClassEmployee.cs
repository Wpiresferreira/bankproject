using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassEmployee : ClassAbstractPerson {

        public int EmployeeId { get; set; }
        protected string Password { get; set; }
        public DateTime StartDate { get; set; }
        public int PositionId { get; set; }



        public override string ToString() {
            string _result = $"EmployeeId: {EmployeeId}\n";
            _result += $"First Name: {FirstName}\n";
            _result += $"Last Name: {LastName}\n";
            _result += $"Email: {Email}\n";

            return _result;
        }
    }
}
