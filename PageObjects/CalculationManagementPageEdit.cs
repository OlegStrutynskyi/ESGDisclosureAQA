using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TestProject1.PageObjects
{
    public class CalculationManagementPageEdit
    {
        IWebDriver driver;

        public CalculationManagementPageEdit(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement CalculationManagementBladeEdit
            => driver.FindElement(By.XPath("//div[@class='pwc-sdk-ui-blade calculation-management-blade']"));

        private IWebElement CalculationManagementBladeEditTitle
            => driver.FindElement(By.XPath("(//p[@class='pwc-sdk-ui-main-text'])[3]"));


        private IWebElement CalculationManagementBladeEditSubTitle
            => driver.FindElement(By.XPath("(//p[@class='pwc-sdk-ui-sub-text'])[3]"));




        public IWebElement GetCalculationManagementBladeEdit()
        {
            return CalculationManagementBladeEdit;
        }

        public string GetCalculationManagementBladeEditTitle()
        {
            return CalculationManagementBladeEditTitle.Text;
        }

        public string GetCalculationManagementBladeEditSubTitle()
        {
            return CalculationManagementBladeEditSubTitle.Text;
        }

    }
}
