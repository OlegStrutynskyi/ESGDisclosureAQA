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
    public class QuestionManagementPageEdit
    {
        IWebDriver driver;

        public QuestionManagementPageEdit(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement QuestionManagementBladeEdit
            => driver.FindElement(By.XPath("//div[@class='pwc-sdk-ui-blade question-management-blade']"));

        private IWebElement QuestionManagementBladeEditTitle
            => driver.FindElement(By.XPath("(//p[@class='pwc-sdk-ui-main-text'])[4]"));


        private IWebElement QuestionManagementBladeEditSubTitle
            => driver.FindElement(By.XPath("(//p[@class='pwc-sdk-ui-sub-text'])[4]"));




        public IWebElement GetQuestionManagementBladeEdit()
        {
            return QuestionManagementBladeEdit;
        }

        public string GetQuestionManagementBladeEditTitle()
        {
            return QuestionManagementBladeEditTitle.Text;
        }

        public string GetQuestionManagementBladeEditSubTitle()
        {
            return QuestionManagementBladeEditSubTitle.Text;
        }
    }
}
