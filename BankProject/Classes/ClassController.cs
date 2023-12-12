using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject.Classes
{
    public class ClassController
    {
        private ClassCustomSqlClient MySqlClient { get; set; }
        public ClassUserLogged? MyUserLogged { get; set; }
        public List<ClassBranch>? MyListBranches { get; set; }


        public ClassController()
        {
            MySqlClient = new ClassCustomSqlClient();
            MyUserLogged = null;
            MyListBranches = new List<ClassBranch>();

        }


        


        public void CreateNewBranch()
        {

        }
    }
}
