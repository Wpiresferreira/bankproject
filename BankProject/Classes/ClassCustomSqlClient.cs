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


        public bool CreateNewEmployee(string insertQuery) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn)) {
                        cnn.Open();
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


        public ClassUserLogged AuthenticateLogin(string _email, string _password) {
            //Build Select Query
            string selectQuery = "SELECT employeeId, firstName, lastName, email, positionId ";
            selectQuery += "FROM dbo.Employees ";
            selectQuery += $"WHERE email = '{_email}' AND password = '{_password}'; ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        using (SqlDataReader myReader = cmd.ExecuteReader()) {
                            if (myReader.Read()) {
                                //Create MyUserLogged Object
                                ClassUserLogged MyUserLogged = new ClassUserLogged((int)myReader[0], (string)myReader[1], (string)myReader[2], (string)myReader[3], (int)myReader[4]);
                                Debug.WriteLine($"Login Sucessful\nLogged in as: {MyUserLogged.FirstName} {MyUserLogged.LastName}");
                                return MyUserLogged;
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Credentials!");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }

            //selectQuery = "SELECT * FROM Branches";

            //try {
            //    using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
            //        using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
            //            cnn.Open();
            //            using (SqlDataReader myReader = cmd.ExecuteReader()) {
            //                while (myReader.Read()) {
            //                    //Update List of Branches
            //                    var branch = new ClassBranch((int)myReader[0], myReader[1].ToString(), myReader[2].ToString());
            //                    MyListBranches.Add(branch);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex) {
            //    MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
            //}
        }


        public ClassCustomer? SearchCustomer(string selectQuery) {
            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
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
                            branch,
                            listOfAccounts
                        );

                        return customer;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }
    }
}
