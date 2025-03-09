using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SupplierModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string TaxTreatment { get; set; }
        public string TaxRegistrationNumber { get; set; }
        public string Group { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PayableAccount { get; set; }
        public string Description { get; set; }        
        public string CreditLimitAmount { get; set; }
        public string CreditLimitDays { get; set; }
        public string PaymentTerm { get; set; }
        public string ShippingTerm { get; set; }
        public string LoadingPort { get; set; }
        public string DestinationPort { get; set; }
        public string ShippingMethod { get; set; }
        public string ShipmentPriority { get; set; }  
        public List<SupplierContactPerson> Persons { get; set; }
        public List<SupplierAddress> Addresses { get; set; }
        public List<SupplierItem> Items { get; set; }
        public List<SupplierDocument> Documents { get; set; }
    }
    public class SupplierContactPerson
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
    public class SupplierAddress
    {
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string DialingCode { get; set; }
        public string Zipcode { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string TelNumber { get; set; }
        public string FaxNumber { get; set; }
    }
    public class SupplierItem
    {
        public string Item { get; set; }
    }
    public class SupplierDocument
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
    }
}
