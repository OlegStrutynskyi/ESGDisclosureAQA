using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Collections;
using System.Collections.Generic;
using TestProject1.Utilities;

namespace TestProject1.PageObjects
{
    public class TemplateOverviewPageNew
    {
        IWebDriver driver;
        public TemplateOverviewPageNew(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='pwc-sdk-ui-blade template-overview-blade']")]
        private IWebElement TemplateOverviewBladeNew;

        [FindsBy(How = How.XPath, Using = "//p[normalize-space()='Template Overview']")]
        private IWebElement TemplateOverviewTitle;

        [FindsBy(How = How.XPath, Using = "//p[normalize-space()='Template Overview']/following-sibling::p")]
        private IWebElement TemplateOverviewSubTitle;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Working Program Library']")]
        private IWebElement WorkingProgramLibraryButton;

        //TODO: Template Name

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Template Type']/..//span[@class='k-dropdown-wrap']")]
        private IWebElement TemplateTypeDropdown;

        [FindsBy(How = How.XPath, Using = "//div[@class='k-nodata']/div")]
        private IWebElement TemplateTypeDropdownItem;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Section']/..//span[@class='k-dropdown-wrap']")]
        private IWebElement SectionDropdown;

        [FindsBy(How = How.XPath, Using = "//div[@class='k-nodata']/div")]
        private IWebElement SectionDropdownItem;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Enabled/Disabled']/..//span[@class='k-dropdown-wrap']")]
        private IWebElement EnabledDisabledDropdown;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']")]
        private IList<IWebElement> EnabledDisabledDropdownItems;




        public TemplateOverviewPageNew NavigateToTemplateOverviewPage()
        {
            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageTemplatesClickable();
            ManageTemplatesPage manageTemplatesPage = adminSettingsPage.ClickManageTemplatesMenuItem();
            TemplateOverviewPageNew templateOverviewPageNew = manageTemplatesPage.ClickAddNewTemplateButton();
            return new TemplateOverviewPageNew(driver);
        }
        
        public IWebElement GetTemplateOverviewBladeNew()
        {
            return TemplateOverviewBladeNew;
        }

        public string GetTemplateOverviewTitle()
        {
            return TemplateOverviewTitle.Text;
        }

        public string GetTemplateOverviewSubTitle()
        {
            return TemplateOverviewSubTitle.Text;
        }
        public void WaitTemplateOverviewSubTitleDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//p[@class='pwc-sdk-ui-sub-text'])[3]")));
        }
        public void WaitTemplateOverviewGridDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[aria-label='Data table']")));
        }

        public WorkingProgramLibraryPage ClickWorkingProgramLibraryButton()
        {
            WorkingProgramLibraryButton.Click();
            return new WorkingProgramLibraryPage(driver);
        }

        //TODO: GetTemplateName

        public void ClickTemplateTypeDropdown()
        {
            TemplateTypeDropdown.Click();
        }

        public string GetTemplateTypeDropdownItem()
        {
            return TemplateTypeDropdownItem.Text;
        }

        public void WaitTemplateTypeDropdownItemDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='k-nodata']/div")));
        }

        public void ClickSectionDropdown()
        {
            SectionDropdown.Click();
        }

        public string GetSectionDropdownItem()
        {
            return SectionDropdownItem.Text;
        }

        public void WaitSectionDropdownItemDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='k-nodata']/div")));
        }

        public void ClickEnabledDisabledDropdown()
        {
            EnabledDisabledDropdown.Click();
        }
        public ArrayList GetEnabledDisabledDropdownItems()
        {
            ArrayList enabledDisabledDropdownItems = new ArrayList();

            foreach (var item in EnabledDisabledDropdownItems)
            {
                enabledDisabledDropdownItems.Add(item.Text);
            }
            return enabledDisabledDropdownItems;
        }

        public void WaitEnabledDisabledDropdownItemDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@role='option']")));
        }

    }
}
