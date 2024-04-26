using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
    public class CalculationManagementPageNew
    {
        IWebDriver driver;

        public CalculationManagementPageNew(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        private IWebElement CalcManagementPageNew
            => driver.FindElement(By.XPath("//div[@class='pwc-sdk-ui-blade calculation-management-blade']"));
        private IWebElement CalcManagementPageNewTitle
            => driver.FindElement(By.XPath("//p[normalize-space()='Calculation Management']"));
        private IWebElement CalcManagementPageNewSubTitle
            => driver.FindElement(By.XPath("(//p[@class='pwc-sdk-ui-sub-text'])[3]"));
        private IWebElement EnableDisableToggle
            => driver.FindElement(By.XPath("//switch[@class='ng-untouched ng-pristine']//input[@type='checkbox']"));
        private IWebElement DuplicateButton
            => driver.FindElement(By.XPath("//blade-action[@icon='duplicate']/div"));
        private IWebElement DependenciesButton
            => driver.FindElement(By.XPath("//blade-action[@icon='dependencies']/div"));
        private IWebElement DeleteButton
            => driver.FindElement(By.XPath("//blade-action[@icon='delete']/div"));
        private IWebElement CalculationName
            => driver.FindElement(By.XPath("//text-input[@formcontrolname='calculationName']//input"));
        private IWebElement CalculationNameErrorMessage
            => driver.FindElement(By.XPath("//text-input[@formcontrolname='calculationName']/following-sibling::control-error//div[@class='control-error__message']"));
        private IWebElement HoldingFileSelectionDropdown
            => driver.FindElement(By.XPath("//div[@class='multi-select__input-wrapper']/kendo-multiselect"));
        public IList<IWebElement> HoldingFileSelectionSelectedItems
            => driver.FindElements(By.XPath("//ul[@class='k-reset']/li//span[@class='multi-select__tag-content']/b"));
        private IWebElement HoldingFileSelectionSelectedItemYearEnd
            => driver.FindElement(By.XPath("//span[@title='Year End']/b"));
        private IWebElement HoldingFileSelectionSelectedItemYearEndState
            => driver.FindElement(By.XPath("//span[@title='Year End']/b/../../.."));
        private IWebElement HoldingFileSelectionSelectedItemQ1Name
            => driver.FindElement(By.XPath("//span[@title='Q1']/b"));
        private IWebElement HoldingFileSelectionSelectedItemQ1DeleteIcon
            => driver.FindElement(By.XPath("//span[@title='Q1']/../following-sibling::span/span"));
        private IWebElement HoldingFileSelectionSelectedItemQ2Name
            => driver.FindElement(By.XPath("//span[@title='Q2']/b"));
        private IWebElement HoldingFileSelectionSelectedItemQ2DeleteIcon
            => driver.FindElement(By.XPath("//span[@title='Q2']/../following-sibling::span/span"));
        private IWebElement HoldingFileSelectionSelectedItemQ3Name
            => driver.FindElement(By.XPath("//span[@title='Q3']/b"));
        private IWebElement HoldingFileSelectionSelectedItemQ3DeleteIcon
            => driver.FindElement(By.XPath("//span[@title='Q3']/../following-sibling::span/span"));
        private IList<IWebElement> HoldingFileSelectionDropdownItems
            => driver.FindElements(By.XPath("//div[@class='multi-select__name']"));
        private IWebElement HoldingFileSelectionDropdownYearEndName
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Year End')]"));
        private IWebElement HoldingFileSelectionDropdownYearEndNameState
            => driver.FindElement(By.XPath("//li[@role='option'][1]"));
        private IWebElement HoldingFileSelectionDropdownYearEndCheckbox
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Year End')]/../preceding-sibling::div//input"));
        private IWebElement HoldingFileSelectionDropdownQ1Name
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Q1')]"));
        private IWebElement HoldingFileSelectionDropdownQ1Checkbox
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Q1')]/../preceding-sibling::div//input"));
        private IWebElement HoldingFileSelectionDropdownQ2Name
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Q2')]"));
        private IWebElement HoldingFileSelectionDropdownQ2Checkbox
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Q2')]/../preceding-sibling::div//input"));
        private IWebElement HoldingFileSelectionDropdownQ3Name
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Q3')]"));
        private IWebElement HoldingFileSelectionDropdownQ3Checkbox
            => driver.FindElement(By.XPath("//div[@class='multi-select__name']//b[contains(text(),'Q3')]/../preceding-sibling::div//input"));





        private IWebElement SaveButton
            => driver.FindElement(By.XPath("//button[@class='btn btn-primary ml-auto']"));
        private IWebElement CancelButton
            => driver.FindElement(By.XPath("//button[@class='btn btn-cancel sdk-btn-tertiary']"));


        public CalculationManagementPageNew NavigateToCalcManagementPageNew()
        {
            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageCalculationsClickable();
            ManageCalculationsPage manageCalculationsPage = adminSettingsPage.ClickManageCalculationsMenuItem();
            CalculationManagementPageNew calculationManagementPageNew = manageCalculationsPage.ClickAddNewCalculationButton();
            return new CalculationManagementPageNew(driver);
        }

        public IWebElement GetCalcManagementPageNew()
        {
            return CalcManagementPageNew;
        }
        public string GetCalcManagementPageNewTitle()
        {
            return CalcManagementPageNewTitle.Text;
        }
        public string GetCalcManagementPageNewSubTitle()
        {
            return CalcManagementPageNewSubTitle.Text;
        }
        public IWebElement GetEnableDisableToggle()
        {
            return EnableDisableToggle;
        }
        public string GetDuplicateButtonState()
        {
            string a = DuplicateButton.GetAttribute("class");
            string[] b = a.Split("action_");
            return b[1];
        }
        public string GetDependenciesButtonState()
        {
            string a = DependenciesButton.GetAttribute("class");
            string[] b = a.Split("action_");
            return b[1];
        }
        public string GetDeleteButtonState()
        {
            string a = DeleteButton.GetAttribute("class");
            string[] b = a.Split("action_");
            return b[1];
        }
        public IWebElement GetCalculationName()
        {
            return CalculationName;
        }
        public string GetCalculationNameErrorMessage()
        {
            return CalculationNameErrorMessage.Text;
        }
        public void ClickHoldingFileSelectionDropdown()
        {
            HoldingFileSelectionDropdown.Click();
        }
        public ArrayList GetHoldingFileSelectionSelectedItems()
        {
            ArrayList itemNames = new ArrayList();
            var items = HoldingFileSelectionSelectedItems;
            foreach (var item in items)
            {
                itemNames.Add(item.Text);
            }
            return itemNames;
        }
        public string GetHoldingFileSelectionSelectedItemYearEndState()
        {
            string a = HoldingFileSelectionSelectedItemYearEndState.GetAttribute("class");
            string[] b = a.Split("state-");
            return b[1];
        }
        public void ClickHoldingFileSelectionSelectedItemQ1DeleteIcon()
        {
            HoldingFileSelectionSelectedItemQ1DeleteIcon.Click();
        }
        public void ClickHoldingFileSelectionSelectedItemQ2DeleteIcon()
        {
            HoldingFileSelectionSelectedItemQ2DeleteIcon.Click();
        }
        public void ClickHoldingFileSelectionSelectedItemQ3DeleteIcon()
        {
            HoldingFileSelectionSelectedItemQ3DeleteIcon.Click();
        }
        public IList<IWebElement> GetHoldingFileSelectionDropdownItems()
        {
            return HoldingFileSelectionDropdownItems;
        }
        public ArrayList GetHoldingFileSelectionDropdownItemsList()
        {
            ArrayList itemNames = new ArrayList();
            var items = GetHoldingFileSelectionDropdownItems();
            foreach (var item in items)
            {
                itemNames.Add(item.Text);
            }
            return itemNames;
        }
        public IWebElement GetHoldingFileSelectionDropdownYearEndCheckbox()
        {
            return HoldingFileSelectionDropdownYearEndCheckbox;
        }
        public string GetHoldingFileSelectionDropdownYearEndNameState()
        {
            string a = HoldingFileSelectionDropdownYearEndNameState.GetAttribute("class");
            string[] b = a.Split("state-");
            return b[1];
        }
        public void ClickHoldingFileSelectionDropdownQ1Name()
        {
            HoldingFileSelectionDropdownQ1Name.Click();
        }
        public IWebElement GetHoldingFileSelectionDropdownQ1Checkbox()
        {
            return HoldingFileSelectionDropdownQ1Checkbox;
        }
        public void ClickHoldingFileSelectionDropdownQ2Name()
        {
            HoldingFileSelectionDropdownQ2Name.Click();
        }
        public IWebElement GetHoldingFileSelectionDropdownQ2Checkbox()
        {
            return HoldingFileSelectionDropdownQ2Checkbox;
        }
        public void ClickHoldingFileSelectionDropdownQ3Name()
        {
            HoldingFileSelectionDropdownQ3Name.Click();
        }
        public IWebElement GetHoldingFileSelectionDropdownQ3Checkbox()
        {
            return HoldingFileSelectionDropdownQ3Checkbox;
        }






        public CalculationManagementPageNew ClickSaveButtonError()
        {
            SaveButton.Click();
            return new CalculationManagementPageNew(driver);
        }
        public CalculationManagementPageEdit ClickSaveButtonSuccess()
        {
            SaveButton.Click();
            return new CalculationManagementPageEdit(driver);
        }
        public CalculationManagementPageNew ClickCancelButton()
        {
            CancelButton.Click();
            return new CalculationManagementPageNew(driver);
        }
    }
}
