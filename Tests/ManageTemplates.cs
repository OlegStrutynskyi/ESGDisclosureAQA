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
    public class ManageTemplates : Base
    {
        [Test]
        public void ManageTemplatesTitle()
        {
            string expectedTitle = "Manage Templates";
            string actualTitle;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            actualTitle = manageTemplatesPage.GetManageTemplatesPageTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Inccorect Manage Templates title.");
        }

        [Test]
        public void ManageTemplatesSubTitle()
        {
            string expectedTitle = "EU";
            string actualTitle;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            actualTitle = manageTemplatesPage.GetManageTemplatesPageSubTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Inccorect Manage Templates subtitle.");
        }

        [Test]
        public void AddNewTemplateBladeOpened()
        {
            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            TemplateOverviewPageNew templateOverviewPage = manageTemplatesPage.ClickAddNewTemplateButton();
            var templateOverviewBlade = templateOverviewPage.GetTemplateOverviewBladeNew();
            
            Assert.That(templateOverviewBlade.Displayed);
        }

        [Test]
        public void TemplateCounterInTile()
        {
            int expectedCounter = 2;
            int actualCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            actualCounter = manageTemplatesPage.GetTemplateCounterInTile();

            Assert.That(actualCounter, Is.EqualTo(expectedCounter), "Error. Incorrect counter in the tile.");
        }

        [Test]
        public void TemplateCounterUnderFilter()
        {
            int expectedCounter = 2;
            int actualCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            actualCounter = manageTemplatesPage.GetTemplatesCountValue();

            Assert.That(actualCounter, Is.EqualTo(expectedCounter), "Error. Incorrect counter under the filter.");
        }

        [Test]
        public void TemplateCounters()
        {
            int numbetInTile;
            int numbetUnderFilter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            numbetInTile = manageTemplatesPage.GetTemplateCounterInTile();
            numbetUnderFilter = manageTemplatesPage.GetTemplatesCountValue();

            Assert.That(numbetInTile, Is.EqualTo(numbetUnderFilter), "Error. Incorrect counters.");
        }

        [Test]
        public void SelectWorflowStatusInTileInProgress()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "In Progress";
            string expectedWorkflowStatusClass = "in-progress";
            string actualWorkflowStatus;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageTemplatesPage.ClickWorkflowStatusInTileInProgress();
                Thread.Sleep(1000);
                var iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by In Progress.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with In Progress status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTilePrepared()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Prepared";
            string expectedWorkflowStatusClass = "prepared";
            string actualWorkflowStatus;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageTemplatesPage.ClickWorkflowStatusInTilePrepared();
                Thread.Sleep(1000);
                var iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Prepared.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Prepared status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTileModifiedSincePrepared()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Prepared";
            string expectedWorkflowStatusClass = "modified-prepared";
            string actualWorkflowStatus;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageTemplatesPage.ClickWorkflowStatusInTileModifiedSincePrepared();
                Thread.Sleep(1000);
                var iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Modified Since Prepared.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Modified Since Prepared status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTileReviewed()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Reviewed";
            string expectedWorkflowStatusClass = "reviewed";
            string actualWorkflowStatus;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageTemplatesPage.ClickWorkflowStatusInTileReviewed();
                Thread.Sleep(1000);
                var iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Reviewed.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Reviewed status.");
            }
        }

        [Test]
        public void SelectWorflowStatusInTileModifiedSinceReviewed()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Reviewed";
            string expectedWorkflowStatusClass = "modified-reviewed";
            string actualWorkflowStatus;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                manageTemplatesPage.ClickWorkflowStatusInTileModifiedSinceReviewed();
                Thread.Sleep(1000);
                var iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList();
                foreach (var icon in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatusClass), "Error. Incorrect filtering by Modified Since Reviewed.");
                }
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Modified Since Reviewed status.");
            }
        }

        [Test]
        public void WorflowStatusInTileInProgressValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "In Progress";
            int valueInTile;
            int valueInCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageTemplatesPage.GetWorkflowStatusInTileInProgressValue();
                manageTemplatesPage.ClickWorkflowStatusInTileInProgress();
                Thread.Sleep(1000);
                valueInCounter = manageTemplatesPage.GetTemplatesCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with In Progress status.");
            }
        }

        [Test]
        public void WorflowStatusInTilePreparedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Prepared";
            int valueInTile;
            int valueInCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageTemplatesPage.GetWorkflowStatusInTilePreparedValue();
                manageTemplatesPage.ClickWorkflowStatusInTilePrepared();
                Thread.Sleep(1000);
                valueInCounter = manageTemplatesPage.GetTemplatesCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Prepared status.");
            }
        }

        [Test]
        public void WorflowStatusInTileModifiedSincePreparedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Prepared";
            int valueInTile;
            int valueInCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageTemplatesPage.GetWorkflowStatusInTileModifiedSincePreparedValue();
                manageTemplatesPage.ClickWorkflowStatusInTileModifiedSincePrepared();
                Thread.Sleep(1000);
                valueInCounter = manageTemplatesPage.GetTemplatesCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Modified Since Prepared status.");
            }
        }

        [Test]
        public void WorflowStatusInTileReviewedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Reviewed";
            int valueInTile;
            int valueInCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageTemplatesPage.GetWorkflowStatusInTileReviewedValue();
                manageTemplatesPage.ClickWorkflowStatusInTileReviewed();
                Thread.Sleep(1000);
                valueInCounter = manageTemplatesPage.GetTemplatesCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Reviewed status.");
            }
        }

        [Test]
        public void WorflowStatusInTileModifiedSinceReviewedValue()
        {
            ArrayList existingStatuses = new ArrayList();
            string expectedWorkflowStatusUI = "Modified Since Reviewed";
            int valueInTile;
            int valueInCounter;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            var existingWorflowStatuses = manageTemplatesPage.GetWorkflowStatusInTileList();
            foreach (var item in existingWorflowStatuses)
            {
                existingStatuses.Add(item.Text);
            }
            if (existingStatuses.Contains(expectedWorkflowStatusUI))
            {
                valueInTile = manageTemplatesPage.GetWorkflowStatusInTileModifiedSinceReviewedValue();
                manageTemplatesPage.ClickWorkflowStatusInTileModifiedSinceReviewed();
                Thread.Sleep(1000);
                valueInCounter = manageTemplatesPage.GetTemplatesCountValue();

                Assert.That(valueInTile, Is.EqualTo(valueInCounter));
            }
            else
            {
                TestContext.Progress.WriteLine("There are no templates with Modified Since Reviewed status.");
            }
        }

        [Test]
        public void WorkflowStatusFilterItems()
        {
            string[] expectedDropdownItems = { "In Progress", "Prepared", "Modified Since Prepared", "Reviewed", "Modified Since Reviewed" };
            ArrayList existingDropdownItems = new ArrayList();

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            existingDropdownItems = manageTemplatesPage.GetWorkflowStatusFilterItems();
            Assert.That(existingDropdownItems, Is.EquivalentTo(expectedDropdownItems), "Error. Incorrect Workflow Status filter items.");
        }

        [Test]
        public void SelectWorkflowStatusFilterInProgress()
        {
            string expectedWorkflowStatus = "in-progress";
            int templatesCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            manageTemplatesPage.SelectWorkflowStatusFilterInProgress();
            Thread.Sleep(1000);
            templatesCount = manageTemplatesPage.GetTemplatesCountValue();
            if(templatesCount == 0)
            {
                actualEmptyGridMessage = manageTemplatesPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageTemplatesPage.GetEmptyGridImage();
                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by In Progress.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterPrepared()
        {
            string expectedWorkflowStatus = "prepared";
            int templatesCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            manageTemplatesPage.SelectWorkflowStatusFilterPrepared();
            Thread.Sleep(1000);
            templatesCount = manageTemplatesPage.GetTemplatesCountValue();
            if (templatesCount == 0)
            {
                actualEmptyGridMessage = manageTemplatesPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageTemplatesPage.GetEmptyGridImage();
                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Prepared.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterModifiedSincePrepared()
        {
            string expectedWorkflowStatus = "modified-prepared";
            int templatesCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            manageTemplatesPage.SelectWorkflowStatusFilterModifiedSincePrepared();
            Thread.Sleep(1000);
            templatesCount = manageTemplatesPage.GetTemplatesCountValue();
            if (templatesCount == 0)
            {
                actualEmptyGridMessage = manageTemplatesPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageTemplatesPage.GetEmptyGridImage();
                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Modified Since Prepared.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterReviewed()
        {
            string expectedWorkflowStatus = "reviewed";
            int templatesCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            manageTemplatesPage.SelectWorkflowStatusFilterReviewed();
            Thread.Sleep(1000);
            templatesCount = manageTemplatesPage.GetTemplatesCountValue();
            if (templatesCount == 0)
            {
                actualEmptyGridMessage = manageTemplatesPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageTemplatesPage.GetEmptyGridImage();
                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
                    Assert.That(actualWorkflowStatus, Is.EqualTo(expectedWorkflowStatus), "Error. Incorrect filtering by Reviewed.");
                }
            }
        }

        [Test]
        public void SelectWorkflowStatusFilterModifiedSinceReviewed()
        {
            string expectedWorkflowStatus = "modified-reviewed";
            int templatesCount;
            IWebElement[] iconsList;
            string actualWorkflowStatus;
            string expectedEmptyGridMessage = "No information found based on the selection.";
            string actualEmptyGridMessage;
            IWebElement actualEmptyGridImage;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            manageTemplatesPage.SelectWorkflowStatusFilterModifiedSinceReviewed();
            Thread.Sleep(1000);
            templatesCount = manageTemplatesPage.GetTemplatesCountValue();
            if (templatesCount == 0)
            {
                actualEmptyGridMessage = manageTemplatesPage.GetEmptyGridMessageText();
                actualEmptyGridImage = manageTemplatesPage.GetEmptyGridImage();
                Assert.That(actualEmptyGridImage.Displayed, "Error. Empty image is not displayed.");
                Assert.That(actualEmptyGridMessage, Is.EqualTo(expectedEmptyGridMessage), "Error. Incorrect Empty message.");
            }
            else
            {
                iconsList = manageTemplatesPage.GetTemplateWorkflowStatusIconList().ToArray();
                foreach (var item in iconsList)
                {
                    actualWorkflowStatus = manageTemplatesPage.GetWorkflowStatusFromAtr();
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

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            filterTextBeforeFiltering = manageTemplatesPage.GetWorkflowStatusFilterText();
            manageTemplatesPage.SelectWorkflowStatusFilterModifiedSinceReviewed();
            filterTextAfterFiltering = manageTemplatesPage.GetWorkflowStatusFilterText();
            manageTemplatesPage.ClickResetAllFiltersButton();
            filterTextAfterResetAllBtn = manageTemplatesPage.GetWorkflowStatusFilterText();
            
            Assert.That(filterTextAfterResetAllBtn, Is.EqualTo(filterTextBeforeFiltering), "Error. Incorrect Workflow Status Filter placeholder");
        }

        [Test]
        public void ExpectedTemplatesDisplayed()
        {
            string[] expectedTemplateNames = { "PREC Template", "PER Template" };
            ArrayList existingTemplateNames = new ArrayList();

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            existingTemplateNames = manageTemplatesPage.GetAllTemplateNames();
            foreach (string item in existingTemplateNames)
            {
                Assert.That(expectedTemplateNames, Has.Member(item));
            }
            //Check total number
            //Assert.That(existingTemplateNames.Count, Is.EqualTo(2));

            //Check that counter = number of template names
            //int existingTemplateTotalNumber = manageTemplatesPage.GetTemplateCounterInTile();
            //Assert.That(existingTemplateTotalNumber, Is.EqualTo(existingTemplateNames.Count));

            //Check template names
            //Assert.That(existingTemplateNames[0].ToString(), Does.Contain(expectedTemplateNames[0]));
            //Assert.That(existingTemplateNames[1].ToString(), Is.EqualTo(expectedTemplateNames[1]));
            //StringAssert.Contains(expectedTemplateNames[0], existingTemplateNames[0].ToString());
            //StringAssert.Contains(expectedTemplateNames[1], existingTemplateNames[1].ToString());            
        }

        [Test]
        public void TemplatesFromDBDisplayed()
        {
            ArrayList templatesInUI;
            List<string> templatesFromDB;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            templatesInUI = manageTemplatesPage.GetAllTemplateNames();
            templatesFromDB = manageTemplatesPage.GetTemplateNamesListFromDB();

            Assert.That(templatesInUI, Is.EqualTo(templatesFromDB));
            //Console.WriteLine(templatesInUI);
        }

        [Test]
        public void PrecTemplateWorkflowStatusIcon()
        {
            string expectedWorkflowStatus = "reviewed";//TODO take workflow status from Template Overview page

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            string a = manageTemplatesPage.GetPrecTemplateWorkflowStatusIconClass();
            //now a = 'color_in-progress status-label__box' or a = 'gradient_modified-prepared status-label__box'
            string[] b = a.Split("_");
            string[] c = b[1].Split(" ");
            string actualWorkflowStatus = c[0];

            Assert.That(actualWorkflowStatus.ToLower(), Is.EqualTo(expectedWorkflowStatus.ToLower()), "Error. Incorrect PREC workflow status");
        }

        [Test]
        public void PerTemplateWorkflowStatusIcon()
        {
            string expectedWorkflowStatus = "reviewed";//TODO take workflow status from Template Overview page

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            string a = manageTemplatesPage.GetPerTemplateWorkflowStatusIconClass();
            string[] b = a.Split("_");
            string[] c = b[1].Split(" ");
            string actualWorkflowStatus = c[0];

            Assert.That(actualWorkflowStatus.ToLower(), Is.EqualTo(expectedWorkflowStatus.ToLower()), "Error. Incorrect PER workflow status");
        }

        [Test]
        public void OpenPrecTemplateOverviewPageByNameClick()
        {
            string expectedPrecTemplateName;
            string actualPrecTemplateSubTitle;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            expectedPrecTemplateName = manageTemplatesPage.GetPrecTemplateNameText();
            manageTemplatesPage.WaitPrecTemplateNameClickable();
            TemplateOverviewPageNew templateOverviewPage = manageTemplatesPage.ClickPrecTemplateName();
            templateOverviewPage.WaitTemplateOverviewSubTitleDisplayed();
            actualPrecTemplateSubTitle = templateOverviewPage.GetTemplateOverviewSubTitle();

            Assert.That(actualPrecTemplateSubTitle, Is.EqualTo(expectedPrecTemplateName), "Error. Incorrect PREC Template name in the Template Overview.");
        }

        [Test]
        public void OpenPrecTemplateOverviewPageByEditIconClick()
        {
            string expectedPrecTemplateName;
            string actualPrecTemplateSubTitle;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            expectedPrecTemplateName = manageTemplatesPage.GetPrecTemplateNameText();
            manageTemplatesPage.WaitPrecEditIconClickable();
            TemplateOverviewPageNew templateOverviewPage = manageTemplatesPage.ClickPrecTemplateEditIcon();
            templateOverviewPage.WaitTemplateOverviewSubTitleDisplayed();
            actualPrecTemplateSubTitle = templateOverviewPage.GetTemplateOverviewSubTitle();

            Assert.That(actualPrecTemplateSubTitle, Is.EqualTo(expectedPrecTemplateName), "Error. Incorrect PREC Template name in the Template Overview.");
        }

        [Test]
        public void OpenPerTemplateOverviewPageByNameClick()
        {
            string expectedPerTemplateName;
            string actualPerTemplateSubTitle;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            expectedPerTemplateName = manageTemplatesPage.GetPerTemplateNameText();
            manageTemplatesPage.WaitPerTemplateNameClickable();
            TemplateOverviewPageNew templateOverviewPage = manageTemplatesPage.ClickPerTemplateName();
            templateOverviewPage.WaitTemplateOverviewSubTitleDisplayed();
            actualPerTemplateSubTitle = templateOverviewPage.GetTemplateOverviewSubTitle();

            Assert.That(actualPerTemplateSubTitle, Is.EqualTo(expectedPerTemplateName), "Error. Incorrect PER Template name in the Template Overview.");
        }

        [Test]
        public void OpenPerTemplateOverviewPageByEditIconClick()
        {
            string expectedPerTemplateName;
            string actualPerTemplateSubTitle;

            ManageTemplatesPage manageTemplatesPage = new ManageTemplatesPage(GetDriver());
            manageTemplatesPage.NavigateToManageTemplatesPage();
            expectedPerTemplateName = manageTemplatesPage.GetPerTemplateNameText();
            manageTemplatesPage.WaitPerEditIconClickable();
            TemplateOverviewPageNew templateOverviewPage = manageTemplatesPage.ClickPerTemplateEditIcon();
            templateOverviewPage.WaitTemplateOverviewSubTitleDisplayed();
            actualPerTemplateSubTitle = templateOverviewPage.GetTemplateOverviewSubTitle();

            Assert.That(actualPerTemplateSubTitle, Is.EqualTo(expectedPerTemplateName), "Error. Incorrect PER Template name in the Template Overview.");
        }

    }
}
