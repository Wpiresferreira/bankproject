using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject.Classes {
    internal class ClassCustomSqlClient {

        public bool ConnectToLocalDatabase { get; set; }
        private string ConnectionString { get; set; }


        public ClassCustomSqlClient() {
        
            ConnectToLocalDatabase = true;

            //Build Connection String
            if (ConnectToLocalDatabase) {
                //string connetionString = "Server=MSI\\SQLEXPRESS; Database= bankproject;User Id=test;Password=123;";              //Old Connection String (DELETE)
                string path_RootFolder = $"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent}";
                //Debug.WriteLine(path_RootFolder);                                                                                 //DEBUG (DELETE)
                ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; ";
                ConnectionString += $"AttachDbFilename={path_RootFolder}\\bankproject.mdf; ";
                ConnectionString += "Integrated Security=True; ";
            }
            else {
                ConnectionString = "Server=tcp:137.186.165.104,49172; ";
                ConnectionString += "Database=bankproject; ";
                ConnectionString += "User Id=test; ";
                ConnectionString += "Password=123; ";
            }
        }


        public bool CreateNewEmployee(string inputFirstName, string inputLastName, string inputEmail, string inputPhone, string inputPositionId, string inputPassword) {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Employees (firstName, lastName, email, phone, positionId, password) ";
            insertQuery += $"VALUES (@FIRSTNAME, @LASTNAME, @EMAIL, @PHONE, @POSITIONID, @PASSWORD); ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn)) {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@FIRSTNAME", inputFirstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", inputLastName);
                        cmd.Parameters.AddWithValue("@EMAIL", inputEmail);
                        cmd.Parameters.AddWithValue("@PHONE", inputPhone);
                        cmd.Parameters.AddWithValue("@POSITIONID", inputPositionId);
                        cmd.Parameters.AddWithValue("@PASSWORD", inputPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return false;
            }
        }


        public ClassUserLogged AuthenticateLogin(string inputEmail, string inputPassword) {
            //Build Select Query
            string selectQuery = "SELECT employeeId, firstName, lastName, email, positionId ";
            selectQuery += "FROM dbo.Employees ";
            selectQuery += $"WHERE email = @EMAIL AND password = @PASSWORD; ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@EMAIL", inputEmail);
                        cmd.Parameters.AddWithValue("@PASSWORD", inputPassword);
                        using (SqlDataReader myReader = cmd.ExecuteReader()) {
                            if (myReader.Read()) {
                                //Create MyUserLogged Object
                                ClassUserLogged MyUserLogged = new ClassUserLogged((int)myReader[0], (string)myReader[1], (string)myReader[2], (string)myReader[3], (int)myReader[4]);
                                Debug.WriteLine($"Login Sucessful\nLogged in as: {MyUserLogged.FirstName} {MyUserLogged.LastName}");
                                return MyUserLogged;
                            }
                            else {
                                MessageBox.Show("Incorrect Credentials!");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public ClassCustomer? SearchCustomer(string inputCustomerId, string inputFirstName, string inputLastName, string inputDateOfBirth) {
            //Build Select Query
            string selectQuery = "";
            if (inputCustomerId != "") {
                selectQuery = $"SELECT * FROM dbo.Customers ";
                selectQuery += $"WHERE customerId = @CUSTOMERID";
            }
            else {
                selectQuery = $"SELECT * FROM dbo.Customers ";
                selectQuery += $"WHERE firstName = @FIRSTNAME AND lastName = @LASTNAME AND dateOfBirth = @DATEOFBIRTH";
            };

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", inputCustomerId);
                        cmd.Parameters.AddWithValue("@FIRSTNAME", inputFirstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", inputLastName);
                        cmd.Parameters.AddWithValue("@DATEOFBIRTH", inputDateOfBirth);

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            reader.Read();

                            ClassDocument customerDocument = new ClassDocument(reader.GetString(4), reader.GetString(5), DateOnly.FromDateTime(reader.GetDateTime(6)), DateOnly.FromDateTime(reader.GetDateTime(7)));
                            ClassAddress customerAddress = new ClassAddress(reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13));
                            ClassEmployee financialAdvisor = null;
                            ClassBranch branch = null;
                            var listOfAccounts = new List<ClassAbstractAccount>();

                            ClassCustomer customer = new ClassCustomer(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                DateOnly.FromDateTime(reader.GetDateTime(3)),
                                customerDocument,
                                customerAddress,
                                reader.GetString(14),
                                reader.GetString(15),
                                financialAdvisor,
                                listOfAccounts
                            );
                            return customer;
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public bool CreateNewBranch(string inputNewBranchName, string inputNewBranchCity) {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Branches (name, city) ";
            insertQuery += $"VALUES (@NAME, @CITY); ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn)) {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@NAME", inputNewBranchName);
                        cmd.Parameters.AddWithValue("@CITY", inputNewBranchCity);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return false;
            }
        }


        public List<ClassBranch> GetListOfBranches() {
            //Initialize list of branches
            List<ClassBranch> _listClassBranches = new List<ClassBranch>();

            //Build Select Query
            string selectQuery = "SELECT branchId, name, city ";
            selectQuery += "FROM dbo.Branches; ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        using (SqlDataReader myReader = cmd.ExecuteReader()) {
                            while (myReader.Read()) {
                                //Create new Branch object
                                ClassBranch _newBranch = new ClassBranch() {
                                    IdBranch = (int)myReader["branchId"],
                                    Name = (string)myReader["name"],
                                    City = (string)myReader["city"]
                                };
                                _listClassBranches.Add(_newBranch);
                            }
                        }
                    }
                }
                return _listClassBranches;
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }
    }
}
