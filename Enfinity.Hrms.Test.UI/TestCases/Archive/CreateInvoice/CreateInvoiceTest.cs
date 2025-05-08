//using Enfinity.Common.Test;
//using Enfinity.Erp.Test.UI.Models.Sales.Invoice;
//using Enfinity.Erp.Test.UI.PageObjects.Sales;
//using NUnit.Framework;
//using NUnit.Framework.Legacy;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Enfinity.Erp.Test.UI
//{ 
//    [TestFixture]
//    public class CreateInvoiceTest:BaseTest
//    {
//        public string Product = "Erp";

//        [Test, Ignore("")]
//        public void VerifyInvoice()
//        {
//            try
//            {
//                Login(Product);

//                var invoiceFile = FileHelper.GetDataFile("Erp", "Sales", "Invoice", "InvoiceData");
//                var invoiceData = JsonHelper.ConvertJsonListDataModel<InvoiceModel>(invoiceFile, "createInvoice");

//                InvoicePage ip=new InvoicePage(_driver);
//                ip.ClickSales();
//                ip.ClickInvoice();
//                ip.ClickNew();
//                ip.ProvideCustomer("Meera Kapil");

//                foreach (var invoice in invoiceData)
//                {
                   
//                    ip.ProvideItem(invoice.item);
//                    //ip.ScrollDownPage();
//                    ip.PressTabFourTimes();
//                    if(ip.CheckUnitPrice())
//                    {
//                        ip.ProvideUnitPrice("10");
//                    }
                    
//                    ip.ClickAdd();
//                }
                
//            }
//            catch (Exception e)
//            {

//                ClassicAssert.Fail("Test case failed: " + e);

//            }
//        }
//    }
//}
