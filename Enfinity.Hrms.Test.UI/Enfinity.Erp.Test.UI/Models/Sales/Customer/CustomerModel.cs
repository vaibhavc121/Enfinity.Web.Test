using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Enfinity.Erp.Test.UI
{
    public class CustomerModel
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
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public string ReceivableAccount { get; set; }
        public string CreditLimitAmount { get; set; }
        public string CreditLimitDays { get; set; }
        public string CreditrRating { get; set; }
        public string CreditCheckMode { get; set; }
        public string Salesman { get; set; }
        public string PaymentTerm { get; set; }
        public string PriceList { get; set; }
        public string ShippingTerm { get; set; }
        public string LoadingPort { get; set; }
        public string DestinationPort { get; set; }
        public string ShippingMethod { get; set; }
        public string ShipmentPriority { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipcode { get; set; }
        public string BillingContactPerson { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingState { get; set; }
        public string ShippingZipcode { get; set; }
        public string ShippingContactPerson { get; set; }
        public List<CustomerContactPerson> Persons { get; set; }
        public List<CustomerDocument> Documents { get; set; }
    }
    public class CustomerContactPerson
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
    public class CustomerDocument
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
    }
}
