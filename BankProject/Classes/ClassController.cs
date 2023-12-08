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

        public bool ConnectToLocalDatabase { get; set; }
        public string ConnectionString { get; set; }
        public ClassUserLogged? MyUserLogged { get; set; }
        public List<ClassBranch> MyListBranches { get; set; }


        public ClassController(bool connectToLocalDatabase)
        {

            ConnectToLocalDatabase = connectToLocalDatabase;
            MyUserLogged = null;

            //Build Connection String
            if (ConnectToLocalDatabase)
            {
                //string connetionString = "Server=MSI\\SQLEXPRESS; Database= bankproject;User Id=test;Password=123;";              //Old Connection String (DELETE)
                string path_RootFolder = $"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent}";
                //Debug.WriteLine(path_RootFolder);                                                                                 //DEBUG (DELETE)
                ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; ";
                ConnectionString += $"AttachDbFilename={path_RootFolder}\\bankproject.mdf; ";
                ConnectionString += "Integrated Security=True; ";
            }
            else
            {
                ConnectionString = "Server=tcp:137.186.165.104,49172; ";
                ConnectionString += "Database=bankproject; ";
                ConnectionString += "User Id=test; ";
                ConnectionString += "Password=123; ";
            }
        }


        public void AuthenticateLogin(string _email, string _password)
        {
            //Build Select Query
            string selectQuery = "SELECT employeeID, firstName , lastName, email, positionId ";
            selectQuery += "FROM dbo.Employees ";
            selectQuery += $"WHERE email = '{_email}' AND password = '{_password}'; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {

                                //Create MyUserLogged Object
                                MyUserLogged = new ClassUserLogged((int)myReader[0], (string)myReader[1], (string)myReader[2], (string)myReader[3], (int)myReader[4]);
                                Debug.WriteLine($"Login Sucessful\nLogged in as: {MyUserLogged.FirstName} {MyUserLogged.LastName}");
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Credentials!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
            }
        }
    }
}
