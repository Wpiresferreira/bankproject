using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassBranch {

        public int BranchId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<ClassCustomer>? MyListCustomers { get; set; }
        public List<ClassEmployee>? MyListEmployees { get; set; }


        public ClassBranch() {
        
        }


        public ClassBranch(int branchId, string name, string city)
        {
            BranchId = branchId;
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
            _result += $"BranchId :{BranchId}\n";
            _result += $"Name :{Name}\n";
            _result += $"City :{City} \n";
            _result += $"MyListCustomers : [\n";
            if (MyListCustomers != null) {
                foreach(ClassCustomer c in MyListCustomers) {
                    _result += $"{c} \n";
                }
            }
            _result += $"]\n";
            _result += $"MyListEmployees : [\n";
            if(MyListEmployees != null) {
                foreach(ClassEmployee e in MyListEmployees) {
                    _result += $"{e} \n";
                }
            }
            _result += $"]\n";
            return _result;
        }
    }

}
