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
using BankProject.UserControls;
using System.Windows.Controls.Primitives;

namespace BankProject.Classes
{
    internal class ClassCustomSqlClient
    {

        public bool ConnectToLocalDatabase { get; set; }
        private string ConnectionString { get; set; }


        public ClassCustomSqlClient()
        {
            ConnectToLocalDatabase = true;

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


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ---------------------------------------------------- LOGGED USER METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public ClassUserLogged? AuthenticateLogin(string inputEmail, string inputPassword)
        {
            //Build Select Query
            string selectQuery = "SELECT employeeId, firstName, lastName, emailAddress, positionId, branchId ";
            selectQuery += "FROM dbo.Employees ";
            selectQuery += $"WHERE emailAddress = @EMAIL AND password = @PASSWORD; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@EMAIL", inputEmail);
                        cmd.Parameters.AddWithValue("@PASSWORD", inputPassword);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                //Create MyUserLogged Object
                                ClassUserLogged MyUserLogged = new ClassUserLogged()
                                {
                                    EmployeeId = (int)myReader["employeeId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["emailAddress"],
                                    PositionId = (int)myReader["positionId"],
                                    BranchId = (int)myReader["branchId"]
                                };
                                Debug.WriteLine($"Login Sucessful\nLogged in as: {MyUserLogged.FirstName} {MyUserLogged.LastName}\nBranchId: {MyUserLogged.BranchId}");
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
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }



        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------- BRANCH METHODS -----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public ClassBranch InsertNewBranch(string inputNewBranchName, string inputNewBranchCity)
        {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Branches (name, city) ";
            insertQuery += $"VALUES (@NAME, @CITY); ";

            //Select Query
            string selectQuery = "SELECT * FROM dbo.Branches ";
            selectQuery += $"WHERE name = @NAME AND city = @CITY; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@NAME", inputNewBranchName);
                        cmd.Parameters.AddWithValue("@CITY", inputNewBranchCity);
                        cmd.ExecuteNonQuery();
                    }
                }

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@NAME", inputNewBranchName);
                        cmd.Parameters.AddWithValue("@CITY", inputNewBranchCity);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                //Create new Branch object
                                ClassBranch _newBranch = new ClassBranch()
                                {
                                    BranchId = (int)myReader["branchId"],
                                    Name = (string)myReader["name"],
                                    City = (string)myReader["city"]
                                };
                                return _newBranch;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public List<ClassBranch> GetListOfBranches()
        {
            //Initialize list of branches
            List<ClassBranch> _listBranches = new List<ClassBranch>();

            //Build Select Query
            string selectQuery = "SELECT branchId, name, city ";
            selectQuery += "FROM dbo.Branches; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new Branch object
                                ClassBranch _newBranch = new ClassBranch()
                                {
                                    BranchId = (int)myReader["branchId"],
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
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }



        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------ EMPLOYEE METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public ClassEmployee InsertNewEmployee(
            string inputFirstName, string inputLastName, string inputEmailAddress, string inputPhoneNumber, int inputPositionId,
            string inputPassword, int inputBranchId, DateTime inputStartDate, DateTime inputDateOfBirth, string inputZipCode,
            string inputLine1, string inputLine2, string inputCity, string inputProvince, string inputCountry,
            string inputDocumentType, string inputDocumentNumber, string inputDocumentIssuedDate, string inputDocumentExpirationDate
        )
        {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Employees (firstName, lastName, emailAddress, phoneNumber, positionId, password, branchId, startDate, dateOfBirth, zipCode, line1, line2, city, province, country, documentType, documentNumber, documentIssuedDate, documentExpirationDate) ";
            insertQuery += $"VALUES (@FIRSTNAME, @LASTNAME, @EMAILADDRESS, @PHONENUMBER, @POSITIONID, @PASSWORD, @BRANCHID, @STARTDATE, @DATEOFBIRTH, @ZIPCODE, @LINE1, @LINE2, @CITY, @PROVINCE, @COUNTRY, @DOCUMENTTYPE, @DOCUMENTNUMBER, @DOCUMENTISSUEDDATE, @DOCUMENTEXPIRATIONDATE); ";

            //Select Query
            string selectQuery = "SELECT * FROM dbo.Employees ";
            selectQuery += $"WHERE emailAddress = @EMAILADDRESS; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    //Do insert Employee
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@FIRSTNAME", inputFirstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", inputLastName);
                        cmd.Parameters.AddWithValue("@EMAILADDRESS", inputEmailAddress);
                        cmd.Parameters.AddWithValue("@PHONENUMBER", inputPhoneNumber);
                        cmd.Parameters.AddWithValue("@POSITIONID", inputPositionId);
                        cmd.Parameters.AddWithValue("@PASSWORD", inputPassword);
                        cmd.Parameters.AddWithValue("@BRANCHID", inputBranchId);
                        cmd.Parameters.AddWithValue("@STARTDATE", inputStartDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@DATEOFBIRTH", inputDateOfBirth.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ZIPCODE", inputZipCode);
                        cmd.Parameters.AddWithValue("@LINE1", inputLine1);
                        cmd.Parameters.AddWithValue("@LINE2", inputLine2);
                        cmd.Parameters.AddWithValue("@CITY", inputCity);
                        cmd.Parameters.AddWithValue("@PROVINCE", inputProvince);
                        cmd.Parameters.AddWithValue("@COUNTRY", inputCountry);
                        cmd.Parameters.AddWithValue("@DOCUMENTTYPE", inputDocumentType);
                        cmd.Parameters.AddWithValue("@DOCUMENTNUMBER", inputDocumentNumber);
                        cmd.Parameters.AddWithValue("@DOCUMENTISSUEDDATE", inputDocumentIssuedDate);
                        cmd.Parameters.AddWithValue("@DOCUMENTEXPIRATIONDATE", inputDocumentExpirationDate);
                        cmd.ExecuteNonQuery();
                    }

