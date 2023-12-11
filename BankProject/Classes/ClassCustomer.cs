using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes
{
    public class ClassCustomer : ClassAbstractPerson
    {
        public ClassEmployee? FinancialAdvisor { get; set; }
        public ClassBranch? Branch { get; set; }
        public List<ClassAbstractAccount>? MyListAccounts { get; set; }
        int customerID { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        DateOnly dateOfBirth { get; set; }
        ClassDocument document { get; set; }
        ClassAddress address { get; set; }
        string phoneNumber { get; set; }
        string emailAddress { get; set; }

        public ClassCustomer(int customerID, string firstName, string lastName, DateOnly dateOfBirth, ClassDocument document, ClassAddress address, string phoneNumber, string emailAddress, ClassEmployee? financialAdvisor, ClassBranch? branch, List<ClassAbstractAccount>? myListAccounts)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.document = document;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
            FinancialAdvisor = financialAdvisor;
            Branch = branch;
            MyListAccounts = myListAccounts;
        }



        //public ClassCustomer(int customerID, string firstName, string lastName, DateOnly dateOfBirth, ClassDocument document, ClassAddress address, string phoneNumber, string emailAddress)
        //{
        //    this.customerID = customerID;
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.dateOfBirth = dateOfBirth;
        //    this.document = document;
        //    this.address = address;
        //    this.phoneNumber = phoneNumber;
        //    this.emailAddress = emailAddress;
        //}

        public override string ToString()
        {
            return $"CustomerID: {customerID}\nFirst Name: {firstName}\nLast Name: {lastName}\nDate Of Birth: {dateOfBirth}\nDocument:{document}\nAddress: {address}\nPhone Number: {phoneNumber}\nEmail: {emailAddress}";
        }
        public string DetailsAllMyAccounts()
        {
            string _result = string.Empty;
            return _result;
        }

    }


    public class ClassDocument
    {

        string documentType { get; set; }

        string documentNumber { get; set; }

        DateOnly documentIssuedDate { get; set; }

        DateOnly documentExpirationDate { get; set; }

        public ClassDocument(string documentType, string documentNumber, DateOnly documentIssuedDate, DateOnly documentExpirationDate)
        {
            this.documentType = documentType;
            this.documentNumber = documentNumber;
            this.documentIssuedDate = documentIssuedDate;
            this.documentExpirationDate = documentExpirationDate;
        }
        public override string ToString()
        {
            return $"\nDocument Type: {documentType}\ndocumentNumber: {documentNumber}\ndocumentIssuedDate: {documentIssuedDate}\n Expiration Date: {documentExpirationDate}";
        }
    }

    public class ClassAddress
    {

        string zipCode { get; set; }

        string line1 { get; set; }

        string line2 { get; set; }

        string city { get; set; }

        string province { get; set; }

        string country { get; set; }

        public ClassAddress(string zipCode, string line1, string line2, string city, string province, string country)
        {
            this.zipCode = zipCode;
            this.line1 = line1;
            this.line2 = line2;
            this.city = city;
            this.province = province;
            this.country = country;
        }

        public override string ToString()
        {
            return $"\nZip Code: {zipCode}\n{line1}\n{line2}\nCity: {city}\nProvince: {province}\nCountry: {country}";
        }
    }
}
