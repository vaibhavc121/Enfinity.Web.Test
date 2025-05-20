using Enfinity.Common.Test;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class InvoiceTest: BaseTest
    {
        #region Constructor
        public InvoiceTest()
        { }
        #endregion

        #region Create new invoice
        [Test, Category("Sales"), Order(1)]
        public async Task CreateInvoice()
        {
            #region Login region
            Login(ErpProduct);
            #endregion

            try
            {
                var invoicedataFile = FileHelper.GetDataFile("Erp", "Sales", "Invoice", "invoiceData");
                var invoiceheaderDM = JsonHelper.ConvertJsonListDataModel<InvoiceHeaderModel>(invoicedataFile, "header");
                var invoicelineDM = JsonHelper.ConvertJsonListDataModel<InvoiceLineModel>(invoicedataFile, "new");

                var sp = new SalesPage(_driver);
                var ip = new InvoicePage(_driver);

                CommonPageActions.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(1);

                sp.ClickOnInvoice();
                CommonPageActions.ClickOnNew();
                
                // Apply header data only once
                var header = invoiceheaderDM.FirstOrDefault();
                if (header != null)
                {
                    ip.ClickOnCustomer();
                    CommonPageActions.SelectDropDownOption(header.Customer);

                    ip.ProvideMobile(header.Mobile);

                    ip.ClickOnWarehouse();
                    CommonPageActions.SelectDropDownOption(header.Warehouse);

                    ip.ClickOnSalesman();
                    CommonPageActions.SelectOption(header.Salesman);

                    if (header.PriceListEnable)
                    {
                        ip.ClickOnPriceList();
                        CommonPageActions.SelectDropDownListOption(header.PriceList);
                    }
                    if (header.RequirePaymentMethod)
                    {
                        ip.ClickOnPaymentMethod();
                        CommonPageActions.SelectDropDownOption(header.PaymentMethod);
                    }

                    ip.ClickOnPaymentTerm();
                    CommonPageActions.SelectOption(header.PaymentTerm);

                    if (header.ProjectEnable) 
                    {
                        ip.ClickOnProject();
                        CommonPageActions.SelectOption(header.Project);
                    }
                }

                foreach (var item in invoicelineDM)
                {                    
                    if (header != null && header.ShowBarcodeOnLines)
                    {
                        if (!string.IsNullOrWhiteSpace(item.Barcode))
                        {
                            ip.ProvideBarcode(item.Barcode);
                            CommonPageActions.PressEnterKey();
                        }
                        else
                        {
                            ip.ClickOnItem();
                            CommonPageActions.SelectDropDownOption(item.Item);
                        }
                    }
                    else
                    {
                        ip.ClickOnItem();
                        CommonPageActions.SelectDropDownOption(item.Item);
                    }
                    if (header != null && header.AllowModifyItemDescription) 
                    {
                        ip.ProvideItemDescription(item.ItemDescription);
                    }
                    if (header != null && header.ShowWarehouseOnLines)
                    {
                        ip.ClickOnLineWarehouse();
                        CommonPageActions.SelectOption(item.WarehouseOnLines);
                    }

                    //Check the actual feature is Enabled/Disabled on item setting
                    if (header != null && header.EnableItemColor && !string.IsNullOrWhiteSpace(item.Color))
                    {
                        ip.ClickOnColor();
                        CommonPageActions.SelectDropDownOption(item.Color);
                    }
                    if (header != null && header.EnableItemSize && !string.IsNullOrWhiteSpace(item.Size))
                    {
                        ip.ClickOnSize();
                        CommonPageActions.SelectDropDownOption(item.Size);
                    }                    

                    #region scroll to last element
                    IWebElement lastElement = _driver.FindElement(By.XPath("(//input[contains(@id, '_GrossValue')])"));
                    ScrollHelper.ScrollToElement(lastElement);
                    await WaitHelper.WaitForSeconds(1);
                    #endregion

                    ip.ClickOnUOM();
                    CommonPageActions.SelectDropDownOption(item.UOM);

                    ip.ProvideQty(item.Qty);
                    ip.CheckAndProvideUnitPrice(item.UnitPrice);

                    if (header != null && header.ShowDiscountOnLines)
                    {
                        ip.ProvideDiscountInPercent(item.DiscountInPercent);
                        //ip.ProvideDiscountValue(item.DiscountValue);
                    }

                    ip.ProvideRemarks(item.Remarks);

                    if (header != null && header.AllowBonusQty)
                    {
                        ip.ProvideBonusQty(item.BonusQty); 
                    }

                    #region Click on Add Item                  
                    ip.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);
                    #endregion
                    
                }
                if (!string.IsNullOrWhiteSpace(header.TotalDiscountInPercent))
                {
                    ip.ProvideTotalDiscountInPercent(header.TotalDiscountInPercent);
                    //ip.ProvideToalDiscountValue(header.TotalDiscountValue);
                }

                if (header != null && header.View)
                {
                    CommonPageActions.ClickOnSave();
                    CommonPageActions.ClickOnView();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validation Invoice updated message
                    CommonPageActions.ValidateMessage("Invoice updated successfully!");
                    #endregion
                }
                if (header != null && header.View && header.Approve) 
                {
                    CommonPageActions.ClickOnApprove();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validation Invoice approved message
                    CommonPageActions.ValidateSucess("Invoice Approved!");
                    #endregion
                }
                ip.ClickOnInvoice();
                await WaitHelper.WaitForSeconds(2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed : CreateInvoice", ex);
            }            
        }
        #endregion

        #region Create new invoice with multiple payment methods
        [Test, Category("Sales"), Order(2)]
        public async Task CreateInvoiceWithMultiplePaymentMethod()
        {
            #region Login region
            Login(ErpProduct);
            #endregion

            try
            {
                var invoicedataFile = FileHelper.GetDataFile("Erp", "Sales", "Invoice", "invoiceData");
                var invoiceheaderDM = JsonHelper.ConvertJsonListDataModel<InvoiceHeaderModel>(invoicedataFile, "header");
                var invoicelineDM = JsonHelper.ConvertJsonListDataModel<InvoiceLineModel>(invoicedataFile, "new");
                var paymentmethodDM = JsonHelper.ConvertJsonListDataModel<InvoiceLineModel>(invoicedataFile, "paymentmethods");

                var sp = new SalesPage(_driver);
                var ip = new InvoicePage(_driver);

                CommonPageActions.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(1);

                sp.ClickOnInvoice();
                CommonPageActions.ClickOnNew();

                // Apply header data only once
                var header = invoiceheaderDM.FirstOrDefault();
                if (header != null)
                {
                    ip.ClickOnCustomer();
                    CommonPageActions.SelectDropDownOption(header.Customer);

                    ip.ProvideMobile(header.Mobile);

                    ip.ClickOnWarehouse();
                    CommonPageActions.SelectDropDownOption(header.Warehouse);

                    ip.ClickOnSalesman();
                    CommonPageActions.SelectOption(header.Salesman);

                    if (header.PriceListEnable)
                    {
                        ip.ClickOnPriceList();
                        CommonPageActions.SelectDropDownListOption(header.PriceList);
                    }
                    if (header.RequirePaymentMethod)
                    {
                        ip.ClickOnPaymentMethod();
                        CommonPageActions.SelectDropDownOption(header.PaymentMethod);
                    }

                    ip.ClickOnPaymentTerm();
                    CommonPageActions.SelectOption(header.PaymentTerm);

                    if (header.ProjectEnable)
                    {
                        ip.ClickOnProject();
                        CommonPageActions.SelectOption(header.Project);
                    }
                }

                foreach (var item in invoicelineDM)
                {
                    if (header != null && header.ShowBarcodeOnLines)
                    {
                        if (!string.IsNullOrWhiteSpace(item.Barcode))
                        {
                            ip.ProvideBarcode(item.Barcode);
                            CommonPageActions.PressEnterKey();
                        }
                        else
                        {
                            ip.ClickOnItem();
                            CommonPageActions.SelectDropDownOption(item.Item);
                        }
                    }
                    else
                    {
                        ip.ClickOnItem();
                        CommonPageActions.SelectDropDownOption(item.Item);
                    }
                    if (header != null && header.AllowModifyItemDescription)
                    {
                        ip.ProvideItemDescription(item.ItemDescription);
                    }
                    if (header != null && header.ShowWarehouseOnLines)
                    {
                        ip.ClickOnLineWarehouse();
                        CommonPageActions.SelectOption(item.WarehouseOnLines);
                    }

                    //Check the actual feature is Enabled/Disabled on item setting
                    if (header != null && header.EnableItemColor && !string.IsNullOrWhiteSpace(item.Color))
                    {
                        ip.ClickOnColor();
                        CommonPageActions.SelectDropDownOption(item.Color);
                    }
                    if (header != null && header.EnableItemSize && !string.IsNullOrWhiteSpace(item.Size))
                    {
                        ip.ClickOnSize();
                        CommonPageActions.SelectDropDownOption(item.Size);
                    }

                    #region scroll to last element
                    IWebElement lastElement = _driver.FindElement(By.XPath("(//input[contains(@id, '_GrossValue')])"));
                    ScrollHelper.ScrollToElement(lastElement);
                    await WaitHelper.WaitForSeconds(1);
                    #endregion

                    ip.ClickOnUOM();
                    CommonPageActions.SelectDropDownOption(item.UOM);

                    ip.ProvideQty(item.Qty);
                    ip.CheckAndProvideUnitPrice(item.UnitPrice);

                    if (header != null && header.ShowDiscountOnLines)
                    {
                        ip.ProvideDiscountInPercent(item.DiscountInPercent);
                        //ip.ProvideDiscountValue(item.DiscountValue);
                    }

                    ip.ProvideRemarks(item.Remarks);

                    if (header != null && header.AllowBonusQty)
                    {
                        ip.ProvideBonusQty(item.BonusQty);
                    }

                    #region Click on Add Item                  
                    ip.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);
                    #endregion

                }
                if (!string.IsNullOrWhiteSpace(header.TotalDiscountInPercent))
                {
                    ip.ProvideTotalDiscountInPercent(header.TotalDiscountInPercent);
                    //ip.ProvideToalDiscountValue(header.TotalDiscountValue);
                }

                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                if (header.UseMultiplePaymentMethod) 
                {
                    foreach (var paymentmethod in paymentmethodDM)
                    {
                        ip.ClickOnPayments();
                        await WaitHelper.WaitForSeconds(1);

                        CommonPageActions.SelectDropDownOption(paymentmethod.PaymentMethod);

                        ip.ProvideCardNumber(paymentmethod.CardNum);
                        ip.ProvideAmountFC(paymentmethod.AmountFC);

                        CommonPageActions.ClickOnPopUpSave();
                    }                     
                }

                if (header != null && header.View)
                {
                    CommonPageActions.ClickOnSave();
                    CommonPageActions.ClickOnView();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validation Invoice updated message
                    CommonPageActions.ValidateMessage("Invoice updated successfully!");
                    #endregion
                }
                if (header != null && header.View && header.Approve)
                {
                    CommonPageActions.ClickOnApprove();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validation Invoice approved message
                    CommonPageActions.ValidateSucess("Invoice Approved!");
                    #endregion
                }
                ip.ClickOnInvoice();
                await WaitHelper.WaitForSeconds(2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed : CreateInvoiceWithMultiplePaymentMethod", ex);
            }
        }
        #endregion
    }
}
