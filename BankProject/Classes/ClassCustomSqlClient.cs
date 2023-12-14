﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Shapes;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Windows.Controls;

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

        

        public (ClassUserLogged?, int?) AuthenticateLogin(string inputEmail, string inputPassword) {
            //Build Select Query
            string selectQuery = "SELECT employeeId, firstName, lastName, email, positionId, branchId ";
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
                                ClassUserLogged MyUserLogged = new ClassUserLogged() {
                                    EmployeeId = (int)myReader["employeeId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["email"],
                                    PositionId = (int)myReader["positionId"]
                                };
                                int MyUserLoggedBranchId = (int)myReader["branchId"];
                                Debug.WriteLine($"Login Sucessful\nLogged in as: {MyUserLogged.FirstName} {MyUserLogged.LastName}\nBranchId: {MyUserLoggedBranchId}");
                                return (MyUserLogged, MyUserLoggedBranchId);
                            }
                            else {
                                MessageBox.Show("Incorrect Credentials!");
                                return (null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return (null, null);
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

                            var listOfAccounts = new List<ClassAbstractAccount>();

                            ClassCustomer customer = new ClassCustomer() {
                                CustomerId = (int)reader["customerId"],
                                FirstName = (string)reader["firstName"],
                                LastName = (string)reader["lastName"],
                                DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(reader["dateOfBirth"])),
                                Document = new ClassDocument () {
                                    DocumentType = (string)reader["documentType"],
                                    DocumentNumber = (string)reader["documentNumber"],
                                    DocumentIssuedDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["documentIssuedDate"])),
                                    DocumentExpirationDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["documentExpirationDate"]))
                                },
                                Address = new ClassAddress() {
                                    ZipCode = (string)reader["zipCode"],
                                    Line1 = (string)reader["line1"],
                                    Line2 = Convert.IsDBNull(reader["line2"]) ? null : (string)reader["line2"],
                                    City = (string)reader["city"],
                                    Province = (string)reader["province"],
                                    Country = (string)reader["country"]
                                },
                                Phone = (string)reader["phoneNumber"],
                                Email = (string)reader["emailAddress"],
                            };
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


        public bool InsertNewBranch(string inputNewBranchName, string inputNewBranchCity) {
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
            List<ClassBranch> _listBranches = new List<ClassBranch>();

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
                                _listBranches.Add(_newBranch);
                            }
                        }
                    }
                }
                return _listBranches;
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public List<ClassCustomer> GetListCustomersOfSpecificBranch(int inputBranchId) {
            //Initialize list of customers
            List<ClassCustomer> _listCustomers = new List<ClassCustomer>();

            //Build Select Query
            string selectQuery = "SELECT * ";
            selectQuery += "FROM dbo.Customers ";
            selectQuery += "WHERE branchId = @BRANCHID; ";

            try {
                using (SqlConnection cnn = new SqlConnection(ConnectionString)) {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn)) {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@BRANCHID", inputBranchId);
                        using (SqlDataReader myReader = cmd.ExecuteReader()) {
                            while (myReader.Read()) {
                                //Create new Branch object
                                ClassCustomer _newCustomer = new ClassCustomer() {
                                    CustomerId = (int)myReader["customerId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(myReader["dateOfBirth"])),
                                    Document = new ClassDocument() {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = DateOnly.FromDateTime(Convert.ToDateTime(myReader["documentIssuedDate"])),
                                        DocumentExpirationDate = DateOnly.FromDateTime(Convert.ToDateTime(myReader["documentExpirationDate"])),
                                    },
                                    Address = new ClassAddress() {
                                        ZipCode = (string)myReader["zipCode"],
                                        Line1 = (string)myReader["line1"],
                                        Line2 = Convert.IsDBNull(myReader["line2"]) ? null : (string)myReader["line2"],
                                        City = (string)myReader["city"],
                                        Province = (string)myReader["province"],
                                        Country = (string)myReader["country"]
                                    },
                                    Phone = (string)myReader["phoneNumber"],
                                    Email = (string)myReader["emailAddress"]
                                };
                                _listCustomers.Add(_newCustomer);
                            }
                        }
                    }
                }
                return _listCustomers;
            }
            catch (Exception ex) {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }
















        public int CreateNewCustomer(string firstName, string lastName, string dateOfBirth,
           string documentType, string documentNumber, string documentIssuedDate,
           string documentExpirationDate, string zipCode, string line1, string line2,
           string city, string province, string country, string phoneNumber, string emailAddress,
           string branchId, string financialAdvisorId)
        {
            //Build Insert Query


            string insertQuery = "INSERT INTO dbo.Customers (firstName, lastName, dateOfBirth, documentType," +
            " documentNumber, documentIssuedDate, documentExpirationDate, zipCode, line1, line2, city, province," +
            "country, phoneNumber, emailAddress, branchId, financialAdvisorID ) ";
            //string insertQuery = "INSERT INTO dbo.Customers (firstName, lastName, email, phone, positionId, password) ";
            insertQuery += $"VALUES (@FIRSTNAME, @LASTNAME, @DATEOFBIRTH, @DOCUMENTTYPE, @DOCUMENTNUMBER," +
                $"@DOCUMENTISSUEDDATE, @DOCUMENTEXPIRATIONDATE, @ZIPCODE, @LINE1, @LINE2, @CITY, @PROVINCE," +
                $"@COUNTRY, @PHONENUMBER, @EMAILADDRESS, @BRANCHID, @FINANCIALADVISORID); ";
            //insertQuery += $"VALUES (@FIRSTNAME, @LASTNAME, @EMAIL, @PHONE, @POSITIONID, @PASSWORD); ";

            string selectQuery = "SELECT customerId FROM dbo.Customers ";
            selectQuery += "WHERE firstName = @FIRSTNAME ";
            selectQuery += " AND lastName = @LASTNAME ";
            selectQuery += " AND dateOfBirth = @DATEOFBIRTH";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@FIRSTNAME", firstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", lastName);
                        cmd.Parameters.AddWithValue("@DATEOFBIRTH", dateOfBirth);
                        cmd.Parameters.AddWithValue("@DOCUMENTTYPE", documentType);
                        cmd.Parameters.AddWithValue("@DOCUMENTNUMBER", documentNumber);
                        cmd.Parameters.AddWithValue("@DOCUMENTISSUEDDATE", documentIssuedDate);
                        cmd.Parameters.AddWithValue("@DOCUMENTEXPIRATIONDATE", documentExpirationDate);
                        cmd.Parameters.AddWithValue("@ZIPCODE", zipCode);
                        cmd.Parameters.AddWithValue("@LINE1", line1);
                        cmd.Parameters.AddWithValue("@LINE2", line2);
                        cmd.Parameters.AddWithValue("@CITY", city);
                        cmd.Parameters.AddWithValue("@PROVINCE", province);
                        cmd.Parameters.AddWithValue("@COUNTRY", country);
                        cmd.Parameters.AddWithValue("@PHONENUMBER", phoneNumber);
                        cmd.Parameters.AddWithValue("@EMAILADDRESS", emailAddress);
                        cmd.Parameters.AddWithValue("@BRANCHID", branchId);
                        cmd.Parameters.AddWithValue("@FINANCIALADVISORID", financialAdvisorId);

                        cmd.ExecuteNonQuery();
                    }
                }

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@FIRSTNAME", firstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", lastName);
                        cmd.Parameters.AddWithValue("@DATEOFBIRTH", dateOfBirth);

                        return (int)cmd.ExecuteScalar();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return 0;
            }
        }

        internal bool UpdateCustomer(string customerId, string firstName, string lastName, string dateOfBirth, string documentType, string documentNumber, string documentIssuedDate, string documentExpirationDate, string zipCode, string line1, string line2, string city, string province, string country, string phoneNumber, string emailAddress, string branchId, string financialAdvisorId)
        {
            //Build Update Query


            string updateQuery = "UPDATE dbo.Customers ";
            updateQuery += "SET firstName = @FIRSTNAME, lastName = @LASTNAME, dateOfBirth = @DATEOFBIRTH, ";
            updateQuery += " documentType = @DOCUMENTTYPE, documentNumber = @DOCUMENTNUMBER, documentIssuedDate = @DOCUMENTISSUEDDATE, "; ;
            updateQuery += " documentExpirationDate = @DOCUMENTEXPIRATIONDATE, zipCode = @ZIPCODE, line1 = @LINE1, line2 = @LINE2, ";
            updateQuery += " city = @CITY, province = @PROVINCE, country = @COUNTRY, phoneNumber = @PHONENUMBER, emailAddress = @EMAILADDRESS, branchId = @BRANCHID, financialAdvisorID = @FINANCIALADVISORID ";
            updateQuery += " WHERE customerId = @CUSTOMERID ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", customerId);
                        cmd.Parameters.AddWithValue("@FIRSTNAME", firstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", lastName);
                        cmd.Parameters.AddWithValue("@DATEOFBIRTH", dateOfBirth);
                        cmd.Parameters.AddWithValue("@DOCUMENTTYPE", documentType);
                        cmd.Parameters.AddWithValue("@DOCUMENTNUMBER", documentNumber);
                        cmd.Parameters.AddWithValue("@DOCUMENTISSUEDDATE", documentIssuedDate);
                        cmd.Parameters.AddWithValue("@DOCUMENTEXPIRATIONDATE", documentExpirationDate);
                        cmd.Parameters.AddWithValue("@ZIPCODE", zipCode);
                        cmd.Parameters.AddWithValue("@LINE1", line1);
                        cmd.Parameters.AddWithValue("@LINE2", line2);
                        cmd.Parameters.AddWithValue("@CITY", city);
                        cmd.Parameters.AddWithValue("@PROVINCE", province);
                        cmd.Parameters.AddWithValue("@COUNTRY", country);
                        cmd.Parameters.AddWithValue("@PHONENUMBER", phoneNumber);
                        cmd.Parameters.AddWithValue("@EMAILADDRESS", emailAddress);
                        cmd.Parameters.AddWithValue("@BRANCHID", branchId);
                        cmd.Parameters.AddWithValue("@FINANCIALADVISORID", financialAdvisorId);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                return false;
            }
        }
    }
}