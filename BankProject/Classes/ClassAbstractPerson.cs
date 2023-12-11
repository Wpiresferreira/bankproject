using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public abstract class ClassAbstractPerson {

        public string Email { get; set; }
        protected string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    

        public virtual void ChangePassword(string password) {
            Password = password;
        }

    }
}