                    //Retrieve inserted Employee
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@EMAILADDRESS", inputEmailAddress);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassEmployee _newEmployee = new ClassEmployee()
                                {
                                    EmployeeId = (int)myReader["employeeId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["emailAddress"],
                                    Phone = (string)myReader["phoneNumber"],
                                    PositionId = (int)myReader["positionId"],
                                    StartDate = (DateTime)myReader["startDate"],
                                    DateOfBirth = (DateTime)myReader["dateOfBirth"],
                                    Address = new ClassAddress()
                                    {
                                        ZipCode = (string)myReader["zipCode"],
                                        Line1 = (string)myReader["line1"],
                                        Line2 = Convert.IsDBNull(myReader["line2"]) ? null : (string)myReader["line2"],
                                        City = (string)myReader["city"],
                                        Province = (string)myReader["province"],
                                        Country = (string)myReader["country"]
                                    },
                                    Document = new ClassDocument()
                                    {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = (DateTime)myReader["documentIssuedDate"],
                                        DocumentExpirationDate = (DateTime)myReader["documentExpirationDate"],
                                    },
                                };
                                return _newEmployee;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public List<ClassEmployee> GetListEmployeesOfSpecificBranch(int inputBranchId)
        {
            //Initialize list of employees
            List<ClassEmployee> _listEmployees = new List<ClassEmployee>();

            //Build Select Query
            string selectQuery = "SELECT * ";
            selectQuery += "FROM dbo.Employees ";
            selectQuery += "WHERE branchId = @BRANCHID; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@BRANCHID", inputBranchId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new Employee object
                                ClassEmployee _newEmployee = new ClassEmployee()
                                {
                                    EmployeeId = (int)myReader["employeeId"],
                                    //Not Retrieving Password (On purpose)
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["emailAddress"],
                                    Phone = (string)myReader["phoneNumber"],
                                    PositionId = (int)myReader["positionId"],
                                    StartDate = (DateTime)myReader["startDate"],
                                    DateOfBirth = (DateTime)myReader["dateOfBirth"],
                                    Address = new ClassAddress()
                                    {
                                        ZipCode = (string)myReader["zipCode"],
                                        Line1 = (string)myReader["line1"],
                                        Line2 = Convert.IsDBNull(myReader["line2"]) ? null : (string)myReader["line2"],
                                        City = (string)myReader["city"],
                                        Province = (string)myReader["province"],
                                        Country = (string)myReader["country"]
                                    },
                                    Document = new ClassDocument()
                                    {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = (DateTime)myReader["documentIssuedDate"],
                                        DocumentExpirationDate = (DateTime)myReader["documentExpirationDate"],
                                    },
                                };
                                _listEmployees.Add(_newEmployee);
                            }
                        }
                    }
                }
                return _listEmployees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        internal ClassEmployee GetEmployeeById(int employeeId)
        {
            //Build Select Query
            string selectQuery = "";
            selectQuery = $"SELECT * FROM dbo.Employees ";
            selectQuery += $"WHERE employeeId = @EMPLOYEEID";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@EMPLOYEEID", employeeId);

                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            myReader.Read();

                            //Create new Employee object
                                ClassEmployee _employee = new ClassEmployee()
                                {
                                    EmployeeId = (int)myReader["employeeId"],
                                    //Not Retrieving Password (On purpose)
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["emailAddress"],
                                    Phone = (string)myReader["phoneNumber"],
                                    PositionId = (int)myReader["positionId"],
                                    StartDate = (DateTime)myReader["startDate"],
                                    DateOfBirth = (DateTime)myReader["dateOfBirth"],
                                    Address = new ClassAddress()
                                    {
                                        ZipCode = (string)myReader["zipCode"],
                                        Line1 = (string)myReader["line1"],
                                        Line2 = Convert.IsDBNull(myReader["line2"]) ? null : (string)myReader["line2"],
                                        City = (string)myReader["city"],
                                        Province = (string)myReader["province"],
                                        Country = (string)myReader["country"]
                                    },
                                    Document = new ClassDocument()
                                    {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = (DateTime)myReader["documentIssuedDate"],
                                        DocumentExpirationDate = (DateTime)myReader["documentExpirationDate"],
                                    },
                                };
                            return _employee;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------ CUSTOMER METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public ClassCustomer? InsertNewCustomer(
            string firstName, string lastName, DateTime dateOfBirth, string documentType, string documentNumber,
            DateTime documentIssuedDate, DateTime documentExpirationDate, string zipCode, string line1, string line2,
            string city, string province, string country, string phoneNumber, string emailAddress,
            int branchId, int financialAdvisorId)
        {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Customers (firstName, lastName, dateOfBirth, documentType," +
            " documentNumber, documentIssuedDate, documentExpirationDate, zipCode, line1, line2, city, province," +
            "country, phoneNumber, emailAddress, branchId, financialAdvisorID ) ";
            insertQuery += $"VALUES (@FIRSTNAME, @LASTNAME, @DATEOFBIRTH, @DOCUMENTTYPE, @DOCUMENTNUMBER," +
                $"@DOCUMENTISSUEDDATE, @DOCUMENTEXPIRATIONDATE, @ZIPCODE, @LINE1, @LINE2, @CITY, @PROVINCE," +
                $"@COUNTRY, @PHONENUMBER, @EMAILADDRESS, @BRANCHID, @FINANCIALADVISORID); ";

            //Build Select Query
            string selectQuery = "SELECT * FROM dbo.Customers ";
            selectQuery += "WHERE emailAddress = @EMAILADDRESS; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    //Do Customer Insert
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
                    //Retrieve inserted Customer
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@EMAILADDRESS", emailAddress);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassCustomer _newCustomer = new ClassCustomer()
                                {
                                    CustomerId = (int)myReader["customerId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["emailAddress"],
                                    Phone = (string)myReader["phoneNumber"],
                                    DateOfBirth = (DateTime)myReader["dateOfBirth"],
                                    Address = new ClassAddress()
                                    {
                                        ZipCode = (string)myReader["zipCode"],
                                        Line1 = (string)myReader["line1"],
                                        Line2 = Convert.IsDBNull(myReader["line2"]) ? null : (string)myReader["line2"],
                                        City = (string)myReader["city"],
                                        Province = (string)myReader["province"],
                                        Country = (string)myReader["country"]
                                    },
                                    Document = new ClassDocument()
                                    {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = (DateTime)myReader["documentIssuedDate"],
                                        DocumentExpirationDate = (DateTime)myReader["documentExpirationDate"],
                                    },
                                    FinancialAdvisor = GetEmployeeById((int)myReader["financialAdvisorId"]),
                                    MyListAccounts = new List<ClassAbstractAccount>(),
                                };
                                return _newCustomer;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        internal ClassCustomer? UpdateCustomer(
            int customerId, string firstName, string lastName, DateTime dateOfBirth, string documentType,
            string documentNumber, DateTime documentIssuedDate, DateTime documentExpirationDate, string zipCode, string line1,
            string line2, string city, string province, string country, string phoneNumber,
            string emailAddress, int branchId, int financialAdvisorId)
        {
            //Build Update Query
            string updateQuery = "UPDATE dbo.Customers ";
            updateQuery += "SET firstName = @FIRSTNAME, lastName = @LASTNAME, dateOfBirth = @DATEOFBIRTH, ";
            updateQuery += " documentType = @DOCUMENTTYPE, documentNumber = @DOCUMENTNUMBER, documentIssuedDate = @DOCUMENTISSUEDDATE, "; ;
            updateQuery += " documentExpirationDate = @DOCUMENTEXPIRATIONDATE, zipCode = @ZIPCODE, line1 = @LINE1, line2 = @LINE2, ";
            updateQuery += " city = @CITY, province = @PROVINCE, country = @COUNTRY, phoneNumber = @PHONENUMBER, emailAddress = @EMAILADDRESS, branchId = @BRANCHID, financialAdvisorID = @FINANCIALADVISORID ";
            updateQuery += " WHERE customerId = @CUSTOMERID ";

            //Build Select Query
            string selectQuery = "SELECT * FROM dbo.Customers ";
            selectQuery += "WHERE customerId = @CUSTOMERID; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    //Do Customer Update
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
                    }

                    //Retrieve inserted Customer
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@CUSTOMERID", customerId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassCustomer _newCustomer = new ClassCustomer()
                                {
                                    CustomerId = (int)myReader["customerId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    Email = (string)myReader["emailAddress"],
                                    Phone = (string)myReader["phoneNumber"],
                                    DateOfBirth = (DateTime)myReader["dateOfBirth"],
                                    Address = new ClassAddress()
                                    {
                                        ZipCode = (string)myReader["zipCode"],
                                        Line1 = (string)myReader["line1"],
                                        Line2 = Convert.IsDBNull(myReader["line2"]) ? null : (string)myReader["line2"],
                                        City = (string)myReader["city"],
                                        Province = (string)myReader["province"],
                                        Country = (string)myReader["country"]
                                    },
                                    Document = new ClassDocument()
                                    {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = (DateTime)myReader["documentIssuedDate"],
                                        DocumentExpirationDate = (DateTime)myReader["documentExpirationDate"],
                                    },
                                    FinancialAdvisor = GetEmployeeById((int)myReader["financialAdvisorId"]),
                                    MyListAccounts = GetListAccountsOfSpecificCustomer((int)myReader["customerId"]),
                                };
                                return _newCustomer;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public ClassCustomer? SearchCustomer(string inputCustomerId, string inputFirstName, string inputLastName, string inputDateOfBirth)
        {
            //Build Select Query
            string selectQuery = "";
            if (inputCustomerId != "")
            {
                selectQuery = $"SELECT * FROM dbo.Customers ";
                selectQuery += $"WHERE customerId = @CUSTOMERID";
            }
            else
            {
                selectQuery = $"SELECT * FROM dbo.Customers ";
                selectQuery += $"WHERE firstName = @FIRSTNAME AND lastName = @LASTNAME AND dateOfBirth = @DATEOFBIRTH";
            };

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", inputCustomerId);
                        cmd.Parameters.AddWithValue("@FIRSTNAME", inputFirstName);
                        cmd.Parameters.AddWithValue("@LASTNAME", inputLastName);
                        cmd.Parameters.AddWithValue("@DATEOFBIRTH", inputDateOfBirth);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            var listOfAccounts = new List<ClassAbstractAccount>();

                            ClassCustomer customer = new ClassCustomer()
                            {
                                CustomerId = (int)reader["customerId"],
                                FirstName = (string)reader["firstName"],
                                LastName = (string)reader["lastName"],
                                DateOfBirth = (DateTime)reader["dateOfBirth"],
                                Document = new ClassDocument()
                                {
                                    DocumentType = (string)reader["documentType"],
                                    DocumentNumber = (string)reader["documentNumber"],
                                    DocumentIssuedDate = (DateTime)reader["documentIssuedDate"],
                                    DocumentExpirationDate = (DateTime)reader["documentExpirationDate"]
                                },
                                Address = new ClassAddress()
                                {
                                    ZipCode = (string)reader["zipCode"],
                                    Line1 = (string)reader["line1"],
                                    Line2 = Convert.IsDBNull(reader["line2"]) ? null : (string)reader["line2"],
                                    City = (string)reader["city"],
                                    Province = (string)reader["province"],
                                    Country = (string)reader["country"]
                                },
                                Phone = (string)reader["phoneNumber"],
                                Email = (string)reader["emailAddress"],
                                FinancialAdvisor = GetEmployeeById((int)reader["financialAdvisorId"]),
                                MyListAccounts = GetListAccountsOfSpecificCustomer((int)reader["customerId"]),
                            };
                            return customer;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public List<ClassCustomer> GetListCustomersOfSpecificBranch(int inputBranchId)
        {
            //Initialize list of customers
            List<ClassCustomer> _listCustomers = new List<ClassCustomer>();

            //Build Select Query
            string selectQuery = "SELECT * ";
            selectQuery += "FROM dbo.Customers ";
            selectQuery += "WHERE branchId = @BRANCHID AND customerId<>17; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@BRANCHID", inputBranchId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new Customer object
                                ClassCustomer _newCustomer = new ClassCustomer()
                                {
                                    CustomerId = (int)myReader["customerId"],
                                    FirstName = (string)myReader["firstName"],
                                    LastName = (string)myReader["lastName"],
                                    DateOfBirth = (DateTime)myReader["dateOfBirth"],
                                    Document = new ClassDocument()
                                    {
                                        DocumentType = (string)myReader["documentType"],
                                        DocumentNumber = (string)myReader["documentNumber"],
                                        DocumentIssuedDate = (DateTime)myReader["documentIssuedDate"],
                                        DocumentExpirationDate = (DateTime)myReader["documentExpirationDate"],
                                    },
                                    Address = new ClassAddress()
                                    {
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
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        internal ClassCustomer GetCustomerById(int id)
        {
            //Build Select Query
            string selectQuery = "";
            selectQuery = $"SELECT * FROM dbo.Customers ";
            selectQuery += $"WHERE customerId = @CUSTOMERID";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            ClassCustomer customer = new ClassCustomer()
                            {
                                CustomerId = (int)reader["customerId"],
                                FirstName = (string)reader["firstName"],
                                LastName = (string)reader["lastName"],
                                DateOfBirth = (DateTime)reader["dateOfBirth"],
                                Document = new ClassDocument()
                                {
                                    DocumentType = (string)reader["documentType"],
                                    DocumentNumber = (string)reader["documentNumber"],
                                    DocumentIssuedDate = (DateTime)reader["documentIssuedDate"],
                                    DocumentExpirationDate = (DateTime)reader["documentExpirationDate"]
                                },
                                Address = new ClassAddress()
                                {
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
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }



        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------- ACCOUNT METHODS ----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public ClassCheckingAccount? InsertNewCheckingAccount(int customerId, string accountType, float monthlyFee, float interestRate)
        {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Accounts (customerId, balance, mostRecentActivity, interestRate, monthlyFee, isOverdrafted, accountType) ";
            insertQuery += $"VALUES (@CUSTOMERID, @BALANCE, @MOSTRECENTACTIVITY, @INTERESTRATE, @MONTHLYFEE, @ISOVERDRAFTED, @ACCOUNTTYPE); ";

            string selectQuery = "SELECT * FROM dbo.Accounts ";
            selectQuery += "WHERE customerId = @CUSTOMERID ";
            selectQuery += " AND balance = @BALANCE ";
            selectQuery += " AND mostRecentActivity = @MOSTRECENTACTIVITY ";
            selectQuery += " AND interestRate = @INTERESTRATE ";
            selectQuery += " AND monthlyFee = @MONTHLYFEE ";
            selectQuery += " AND isOverdrafted = @ISOVERDRAFTED ";
            selectQuery += " AND accountType = @ACCOUNTTYPE ";
            selectQuery += " ORDER BY accountId  DESC; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", customerId);
                        cmd.Parameters.AddWithValue("@BALANCE", "0");
                        cmd.Parameters.AddWithValue("@MOSTRECENTACTIVITY", DateTime.Now);
                        cmd.Parameters.AddWithValue("@INTERESTRATE", interestRate);
                        cmd.Parameters.AddWithValue("@MONTHLYFEE", monthlyFee);
                        cmd.Parameters.AddWithValue("@ISOVERDRAFTED", false);
                        cmd.Parameters.AddWithValue("@ACCOUNTTYPE", accountType);

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@CUSTOMERID", customerId);
                        cmd.Parameters.AddWithValue("@BALANCE", "0");
                        cmd.Parameters.AddWithValue("@MOSTRECENTACTIVITY", DateTime.Now);
                        cmd.Parameters.AddWithValue("@INTERESTRATE", interestRate);
                        cmd.Parameters.AddWithValue("@MONTHLYFEE", monthlyFee);
                        cmd.Parameters.AddWithValue("@ISOVERDRAFTED", false);
                        cmd.Parameters.AddWithValue("@ACCOUNTTYPE", accountType);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassCheckingAccount _newCheckingAccount = new ClassCheckingAccount()
                                {
                                    AccountId = (int)myReader["accountId"],
                                    CustomerId = (int)myReader["customerId"],
                                    Balance = (float)myReader["balance"],
                                    MostRecentActivity = Convert.ToDateTime(myReader["mostRecentActivity"]),
                                    IsOverdrafted = bool.Parse(myReader["isOverdrafted"].ToString()),
                                    MonthlyFee = (float)myReader["monthlyFee"],
                                    MyListTransactions = new List<ClassTransaction>(),
                                };
                                return _newCheckingAccount;
                            }
                            return null;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public ClassSavingsAccount? InsertNewSavingsAccount(int customerId, string accountType, float monthlyFee, float interestRate)
        {
            //Build Insert Query
            string insertQuery = "INSERT INTO dbo.Accounts (customerId, balance, mostRecentActivity, interestRate, monthlyFee, isOverdrafted, accountType) ";
            insertQuery += $"VALUES (@CUSTOMERID, @BALANCE, @MOSTRECENTACTIVITY, @INTERESTRATE, @MONTHLYFEE, @ISOVERDRAFTED, @ACCOUNTTYPE); ";

            //Build Select Query
            string selectQuery = "SELECT * FROM dbo.Accounts ";
            selectQuery += "WHERE customerId = @CUSTOMERID ";
            selectQuery += " AND balance = @BALANCE ";
            selectQuery += " AND mostRecentActivity = @MOSTRECENTACTIVITY ";
            selectQuery += " AND interestRate = @INTERESTRATE ";
            selectQuery += " AND monthlyFee = @MONTHLYFEE ";
            selectQuery += " AND isOverdrafted = @ISOVERDRAFTED ";
            selectQuery += " AND accountType = @ACCOUNTTYPE ";
            selectQuery += " ORDER BY accountId  DESC; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", customerId);
                        cmd.Parameters.AddWithValue("@BALANCE", "0");
                        cmd.Parameters.AddWithValue("@MOSTRECENTACTIVITY", DateTime.Now);
                        cmd.Parameters.AddWithValue("@INTERESTRATE", interestRate);
                        cmd.Parameters.AddWithValue("@MONTHLYFEE", monthlyFee);
                        cmd.Parameters.AddWithValue("@ISOVERDRAFTED", false);
                        cmd.Parameters.AddWithValue("@ACCOUNTTYPE", accountType);

                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@CUSTOMERID", customerId);
                        cmd.Parameters.AddWithValue("@BALANCE", "0");
                        cmd.Parameters.AddWithValue("@MOSTRECENTACTIVITY", DateTime.Now);
                        cmd.Parameters.AddWithValue("@INTERESTRATE", interestRate);
                        cmd.Parameters.AddWithValue("@MONTHLYFEE", monthlyFee);
                        cmd.Parameters.AddWithValue("@ISOVERDRAFTED", false);
                        cmd.Parameters.AddWithValue("@ACCOUNTTYPE", accountType);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassSavingsAccount _newSavingsAccount = new ClassSavingsAccount()
                                {
                                    AccountId = (int)myReader["accountId"],
                                    CustomerId = (int)myReader["customerId"],
                                    Balance = (float)myReader["balance"],
                                    MostRecentActivity = Convert.ToDateTime(myReader["mostRecentActivity"]),
                                    InterestRate = (float)myReader["interestRate"],
                                    MyListTransactions = new List<ClassTransaction>(),
                                };
                                return _newSavingsAccount;
                            }
                            return null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        internal ClassCheckingAccount? UpdateCheckingAccount(int accountId, int customerId, string accountType, float monthlyFee, float interestRate)
        {
            //Build Update Query
            string updateQuery = "UPDATE dbo.Accounts ";
            updateQuery += "SET monthlyFee = @MONTHLYFEE, interestRate = @INTERESTRATE";
            updateQuery += " WHERE accountId = @ACCOUNTID ";

            //Build Select Query
            string selectQuery = "SELECT * FROM dbo.Accounts ";
            selectQuery += "WHERE accountId = @ACCOUNTID ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    //Do Checking Account Update
                    using (SqlCommand cmd = new SqlCommand(updateQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@MONTHLYFEE", monthlyFee);
                        cmd.Parameters.AddWithValue("@INTERESTRATE", interestRate);
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);

                        cmd.ExecuteNonQuery();
                    }

                    //Retrieve Updated Checking Account
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@ACCOUNTID", customerId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassCheckingAccount _updatedCheckingAccount = new ClassCheckingAccount()
                                {
                                    AccountId = (int)myReader["accountId"],
                                    CustomerId = (int)myReader["customerId"],
                                    Balance = float.Parse(myReader["balance"].ToString()),
                                    MostRecentActivity = Convert.ToDateTime(myReader["mostRecentActivity"]),
                                    IsOverdrafted = bool.Parse(myReader["isOverdrafted"].ToString()),
                                    MonthlyFee = float.Parse(myReader["monthlyFee"].ToString()),
                                    MyListTransactions = GetListTransactionsOfSpecificAccount((int)myReader["accountId"]),
                                };
                                return _updatedCheckingAccount;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        internal ClassSavingsAccount? UpdateSavingsAccount(int accountId, int customerId, string accountType, float monthlyFee, float interestRate)
        {
            //Build Update Query
            string updateQuery = "UPDATE dbo.Accounts ";
            updateQuery += "SET monthlyFee = @MONTHLYFEE, interestRate = @INTERESTRATE";
            updateQuery += " WHERE accountId = @ACCOUNTID ";

            //Build Select Query
            string selectQuery = "SELECT * FROM dbo.Accounts ";
            selectQuery += "WHERE accountId = @ACCOUNTID ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    //Do Savings Account Update
                    using (SqlCommand cmd = new SqlCommand(updateQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@MONTHLYFEE", monthlyFee);
                        cmd.Parameters.AddWithValue("@INTERESTRATE", interestRate);
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);

                        cmd.ExecuteNonQuery();
                    }

                    //Retrieve Updated Savings Account
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@ACCOUNTID", customerId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                ClassSavingsAccount _updatedSavingsAccount = new ClassSavingsAccount()
                                {
                                    AccountId = (int)myReader["accountId"],
                                    CustomerId = (int)myReader["customerId"],
                                    Balance = float.Parse(myReader["balance"].ToString()),
                                    MostRecentActivity = Convert.ToDateTime(myReader["mostRecentActivity"]),
                                    InterestRate = float.Parse(myReader["interestRate"].ToString()),
                                    MyListTransactions = GetListTransactionsOfSpecificAccount((int)myReader["accountId"]),
                                };
                                return _updatedSavingsAccount;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        public ClassCheckingAccount SearchCheckingAccount(string accountId)
        {
            //Build Select Query
            string selectQuery = "";
            if (accountId != "")
            {
                selectQuery = $"SELECT * FROM dbo.Accounts ";
                selectQuery += $"WHERE accountId = @ACCOUNTID";
            }

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            ClassCheckingAccount AccountSelected = new ClassCheckingAccount()
                            {
                                AccountId = (int)reader["accountId"],
                                CustomerId = (int)reader["customerId"],
                                Balance = float.Parse(reader["balance"].ToString()),
                                MonthlyFee = float.Parse(reader["monthlyFee"].ToString()),
                                MostRecentActivity = Convert.ToDateTime(reader["mostRecentActivity"]),
                                IsOverdrafted = (bool)reader["isOverdrafted"],
                                MyListTransactions = GetListTransactionsOfSpecificAccount((int)reader["accountId"]),
                            };

                            return AccountSelected;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return default(ClassCheckingAccount);
            }
        }



        internal ClassSavingsAccount SearchSavingsAccount(string accountId)
        {
            //Build Select Query
            string selectQuery = "";
            if (accountId != "")
            {
                selectQuery = $"SELECT * FROM dbo.Accounts ";
                selectQuery += $"WHERE accountId = @ACCOUNTID";
            }

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            ClassSavingsAccount AccountSelected = new ClassSavingsAccount()
                            {
                                AccountId = (int)reader["accountId"],
                                CustomerId = (int)reader["customerId"],
                                Balance = float.Parse(reader["balance"].ToString()),
                                MostRecentActivity = Convert.ToDateTime(reader["mostRecentActivity"]),
                                InterestRate = float.Parse(reader["interestRate"].ToString()),
                                MyListTransactions = GetListTransactionsOfSpecificAccount((int)reader["accountId"]),
                            };

                            return AccountSelected;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return default(ClassSavingsAccount);
            }

        }


        public List<ClassAbstractAccount> GetListAccountsOfSpecificCustomer(int inputCustomerId)
        {
            //Initialize list of accounts
            List<ClassAbstractAccount> _listAccounts = new List<ClassAbstractAccount>();

            //Build Select Query for Savings Accounts
            string selectQuerySavings = "SELECT * ";
            selectQuerySavings += "FROM dbo.Accounts ";
            selectQuerySavings += "WHERE customerId = @CUSTOMERID AND accountType = 'SAVINGS'; ";

            //Build Select Query for Savings Accounts
            string selectQueryChecking = "SELECT * ";
            selectQueryChecking += "FROM dbo.Accounts ";
            selectQueryChecking += "WHERE customerId = @CUSTOMERID AND accountType = 'CHECKING'; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuerySavings, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@CUSTOMERID", inputCustomerId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new Savings Account object
                                ClassSavingsAccount _newSavingsAccount = new ClassSavingsAccount()
                                {
                                    AccountId = (int)myReader["accountId"],
                                    CustomerId = (int)myReader["customerId"],
                                    Balance = float.Parse(myReader["balance"].ToString()),
                                    MostRecentActivity = Convert.ToDateTime(myReader["mostRecentActivity"]),
                                    InterestRate = float.Parse(myReader["interestRate"].ToString()),
                                    MyListTransactions = GetListTransactionsOfSpecificAccount((int)myReader["accountId"]),
                                };
                                _listAccounts.Add(_newSavingsAccount);
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(selectQueryChecking, cnn))
                    {
                        cmd.Parameters.AddWithValue("@CUSTOMERID", inputCustomerId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new Checking Account object
                                ClassCheckingAccount _newCheckingAccount = new ClassCheckingAccount()
                                {
                                    AccountId = (int)myReader["accountId"],
                                    Balance = float.Parse(myReader["balance"].ToString()),
                                    MostRecentActivity = Convert.ToDateTime(myReader["mostRecentActivity"]),
                                    IsOverdrafted = (bool)myReader["isOverdrafted"],
                                    CustomerId = (int)myReader["customerId"],
                                    MonthlyFee = float.Parse(myReader["monthlyFee"].ToString()),
                                    MyListTransactions = GetListTransactionsOfSpecificAccount((int)myReader["accountId"]),
                                };
                                _listAccounts.Add(_newCheckingAccount);
                            }
                        }
                    }
                }
                return _listAccounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }


        internal string TypeOfAccount(string accountId)
        {
            //Build Select Query
            string selectQuery = "";
            if (accountId != "")
            {
                selectQuery = $"SELECT accountType FROM dbo.Accounts ";
                selectQuery += $"WHERE accountId = @ACCOUNTID";
            }

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);

                        return cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return "";
            }
        }


        internal float GetAccountBalanceById(int accountId)
        {
            //Build Select Query in Accounts
            string selectQuery = "SELECT balance FROM dbo.Accounts ";
            selectQuery += "WHERE accountId = @ACCOUNTID; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);

                        return float.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return 0;
            }
        }


        internal void UpdateAccountAfterTransaction(int accountId, float newBalance, DateTime newMostRecentActivity, bool newIsOverdrafted)
        {
            //Build UPDATE Query in Accounts
            string updateQuery = "UPDATE dbo.Accounts ";
            updateQuery += "SET balance = @NEWBALANCE, mostRecentActivity = @NEWMOSTRECENTACTIVITY, isOverdrafted = @NEWISOVERDRAFTED ";
            updateQuery += "WHERE accountId = @ACCOUNTID; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);
                        cmd.Parameters.AddWithValue("@NEWBALANCE", newBalance);
                        cmd.Parameters.AddWithValue("@NEWMOSTRECENTACTIVITY", newMostRecentActivity.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        cmd.Parameters.AddWithValue("@NEWISOVERDRAFTED", newIsOverdrafted);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
            }
        }


        /* ----------------------------------------------------------------------------------------------------------------------------------
           ---------------------------------------------------- TRANSACTION METHODS ---------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        public bool CreateTransaction(int inputAccountId, float inputAmountToDebit, float inputAmountToCredit, int inputOtherAccountId, string inputTypeTransaction)
        {

            DateTime _timestampTransaction = DateTime.Now;

            //TRANSACTIONS MUST BE CREATED IN PAIRS
            //Build Insert Query in Transactions
            string insertQuery = "INSERT INTO dbo.Transactions (accountId, datetimeTransaction, amountDebit, amountCredit, otherAccountId, typeTransaction) ";
            insertQuery += $"VALUES ";
            insertQuery += $"(@ACCOUNTID, @DATETIMETRANSACTION, @AMOUNTDEBIT, @AMOUNTCREDIT, @OTHERACCOUNTID, @TYPETRANSACTION), ";     //Transaction
            insertQuery += $"(@OTHERACCOUNTID, @DATETIMETRANSACTION, @AMOUNTCREDIT, @AMOUNTDEBIT, @ACCOUNTID, @TYPETRANSACTION); ";    //Mirror Transaction

            try
            {
                //Create Transactions
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", inputAccountId);
                        cmd.Parameters.AddWithValue("@DATETIMETRANSACTION", _timestampTransaction);
                        cmd.Parameters.AddWithValue("@AMOUNTDEBIT", inputAmountToDebit);
                        cmd.Parameters.AddWithValue("@AMOUNTCREDIT", inputAmountToCredit);
                        cmd.Parameters.AddWithValue("@OTHERACCOUNTID", inputOtherAccountId);
                        cmd.Parameters.AddWithValue("@TYPETRANSACTION", inputTypeTransaction);

                        cmd.ExecuteNonQuery();
                    }
                }

                //Get Old Balance of Accounts
                float _oldBalanceAccount1 = GetAccountBalanceById(inputAccountId);
                float _oldBalanceAccount2 = GetAccountBalanceById(inputOtherAccountId);
                float _newBalanceAccount1 = _oldBalanceAccount1 - inputAmountToDebit + inputAmountToCredit;
                float _newBalanceAccount2 = _oldBalanceAccount2 + inputAmountToDebit - inputAmountToCredit;
                bool _newIsOverdrafted1 = (_newBalanceAccount1 < 0) ? true : false;
                bool _newIsOverdrafted2 = (_newBalanceAccount2 < 0) ? true : false;

                //Update Accounts Information
                UpdateAccountAfterTransaction(inputAccountId, _newBalanceAccount1, _timestampTransaction, _newIsOverdrafted1);
                UpdateAccountAfterTransaction(inputOtherAccountId, _newBalanceAccount2, _timestampTransaction, _newIsOverdrafted2);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return false;
            }
        }


        public List<ClassTransaction> GetListTransactionsOfSpecificAccount(int inputAccountId)
        {
            //Initialize list of transactions
            List<ClassTransaction> _listTransactions = new List<ClassTransaction>();

            //Build Select Query for Savings Accounts
            string selectQuery = "SELECT * ";
            selectQuery += "FROM dbo.Transactions ";
            selectQuery += "WHERE accountId = @ACCOUNTID; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", inputAccountId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new Savings Account object
                                ClassTransaction _newTransaction = new ClassTransaction()
                                {
                                    TransactionId = (int)myReader["transactionId"],
                                    AccountId = (int)myReader["accountId"],
                                    DatetimeTransaction = Convert.ToDateTime(myReader["datetimeTransaction"]),
                                    AmountCredit = float.Parse(myReader["amountCredit"].ToString()),
                                    AmountDebit = float.Parse(myReader["amountDebit"].ToString()),
                                    OtherAccountId = (int)myReader["otherAccountId"],
                                    TypeTransaction = (string)myReader["typeTransaction"],
                                };
                                _listTransactions.Add(_newTransaction);
                            }
                        }
                    }
                }
                return _listTransactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }

        public List<ClassTransaction> GetListTransactionsBetweenDates(int inputAccountId, DateTime dateStart, DateTime dateEnd)
        {
            //Initialize list of transactions
            List<ClassTransaction> _listTransactions = new List<ClassTransaction>();

            //Build Select Query for Savings Accounts
            string selectQuery = "SELECT * ";
            selectQuery += "FROM dbo.Transactions ";
            selectQuery += "WHERE accountId = @ACCOUNTID ";
            selectQuery += "AND datetimeTransaction >= '" + dateStart.ToString("yyyy-MM-dd") + "' ";
            selectQuery += "AND datetimeTransaction <= '" + dateEnd.ToString("yyyy-MM-dd") + " 23:59:59' ; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", inputAccountId);
                        using (SqlDataReader myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //Create new object
                                ClassTransaction _newTransaction = new ClassTransaction();


                                _newTransaction.TransactionId = (int)myReader["transactionId"];
                                _newTransaction.AccountId = (int)myReader["accountId"];
                                _newTransaction.DatetimeTransaction = Convert.ToDateTime(myReader["datetimeTransaction"]);
                                _newTransaction.AmountCredit = float.Parse(myReader["amountCredit"].ToString());
                                _newTransaction.AmountDebit = float.Parse(myReader["amountDebit"].ToString());
                                _newTransaction.OtherAccountId = (int)myReader["otherAccountId"];
                                _newTransaction.TypeTransaction = myReader["typeTransaction"].ToString();
                                _listTransactions.Add(_newTransaction);
                            }
                        }
                    }
                }
                return _listTransactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Something went wrong!\n{ex.Message}");
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }





        /* ----------------------------------------------------------------------------------------------------------------------------------
           ------------------------------------------------------- CUSTOM METHODS -----------------------------------------------------------
           ---------------------------------------------------------------------------------------------------------------------------------- */
        internal ClassZipCode UpdateZipCode(string inputZipCode)
        {
            //Build Select Query
            string selectQuery = "";
            if (inputZipCode.Length == 6)
            {
                string inputZipCodeFormated = inputZipCode.Substring(0, 3) + " " + inputZipCode.Substring(3);
                selectQuery = $"SELECT * FROM dbo.ZipCode ";
                selectQuery += $"WHERE postalCode = '" + inputZipCodeFormated + "'";
            }
            else
            {
                selectQuery = $"SELECT * FROM dbo.ZipCode ";
                selectQuery += $"WHERE postalCode = '" + inputZipCode + "'";
            };

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            ClassZipCode MyZipCode = new ClassZipCode()
                            {
                                ZipCode = (string)reader["postalCode"],
                                City = (string)reader["city"],
                                Province = (string)reader["province"],
                                Country = (string)reader["country"],
                            };
                            return MyZipCode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Something went wrong!\n{ex.Message}");
                return null;
            }
        }

        internal string GetSavingsBalance(int employeeId)
        {

            //Build Select Query
            string selectQuery = "SELECT SUM(balance) as SUM ";
            selectQuery += "FROM dbo.Accounts LEFT JOIN dbo.Customers ";
            selectQuery += "ON dbo.Accounts.customerId = dbo.Customers.customerId ";
            selectQuery += "WHERE dbo.Customers.financialAdvisorId = @EMPLOYEEID ";
            selectQuery += "AND dbo.Accounts.accountType= 'SAVINGS' ; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@EMPLOYEEID", employeeId);
                        double _result = (double)cmd.ExecuteScalar();
                        return _result.ToString("$ #,##0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                return "$ 0.00";
            }

        }

        internal string GetChequingBalance(int employeeId)
        {
            //Build Select Query
            string selectQuery = "SELECT SUM(balance) as SUM ";
            selectQuery += "FROM dbo.Accounts LEFT JOIN dbo.Customers ";
            selectQuery += "ON dbo.Accounts.customerId = dbo.Customers.customerId ";
            selectQuery += "WHERE dbo.Customers.financialAdvisorId = @EMPLOYEEID ";
            selectQuery += "AND dbo.Accounts.accountType= 'CHEQUING' ; ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@EMPLOYEEID", employeeId);
                        double _result = (double)cmd.ExecuteScalar();
                        return _result.ToString("$ #,##0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                return "$ 0.00";
            }
        }

        internal string GetCountCustomers(int employeeId)
        {
            //Build Select Query
            string selectQuery = "SELECT COUNT(customerId) as COUNT ";
            selectQuery += "FROM dbo.Customers ";
            selectQuery += "WHERE dbo.Customers.financialAdvisorId = @EMPLOYEEID ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@EMPLOYEEID", employeeId);
                        int _result = (int)cmd.ExecuteScalar();
                        return _result.ToString("0");
                    }
                }
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        internal string GetCustomerNameByAccountId(string accountId)
        {
            //Build Select Query
            string selectQuery = "SELECT firstName + ' ' +  lastName AS customerFullName ";
            selectQuery += "FROM [dbo].[Accounts] LEFT JOIN [dbo].[Customers] ";
            selectQuery += "ON [dbo].[Accounts].[customerId] = [dbo].[Customers].[customerId] ";
            selectQuery += "WHERE [dbo].[Accounts].[accountId] =  @ACCOUNTID ";

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cnn.Open();
                        cmd.Parameters.AddWithValue("@ACCOUNTID", accountId);
                        string _result = cmd.ExecuteScalar().ToString();
                        return _result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Unknow Customer";
            }
        }
    }
}
