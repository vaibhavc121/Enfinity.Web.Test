using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class CreatenewItemPage
    {
        private readonly IWebDriver _driver;

        //Locators 
        private By modulenameField = By.Id("applicationMenu_DXI3_T");
        private By setupField = By.Id("leftNavigation_I2i3_");
        private By setupnameField = By.Id("NavViewCommon_I0i0_T");
        private By newField = By.Id("MainMenu_DXI0_T");
        private By nameField = By.CssSelector("input[name='Name']");
        private By namearabicField = By.CssSelector("input[name='NameL2']");
        private By saveField = By.CssSelector("#MainMenu_DXI0_T, #MainMenu_DXI0_");
        private By dropdownselectofUOM = By.CssSelector(".dx-widget.dx-dropdowneditor-button");         
        private By dropdownselectofType = By.XPath("(//div[contains(@class, 'dx-button-content')])[7]");
        private By dropdownselectofTrackingMode = By.XPath("(//div[contains(@class, 'dx-button-content')])[8]");
        private By dropdownselectofCostingMethod = By.XPath("(//div[contains(@class, 'dx-button-content')])[9]");
        private By dropdownOptions = By.CssSelector(".dx-item-content, .dx-list-item-content");
        private By backBtn = By.Id("pre-Button");
        private By bomTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Bill Of Material']");
        private By addBtn = By.ClassName("dx-icon-edit-button-addrow");
        private By dropdownselectofItem = By.CssSelector(".dx-widget.dx-button-normal.dx-dropdowneditor-button");
        private By qtyField = By.XPath("//input[contains(@id, 'ComponentBaseQtyPerAssembledUnit')]");
        private By saveBtnofPopup = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[3]");
        public CreatenewItemPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void selectModule()
        {
            _driver.FindElement(modulenameField).Click();
        }
        public void navigateToItem()
        {
            _driver.FindElement(setupField).Click();
            _driver.FindElement(setupnameField).Click();
        }
        public void clickNew()
        {
            _driver.FindElement(newField).Click();
        }
        public void createNewItem(string name, string namearabic)
        {
            _driver.FindElement(nameField).SendKeys(name);
            _driver.FindElement(namearabicField).SendKeys(namearabic);
        }
        public void clickUOM()
        {
            _driver.FindElement(dropdownselectofUOM).Click();
        }
        public void clickType()
        {
            _driver.FindElement(dropdownselectofType).Click();
        }
        public void clickTrackingMode()
        {
            _driver.FindElement(dropdownselectofTrackingMode).Click();
        }
        public void clickCostingMethod()
        {
            _driver.FindElement(dropdownselectofCostingMethod).Click();
        }
        public void clickSaveItem()
        {
            _driver.FindElement(saveField).Click();
        }
        public void clickBackButton()
        {
            _driver.FindElement(backBtn).Click();
        }
        public void clickOnBOMTab()
        {
            _driver.FindElement(bomTab).Click();
        }
        public void clickOnAdd()
        {
            _driver.FindElement(addBtn).Click();
        }
        public void clickItem()
        {
            Thread.Sleep(1000);
            _driver.FindElement(dropdownselectofItem).Click();
        }
        public void provideQty(string qty)
        {
            _driver.FindElement(qtyField).SendKeys(qty);
        }
        public void clickSavePopup()
        {
            _driver.FindElement(saveBtnofPopup).Click();
        }
        public void SelectDropDownOption(string option)
        {
            //_driver.FindElement(dropdownselectofUOM).Click();
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            //wait.Until(_driver => _driver.FindElements(dropdownOptions).Any());
            Thread.Sleep(1000);
            var options = _driver.FindElements(dropdownOptions);

            foreach (var valueElement in options)
            {
                string actualValue = valueElement.Text;               
                if (actualValue.Contains(option))
                {
                    valueElement.Click();
                    //Thread.Sleep(1000);
                    return;  
                }
            }
        }
    }
}
