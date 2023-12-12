using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BankProject.Classes
{
    public class ClassCustomer : ClassAbstractPerson
    {
        public ClassEmployee? FinancialAdvisor { get; set; }
        public ClassBranch? Branch { get; set; }
        public List<ClassAbstractAccount>? MyListAccounts { get; set; }
        int CustomerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateOnly DateOfBirth { get; set; }
        ClassDocument Document { get; set; }
        ClassAddress Address { get; set; }
        string PhoneNumber { get; set; }
        string EmailAddress { get; set; }

        public ClassCustomer(int customerId, string firstName, string lastName, DateOnly dateOfBirth, ClassDocument document, ClassAddress address, string phoneNumber, string emailAddress, ClassEmployee? financialAdvisor, ClassBranch? branch, List<ClassAbstractAccount>? myListAccounts)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Document = document;
            Address = address;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            FinancialAdvisor = financialAdvisor;
            Branch = branch;
            MyListAccounts = myListAccounts;
        }


        public override string ToString()
        {
            string _result = $"CustomerId: {CustomerId}\n";
            _result += $"FirstName: {FirstName}\n";
            _result += $"LastName: {LastName}\n";
            _result += $"DateOfBirth: {DateOfBirth}\n";
            _result += $"Document: {Document}\n";
            _result += $"Address: {Address}\n";
            _result += $"Phone Number: {PhoneNumber}\n";
            _result += $"Email: {EmailAddress}";
            return _result;
        }


        public string DetailsAllMyAccounts()
        {
            string _result = string.Empty;
            return _result;
        }

    }


    public class ClassDocument
    {

        string DocumentType { get; set; }
        string DocumentNumber { get; set; }
        DateOnly DocumentIssuedDate { get; set; }
        DateOnly DocumentExpirationDate { get; set; }


        public ClassDocument(string documentType, string documentNumber, DateOnly documentIssuedDate, DateOnly documentExpirationDate)
        {
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            DocumentIssuedDate = documentIssuedDate;
            DocumentExpirationDate = documentExpirationDate;
        }


        public override string ToString()
        {
            string _result = $"\nDocumentType: {DocumentType}\n";
            _result += $"DocumentNumber: {DocumentNumber}\n";
            _result += $"DocumentIssuedDate: {DocumentIssuedDate}\n";
            _result += $"ExpirationDate: {DocumentExpirationDate}\n";
            return _result;
        }
    }



    public class ClassAddress
    {

        string ZipCode { get; set; }
        string Line1 { get; set; }
        string Line2 { get; set; }
        string City { get; set; }
        string Province { get; set; }
        string Country { get; set; }


        public ClassAddress(string zipCode, string line1, string line2, string city, string province, string country)
        {
            ZipCode = zipCode;
            Line1 = line1;
            Line2 = line2;
            City = city;
            Province = province;
            Country = country;
        }

        public override string ToString()
        {
            string _result = $"\nZipCode: {ZipCode}\n";
            _result += $"Line1: {Line1}\n";
            _result += $"Line2: {Line2}\n";
            _result += $"City: {City}\n";
            _result += $"Province: {Province}\n";
            _result += $"Country: {country}\n";
            return _result;
        }
    }
}
