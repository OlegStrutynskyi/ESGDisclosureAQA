using OpenQA.Selenium;
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
    public class ManageCharacteristicsPage
    {
        IWebDriver driver;

        public ManageCharacteristicsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath, Using = "//p[contains(text(),'Manage Characteristics')]")]
        private IWebElement ManageCharacteristicsPageTitle;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Add New Characteristic']")]
        private IWebElement AddNewCharacteristicButton;

        [FindsBy(How = How.CssSelector, Using = ".esg-kendo-grid")]
        private IWebElement CharacteristicsGrid;

        [FindsBy(How = How.XPath, Using = "//tbody/tr")]
        private IList<IWebElement> CharacteristicsGridItems;

        [FindsBy(How = How.XPath, Using =
            //"//td[@class='k-touch-action-auto esg-kendo-grid__column'][1]"
            "//tbody[@role='presentation']/tr")]
        private IList<IWebElement> CharacteristicInTableList;

        [FindsBy(How = How.CssSelector, Using = ".esg-text-ellipsis")]
        private IList<IWebElement> CharacteristicNamesList;

        [FindsBy(How = How.XPath, Using = "//div[@title='000 - Do not change pls']")]
        private IWebElement CharacteristicWithDependency;
        
        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='000 - Do not change pls']/../following-sibling::td[3]/div/action-button[@icon='edit']/div/i")]
        private IWebElement CharacteristicEditIcon;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='000 - Do not change pls']/../following-sibling::td[3]/div/action-button[@icon='delete']/div/i")]
        private IWebElement CharacteristicDeleteIcon;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Selenium')]/../following-sibling::td[3]/div/action-button[@icon='delete']/div/i")]
        private IWebElement SeleniumCharacteristicDeleteIcon;

        [FindsBy(How = How.CssSelector, Using = ".pager__input-wrapper")]
        private IWebElement PageCount;

        [FindsBy(How = How.CssSelector, Using = ".k-dropdown-wrap")]
        private IWebElement RowsPerPageDropdown;

        [FindsBy(How = How.XPath, Using = "//ul[@class = 'k-list k-reset']/li/div/div")]
        private IList<IWebElement> RowsPerPageDropdownItems;

        [FindsBy(How = How.XPath, Using = "//ul[@class='k-list k-reset']/li[2]/div/div")]
        private IWebElement RowsPerPage25;

        [FindsBy(How = How.XPath, Using = "//ul[@class='k-list k-reset']/li[3]/div/div")]
        private IWebElement RowsPerPage50;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-container']//p[text()=' Warning ']")]
        public IWebElement CharacteristicDeleteWarningWindow;

        [FindsBy(How = How.CssSelector, Using = ".header__title")]
        private IWebElement CharacteristicDeleteWarningWindowTitle;

        [FindsBy(How = How.CssSelector, Using = ".confirmation-modal-body")]
        private IWebElement CharacteristicDeleteWarningWindowMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-container__footer']//button[@class='btn sdk-btn-tertiary']")]
        private IWebElement CharacteristicDeleteWarningWindowCancelBtn;

        [FindsBy(How = How.XPath, Using = "//i[@class='esg-disc-icon esg-disc-icon-close']")]
        private IWebElement CharacteristicDeleteWarningWindowCloseBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-container__footer']//button[@class='btn btn-primary btn-confirm']")]
        private IWebElement CharacteristicDeleteWarningWindowConfirmBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-container']//p[text()=' Delete Characteristic ']")]
        public IWebElement CharacteristicUnseccessDeleteWindow;

        [FindsBy(How = How.CssSelector, Using = ".header__title")]
        private IWebElement CharacteristicUnseccessDeleteWindowTitle;

        [FindsBy(How = How.XPath, Using = "//p[@class='error__title mt-1']")]
        private IWebElement CharacteristicUnseccessDeleteWindowMessageLine1;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='error mb-2']/following-sibling::p")]
        private IWebElement CharacteristicUnseccessDeleteWindowMessageLine2;

        [FindsBy(How = How.XPath, Using = "//td[normalize-space()='DO NOT DELETE']")]
        private IWebElement CharacteristicUnseccessDeleteWindowGridLine1Name;

        [FindsBy(How = How.XPath, Using = "//div[@class='edit-btn']")]
        private IWebElement CharacteristicUnseccessDeleteWindowGridLine1Link;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-cancel.sdk-btn-tertiary")]
        private IWebElement CharacteristicUnseccessDeleteWindowCancelBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-container__footer']//button[@class='btn btn-primary']")]
        private IWebElement CharacteristicUnseccessDeleteWindowContinueBtn;

        [FindsBy(How = How.XPath, Using = "//i[@class='esg-disc-icon esg-disc-icon-close']")]
        private IWebElement CharacteristicUnseccessDeleteWindowCloseBtn;

        [FindsBy(How = How.CssSelector, Using = "div[class='pager'] kendo-pager-next-buttons")]
        private IWebElement PaginatorButtonNext;

        [FindsBy(How = How.CssSelector, Using = ".pager__range-title")]
        private IWebElement TotalRecordsCount;


        public ManageCharacteristicsPage NavigateToManageCharacteristicPage()
        {
            HaloHomePage haloHomePage = new HaloHomePage(driver);
            AdminSettingsPage adminSettingsPage = haloHomePage.GetAdminSettingsPage();
            adminSettingsPage.WaitUntilManageCharactericticsClickable();
            ManageCharacteristicsPage manageCharacteristicsPage = adminSettingsPage.ClickManageCharacteristicsMenuItem();
            return new ManageCharacteristicsPage(driver);
        }

        public string GetManageCharacteristicsPageTitle()
        {
            return ManageCharacteristicsPageTitle.Text;
        }

        public IWebElement GetAddNewCharacteristicButton()
        {
            return AddNewCharacteristicButton;
        }

        public AddNewCharacteristicPage ClickAddNewCharacteristicButton()
        {
            AddNewCharacteristicButton.Click();
            return new AddNewCharacteristicPage(driver);
        }

        public IWebElement GetCharacteristicsGrid()
        {
            return CharacteristicsGrid;
        }

        public void WaitCharacteristicsGridDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//tbody[@role='presentation']/tr")));
        }

        public IList<IWebElement> GetCharacteristicsGridItems()
        {
            return CharacteristicsGridItems;
        }

        public IList<IWebElement> GetCharacteristicInTableList()
        {
            return CharacteristicInTableList;
        }

        public IList <IWebElement> GetCharacteristicNamesList()
        {
            return CharacteristicNamesList;
        }

        public string GetCharacteristicWithDependencyName()
        {
            return CharacteristicWithDependency.Text;
        }

        public void ClickCharacteristicEditIcon()
        {
            CharacteristicEditIcon.Click();            
        }

        public void ClickCharacteristicDeleteIcon()
        {
            CharacteristicDeleteIcon.Click();
        }

        public void ClickSeleniumCharacteristicDeleteIcon()
        {
            SeleniumCharacteristicDeleteIcon.Click();
        }

        public IWebElement GetCharacteristicDeleteWarningWindow()
        {
            return CharacteristicDeleteWarningWindow;
        }

        public string GetCharacteristicDeleteWarningWindowTitle()
        {
            return CharacteristicDeleteWarningWindowTitle.Text;
        }

        public string GetCharacteristicDeleteWarningWindowMessage()
        {
            return CharacteristicDeleteWarningWindowMessage.Text;
        }

        public IWebElement GetCharacteristicDeleteWarningWindowCancelBtn()
        {
            return CharacteristicDeleteWarningWindowCancelBtn;
        }

        public ManageCharacteristicsPage ClickCharacteristicDeleteWarningWindowCancelBtn()
        {
            CharacteristicDeleteWarningWindowCancelBtn.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public ManageCharacteristicsPage ClickCharacteristicDeleteWarningCloseBtn()
        {
            CharacteristicDeleteWarningWindowCloseBtn.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public ManageCharacteristicsPage ClickCharacteristicDeleteWarningWindowConfirmBtn()
        {
            CharacteristicDeleteWarningWindowConfirmBtn.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public IWebElement GetCharacteristicUnseccessDeleteWindow()
        {
            return CharacteristicUnseccessDeleteWindow;
        }

        public string GetCharacteristicUnseccessDeleteWindowTitle()
        {
            return CharacteristicUnseccessDeleteWindowTitle.Text;
        }

        public string GetCharacteristicUnseccessDeleteWindowMessageLine1()
        {
            return CharacteristicUnseccessDeleteWindowMessageLine1.Text;
        }

        public string GetCharacteristicUnseccessDeleteWindowMessageLine2()
        {
            return CharacteristicUnseccessDeleteWindowMessageLine2.Text;
        }

        public string GetCharacteristicUnseccessDeleteWindowGridLine1NameText()
        {
            return CharacteristicUnseccessDeleteWindowGridLine1Name.Text;
        }

        public string GetCharacteristicUnseccessDeleteWindowGridLine1LinkText()
        {
            return CharacteristicUnseccessDeleteWindowGridLine1Link.Text;
        }

        public QuestionManagementPageEdit ClickCharacteristicUnseccessDeleteWindowGridLine1LinkText()
        {
            CharacteristicUnseccessDeleteWindowGridLine1Link.Click();
            return new QuestionManagementPageEdit(driver);
        }

        public ManageCharacteristicsPage ClickCharacteristicUnseccessDeleteWindowCancelBtn()
        {
            CharacteristicUnseccessDeleteWindowCancelBtn.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public ManageCharacteristicsPage ClickCharacteristicUnseccessDeleteWindowCloseBtn()
        {
            CharacteristicUnseccessDeleteWindowCloseBtn.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public string GetCharacteristicUnseccessDeleteWindowContinueBtnState()
        {
            return CharacteristicUnseccessDeleteWindowContinueBtn.GetAttribute("disabled");
        }

        public IWebElement GetRowsPerPageDropdown()
        {
            return RowsPerPageDropdown;
        }

        public void WaitRowsPerPageDropdownClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".k-dropdown-wrap")));
        }

        public void ClickRowsPerPageDropdown()
        {
            WaitRowsPerPageDropdownClickable();
            Thread.Sleep(500);
            RowsPerPageDropdown.Click();
        }

        public IList<IWebElement> GetRowsPerPageDropdownItems()
        {
            ClickRowsPerPageDropdown();
            return RowsPerPageDropdownItems;
        }

        public ManageCharacteristicsPage ClickRowsPerPage25()
        {
            ClickRowsPerPageDropdown();
            RowsPerPage25.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public ManageCharacteristicsPage ClickRowsPerPage50()
        {
            ClickRowsPerPageDropdown();
            RowsPerPage50.Click();
            return new ManageCharacteristicsPage(driver);
        }

        public int GetPagesCount()
        {
            String a = PageCount.Text;
            String[] b = a.Split(" ");
            return Int32.Parse(b[1]);
        }

        public int GetTotalRecordsCount()
        {
            String a = TotalRecordsCount.Text;
            String[] b = a.Split("of ");
            return Int32.Parse(b[1]);
        }

        public void ClickPaginatorButtonNext()
        {
            PaginatorButtonNext.Click();
        }
       
        public ArrayList GetAllCharacteristicNames()
        {
            ArrayList characteristicsInTable = new ArrayList();

            ClickRowsPerPage50();
            Thread.Sleep(1000);
            int numberOfPages = GetPagesCount();
            if (numberOfPages == 1)
            {
                var characteristicNameList = GetCharacteristicNamesList();
                foreach(var charname in characteristicNameList)
                {
                    characteristicsInTable.Add(charname.Text);
                }
                return characteristicsInTable;
            }
            else
            {
                for (byte i = 1; i <= numberOfPages; i++)
                {
                    IList<IWebElement> pageRecords = GetCharacteristicsGridItems();
                    for (byte j = 0; j < pageRecords.Count; j++)
                    {
                        String characteristic = driver.FindElement(By.XPath("//tbody/tr[" + (j + 1) + "]/td[1]")).Text;
                        characteristicsInTable.Add(characteristic);
                    }
                    ClickPaginatorButtonNext();
                    Thread.Sleep(1000);
                }
                return characteristicsInTable;
            }
        }

        public void WaitAddNewCharacteristicButtonClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetAddNewCharacteristicButton()));
        }

        public void WaitCharacteristicsGridDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".esg-kendo-grid")));
        }

        public void WaitDeleteModalDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-container")));
        }

        public List<string> GetCharacteristicNamesListFromDB()
        {
            var characteristicNamesList = new List<string>();
            try
            {
                string connectionString = @"Data Source=ludbs831.lu.ema.ad.pwcinternal.com; Initial Catalog=EsgDisclosure;User ID=PrismDevUser;Password=Sjbxemua874";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Creating the command object
                    SqlCommand command = new SqlCommand("SELECT Name FROM [EsgDisclosure].[AdminSetup].[Characteristic] WHERE IsDeleted = 0", connection);

                    // Opening Connection  
                    connection.Open();

                    // Executing the SQL query  
                    SqlDataReader sdr = command.ExecuteReader();

                    //Looping through each record
                    while (sdr.Read())
                    {
                        //Console.WriteLine(sdr["Name"]);
                        characteristicNamesList.Add((string)sdr["Name"]);
                    }
                }
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("Error. List from DB is wrong. Error: " + e);
            }
            characteristicNamesList.Sort();
            //characteristicNamesList.ForEach(item => Console.WriteLine(item));//Print list
            return characteristicNamesList;
        }

    }
}
