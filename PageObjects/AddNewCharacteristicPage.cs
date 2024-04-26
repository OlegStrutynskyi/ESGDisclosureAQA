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
    public class AddNewCharacteristicPage
    {
        IWebDriver driver;

        public AddNewCharacteristicPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement AddNewCharacteristicBlade
            => driver.FindElement(By.XPath("//pwc-sdk-ui-blade[@blade-title='Add New Characteristic']"));
        private IList<IWebElement> AddNewCharacteristicBladeList
            => driver.FindElements(By.XPath("//pwc-sdk-ui-blade[@blade-title='Add New Characteristic']"));
        private IWebElement AddNewCharacteristicPageTitle
             => driver.FindElement(By.XPath("//p[contains(text(),'Add New Characteristic')]"));
        private IWebElement CharacteristicName
            => driver.FindElement(By.CssSelector("#undefined"));
        private IWebElement CancelButton
            => driver.FindElement(By.CssSelector(".esg-disclosure-blade-footer .btn.btn-cancel.sdk-btn-tertiary"));
        private IWebElement SaveButton
            => driver.FindElement(By.CssSelector(".esg-disclosure-blade-footer .btn.btn-primary"));
        private IWebElement CloseButton
            => driver.FindElement(By.XPath("//p[normalize-space()='Add New Characteristic']/../../preceding-sibling::section//i[@class='close']"));
        private IWebElement ErrorMessage
            => driver.FindElement(By.CssSelector(".control-error__message"));
        private IWebElement WarningWindow
            => driver.FindElement(By.CssSelector(".modal-container"));
        private IList<IWebElement> WarningWindowList
            => driver.FindElements(By.CssSelector(".modal-container"));
        private IWebElement WarningWindowTitle
            => driver.FindElement(By.CssSelector(".header__title"));
        private IWebElement WarningWindowMessage
            => driver.FindElement(By.CssSelector(".confirmation-modal-body"));
        private IWebElement WarningWindowCancelButton
            => driver.FindElement(By.CssSelector(".footer .btn.sdk-btn-tertiary"));
        private IWebElement WarningWindowContinueButton
            => driver.FindElement(By.CssSelector(".footer .btn.btn-primary.btn-confirm"));
        private IWebElement WarningWindowCloseButton
            => driver.FindElement(By.CssSelector(".modal-container__close"));

        public AddNewCharacteristicPage NavigateToAddNewCharacteristicPage()
        {
            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageCharactericticsClickable();
            ManageCharacteristicsPage manageCharacteristicsPage = adminSettingsPage.ClickManageCharacteristicsMenuItem();
            manageCharacteristicsPage.WaitAddNewCharacteristicButtonClickable();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            return new AddNewCharacteristicPage(driver);
        }

        public IWebElement GetAddNewCharacteristicBlade()
        {
            return AddNewCharacteristicBlade;
        }
        public IList<IWebElement> GetAddNewCharacteristicBladeList()
        {
            return AddNewCharacteristicBladeList;
        }
        public string GetAddNewCharacteristicPageTitle()
        {
            return AddNewCharacteristicPageTitle.Text;
        }
        public IWebElement GetCharacteristicName()
        {
            return CharacteristicName;
        }
        public void ClickCharacteristicName()
        {
            CharacteristicName.Click();            
        }
        public void WaitCharacteristicNameDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#undefined")));
        }
        public void ClearCharacteriticName()
        {
            Actions action = new Actions(driver);

            ClickCharacteristicName();
            action.KeyDown(Keys.Control).SendKeys("a")
                .KeyUp(Keys.Control).SendKeys(Keys.Delete).Perform();
        }
        public AddNewCharacteristicPage ClickCancelButton()
        {
            CancelButton.Click();
            return new AddNewCharacteristicPage(driver);
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
        public AddNewCharacteristicPage ClickSaveButtonUnsuccess()
        {
            SaveButton.Click();
            return new AddNewCharacteristicPage(driver);
        }
        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public IWebElement GetWarningWindow()
        {
            GetCharacteristicName().SendKeys("123");
            ClickCloseButtonWithChanges();
            return WarningWindow;
        }

        public IList<IWebElement> GetWarningWindowList()
        {
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

        public AddNewCharacteristicPage ClickWarningWindowCancelButton()
        {
            WarningWindowCancelButton.Click();
            return new AddNewCharacteristicPage(driver);
        }

        public AddNewCharacteristicPage ClickWarningWindowCloseButton()
        {
            WarningWindowCloseButton.Click();
            return new AddNewCharacteristicPage(driver);
        }

        public ManageCharacteristicsPage ClickWarningWindowContinueButton()
        {
            WarningWindowContinueButton.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public string GetCharactericticNameText()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //var element = js.ExecuteScript("return document.querySelector('.text-input__control').value;");
            //return element.ToString();
            string element = (string)js.ExecuteScript("return document.getElementById('undefined').value");
            return element;
        }

        public string GetCharactericticNameText2()
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
