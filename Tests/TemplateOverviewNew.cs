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
    public class TemplateOverviewNew : Base
    {

        [Test]
        public void TemplateOverviewNewTitle()
        {
            string expectedTitle = "Template Overview";
            string actualTitle;

            TemplateOverviewPageNew templateOverviewPageNew = new TemplateOverviewPageNew(GetDriver());
            templateOverviewPageNew.NavigateToTemplateOverviewPage();
            actualTitle = templateOverviewPageNew.GetTemplateOverviewTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Template Overview title.");
        }

        [Test]
        public void TemplateOverviewNewSubTitleEmpty()
        {
            string actualSubTitle;

            TemplateOverviewPageNew templateOverviewPageNew = new TemplateOverviewPageNew(GetDriver());
            templateOverviewPageNew.NavigateToTemplateOverviewPage();
            actualSubTitle = templateOverviewPageNew.GetTemplateOverviewSubTitle();

            Assert.That(actualSubTitle, Is.Empty, "Error. Incorrect Template Overview subtitle.");
        }

        [Test]
        public void WorkingProgramLibraryOpened()
        {
            string expectedTitle = "Working Program Library";
            string actualTitle;

            TemplateOverviewPageNew templateOverviewPageNew = new TemplateOverviewPageNew(GetDriver());
            templateOverviewPageNew.NavigateToTemplateOverviewPage();
            WorkingProgramLibraryPage workingProgramLibraryPage = templateOverviewPageNew.ClickWorkingProgramLibraryButton();
            actualTitle = workingProgramLibraryPage.GetWorkingProgramLibraryTitle();

            Assert.That(expectedTitle, Is.EqualTo(actualTitle), "Error. Incorrect title.");
        }

        //TODO: Template Name


        [Test]
        public void TemplateTypeDropdownItem()
        {
            string expectedItem = "NO DATA FOUND";
            string actualItem;

            TemplateOverviewPageNew templateOverviewPageNew = new TemplateOverviewPageNew(GetDriver());
            templateOverviewPageNew.NavigateToTemplateOverviewPage();
            templateOverviewPageNew.ClickTemplateTypeDropdown();
            templateOverviewPageNew.WaitTemplateTypeDropdownItemDisplayed();
            actualItem = templateOverviewPageNew.GetTemplateTypeDropdownItem();

            Assert.That(actualItem, Is.EqualTo(expectedItem), "Error. Incorrect Template Type dropdown item.");
        }

        [Test]
        public void SectionDropdownItem()
        {
            string expectedItem = "NO DATA FOUND";
            string actualItem;

            TemplateOverviewPageNew templateOverviewPageNew = new TemplateOverviewPageNew(GetDriver());
            templateOverviewPageNew.NavigateToTemplateOverviewPage();
            templateOverviewPageNew.ClickSectionDropdown();
            templateOverviewPageNew.WaitSectionDropdownItemDisplayed();
            actualItem = templateOverviewPageNew.GetSectionDropdownItem();

            Assert.That(actualItem, Is.EqualTo(expectedItem), "Error. Incorrect Section dropdown item.");
        }

        [Test]
        public void EnabledDisabledDropdownItems()
        {
            string[] expectedDropdownItems = { "Enabled", "Disabled" };
            ArrayList existingDropdownItems = new ArrayList();

            TemplateOverviewPageNew templateOverviewPageNew = new TemplateOverviewPageNew(GetDriver());
            templateOverviewPageNew.NavigateToTemplateOverviewPage();
            templateOverviewPageNew.ClickEnabledDisabledDropdown();
            templateOverviewPageNew.WaitEnabledDisabledDropdownItemDisplayed();
            existingDropdownItems = templateOverviewPageNew.GetEnabledDisabledDropdownItems();
            Assert.That(existingDropdownItems, Is.EquivalentTo(expectedDropdownItems), "Error. Incorrect Enabled/Disabled dropdown items.");
        }
    }
}
