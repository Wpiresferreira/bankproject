using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassBranch {

        public int IdBranch { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<ClassCustomer>? MyListCustomers { get; set; }
        public List<ClassEmployee>? MyListEmployees { get; set; }


        public ClassBranch() {
        
        }

        public ClassBranch(int idBranch, string name, string city)
        {
            IdBranch = idBranch;
            Name = name;
            City = city;
            MyListCustomers = null;
            MyListEmployees = null;
        }


        public string DetailsAllMyCustomers() {
            string _result = string.Empty;
            return _result;
        }


        public string DetailsAllMyEmployees() {
            string _result = string.Empty;
            return _result;
        }


        public override string ToString() {
            string _result = string.Empty;
            _result += $"IdBranch :{IdBranch}";
            _result += $" | Name :{Name}";
            _result += $" | City :{City}";
            return _result;
        }
    }

}
