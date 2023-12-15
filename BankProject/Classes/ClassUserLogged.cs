using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassUserLogged : ClassEmployee {
        public int BranchId { get; set; }


        public ClassUserLogged() {

        }


        public ClassUserLogged(int employeeId, string firstName, string lastName, string email, int positionId) {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PositionId = positionId;
        }

        public override string ToString() {
            string _result = string.Empty;
            _result += $"EmployeeId: {EmployeeId}" + Environment.NewLine;
            _result += $"FirstName: {FirstName}" + Environment.NewLine;
            _result += $"LastName: {LastName}" + Environment.NewLine;
            _result += $"Email: {Email}" + Environment.NewLine;
            _result += $"PositionId: {PositionId}";
            return _result;
        }
    }
}
