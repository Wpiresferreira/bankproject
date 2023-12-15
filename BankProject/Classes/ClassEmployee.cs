using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassEmployee : ClassAbstractPerson {

        public int EmployeeId { get; set; }
        protected string Password { get; set; }
        public ClassEmployee? Manager { get; set; }
        public DateOnly StartDate { get; set; }
        public int PositionId { get; set; }


        public void SetManager(ClassEmployee newManager) {
            Manager = newManager;
        }

        public virtual void ChangePassword(string password) {
            Password = password;
        }


        public override string ToString() {
            string _result = $"EmployeeId: {EmployeeId}\n";
            _result += $"First Name: {FirstName}\n";
            _result += $"Last Name: {LastName}\n";
            _result += $"Email: {Email}\n";

            return _result;
        }
    }
}
