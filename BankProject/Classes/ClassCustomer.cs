using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public class ClassCustomer : ClassAbstractPerson {

        public int IdCustomer { get; set; }
        public ClassEmployee? FinancialAdvisor { get; set; }
        public List<ClassAbstractAccount>? MyListAccounts { get; set; }
    internal class ClassCustomer
    {
        int customerID { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        DateOnly dateOfBirth { get; set; }
        ClassDocument document { get; set; }
        ClassAddress address { get; set; }
        string phoneNumber { get; set; }
        string emailAddress { get; set; }

        public ClassCustomer( int customerID, string firstName, string lastName, DateOnly dateOfBirth, ClassDocument document, ClassAddress address, string phoneNumber, string emailAddress)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.document = document;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }

        public override string ToString()
        {
            return $"CustomerID: {customerID}\nFirst Name: {firstName}\nLast Name: {lastName}\nDate Of Birth: {dateOfBirth}\nDocument:{document}\nAddress: {address}\nPhone Number: {phoneNumber}\nEmail: {emailAddress}";
        }
        public string DetailsAllMyAccounts() {
            string _result = string.Empty;
            return _result;
        }



    internal class ClassDocument
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
}
