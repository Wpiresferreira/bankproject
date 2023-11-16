using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject {
    public class ClassUserLogged {

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }

        public ClassUserLogged(int employeeId, string firstName, string lastName, string email, int positionId) {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PositionId = positionId;
        }
    }
}
