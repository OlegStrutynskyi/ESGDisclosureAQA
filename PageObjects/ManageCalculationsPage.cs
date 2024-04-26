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
    public class ManageCalculationsPage
    {
        IWebDriver driver;

        public ManageCalculationsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ManageCalculationsPageTitle
            => driver.FindElement(By.XPath("//p[normalize-space()='Manage Calculations']"));

        private IWebElement ManageCalculationsPageSubTitle
            => driver.FindElement(By.XPath("//p[normalize-space()='Manage Calculations']/following-sibling::p"));

        private IWebElement AddNewCalculationButton
            => driver.FindElement(By.XPath("//span[normalize-space()='Add New Calculation']"));

        private IWebElement CalculationCounterInTile
            => driver.FindElement(By.CssSelector(".chart__title-center"));

        private IList<IWebElement> WorkflowStatusInTileList
            => driver.FindElements(By.XPath("//div[@class='legend-items column']//div[@class='item__name']"));
        
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

        private IWebElement WorkflowStatusFilter
            => driver.FindElement(By.CssSelector(".k-input"));

        private IList<IWebElement> WorkflowStatusFilterItems
            => driver.FindElements(By.XPath("//li[@role='option']"));

        private IWebElement WorkflowStatusFilterInProgress
            => driver.FindElement(By.XPath("//li[@role='option']/div/div[text()='In Progress']"));

        private IWebElement WorkflowStatusFilterPrepared
             => driver.FindElement(By.XPath("//li[@role='option']/div/div[text()='Prepared']"));

        private IWebElement WorkflowStatusFilterModifiedSincePrepared
             => driver.FindElement(By.XPath("//li[@role='option']/div/div[text()='Modified Since Prepared']"));

        private IWebElement WorkflowStatusFilterReviewed
            => driver.FindElement(By.XPath("//li[@role='option']/div/div[text()='Reviewed']"));

        private IWebElement WorkflowStatusFilterModifiedSinceReviewed
            => driver.FindElement(By.XPath("//li[@role='option']/div/div[text()='Modified Since Reviewed']"));

        private IWebElement ResetAllFiltersButton
            => driver.FindElement(By.CssSelector(".reset-filters-btn"));

        private IWebElement CalculationsCount
            => driver.FindElement(By.CssSelector(".calculations__count"));

        private IWebElement EmptyGridMessage
            => driver.FindElement(By.CssSelector(".empty-message__title"));

        private IWebElement EmptyGridImage
            => driver.FindElement(By.CssSelector(".placeholder-image"));

        private IList<IWebElement> CalculationNamesList
            => driver.FindElements(By.CssSelector(".calculation-title"));

        private IList<IWebElement> CalculationIdsList
            => driver.FindElements(By.CssSelector(".calculation-subtitle"));

        private IList<IWebElement> CalculationWorkflowStatusIconList
            => driver.FindElements(By.XPath("//div[@class='status-label']/div"));

        private IWebElement CalculationWorkflowStatusIcon
            => driver.FindElement(By.XPath("//div[@class='status-label']/div"));

        private IWebElement EnableDisableToggleState
            => driver.FindElement(By.XPath("//*[text()[contains(.,'000 - Don')]]/../../../following-sibling::div//input[@class='custom-control-input']"));

        private IWebElement EnableDisableToggleClick
            => driver.FindElement(By.XPath("//*[text()[contains(.,'000 - Don')]]/../../../following-sibling::div//switch"));

        private IWebElement DisableCalculationWarningWindow
            => driver.FindElement(By.XPath("//div[@role='document']//div[@class='modal-content']"));

        private IList<IWebElement> DisableCalculationWarningWindowList
            => driver.FindElements(By.XPath("//div[@role='document']//div[@class='modal-content']"));

        private IWebElement DisableCalculationWarningWindowTitle
            => driver.FindElement(By.CssSelector(".header__title"));

        private IWebElement DisableCalculationWarningWindowMessage
            => driver.FindElement(By.CssSelector(".confirmation-modal-body"));

        private IWebElement DisableCalculationWarningWindowCloseBtn
            => driver.FindElement(By.XPath("//i[@class='esg-disc-icon esg-disc-icon-close']"));

        private IWebElement DisableCalculationWarningWindowCancelBtn
            => driver.FindElement(By.XPath("//button[@class='btn sdk-btn-tertiary']"));

        private IWebElement DisableCalculationWarningWindowContinueBtn
            => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-confirm']"));

        private IWebElement EnableDisableToggleWithDependencyState
            => driver.FindElement(By.XPath("//*[text()[contains(.,'Calculation 85 with dependency')]]/../../../following-sibling::div//input[@class='custom-control-input']"));

        private IWebElement EnableDisableToggleWithDependencyClick
            => driver.FindElement(By.XPath("//*[text()[contains(.,'Calculation 85 with dependency')]]/../../../following-sibling::div//switch"));

        private IWebElement DisableCalculationUnsuccessWindow
            => driver.FindElement(By.CssSelector(".modal-container"));

        private IList<IWebElement> DisableCalculationUnsuccessWindowList
            => driver.FindElements(By.CssSelector(".modal-container"));

        private IWebElement DisableCalculationUnsuccessWindowTitle
            => driver.FindElement(By.CssSelector(".header__title"));

        private IWebElement DisableCalculationUnsuccessWindowMessageLine1
            => driver.FindElement(By.XPath("//p[@class='error__title mb-1']"));

        private IWebElement DisableCalculationUnsuccessWindowMessageLine2
            => driver.FindElement(By.XPath("//p[@class='error__title mb-1']/following-sibling::p"));

        private IWebElement DisableCalculationUnsuccessWindowMessageLine3
            => driver.FindElement(By.XPath("//div[@class='error mb-2']/following-sibling::p"));

        private IWebElement DisableCalculationUnsuccessWindowGridNameLine1
            => driver.FindElement(By.XPath("(//div[@class='esg-text-ellipsis'])[1]"));
        
        private IWebElement DisableCalculationUnsuccessWindowGridLinkLine1
            => driver.FindElement(By.XPath("(//div[@class='edit-btn'])[1]"));

        private IWebElement DisableCalculationUnsuccessWindowCloseBtn
            => driver.FindElement(By.XPath("//i[@class='esg-disc-icon esg-disc-icon-close']"));

        private IWebElement DisableCalculationUnsuccessWindowCancelBtn
            => driver.FindElement(By.XPath("//button[@class='btn btn-cancel sdk-btn-tertiary']"));

        private IWebElement DisableCalculationUnsuccessWindowContinueBtn
            => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));

        private IWebElement EditCalculationIcon
            => driver.FindElement(By.XPath("//*[text()[contains(.,'000 - Don')]]/../../../following-sibling::div//action-button[@icon='edit']//i"));

        private IWebElement ThreeDotsIconWithoutDepedency
            => driver.FindElement(By.XPath("//*[text()[contains(.,'Testing Calculation')]]/../../../following-sibling::div//action-menu//i"));

        private IWebElement ThreeDotsIconWithDepedency
            => driver.FindElement(By.XPath("//*[text()[contains(.,'Calculation 85')]]/../../../following-sibling::div//action-menu//i"));

        private IWebElement ThreeDotsMenuPopup
            => driver.FindElement(By.XPath("//div[@class='k-popup k-menu-popup']"));

        private IList<IWebElement> ThreeDotsMenuItems
            => driver.FindElements(By.CssSelector(".context-menu__item"));

        private IWebElement ThreeDotsMenuDuplicate
            => driver.FindElement(By.XPath("//div[@class='context-menu']/div[normalize-space()='Duplicate Calculation']"));

        private IWebElement ThreeDotsMenuDelete
            => driver.FindElement(By.XPath("//div[@class='context-menu']/div[normalize-space()='Delete Calculation']"));

        private IWebElement DuplicateCalculationWindow
            => driver.FindElement(By.XPath("//p[normalize-space()='Duplicate Calculation']/../.."));

        private IWebElement DuplicateCalculationWindowTitle
            => driver.FindElement(By.XPath("//div[@class='modal-container']//p[@class='header__title']"));

        private IWebElement DuplicateCalculationWindowMessage
            => driver.FindElement(By.XPath("//div[@class='modal-container']//div[@class='mb-2']"));

        private IWebElement DuplicateCalculationWindowCalculationName
            => driver.FindElement(By.XPath("//div[@class='modal-container']//input[@id='undefined']"));

        private IWebElement DuplicateCalculationWindowErrorMessage
            => driver.FindElement(By.CssSelector(".control-error__message"));

        private IWebElement DuplicateCalculationWindowCloseBtn
            => driver.FindElement(By.XPath("//i[@class='esg-disc-icon esg-disc-icon-close']"));

        private IWebElement DuplicateCalculationWindowCancelBtn
            => driver.FindElement(By.XPath("//button[@class='btn btn-cancel sdk-btn-tertiary']"));

        private IWebElement DuplicateCalculationWindowContinueBtn
            => driver.FindElement(By.XPath("//div[@class='footer']//button[@class='btn btn-primary']"));

        private IWebElement DeleteCalculationUnsuccessWindow
            => driver.FindElement(By.CssSelector(".modal-container"));

        private IList<IWebElement> DeleteCalculationUnsuccessWindowList
            => driver.FindElements(By.CssSelector(".modal-container"));

        private IWebElement DeleteCalculationUnsuccessWindowTitle
            => driver.FindElement(By.CssSelector(".header__title"));

        private IWebElement DeleteCalculationUnsuccessWindowMessageLine1
            => driver.FindElement(By.XPath("//p[@class='error__title mb-1']"));

        private IWebElement DeleteCalculationUnsuccessWindowMessageLine2
            => driver.FindElement(By.XPath("//p[@class='error__title mb-1']/following-sibling::p"));

        private IWebElement DeleteCalculationUnsuccessWindowMessageLine3
            => driver.FindElement(By.XPath("//div[@class='error mb-2']/following-sibling::p"));

        private IWebElement DeleteCalculationUnsuccessWindowGridNameLine1
            => driver.FindElement(By.XPath("(//div[@class='esg-text-ellipsis'])[1]"));

        private IWebElement DeleteCalculationUnsuccessWindowGridLinkLine1
            => driver.FindElement(By.XPath("(//div[@class='edit-btn'])[1]"));

        private IWebElement DeleteCalculationUnsuccessWindowCloseBtn
            => driver.FindElement(By.XPath("//i[@class='esg-disc-icon esg-disc-icon-close']"));

        private IWebElement DeleteCalculationUnsuccessWindowCancelBtn
            => driver.FindElement(By.XPath("//button[@class='btn btn-cancel sdk-btn-tertiary']"));

        private IWebElement DeleteCalculationUnsuccessWindowContinueBtn
            => driver.FindElement(By.XPath("//div[@class='modal-container__footer']//button[@class='btn btn-primary']"));

        private IWebElement DeleteCalculationWarningWindow
            => driver.FindElement(By.XPath("//div[@role='document']//div[@class='modal-content']"));

        private IList<IWebElement> DeleteCalculationWarningWindowList
            => driver.FindElements(By.XPath("//div[@role='document']//div[@class='modal-content']"));

        private IWebElement DeleteCalculationWarningWindowTitle
            => driver.FindElement(By.CssSelector(".header__title"));

        private IWebElement DeleteCalculationWarningWindowMessage
            => driver.FindElement(By.CssSelector(".confirmation-modal-body"));

        private IWebElement DeleteCalculationWarningWindowCloseBtn
            => driver.FindElement(By.XPath("//i[@class='esg-disc-icon esg-disc-icon-close']"));

        private IWebElement DeleteCalculationWarningWindowCancelBtn
            => driver.FindElement(By.XPath("//button[@class='btn sdk-btn-tertiary']"));

        private IWebElement DeleteCalculationWarningWindowContinueBtn
            => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-confirm']"));




        public ManageCalculationsPage NavigateToManageCalculationsPage()
        {
            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageCalculationsClickable();
            ManageCalculationsPage manageCalculationsPage = adminSettingsPage.ClickManageCalculationsMenuItem();
            return new ManageCalculationsPage(driver);
        }
        public string GetManageCalculationsPageTitle()
        {
            return ManageCalculationsPageTitle.Text;
        }
        public string GetManageCalculationsPageSubTitle()
        {
            return ManageCalculationsPageSubTitle.Text;
        }
        public CalculationManagementPageNew ClickAddNewCalculationButton()
        {
            AddNewCalculationButton.Click();
            return new CalculationManagementPageNew(driver);
        }
        public int GetCalculationCounterInTile()
        {
            return Int32.Parse(CalculationCounterInTile.Text);
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

        public string GetWorkflowStatusFromAtr()
        {
            string a = CalculationWorkflowStatusIcon.GetAttribute("class");
            string[] b = a.Split("_");
            string[] c = b[1].Split(" ");
            return c[0];
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

        public void ClickWorkflowStatusFilter()
        {
            WorkflowStatusFilter.Click();
        }
        public string GetWorkflowStatusFilterText()
        {
            return WorkflowStatusFilter.Text;
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

        public IWebElement GetCalculationsCount()
        {
            return CalculationsCount;
        }

        public string GetCalculationsCountText()
        {
            return CalculationsCount.Text;
        }

        public void WaitCalculationsCountDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(GetCalculationsCount(), GetCalculationsCountText()));
        }

        public int GetCalculationsCountValue()
        {
            WaitCalculationsCountDisplayed();
            return Int32.Parse(CalculationsCount.Text);
        }

        public IList<IWebElement> GetCalculationWorkflowStatusIconList()
        {
            return CalculationWorkflowStatusIconList;
        }

        public string GetEmptyGridMessageText()
        {
            return EmptyGridMessage.Text;
        }

        public IWebElement GetEmptyGridImage()
        {
            return EmptyGridImage;
        }

        public IList<IWebElement> GetCalculationNamesList()
        {
            return CalculationNamesList;
        }

        public ArrayList GetAllCalculationNames()
        {
            ArrayList calculationNames = new ArrayList();
            var calculationsList = GetCalculationNamesList();
            foreach (var item in calculationsList)
            {
                calculationNames.Add(item.Text);
            }
            return calculationNames;            
        }

        public IList<IWebElement> GetCalculationIdsList()
        {
            return CalculationIdsList;
        }

        public ArrayList GetAllCalculationIds()
        {
            ArrayList calculationIds = new ArrayList();
            var calculationsList = GetCalculationIdsList();
            foreach (var item in calculationsList)
            {
                calculationIds.Add(item.Text);
            }
            return calculationIds;
        }

        public List<string> GetCalculationNamesListFromDB()
        {
            var calculationNamesList = new List<string>();
            try
            {
                string connectionString = @"Data Source=ludbs831.lu.ema.ad.pwcinternal.com; Initial Catalog=EsgDisclosure;User ID=PrismDevUser;Password=Sjbxemua874";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Creating the command object
                    SqlCommand command = new SqlCommand("SELECT CalculationName FROM [EsgDisclosure].[AdminSetup].[Calculation] WHERE IsDeleted = 0", connection);

                    // Opening Connection  
                    connection.Open();

                    // Executing the SQL query  
                    SqlDataReader sdr = command.ExecuteReader();

                    //Looping through each record
                    while (sdr.Read())
                    {
                        //Console.WriteLine(sdr["Name"]);
                        calculationNamesList.Add((string)sdr["CalculationName"]);
                    }
                }
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("Error. List from DB is wrong. Error: " + e);
            }
            calculationNamesList.Sort();
            return calculationNamesList;
        }

        public List<string> GetCalculationIdsListFromDB()
        {
            var calculationIdsList = new List<string>();
            try
            {
                string connectionString = @"Data Source=ludbs831.lu.ema.ad.pwcinternal.com; Initial Catalog=EsgDisclosure;User ID=PrismDevUser;Password=Sjbxemua874";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT Id FROM [EsgDisclosure].[AdminSetup].[Calculation] WHERE IsDeleted = 0", connection);
                    connection.Open();
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                    {
                        calculationIdsList.Add("Calc" + sdr["Id"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("Error. List from DB is wrong. Error: " + e);
            }
            calculationIdsList.Sort();
            return calculationIdsList;
        }

        public IWebElement GetEnableDisableToggle()
        {
            return EnableDisableToggleState;
        }
        public void ClickEnableDisableToggle()
        {
            EnableDisableToggleClick.Click();
        }

        public IWebElement GetDisableCalculationWarningWindow()
        {
            return DisableCalculationWarningWindow;
        }

        public IList<IWebElement> GetDisableCalculationWarningWindowList()
        {
            return DisableCalculationWarningWindowList;
        }

        public void WaitDisableCalculationWarningWindowDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='document']//div[@class='modal-content']")));
        }

        public string GetDisableCalculationWarningWindowTitle()
        {
            return DisableCalculationWarningWindowTitle.Text;
        }

        public string GetDisableCalculationWarningWindowMessage()
        {
            return DisableCalculationWarningWindowMessage.Text;
        }

        public ManageCalculationsPage ClickDisableCalculationWarningWindowCloseBtn()
        {
            DisableCalculationWarningWindowCloseBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDisableCalculationWarningWindowCancelBtn()
        {
            DisableCalculationWarningWindowCancelBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDisableCalculationWarningWindowContinueBtn()
        {
            DisableCalculationWarningWindowContinueBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public IWebElement GetEnableDisableToggleWithDependency()
        {
            return EnableDisableToggleWithDependencyState;
        }

        public void ClickEnableDisableToggleWithDependency()
        {
            EnableDisableToggleWithDependencyClick.Click();
        }

        public IWebElement GetDisableCalculationUnsuccessWindow()
        {
            return DisableCalculationUnsuccessWindow;
        }

        public IList<IWebElement> GetDisableCalculationUnsuccessWindowList()
        {
            return DisableCalculationUnsuccessWindowList;
        }

        public void WaitDisableCalculationUnsuccessWindowDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='document']//div[@class='modal-content']")));
        }

        public string GetDisableCalculationUnsuccessWindowTitle()
        {
            return DisableCalculationUnsuccessWindowTitle.Text;
        }

        public string GetDisableCalculationUnsuccessWindowMessageLine1()
        {
            return DisableCalculationUnsuccessWindowMessageLine1.Text;
        }

        public string GetDisableCalculationUnsuccessWindowMessageLine2()
        {
            return DisableCalculationUnsuccessWindowMessageLine2.Text;
        }

        public string GetDisableCalculationUnsuccessWindowMessageLine3()
        {
            return DisableCalculationUnsuccessWindowMessageLine3.Text;
        }

        public string GetDisableCalculationUnsuccessWindowGridNameLine1()
        {
            return DisableCalculationUnsuccessWindowGridNameLine1.Text;
        }

        public string GetDisableCalculationUnsuccessWindowGridLinkLine1Text()
        {
            return DisableCalculationUnsuccessWindowGridLinkLine1.Text;
        }

        public CalculationManagementPageEdit ClickDisableCalculationUnsuccessWindowGridLinkLine1()
        {
            DisableCalculationUnsuccessWindowGridLinkLine1.Click();
            return new CalculationManagementPageEdit(driver);
        }

        public ManageCalculationsPage ClickDisableCalculationUnsuccessWindowCloseBtn()
        {
            DisableCalculationUnsuccessWindowCloseBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDisableCalculationUnsuccessWindowCancelBtn()
        {
            DisableCalculationUnsuccessWindowCancelBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public string GetDisableCalculationUnsuccessWindowContinueBtnState()
        {
            return DisableCalculationUnsuccessWindowContinueBtn.GetAttribute("disabled");            
        }

        public CalculationManagementPageEdit ClickEditCalculationIcon()
        {
            EditCalculationIcon.Click();
            return new CalculationManagementPageEdit(driver);
        }

        public void ClickThreeDotsIconWithoutDependency()
        {
            ThreeDotsIconWithoutDepedency.Click();
        }

        public void ClickThreeDotsIconWithDependency()
        {
            ThreeDotsIconWithDepedency.Click();
        }

        public void WaitThreeDotsMenuDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".context-menu")));
        }

        public IWebElement GetThreeDotsMenuPopup()
        {
            return ThreeDotsMenuPopup;
        }

        public string GetThreeDotsMenuDuplicate()
        {
            return ThreeDotsMenuDuplicate.Text;
        }

        public string GetThreeDotsMenuDelete()
        {
            return ThreeDotsMenuDelete.Text;
        }

        public void ClickThreeDotsMenuDuplicate()
        {
            ThreeDotsMenuDuplicate.Click();
        }

        public void ClickThreeDotsMenuDelete()
        {
            ThreeDotsMenuDelete.Click();
        }

        public IWebElement GetDuplicateCalculationWindow()
        {
            return DuplicateCalculationWindow;
        }

        public string GetDuplicateCalculationWindowTitle()
        {
            return DuplicateCalculationWindowTitle.Text;
        }

        public string GetDuplicateCalculationWindowMessage()
        {
            return DuplicateCalculationWindowMessage.Text;
        }

        public IWebElement GetDuplicateCalculationWindowCalculationName()
        {
            return DuplicateCalculationWindowCalculationName;
        }

        public void ClickDuplicateCalculationWindowCalculationName()
        {
            DuplicateCalculationWindowCalculationName.Click();
        }

        public string GetDuplicateCalculationWindowErrorMessage()
        {
            return DuplicateCalculationWindowErrorMessage.Text;
        }

        public ManageCalculationsPage ClickDuplicateCalculationWindowCloseBtn()
        {
            DuplicateCalculationWindowCloseBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDuplicateCalculationWindowCancelBtn()
        {
            DuplicateCalculationWindowCancelBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public CalculationManagementPageEdit ClickDuplicateCalculationWindowContinueBtnSuccess()
        {
            DuplicateCalculationWindowContinueBtn.Click();
            return new CalculationManagementPageEdit(driver);
        }

        public void ClickDuplicateCalculationWindowContinueBtnError()
        {
            DuplicateCalculationWindowContinueBtn.Click();
        }

        public IWebElement GetDeleteCalculationUnsuccessWindow()
        {
            return DeleteCalculationUnsuccessWindow;
        }

        public IList<IWebElement> GetDeleteCalculationUnsuccessWindowList()
        {
            return DeleteCalculationUnsuccessWindowList;
        }

        public void WaitDeleteCalculationUnsuccessWindowDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='document']//div[@class='modal-content']")));
        }

        public string GetDeleteCalculationUnsuccessWindowTitle()
        {
            return DeleteCalculationUnsuccessWindowTitle.Text;
        }

        public string GetDeleteCalculationUnsuccessWindowMessageLine1()
        {
            return DeleteCalculationUnsuccessWindowMessageLine1.Text;
        }

        public string GetDeleteCalculationUnsuccessWindowMessageLine2()
        {
            return DeleteCalculationUnsuccessWindowMessageLine2.Text;
        }

        public string GetDeleteCalculationUnsuccessWindowMessageLine3()
        {
            return DeleteCalculationUnsuccessWindowMessageLine3.Text;
        }

        public string GetDeleteCalculationUnsuccessWindowGridNameLine1()
        {
            return DeleteCalculationUnsuccessWindowGridNameLine1.Text;
        }

        public string GetDeleteCalculationUnsuccessWindowGridLinkLine1Text()
        {
            return DeleteCalculationUnsuccessWindowGridLinkLine1.Text;
        }

        public CalculationManagementPageEdit ClickDeleteCalculationUnsuccessWindowGridLinkLine1()
        {
            DeleteCalculationUnsuccessWindowGridLinkLine1.Click();
            return new CalculationManagementPageEdit(driver);
        }

        public ManageCalculationsPage ClickDeleteCalculationUnsuccessWindowCloseBtn()
        {
            DeleteCalculationUnsuccessWindowCloseBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDeleteCalculationUnsuccessWindowCancelBtn()
        {
            DeleteCalculationUnsuccessWindowCancelBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public string GetDeleteCalculationUnsuccessWindowContinueBtnState()
        {
            return DeleteCalculationUnsuccessWindowContinueBtn.GetAttribute("disabled");
        }

        public IWebElement GetDeleteCalculationWarningWindow()
        {
            return DeleteCalculationWarningWindow;
        }

        public IList<IWebElement> GetDeleteCalculationWarningWindowList()
        {
            return DeleteCalculationWarningWindowList;
        }

        public void WaitDeleteCalculationWarningWindowDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='document']//div[@class='modal-content']")));
        }

        public string GetDeleteCalculationWarningWindowTitle()
        {
            return DeleteCalculationWarningWindowTitle.Text;
        }

        public string GetDeleteCalculationWarningWindowMessage()
        {
            return DeleteCalculationWarningWindowMessage.Text;
        }

        public ManageCalculationsPage ClickDeleteCalculationWarningWindowCloseBtn()
        {
            DeleteCalculationWarningWindowCloseBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDeleteCalculationWarningWindowCancelBtn()
        {
            DeleteCalculationWarningWindowCancelBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public ManageCalculationsPage ClickDeleteCalculationWarningWindowContinueBtn()
        {
            DeleteCalculationWarningWindowContinueBtn.Click();
            return new ManageCalculationsPage(driver);
        }

        public void UpdateCalculationInDB()
        {
            try
            {
                string connectionString = @"Data Source=ludbs831.lu.ema.ad.pwcinternal.com; Initial Catalog=EsgDisclosure;User ID=PrismDevUser;Password=Sjbxemua874";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE [EsgDisclosure].[AdminSetup].[Calculation] SET IsDeleted = 0 WHERE CalculationName = 'Testing Calculation (DO NOT CHANGE)'", connection);
                    connection.Open();
                    command.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("Error: " + e);
            }
        }


    }
}
