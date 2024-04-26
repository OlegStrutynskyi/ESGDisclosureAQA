using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
    public class WorkingProgramLibraryPage
    {
        IWebDriver driver;

        public WorkingProgramLibraryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.XPath, Using = "//p[normalize-space()='Working Program Library']")]
        private IWebElement WorkingProgramLibraryTitle;



        public string GetWorkingProgramLibraryTitle()
        {
            return WorkingProgramLibraryTitle.Text;
        }

    }
}
