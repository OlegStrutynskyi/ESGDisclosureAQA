using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.PageObjects;

namespace TestProject1.Utilities
{
    public class Base
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {

        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Manage().Window.Maximize();

            driver.Url = "https://lux-dev.pwchalo.com//#/HomeSiteDashboard";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.ValidLogin();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }




    }
}
