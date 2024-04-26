using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
    public class ManageTemplatesPage
    {
        IWebDriver driver;

        public ManageTemplatesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Manage Templates')]")]
        private IWebElement ManageTemplatesPageTitle;

        [FindsBy(How = How.XPath, Using = "(//p[normalize-space()='EU'])[2]")]
        private IWebElement ManageTemplatesPageSubTitle;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Add New Template']")]
        private IWebElement AddNewTemplateButton;

        [FindsBy(How = How.CssSelector, Using = ".chart__title-center")]
        private IWebElement TemplateCounterInTile;

        [FindsBy(How = How.CssSelector, Using = ".item__name")]
        private IList<IWebElement> WorkflowStatusInTileList;

        private IWebElement WorkflowStatusInTileInProgress
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'In Progress')]"));

        private IWebElement WorkflowStatusInTilePrepared
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Prepared')]"));

        private IWebElement WorkflowStatusInTileModifiedSincePrepared
                    => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Modified Since Prepared')]"));

        private IWebElement WorkflowStatusInTileReviewed
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Reviewed')]"));

        private IWebElement WorkflowStatusInTileModifiedSinceReviewed
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Modified Since Reviewed')]"));

        private IWebElement WorkflowStatusInTileInProgressValue
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'In Progress')]/../following-sibling::div[@class='item__value']"));

        private IWebElement WorkflowStatusInTilePreparedValue
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Prepared')]/../following-sibling::div[@class='item__value']"));

        private IWebElement WorkflowStatusInTileModifiedSincePreparedValue
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Modified Since Prepared')]/../following-sibling::div[@class='item__value']"));

        private IWebElement WorkflowStatusInTileReviewedValue
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Reviewed')]/../following-sibling::div[@class='item__value']"));

        private IWebElement WorkflowStatusInTileModifiedSinceReviewedValue
            => driver.FindElement(By.XPath("//div[@class='legend-items column']//div[contains(text(),'Modified Since Reviewed')]/../following-sibling::div[@class='item__value']"));



        [FindsBy(How = How.CssSelector, Using = ".k-input")]
        private IWebElement WorkflowStatusFilter;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']")]
        private IList<IWebElement> WorkflowStatusFilterItems;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']/div/div[text()='In Progress']")]
        private IWebElement WorkflowStatusFilterInProgress;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']/div/div[text()='Prepared']")]
        private IWebElement WorkflowStatusFilterPrepared;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']/div/div[text()='Modified Since Prepared']")]
        private IWebElement WorkflowStatusFilterModifiedSincePrepared;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']/div/div[text()='Reviewed']")]
        private IWebElement WorkflowStatusFilterReviewed;

        [FindsBy(How = How.XPath, Using = "//li[@role='option']/div/div[text()='Modified Since Reviewed']")]
        private IWebElement WorkflowStatusFilterModifiedSinceReviewed;

        [FindsBy(How = How.CssSelector, Using = ".reset-filters-btn")]
        private IWebElement ResetAllFiltersButton;

        [FindsBy(How = How.CssSelector, Using = ".templates__count")]
        private IWebElement TemplatesCount;
        
        private IWebElement EmptyGridMessage
            => driver.FindElement(By.CssSelector(".empty-message__title"));

        private IWebElement EmptyGridImage
            => driver.FindElement(By.CssSelector(".placeholder-image"));


        [FindsBy(How = How.CssSelector, Using = ".ml-1.bold-text.template-title")]
        private IList<IWebElement> ExistingTemplateNames;

        [FindsBy(How = How.XPath, Using = "//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/status-label/div/div")]
        private IWebElement PrecTemplateWorkflowStatusIcon;

        [FindsBy(How = How.XPath, Using = "//div[text()=' To Challenge - Periodic ']/../preceding-sibling::div/div/status-label/div/div")]
        private IWebElement PerTemplateWorkflowStatusIcon;

        [FindsBy(How = How.XPath, Using = "//div[@class='status-label']/div")]
        private IList<IWebElement> TemplateWorkflowStatusIconList;

        [FindsBy(How = How.XPath, Using = "//div[@class='status-label']/div")]
        private IWebElement TemplateWorkflowStatusIcon;

        [FindsBy(How = How.XPath, Using = "//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/span")]
        private IWebElement PrecTemplateName;

        [FindsBy(How = How.XPath, Using = "//div[text()=' To Challenge - Periodic ']/../preceding-sibling::div/div/span[@class='ml-1 bold-text template-title']")]
        private IWebElement PerTemplateName;

        [FindsBy(How = How.XPath, Using =
            //"//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/action-button/div[@title='Edit']"
            //"//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/action-button/div/i[@class='esg-disc-icon esg-disc-icon-edit']"
            "//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/action-button[@icon='edit']/div/i")]
        private IWebElement PrecTemplateEditIcon;

        [FindsBy(How = How.XPath, Using =
            //"//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/action-button/div[@title='Edit']"
            //"//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/action-button/div/i[@class='esg-disc-icon esg-disc-icon-edit']"
            "//div[text()=' To Challenge - Periodic ']/../preceding-sibling::div/div/action-button[@icon='edit']/div/i")]
        private IWebElement PerTemplateEditIcon;

        [FindsBy(How = How.XPath, Using = "//div[text()=' Source - Pre-contractual ']/../preceding-sibling::div/div/action-button[@icon='delete']")]
        private IWebElement PrecTemplateDeleteIcon;

        [FindsBy(How = How.XPath, Using = "//div[text()=' To Challenge - Periodic ']/../preceding-sibling::div/div/action-button[@icon='delete']")]
        private IWebElement PerTemplateDeleteIcon;

        [FindsBy(How = How.CssSelector, Using = ".modal-container")]
        private IWebElement DeleteTemplateWarningWindow;

        [FindsBy(How = How.CssSelector, Using = ".header__title")]
        private IWebElement DeleteTemplateWarningWindowTitle;

        [FindsBy(How = How.CssSelector, Using = ".confirmation-modal-body")]
        private IWebElement DeleteTemplateWarningWindowMessage;

        [FindsBy(How = How.CssSelector, Using = ".btn.sdk-btn-tertiary")]
        private IWebElement DeleteTemplateWarningWindowCancelBtn;

        [FindsBy(How = How.CssSelector, Using = ".esg-disc-icon.esg-disc-icon-close")]
        private IWebElement DeleteTemplateWarningWindowCloseBtn;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary.btn-confirm")]
        private IWebElement DeleteTemplateWarningWindowContinueBtn;



        public ManageTemplatesPage NavigateToManageTemplatesPage()
        {
            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageTemplatesClickable();
            ManageTemplatesPage manageTemplatesPage = adminSettingsPage.ClickManageTemplatesMenuItem();
            return new ManageTemplatesPage(driver);
        }

        public string GetManageTemplatesPageTitle()
        {
            return ManageTemplatesPageTitle.Text;
        }

        public string GetManageTemplatesPageSubTitle()
        {
            return ManageTemplatesPageSubTitle.Text;
        }

        public TemplateOverviewPageNew ClickAddNewTemplateButton()
        {
            AddNewTemplateButton.Click();
            return new TemplateOverviewPageNew(driver);
        }

        public int GetTemplateCounterInTile()
        {
            return Int32.Parse(TemplateCounterInTile.Text);
        }

        public IList<IWebElement> GetWorkflowStatusInTileList()
        {
            return WorkflowStatusInTileList;
        }

        public void WaitWorkflowStatusInTileClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".item__name")));
        }

        public void ClickWorkflowStatusInTileInProgress()
        {
            WaitWorkflowStatusInTileClickable();
            WorkflowStatusInTileInProgress.Click();
        }

        public void ClickWorkflowStatusInTilePrepared()
        {
            WaitWorkflowStatusInTileClickable();
            WorkflowStatusInTilePrepared.Click();
        }

        public void ClickWorkflowStatusInTileModifiedSincePrepared()
        {
            WaitWorkflowStatusInTileClickable();
            WorkflowStatusInTileModifiedSincePrepared.Click();
        }

        public void ClickWorkflowStatusInTileReviewed()
        {
            WaitWorkflowStatusInTileClickable();
            WorkflowStatusInTileReviewed.Click();
        }

        public void ClickWorkflowStatusInTileModifiedSinceReviewed()
        {
            WaitWorkflowStatusInTileClickable();
            WorkflowStatusInTileModifiedSinceReviewed.Click();
        }

        public int GetWorkflowStatusInTileInProgressValue()
        {
            return Int32.Parse(WorkflowStatusInTileInProgressValue.Text);
        }

        public int GetWorkflowStatusInTilePreparedValue()
        {
            return Int32.Parse(WorkflowStatusInTilePreparedValue.Text);
        }

        public int GetWorkflowStatusInTileModifiedSincePreparedValue()
        {
            return Int32.Parse(WorkflowStatusInTileModifiedSincePreparedValue.Text);
        }

        public int GetWorkflowStatusInTileReviewedValue()
        {
            return Int32.Parse(WorkflowStatusInTileReviewedValue.Text);
        }

        public int GetWorkflowStatusInTileModifiedSinceReviewedValue()
        {
            return Int32.Parse(WorkflowStatusInTileModifiedSinceReviewedValue.Text);
        }



        public string GetWorkflowStatusFilterText()
        {
            return WorkflowStatusFilter.Text;
        }

        public void ClickWorkflowStatusFilter()
        {
            WorkflowStatusFilter.Click();
        }

        public ArrayList GetWorkflowStatusFilterItems()
        {
            ArrayList workflowStatusFilterItems = new ArrayList();

            ClickWorkflowStatusFilter();
            WaitWorkflowStatusFilterItemDisplayed();
            foreach (var item in WorkflowStatusFilterItems)
            {
                workflowStatusFilterItems.Add(item.Text);
            }
            return workflowStatusFilterItems;
        }

        public void WaitWorkflowStatusFilterItemDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@role='option']")));
        }

        public void SelectWorkflowStatusFilterInProgress()
        {
            ClickWorkflowStatusFilter();
            WaitWorkflowStatusFilterItemDisplayed();
            WorkflowStatusFilterInProgress.Click();
        }

        public void SelectWorkflowStatusFilterPrepared()
        {
            ClickWorkflowStatusFilter();
            WaitWorkflowStatusFilterItemDisplayed();
            WorkflowStatusFilterPrepared.Click();
        }

        public void SelectWorkflowStatusFilterModifiedSincePrepared()
        {
            ClickWorkflowStatusFilter();
            WaitWorkflowStatusFilterItemDisplayed();
            WorkflowStatusFilterModifiedSincePrepared.Click();
        }

        public void SelectWorkflowStatusFilterReviewed()
        {
            ClickWorkflowStatusFilter();
            WaitWorkflowStatusFilterItemDisplayed();
            WorkflowStatusFilterReviewed.Click();
        }

        public void SelectWorkflowStatusFilterModifiedSinceReviewed()
        {
            ClickWorkflowStatusFilter();
            WaitWorkflowStatusFilterItemDisplayed();
            WorkflowStatusFilterModifiedSinceReviewed.Click();
        }

        public void ClickResetAllFiltersButton()
        {
            ResetAllFiltersButton.Click();
        }

        public IWebElement GetTemplatesCount()
        {
            return TemplatesCount;
        }

        public int GetTemplatesCountValue()
        {
            WaitTemplatesCountDisplayed();
            return Int32.Parse(TemplatesCount.Text);
        }

        public string GetTemplatesCountText()
        {
            return TemplatesCount.Text;
        }

        public void WaitTemplatesCountDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(GetTemplatesCount(), GetTemplatesCountText()));
        }

        public string GetEmptyGridMessageText()
        {
            return EmptyGridMessage.Text;
        }

        public IWebElement GetEmptyGridImage()
        {
            return EmptyGridImage;
        }

        public IList<IWebElement> GetExistingTemplateNamesList()
        {
            return ExistingTemplateNames;
        }

        public ArrayList GetAllTemplateNames()
        {
            ArrayList templatesInUI = new ArrayList();
                        
            var templateNameList = GetExistingTemplateNamesList();
            foreach (var templateName in templateNameList)
            {
                templatesInUI.Add(templateName.Text);
            }
            return templatesInUI;
        }

        public string GetPrecTemplateWorkflowStatusIconClass()
        {
            return PrecTemplateWorkflowStatusIcon.GetAttribute("class");
        }

        public string GetPerTemplateWorkflowStatusIconClass()
        {
            return PerTemplateWorkflowStatusIcon.GetAttribute("class");
        }

        public IList<IWebElement> GetTemplateWorkflowStatusIconList()
        {
            return TemplateWorkflowStatusIconList;
        }

        public string GetWorkflowStatusFromAtr()
        {
            string a = TemplateWorkflowStatusIcon.GetAttribute("class");
            string[] b = a.Split("_");
            string[] c = b[1].Split(" ");
            return c[0];
        }

        public IWebElement GetPrecTemplateName()
        {
            return PrecTemplateName;
        }

        public string GetPrecTemplateNameText()
        {
            return PrecTemplateName.Text;
        }

        public IWebElement GetPerTemplateName()
        {
            return PerTemplateName;
        }

        public string GetPerTemplateNameText()
        {
            return PerTemplateName.Text;
        }

        public TemplateOverviewPageNew ClickPrecTemplateName()
        {
            Actions a = new Actions(driver);
            a.ScrollToElement(GetPrecTemplateName()).Perform();
            PrecTemplateName.Click();
            return new TemplateOverviewPageNew(driver);
        }

        public TemplateOverviewPageNew ClickPerTemplateName()
        {
            Actions a = new Actions(driver);
            a.ScrollToElement(GetPerTemplateName()).Perform();
            PerTemplateName.Click();
            return new TemplateOverviewPageNew(driver);
        }

        public IWebElement GetPrecTemplateEditIcon()
        {
            return PrecTemplateEditIcon;
        }

        public IWebElement GetPerTemplateEditIcon()
        {
            return PerTemplateEditIcon;
        }
        
        public TemplateOverviewPageNew ClickPrecTemplateEditIcon()
        {
            Actions a = new Actions(driver);
            a.ScrollToElement(GetPrecTemplateEditIcon()).Perform();
            PrecTemplateEditIcon.Click();
            return new TemplateOverviewPageNew(driver);
        }

        public TemplateOverviewPageNew ClickPerTemplateEditIcon()
        {
            Actions a = new Actions(driver);
            a.ScrollToElement(GetPerTemplateEditIcon()).Perform();
            PerTemplateEditIcon.Click();
            return new TemplateOverviewPageNew(driver);
        }
        
        public void WaitPrecEditIconClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetPrecTemplateEditIcon()));
        }

        public void WaitPerEditIconClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetPerTemplateEditIcon()));
        }

        public void WaitPrecTemplateNameClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetPrecTemplateName()));
        }

        public void WaitPerTemplateNameClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetPerTemplateName()));
        }

        public IWebElement GetPrecTemplateDeleteIcon()
        {
            return PrecTemplateDeleteIcon;
        }

        public IWebElement GetPerTemplateDeleteIcon()
        {
            return PerTemplateDeleteIcon;
        }

        public void ClickPrecTemplateDeleteIcon()
        {
            Actions a = new Actions(driver);
            a.ScrollToElement(GetPrecTemplateDeleteIcon()).Perform();
            PrecTemplateDeleteIcon.Click();            
        }

        public void ClickPerTemplateDeleteIcon()
        {
            Actions a = new Actions(driver);
            a.ScrollToElement(GetPerTemplateDeleteIcon()).Perform();
            PerTemplateDeleteIcon.Click();
        }

        public void WaitPrecDeleteIconClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetPrecTemplateDeleteIcon()));
        }

        public void WaitPerDeleteIconClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetPerTemplateDeleteIcon()));
        }

        public IWebElement GetDeleteTemplateWarningWindow()
        {
            return DeleteTemplateWarningWindow;
        }

        public string GetDeleteTemplateWarningWindowTitle()
        {
            return DeleteTemplateWarningWindowTitle.Text;
        }

        public string GetDeleteTemplateWarningWindowMessage()
        {
            return DeleteTemplateWarningWindowMessage.Text;
        }

        public ManageCalculationsPage ClickDeleteTemplateWarningWindowCancelBtn()
        {
            DeleteTemplateWarningWindowCancelBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDeleteTemplateWarningWindowCloseBtn()
        {
            DeleteTemplateWarningWindowCloseBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDeleteTemplateWarningWindowContinueBtn()
        {
            DeleteTemplateWarningWindowContinueBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public List<string> GetTemplateNamesListFromDB()
        {
            var templateNamesList = new List<string>();
            try
            {
                string connectionString = @"Data Source=ludbs831.lu.ema.ad.pwcinternal.com; Initial Catalog=EsgDisclosure;User ID=PrismDevUser;Password=Sjbxemua874";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Creating the command object
                    SqlCommand command = new SqlCommand("SELECT TemplateName FROM [EsgDisclosure].[AdminSetup].[Template] WHERE IsDeleted = 0", connection);

                    // Opening Connection  
                    connection.Open();

                    // Executing the SQL query  
                    SqlDataReader sdr = command.ExecuteReader();

                    //Looping through each record
                    while (sdr.Read())
                    {
                        //Console.WriteLine(sdr["Name"]);
                        templateNamesList.Add((string)sdr["TemplateName"]);
                    }
                }
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("Error. List from DB is wrong. Error: " + e);
            }
            templateNamesList.Sort();
            templateNamesList.ForEach(item => Console.WriteLine(item));//Print list
            return templateNamesList;
        }
    }
}
