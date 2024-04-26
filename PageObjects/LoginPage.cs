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
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "initEmail")]
        private IWebElement loginEmail;

        [FindsBy(How = How.CssSelector, Using = "button[type = 'submit']")]
        private IWebElement loginButton;

        public HaloHomePage ValidLogin()
        {
            loginEmail.SendKeys("p@pwc.lu");
            loginButton.Click();
            return new HaloHomePage(driver);
        }

    }
}
