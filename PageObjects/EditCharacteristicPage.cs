using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject1.PageObjects
{
    public class EditCharacteristicPage
    {
        IWebDriver driver;
        public EditCharacteristicPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//pwc-sdk-ui-blade[@blade-title='Edit Characteristic']")]
        private IWebElement EditCharacteristicBlade;

        [FindsBy(How = How.XPath, Using = "//pwc-sdk-ui-blade[@blade-title='Edit Characteristic']")]
        private IList<IWebElement> EditCharacteristicBladeList;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Edit Characteristic')]")]
        private IWebElement EditCharacteristicPageTitle;

        [FindsBy(How = How.CssSelector, Using = "#undefined")]
        private IWebElement CharacteristicName;

        [FindsBy(How = How.CssSelector, Using = ".esg-disclosure-blade-footer .btn.btn-cancel.sdk-btn-tertiary")]
        private IWebElement CancelButton;

        [FindsBy(How = How.CssSelector, Using = ".esg-disclosure-blade-footer .btn.btn-primary")]
        private IWebElement SaveButton;

        [FindsBy(How = How.XPath, Using = "//p[normalize-space()='Edit Characteristic']/../../preceding-sibling::section//i[@class='close']")]
        private IWebElement CloseButton;

        [FindsBy(How = How.CssSelector, Using = ".control-error__message")]
        private IWebElement ErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".modal-container")]
        private IWebElement WarningWindow;

        [FindsBy(How = How.CssSelector, Using = ".modal-container")]
        private IList<IWebElement> WarningWindowList;

        [FindsBy(How = How.CssSelector, Using = ".header__title")]
        private IWebElement WarningWindowTitle;

        [FindsBy(How = How.CssSelector, Using = ".confirmation-modal-body")]
        private IWebElement WarningWindowMessage;

        [FindsBy(How = How.CssSelector, Using = ".footer .btn.sdk-btn-tertiary")]
        private IWebElement WarningWindowCancelButton;

        [FindsBy(How = How.CssSelector, Using = ".footer .btn.btn-primary.btn-confirm")]
        private IWebElement WarningWindowContinueButton;

        [FindsBy(How = How.CssSelector, Using = ".modal-container__close")]
        private IWebElement WarningWindowCloseButton;




        public EditCharacteristicPage NavigateToEditCharacteristicPage()
        {
            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime;


            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageCharactericticsClickable();
            ManageCharacteristicsPage manageCharacteristicsPage = adminSettingsPage.ClickManageCharacteristicsMenuItem();
            manageCharacteristicsPage.WaitAddNewCharacteristicButtonClickable();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplay();
            manageCharacteristicsPage.ClickRowsPerPage50();
            driver.FindElement(By.XPath("//div[@title='" + expectedCharacteristicName + "']/../following-sibling::td[3]/div/action-button[@icon='edit']/div/i")).Click();//How to move it to PO?
           
            return new EditCharacteristicPage(driver);
        }

        public IWebElement GetEditCharacteristicBlade()
        {
            return EditCharacteristicBlade;
        }

        public IList<IWebElement> GetEditCharacteristicBladeList()
        {
            return EditCharacteristicBladeList;
        }

        public string GetEditCharacteristicPageTitle()
        {
            return EditCharacteristicPageTitle.Text;
        }

        public IWebElement GetCharacteristicName()
        {
            return CharacteristicName;
        }

        public void ClickCharacteristicName()
        {
            CharacteristicName.Click();
        }

        public void ClearCharacteriticName()
        {
            Actions action = new Actions(driver);

            ClickCharacteristicName();
            action.KeyDown(Keys.Control).SendKeys("a")
                .KeyUp(Keys.Control).SendKeys(Keys.Delete).Perform();
        }

        public EditCharacteristicPage ClickCancelButton()
        {
            CancelButton.Click();
            return new EditCharacteristicPage(driver);
        }

        public void ClickCloseButtonWithChanges()
        {
            CloseButton.Click();
        }

        public ManageCharacteristicsPage ClickCloseButtonWithouChanges()
        {
            CloseButton.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public ManageCharacteristicsPage ClickSaveButtonSuccess()
        {
            SaveButton.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public EditCharacteristicPage ClickSaveButtonUnsuccess()
        {
            SaveButton.Click();
            return new EditCharacteristicPage(driver);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public IWebElement GetWarningWindow()
        {
            GetCharacteristicName().Clear();
            GetCharacteristicName().SendKeys("123");
            ClickCloseButtonWithChanges();
            return WarningWindow;
        }

        public IList<IWebElement> GetWarningWindowList()
        {
            ClearCharacteriticName();
            GetCharacteristicName().SendKeys("123");
            ClickCloseButtonWithChanges();
            return WarningWindowList;
        }

        public string GetWarningWindowTitle()
        {
            return WarningWindowTitle.Text;
        }

        public string GetWarningWindowMessage()
        {
            return WarningWindowMessage.Text;
        }

        public EditCharacteristicPage ClickWarningWindowCancelButton()
        {
            WarningWindowCancelButton.Click();
            return new EditCharacteristicPage(driver);
        }

        public EditCharacteristicPage ClickWarningWindowCloseButton()
        {
            WarningWindowCloseButton.Click();
            return new EditCharacteristicPage(driver);
        }

        public ManageCharacteristicsPage ClickWarningWindowContinueButton()
        {
            WarningWindowContinueButton.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public void WaitCharacteristicNameDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(GetCharacteristicName(), "A_Selenium"));
        }

        public string GetCharactericticNameText()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string element = (string)js.ExecuteScript("return document.getElementById('undefined').value");
            return element;
        }

        /*
        public string GetCharactericticNameText()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var element = js.ExecuteScript("return document.querySelector('.text-input__control').shadowRoot.querySelectorAll('#placeholder + div');");
            return element.ToString();
        }

        /* public IWebElement FindShadowRootElement(IWebDriver driver, string[] Selectors)
         {
             IWebElement root = null;
             foreach(var selector in Selectors)
             {
                 root = (IWebElement)((IJavaScriptExecutor)driver)
                     .ExecuteScript("return arguments[0].querySelector(arguments[1]).shadowRoot", root, selector);
             }
             return root;
         }
         public string GetCharactericticNameText()
         {
             string[] shadowSelectors = { 
                // "input#undefined.text-input__control.ng-valid.ng-touched.ng-dirty" 
                "#undefined" };
             By selector = By.XPath("//div[@id='placeholder']/following-sibling::div");

             string c = FindShadowRootElement(driver, shadowSelectors).FindElement(selector).Text;
             return c;
         }

        public ISearchContext GetShadowRoot()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#undefined")));
            //return GetCharacteristicName().GetShadowRoot();
            return driver.FindElement(By.CssSelector("#undefined")).GetShadowRoot();
        }

        public IWebElement GetText()
        {
            IWebElement element;
            element = GetShadowRoot().FindElement(By.XPath("//div[@id='placeholder']/following-sibling::div"));
            return element;
        }*/
    }
}
