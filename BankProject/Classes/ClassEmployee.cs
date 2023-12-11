using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassEmployee : ClassAbstractPerson {

        public int IdEmployee { get; set; }
        public ClassEmployee? Manager { get; set; }
        public DateOnly StartDate { get; set; }


        public void SetManager(ClassEmployee newManager) {
            Manager = newManager;
        }


        public override string ToString() {
            string _result = $"IdEmployee: {IdEmployee}";
            _result += $" | First Name: {FirstName}";
            _result += $" | Last Name: {LastName}";
            _result += $" | Email: {Email}";

            return _result;
        }
    }
}
