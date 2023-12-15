using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Classes {
    public abstract class ClassAbstractPerson {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public ClassDocument Document { get; set; }
        public ClassAddress Address { get; set; }

    }


    public class ClassDocument {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateOnly DocumentIssuedDate { get; set; }
        public DateOnly DocumentExpirationDate { get; set; }


        public ClassDocument() {

        }


        public override string ToString() {
            string _result = $"\nDocumentType: {DocumentType}\n";
            _result += $"DocumentNumber: {DocumentNumber}\n";
            _result += $"DocumentIssuedDate: {DocumentIssuedDate}\n";
            _result += $"ExpirationDate: {DocumentExpirationDate}\n";
            return _result;
        }
    }



    public class ClassAddress {
        public string ZipCode { get; set; }
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }


        public ClassAddress() {

        }


        public override string ToString() {
            string _result = $"\nZipCode: {ZipCode}\n";
            _result += $"Line1: {Line1}\n";
            _result += $"Line2: {Line2}\n";
            _result += $"City: {City}\n";
            _result += $"Province: {Province}\n";
            _result += $"Country: {Country}\n";
            return _result;
        }
    }

    public class ClassZipCode {

        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public ClassZipCode() { }


    }
}
