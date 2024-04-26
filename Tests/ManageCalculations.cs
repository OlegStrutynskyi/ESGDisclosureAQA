using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.PageObjects;
using TestProject1.Utilities;

namespace TestProject1.Tests
{
    public class ManageCalculations : Base
    {
        [Test]
        public void ManageCalculationsTitle()
        {
            string expectedTitle = "Manage Calculations";
            string actualTitle;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            actualTitle = manageCalculationsPage.GetManageCalculationsPageTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Manage Calculations title.");
        }

        [Test]
        public void ManageTemplatesSubTitle()
        {
            string expectedTitle = "EU";
            string actualTitle;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            actualTitle = manageCalculationsPage.GetManageCalculationsPageSubTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Manage Calculations subtitle.");
        }

        [Test]
        public void AddNewCalculationBladeOpened()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            CalculationManagementPageNew calculationManagementPageNew = manageCalculationsPage.ClickAddNewCalculationButton();
            var addNewCalculationBlade = calculationManagementPageNew.GetCalcManagementPageNew();
            
            Assert.That(addNewCalculationBlade.Displayed);
        }

        [Test]
        public void CalculationsCounters()
        {
            int numberInTile;
            int numberUnderFilter;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            numberInTile = manageCalculationsPage.GetCalculationCounterInTile();
            numberUnderFilter = manageCalculationsPage.GetCalculationsCountValue();

            Assert.That(numberInTile, Is.EqualTo(numberUnderFilter), "Error. Incorrect counters.");
        }

