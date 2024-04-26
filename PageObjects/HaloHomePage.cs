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
    public class HaloHomePage
    {
        private IWebDriver driver;

        public HaloHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='row row-container']/div/div[@class='title']")]
        private IWebElement HaloWelcomeMessage;

        [FindsBy(How = How.CssSelector, Using = "a[title='ESG Disclosure']")]
        private IWebElement DisclosureMainMenuItem;


        public string GetHaloWelcomeMessage()
        {
            return HaloWelcomeMessage.Text;
        }

        public IWebElement GetDisclosureMainMenuItem()
        {
            return DisclosureMainMenuItem;
        }

        public AdminSettingsPage GetAdminSettingsPage()
        {
            WaitDisclosureItemDisplay();
            GetDisclosureMainMenuItem().Click();
            return new AdminSettingsPage(driver);
        }

        public void WaitDisclosureItemDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[title='ESG Disclosure']")));
        }

    }
}
