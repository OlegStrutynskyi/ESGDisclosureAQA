using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
    public class AdminSettingsPage
    {
        IWebDriver driver;

        public AdminSettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".pwc-sdk-ui-main-text")]
        private IWebElement AdminSettingsTitle;

        [FindsBy(How = How.CssSelector, Using = ".pwc-sdk-ui-sub-text")]
        private IWebElement AdminSettingsSubTitle;

        [FindsBy(How = How.CssSelector, Using = ".esg-blade-action__icon")]
        private IWebElement ManageTeamIcon;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Manage Templates']")]
        private IWebElement ManageTemplatesMenuItem;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Manage Calculations']")]
        private IWebElement ManageCalculationsMenuItem;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Manage Characteristics']")]
        private readonly IWebElement ManageCharacteristicsMenuItem;


        public string GetAdminSettingsTitle()
        {
            return AdminSettingsTitle.Text;
        }

        public string GetAdminSettingsSubTitle()
        {
            return AdminSettingsSubTitle.Text;
        }

        public IWebElement GetManageTeamIcon()
        {
            return ManageTeamIcon;
        }

        public IWebElement GetManageTemplatesMenuItem()
        {
            return ManageTemplatesMenuItem;
        }

        public IWebElement GetManageCharacteristicsMenuItem()
        {
            return ManageCharacteristicsMenuItem;
        }

        public IWebElement GetManageCalculationsMenuItem()
        {
            return ManageCalculationsMenuItem;
        }

        public ManageTemplatesPage ClickManageTemplatesMenuItem()
        {
            ManageTemplatesMenuItem.Click();
            return new ManageTemplatesPage(driver);
        }

        public void WaitUntilManageTemplatesClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetManageTemplatesMenuItem()));
        }

        public ManageCalculationsPage ClickManageCalculationsMenuItem()
        {
            ManageCalculationsMenuItem.Click();
            return new ManageCalculationsPage(driver);
        }

        public void WaitUntilManageCalculationsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetManageCalculationsMenuItem()));
        }

        public ManageCharacteristicsPage ClickManageCharacteristicsMenuItem()
        {
            ManageCharacteristicsMenuItem.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public void WaitUntilManageCharactericticsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetManageCharacteristicsMenuItem()));
        }
    }
}