        [Test]
        public void SelectWorflowStatusInTileInProgress()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "In Progress";
            string expectedWorkflowStatusClass = "in-progress";
            string actualWorkflowStatus;
            
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach(var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageCalculationsPage.ClickWorkflowStatusInTileInProgress();
                Thread.Sleep(1000);
                var iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by In Progress.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with In Progress status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTilePrepared()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Prepared";
            string expectedWorkflowStatusClass = "prepared";
            string actualWorkflowStatus;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageCalculationsPage.ClickWorkflowStatusInTilePrepared();
                Thread.Sleep(1000);
                var iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Prepared.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Prepared status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTileModifiedSincePrepared()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Prepared";
            string expectedWorkflowStatusClass = "modified-prepared";
            string actualWorkflowStatus;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageCalculationsPage.ClickWorkflowStatusInTileModifiedSincePrepared();
                Thread.Sleep(1000);
                var iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Modified Since Prepared.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Modified Since Prepared status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTileReviwed()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Reviewed";
            string expectedWorkflowStatusClass = "reviewed";
            string actualWorkflowStatus;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageCalculationsPage.ClickWorkflowStatusInTileReviewed();
                Thread.Sleep(1000);
                var iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Reviewed.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Reviewed status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTileModifiedSinceReviewed()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Reviewed";
            string expectedWorkflowStatusClass = "modified-reviewed";
            string actualWorkflowStatus;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageCalculationsPage.ClickWorkflowStatusInTileModifiedSinceReviewed();
                Thread.Sleep(1000);
                var iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Modified Since Reviewed.");                    
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Modified Since Reviewed status.");
            }
        }

        [Test]
        public void WorflowStatusInTileInProgressValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "In Progress";
            int valueInTile;
            int valueInCounter;
            
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageCalculationsPage.GetWorkflowStatusInTileInProgressValue();
                manageCalculationsPage.ClickWorkflowStatusInTileInProgress();
                Thread.Sleep(1000);
                valueInCounter = manageCalculationsPage.GetCalculationsCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with In Progress status.");
            }
        }

        [Test]
        public void WorflowStatusInTilePreparedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Prepared";
            int valueInTile;
            int valueInCounter;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageCalculationsPage.GetWorkflowStatusInTilePreparedValue();
                manageCalculationsPage.ClickWorkflowStatusInTilePrepared();
                Thread.Sleep(1000);
                valueInCounter = manageCalculationsPage.GetCalculationsCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Prepared status.");
            }
        }

        [Test]
        public void WorflowStatusInTileModifiedSincePreparedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Prepared";
            int valueInTile;
            int valueInCounter;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageCalculationsPage.GetWorkflowStatusInTileModifiedSincePreparedValue();
                manageCalculationsPage.ClickWorkflowStatusInTileModifiedSincePrepared();
                Thread.Sleep(1000);
                valueInCounter = manageCalculationsPage.GetCalculationsCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Modified Since Prepared status.");
            }
        }

        [Test]
        public void WorflowStatusInTileReviewedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Reviewed";
            int valueInTile;
            int valueInCounter;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageCalculationsPage.GetWorkflowStatusInTileReviewedValue();
                manageCalculationsPage.ClickWorkflowStatusInTileReviewed();
                Thread.Sleep(1000);
                valueInCounter = manageCalculationsPage.GetCalculationsCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Reviewed status.");
            }
        }

        [Test]
        public void WorflowStatusInTileModifiedSinceReviewedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Prepared";
            int valueInTile;
            int valueInCounter;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var existingWorflowStatuses = manageCalculationsPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageCalculationsPage.GetWorkflowStatusInTileModifiedSinceReviewedValue();
                manageCalculationsPage.ClickWorkflowStatusInTileModifiedSinceReviewed();
                Thread.Sleep(1000);
                valueInCounter = manageCalculationsPage.GetCalculationsCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no calculations with Modified Since Reviewed status.");
            }
        }

        [Test]
        public void WorkflowStatusFilterItems()
        {
            string[] expectedDropdownItems = { "In Progress", "Prepared", "Modified Since Prepared", "Reviewed", "Modified Since Reviewed" };
            ArrayList existingDropdownItems = new ArrayList();

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            existingDropdownItems = manageCalculationsPage.GetWorkflowStatusFilterItems();
            Assert.That(existingDropdownItems, Is.EquivalentTo(expectedDropdownItems), "Error. Incorrect Workflow Status filter items.");
        }

        [Test]
        public void SelectWorkflowStatusFilterInProgress()
        {
            string expectedWorkflowStatus = "in-progress";
            int calculationsCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.SelectWorkflowStatusFilterInProgress();
            Thread.Sleep(1000);
            calculationsCount = manageCalculationsPage.GetCalculationsCountValue();
            if (calculationsCount == 0)
            {
                actualEmptyGridMessage = manageCalculationsPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageCalculationsPage.GetEmptyGridImage();
                
                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by In Progress.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterPrepared()
        {
            string expectedWorkflowStatus = "prepared";
            int calculationsCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.SelectWorkflowStatusFilterPrepared();
            Thread.Sleep(1000);
            calculationsCount = manageCalculationsPage.GetCalculationsCountValue();
            if (calculationsCount == 0)
            {
                actualEmptyGridMessage = manageCalculationsPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageCalculationsPage.GetEmptyGridImage();

                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Prepared.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterModifiedSincePrepared()
        {
            string expectedWorkflowStatus = "modified-prepared";
            int calculationsCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.SelectWorkflowStatusFilterModifiedSincePrepared();
            Thread.Sleep(1000);
            calculationsCount = manageCalculationsPage.GetCalculationsCountValue();
            if (calculationsCount == 0)
            {
                actualEmptyGridMessage = manageCalculationsPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageCalculationsPage.GetEmptyGridImage();

                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Modified Since Prepared.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterReviewed()
        {
            string expectedWorkflowStatus = "reviewed";
            int calculationsCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.SelectWorkflowStatusFilterReviewed();
            Thread.Sleep(1000);
            calculationsCount = manageCalculationsPage.GetCalculationsCountValue();
            if (calculationsCount == 0)
            {
                actualEmptyGridMessage = manageCalculationsPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageCalculationsPage.GetEmptyGridImage();

                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Reviewed.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterModifiedSinceReviewed()
        {
            string expectedWorkflowStatus = "modified-reviewed";
            int calculationsCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.SelectWorkflowStatusFilterModifiedSinceReviewed();
            Thread.Sleep(1000);
            calculationsCount = manageCalculationsPage.GetCalculationsCountValue();
            if (calculationsCount == 0)
            {
                actualEmptyGridMessage = manageCalculationsPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageCalculationsPage.GetEmptyGridImage();

                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageCalculationsPage.GetCalculationWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageCalculationsPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Modified Since Reviewed.");
                }
            }
        }

        [Test]
        public void ResetAllFiltersButton()
        {
            string filterTextBeforeFiltering;
            string filterTextAfterFiltering;
            string filterTextAfterResetAllBtn;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            filterTextBeforeFiltering = manageCalculationsPage.GetWorkflowStatusFilterText();
            manageCalculationsPage.SelectWorkflowStatusFilterModifiedSinceReviewed();
            filterTextAfterFiltering = manageCalculationsPage.GetWorkflowStatusFilterText();
            manageCalculationsPage.ClickResetAllFiltersButton();
            filterTextAfterResetAllBtn = manageCalculationsPage.GetWorkflowStatusFilterText();

            Assert.That(filterTextAfterResetAllBtn, Is.EqualTo(filterTextBeforeFiltering), "Error. Incorrect Workflow Status Filter placeholder");
        }

        [Test]
        public void PrintAllCalculationNames()
        {
            ArrayList existingCalculationNames = new ArrayList();
            
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            existingCalculationNames = manageCalculationsPage.GetAllCalculationNames();
            if(existingCalculationNames.Count > 0)
            {
                foreach(string name in existingCalculationNames)
                {
                    TestContext.Progress.WriteLine(name);
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no Calculations.");
            }
        }

        [Test]
        public void PrintAllCalculationIds()
        {
            ArrayList existingCalculationIds = new ArrayList();

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            existingCalculationIds = manageCalculationsPage.GetAllCalculationIds();
            if (existingCalculationIds.Count > 0)
            {
                foreach (string name in existingCalculationIds)
                {
                    TestContext.Progress.WriteLine(name);
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no Calculations.");
            }
        }

        [Test]
        public void AllCalculationNamesFromDBDisplayed()
        {
            ArrayList calculationNamesUI;
            List<string> calculationNamesDB;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            calculationNamesUI = manageCalculationsPage.GetAllCalculationNames();
            calculationNamesDB = manageCalculationsPage.GetCalculationNamesListFromDB();

            Assert.That(calculationNamesUI, Is.EquivalentTo(calculationNamesDB), "Error. Incorrect Calculation Names list.");
        }

        [Test]
        public void AllCalculationIdsFromDBDisplayed()
        {
            ArrayList calculationIdsUI;
            List<string> calculationIdsDB;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            calculationIdsUI = manageCalculationsPage.GetAllCalculationIds();
            calculationIdsDB = manageCalculationsPage.GetCalculationIdsListFromDB();

            Assert.That(calculationIdsUI, Is.EquivalentTo(calculationIdsDB), "Error. Incorrect Calculation IDs list.");
        }

        [Test]
        public void EnableDisableToggleON()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var toggle = manageCalculationsPage.GetEnableDisableToggle();
            if(toggle.Selected == true)
            {
                Assert.That(toggle.Selected, "Error. Enable/Disable toggle is OFF.");
            }
            else 
            {
                manageCalculationsPage.ClickEnableDisableToggle();
                Thread.Sleep(1000);
                var toggle2 = manageCalculationsPage.GetEnableDisableToggle();
                Assert.That(toggle2.Selected, "Error. Enable/Disable toggle is OFF.");
            }
        }

        [Test]
        public void DisableCalculationWarningWindowContent()
        {
            string expectedTitle = "Disable Calculation";
            string expectedMessage = "Are you sure you want to disable the calculation?";
            string actualTitle;
            string actualMessage;
            IWebElement warningWindow;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var toggle = manageCalculationsPage.GetEnableDisableToggle();
            if (toggle.Selected != true)
            {
                manageCalculationsPage.ClickEnableDisableToggle();
            }
            manageCalculationsPage.ClickEnableDisableToggle();
            manageCalculationsPage.WaitDisableCalculationWarningWindowDisplayed();
            warningWindow = manageCalculationsPage.GetDisableCalculationWarningWindow();
            actualTitle = manageCalculationsPage.GetDisableCalculationWarningWindowTitle();
            actualMessage = manageCalculationsPage.GetDisableCalculationWarningWindowMessage();

            Assert.That(warningWindow.Displayed, "Error. Warning window is not displayed.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Disable Calculation pop-up title.");
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Error. Incorrect Disable Calculation pop-up message.");
        }

        [Test]
        public void DisableCalculationWarningWindowClose()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var toggle = manageCalculationsPage.GetEnableDisableToggle();
            if (toggle.Selected != true)
            {
                manageCalculationsPage.ClickEnableDisableToggle();
            }
            manageCalculationsPage.ClickEnableDisableToggle();
            manageCalculationsPage.WaitDisableCalculationWarningWindowDisplayed();
            manageCalculationsPage.ClickDisableCalculationWarningWindowCloseBtn();
            var windowList = manageCalculationsPage.GetDisableCalculationWarningWindowList();
            var toggleAfterPopup = manageCalculationsPage.GetEnableDisableToggle();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(toggleAfterPopup.Selected, Is.True, "Error. Enable/Disable toggle is OFF.");
        }

        [Test]
        public void DisableCalculationWarningWindowCancel()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var toggle = manageCalculationsPage.GetEnableDisableToggle();
            if (toggle.Selected != true)
            {
                manageCalculationsPage.ClickEnableDisableToggle();
            }
            manageCalculationsPage.ClickEnableDisableToggle();
            manageCalculationsPage.WaitDisableCalculationWarningWindowDisplayed();
            manageCalculationsPage.ClickDisableCalculationWarningWindowCancelBtn();
            var windowList = manageCalculationsPage.GetDisableCalculationWarningWindowList();
            var toggleAfterPopup = manageCalculationsPage.GetEnableDisableToggle();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(toggleAfterPopup.Selected, Is.True, "Error. Enable/Disable toggle is OFF.");
        }

        [Test]
        public void DisableCalculationWarningWindowContinue()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            var toggle = manageCalculationsPage.GetEnableDisableToggle();
            if (toggle.Selected != true)
            {
                manageCalculationsPage.ClickEnableDisableToggle();
            }
            manageCalculationsPage.ClickEnableDisableToggle();
            manageCalculationsPage.WaitDisableCalculationWarningWindowDisplayed();
            manageCalculationsPage.ClickDisableCalculationWarningWindowContinueBtn();
            var windowList = manageCalculationsPage.GetDisableCalculationWarningWindowList();
            var toggleAfterPopup = manageCalculationsPage.GetEnableDisableToggle();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(toggleAfterPopup.Selected, Is.Not.True, "Error. Enable/Disable toggle is ON.");
        }

        [Test]
        public void DisableCalculationUnsuccessWindowContent()
        {
            string expectedTitle = "Disable Calculation";
            string expectedMessageLine1 = "This calculation cannot be disabled.";
            string expectedMessageLine2 = "It is currently being used in other sections of the application.";
            string expectedMessageLine3 = "Please modify the following question(s) and calculation(s) to proceed.";
            string expectedGridNameLine1 = "Calculation 113 (do not change)";
            string expectedGridLinkText = "Edit Calculation";
            string actualTitle;
            string actualMessageLine1;
            string actualMessageLine2;
            string actualMessageLine3;
            string actualGridNameLine1;
            string actualGridLinkText;
            IWebElement warningWindow;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickEnableDisableToggleWithDependency();
            manageCalculationsPage.WaitDisableCalculationUnsuccessWindowDisplayed();
            warningWindow = manageCalculationsPage.GetDisableCalculationUnsuccessWindow();
            actualTitle = manageCalculationsPage.GetDisableCalculationUnsuccessWindowTitle();
            actualMessageLine1 = manageCalculationsPage.GetDisableCalculationUnsuccessWindowMessageLine1();
            actualMessageLine2 = manageCalculationsPage.GetDisableCalculationUnsuccessWindowMessageLine2();
            actualMessageLine3 = manageCalculationsPage.GetDisableCalculationUnsuccessWindowMessageLine3();
            actualGridNameLine1 = manageCalculationsPage.GetDisableCalculationUnsuccessWindowGridNameLine1();
            actualGridLinkText = manageCalculationsPage.GetDisableCalculationUnsuccessWindowGridLinkLine1Text();

            Assert.That(warningWindow.Displayed, "Error. Warning window is not displayed.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Disable Calculation pop-up title.");
            Assert.That(actualMessageLine1, Is.EqualTo(expectedMessageLine1), "Error. Incorrect Disable Calculation pop-up message (line 1).");
            Assert.That(actualMessageLine2, Is.EqualTo(expectedMessageLine2), "Error. Incorrect Disable Calculation pop-up message (line 2).");
            Assert.That(actualMessageLine3, Is.EqualTo(expectedMessageLine3), "Error. Incorrect Disable Calculation pop-up message (line 3).");
            Assert.That(actualGridNameLine1, Is.EqualTo(expectedGridNameLine1), "Error. Incorrect 1st Calculation Name in the Disable Calculation pop-up grid.");
            Assert.That(actualGridLinkText, Is.EqualTo(expectedGridLinkText), "Error. Incorrect 1st lik text in the Disable Calculation pop-up grid.");
        }

        [Test]
        public void DisableCalculationUnsuccessWindowClickLink1()
        {
            string calculationNamePopup;
            string calculationNameEditBlade;
            
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickEnableDisableToggleWithDependency();
            manageCalculationsPage.WaitDisableCalculationUnsuccessWindowDisplayed();
            calculationNamePopup = manageCalculationsPage.GetDisableCalculationUnsuccessWindowGridNameLine1();
            CalculationManagementPageEdit calculationManagementPageEdit = manageCalculationsPage.ClickDisableCalculationUnsuccessWindowGridLinkLine1();
            var windowList = manageCalculationsPage.GetDisableCalculationUnsuccessWindowList();
            var editWindow = calculationManagementPageEdit.GetCalculationManagementBladeEdit();
            calculationNameEditBlade = calculationManagementPageEdit.GetCalculationManagementBladeEditSubTitle();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(editWindow.Displayed, Is.True, "Error. Calculation Management blade is not opened.");
            Assert.That(calculationNameEditBlade, Is.EqualTo(calculationNamePopup), "Error. Incorrect Calculation Management blade is opened.");
        }

        [Test]
        public void DisableCalculationUnsuccessWindowClose()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickEnableDisableToggleWithDependency();
            manageCalculationsPage.WaitDisableCalculationUnsuccessWindowDisplayed();
            manageCalculationsPage.ClickDisableCalculationUnsuccessWindowCloseBtn();
            var windowList = manageCalculationsPage.GetDisableCalculationUnsuccessWindowList();
            var toggleAfterPopup = manageCalculationsPage.GetEnableDisableToggleWithDependency();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(toggleAfterPopup.Selected, Is.True, "Error. Enable/Dosable toggle is OFF.");
        }

        [Test]
        public void DisableCalculationUnsuccessWindowCancel()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickEnableDisableToggleWithDependency();
            manageCalculationsPage.WaitDisableCalculationUnsuccessWindowDisplayed();
            manageCalculationsPage.ClickDisableCalculationUnsuccessWindowCancelBtn();
            var windowList = manageCalculationsPage.GetDisableCalculationUnsuccessWindowList();
            var toggleAfterPopup = manageCalculationsPage.GetEnableDisableToggleWithDependency();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(toggleAfterPopup.Selected, Is.True, "Error. Enable/Dosable toggle is OFF.");
        }

        [Test]
        public void DisableCalculationUnsuccessWindowContinue()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickEnableDisableToggleWithDependency();
            manageCalculationsPage.WaitDisableCalculationUnsuccessWindowDisplayed();
            var stateDisabled = manageCalculationsPage.GetDisableCalculationUnsuccessWindowContinueBtnState();

            Assert.That(stateDisabled, Is.EqualTo("true"));
        }

        [Test]
        public void CalculationEditIconClick()
        {
            IWebElement editCalculationBlade;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            CalculationManagementPageEdit calculationManagementPageEdit = manageCalculationsPage.ClickEditCalculationIcon();
            editCalculationBlade = calculationManagementPageEdit.GetCalculationManagementBladeEdit();

            Assert.That(editCalculationBlade.Displayed, "Error. Edit Calculation blade is not opened.");

        }

        [Test]
        public void ThreeDotsMenuItems()
        {
            string expectedItem1 = "Duplicate Calculation";
            string expectedItem2 = "Delete Calculation";
            string actualItem1;
            string actualItem2;
            IWebElement threeDotsPopup;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            threeDotsPopup = manageCalculationsPage.GetThreeDotsMenuPopup();
            actualItem1 = manageCalculationsPage.GetThreeDotsMenuDuplicate();
            actualItem2 = manageCalculationsPage.GetThreeDotsMenuDelete();

            Assert.That(threeDotsPopup.Displayed, "Error. Three dots pop-up is not displayed.");
            Assert.That(actualItem1, Is.EqualTo(expectedItem1), "Error. Incorrect three dots menu item 1.");
            Assert.That(actualItem2, Is.EqualTo(expectedItem2), "Error. Incorrect three dots menu item 2.");
        }

        [Test]
        public void ThreeDotsMenuDuplicateWindowContent()
        {
            IWebElement duplicatePopup;
            string expectedTitle = "Duplicate Calculation";
            string expectedMessage = "Please provide a name for your duplicate calculation.";
            string actualTitle;
            string actualMessage;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDuplicate();
            duplicatePopup = manageCalculationsPage.GetDuplicateCalculationWindow();
            actualTitle = manageCalculationsPage.GetDuplicateCalculationWindowTitle();
            actualMessage = manageCalculationsPage.GetDuplicateCalculationWindowMessage();

            Assert.That(duplicatePopup.Displayed, "Error. Duplicate Calculation pop-up is not opened.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect title.");
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Error. Incorrect message.");
        }

        [Test]
        public void ThreeDotsMenuDuplicateWindowEmptyName()
        {
            string expectedError = "This field is required to be filled in.";
            string actualError;
            
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDuplicate();
            manageCalculationsPage.ClickDuplicateCalculationWindowContinueBtnError();
            actualError = manageCalculationsPage.GetDuplicateCalculationWindowErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void ThreeDotsMenuDuplicateWindowIncorrectName1()
        {
            string expectedError = "The entered text must be between 3 and 255 characters.";
            string actualError;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDuplicate();
            manageCalculationsPage.GetDuplicateCalculationWindowCalculationName().SendKeys("1");
            manageCalculationsPage.ClickDuplicateCalculationWindowContinueBtnError();
            actualError = manageCalculationsPage.GetDuplicateCalculationWindowErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void ThreeDotsMenuDuplicateWindowIncorrectName2()
        {
            string expectedError = "The entered text must be between 3 and 255 characters.";
            string actualError;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDuplicate();
            manageCalculationsPage.GetDuplicateCalculationWindowCalculationName().SendKeys("  A  ");
            manageCalculationsPage.ClickDuplicateCalculationWindowContinueBtnError();
            actualError = manageCalculationsPage.GetDuplicateCalculationWindowErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void ThreeDotsMenuDuplicateWindowIncorrectDuplicatedName()
        {
            string expectedError = "The entered Calculation Name value already exists. Please choose another value.";
            string actualError;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDuplicate();
            manageCalculationsPage.GetDuplicateCalculationWindowCalculationName().SendKeys("000 - Don't change pls");
            manageCalculationsPage.ClickDuplicateCalculationWindowContinueBtnError();
            actualError = manageCalculationsPage.GetDuplicateCalculationWindowErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void ThreeDotsMenuDuplicateWindowCorrectName()
        {
            string calculationTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCaclulationName = "Selenium_" + calculationTime;
            string actualCaclulationName;
            IWebElement editCalculationBlade;
            ArrayList calculationNames;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDuplicate();
            manageCalculationsPage.GetDuplicateCalculationWindowCalculationName().SendKeys(expectedCaclulationName);
            CalculationManagementPageEdit calculationManagementPageEdit = manageCalculationsPage.ClickDuplicateCalculationWindowContinueBtnSuccess();
            editCalculationBlade = calculationManagementPageEdit.GetCalculationManagementBladeEdit();
            actualCaclulationName = calculationManagementPageEdit.GetCalculationManagementBladeEditSubTitle();
            calculationNames = manageCalculationsPage.GetAllCalculationNames();

            Assert.That(editCalculationBlade.Displayed, "Error. calculation Management blade is not opened.");
            Assert.That(actualCaclulationName, Is.EqualTo(expectedCaclulationName), "Error. Incorrect Calculation Name in the subtitle.");
            Assert.That(calculationNames, Has.Member(expectedCaclulationName), "Error. Created Calculation is not displayed in the Manage Calculations blade.");
        }

        [Test]
        public void ThreeDotsMenuDeleteWindowWithDependencyContent()
        {
            string expectedTitle = "Delete Calculation";
            string expectedMessageLine1 = "This calculation cannot be deleted.";
            string expectedMessageLine2 = "It is currently being used in other sections of the application.";
            string expectedMessageLine3 = "Please modify the following question(s) and calculation(s) to proceed.";
            string expectedGridLine1Name = "Calculation 113 (do not change)";
            string expectedGridLine1LinkText = "Edit Calculation";
            string actualTitle;
            string actualMessageLine1;
            string actualMessageLine2;
            string actualMessageLine3;
            string actualGridLine1Name;
            string actualGridLine1LinkText;
            IWebElement warningWindow;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationUnsuccessWindowDisplayed();
            warningWindow = manageCalculationsPage.GetDeleteCalculationUnsuccessWindow();
            actualTitle = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowTitle();
            actualMessageLine1 = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowMessageLine1();
            actualMessageLine2 = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowMessageLine2();
            actualMessageLine3 = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowMessageLine3();
            actualGridLine1Name = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowGridNameLine1();
            actualGridLine1LinkText = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowGridLinkLine1Text();

            Assert.That(warningWindow.Displayed, "Error. Warning window is not displayed.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Delete Calculation pop-up title.");
            Assert.That(actualMessageLine1, Is.EqualTo(expectedMessageLine1), "Error. Incorrect Delete Calculation pop-up message (line 1).");
            Assert.That(actualMessageLine2, Is.EqualTo(expectedMessageLine2), "Error. Incorrect Delete Calculation pop-up message (line 2).");
            Assert.That(actualMessageLine3, Is.EqualTo(expectedMessageLine3), "Error. Incorrect Delete Calculation pop-up message (line 3).");
            Assert.That(actualGridLine1Name, Is.EqualTo(expectedGridLine1Name), "Error. Incorrect 1st Calculation Name in the Delete Calculation pop-up grid.");
            Assert.That(actualGridLine1LinkText, Is.EqualTo(expectedGridLine1LinkText), "Error. Incorrect 1st lik text in the Delete Calculation pop-up grid.");
        }

        [Test]
        public void DeleteCalculationUnsuccessWindowClickLink1()
        {
            string calculationNamePopup;
            string calculationNameEditBlade;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationUnsuccessWindowDisplayed();
            calculationNamePopup = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowGridNameLine1();
            CalculationManagementPageEdit calculationManagementPageEdit = manageCalculationsPage.ClickDeleteCalculationUnsuccessWindowGridLinkLine1();
            var windowList = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowList();
            var editWindow = calculationManagementPageEdit.GetCalculationManagementBladeEdit();
            calculationNameEditBlade = calculationManagementPageEdit.GetCalculationManagementBladeEditSubTitle();

            Assert.That(windowList, Is.Empty, "Error. Delete Calculation pop-up is not closed.");
            Assert.That(editWindow.Displayed, Is.True, "Error. Calculation Management blade is not opened.");
            Assert.That(calculationNameEditBlade, Is.EqualTo(calculationNamePopup), "Error. Incorrect Calculation Management blade is opened.");
        }

        [Test]
        public void DeleteCalculationUnsuccessWindowClose()
        {
            string calculationName = "Calculation 85 with dependency (do not change)";
            
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationUnsuccessWindowDisplayed();
            manageCalculationsPage.ClickDeleteCalculationUnsuccessWindowCloseBtn();
            var windowList = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowList();
            var existingCalculations = manageCalculationsPage.GetAllCalculationNames();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(existingCalculations, Has.Member(calculationName), "Error. Calculation is deleted.");
        }

        [Test]
        public void DeleteCalculationUnsuccessWindowCancel()
        {
            string calculationName = "Calculation 85 with dependency (do not change)";

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationUnsuccessWindowDisplayed();
            manageCalculationsPage.ClickDeleteCalculationUnsuccessWindowCancelBtn();
            var windowList = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowList();
            var existingCalculations = manageCalculationsPage.GetAllCalculationNames();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(existingCalculations, Has.Member(calculationName), "Error. Calculation is deleted.");
        }

        [Test]
        public void DeleteCalculationUnsuccessWindowContinue()
        {
            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationUnsuccessWindowDisplayed();
            var stateDisabled = manageCalculationsPage.GetDeleteCalculationUnsuccessWindowContinueBtnState();

            Assert.That(stateDisabled, Is.EqualTo("true"));
        }

        [Test]
        public void DeleteCalculationWarningWindowContent()
        {
            string expectedTitle = "Warning";
            string expectedMessage = "Are you sure you want to delete the calculation?";
            string actualTitle;
            string actualMessage;
            IWebElement warningWindow;

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithoutDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationWarningWindowDisplayed();
            warningWindow = manageCalculationsPage.GetDeleteCalculationWarningWindow();
            actualTitle = manageCalculationsPage.GetDeleteCalculationWarningWindowTitle();
            actualMessage = manageCalculationsPage.GetDeleteCalculationWarningWindowMessage();

            Assert.That(warningWindow.Displayed, "Error. Warning window is not displayed.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Disable Calculation pop-up title.");
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Error. Incorrect Disable Calculation pop-up message.");
        }

        [Test]
        public void DeleteCalculationWarningWindowClose()
        {
            string calculationName = "Testing Calculation (DO NOT CHANGE)";

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithoutDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationWarningWindowDisplayed();
            manageCalculationsPage.ClickDeleteCalculationWarningWindowCloseBtn();
            var windowList = manageCalculationsPage.GetDeleteCalculationWarningWindowList();
            var existingCalculations = manageCalculationsPage.GetAllCalculationNames();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(existingCalculations, Has.Member(calculationName), "Error. Calculation is deleted.");
        }

        [Test]
        public void DeleteCalculationWarningWindowCancel()
        {
            string calculationName = "Testing Calculation (DO NOT CHANGE)";

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithoutDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationWarningWindowDisplayed();
            manageCalculationsPage.ClickDeleteCalculationWarningWindowCancelBtn();
            var windowList = manageCalculationsPage.GetDeleteCalculationWarningWindowList();
            var existingCalculations = manageCalculationsPage.GetAllCalculationNames();

            Assert.That(windowList, Is.Empty, "Error. Disable Calculation pop-up is not closed.");
            Assert.That(existingCalculations, Has.Member(calculationName), "Error. Calculation is deleted.");
        }

        [Test]
        public void DeleteCalculationWarningWindowContinue()
        {
            string calculationName = "Testing Calculation (DO NOT CHANGE)";

            ManageCalculationsPage manageCalculationsPage = new ManageCalculationsPage(GetDriver());
            manageCalculationsPage.NavigateToManageCalculationsPage();
            manageCalculationsPage.ClickThreeDotsIconWithoutDependency();
            manageCalculationsPage.WaitThreeDotsMenuDisplayed();
            manageCalculationsPage.ClickThreeDotsMenuDelete();
            manageCalculationsPage.WaitDeleteCalculationWarningWindowDisplayed();
            manageCalculationsPage.ClickDeleteCalculationWarningWindowContinueBtn();
            var windowList = manageCalculationsPage.GetDeleteCalculationWarningWindowList();
            var existingCalculations = manageCalculationsPage.GetAllCalculationNames();

            Assert.That(windowList, Is.Empty, "Error. Delete Calculation pop-up is not closed.");
            Assert.That(existingCalculations, Has.No.Member(calculationName), "Error. Calculation is not deleted.");
            
            //update used calculation in DB for future testing
            manageCalculationsPage.UpdateCalculationInDB();
            driver.Navigate().Refresh();
            var existingCalculationsAfterUpdate = manageCalculationsPage.GetAllCalculationNames();
            Assert.That(existingCalculationsAfterUpdate, Has.Member(calculationName), "Error. Calculation is not updated in DB.");
        }

    }
}
