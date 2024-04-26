using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using TestProject1.PageObjects;
using TestProject1.Utilities;
using OpenQA.Selenium.Interactions;

namespace TestProject1.Tests
{
    public class EditCharacteristic : Base
    {
        [Test]
        public void EditCharacteristicBladeDisplayed()
        {
            string expectedTitle = "Edit Characteristic";
            string actualTitle;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            actualTitle = editCharacteristicPage.GetEditCharacteristicPageTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void EditCharacteristicEmptyName()
        {
            string expectedEmptyNameErrorMessage = "This field is required to be filled in.";
            string actualErrorMessage;
            Actions action = new Actions(driver);
            
            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.ClickSaveButtonUnsuccess();
            actualErrorMessage = editCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedEmptyNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void EditCharacteristicIncorrectMinName1()
        {
            string expectedMinNameErrorMessage = "The entered text must be between 3 and 255 characters.";
            string actualErrorMessage;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys("1");
            editCharacteristicPage.ClickSaveButtonSuccess();
            actualErrorMessage = editCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedMinNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void EditCharacteristicIncorrectMinName2()
        {
            string expectedMinNameErrorMessage = "The entered text must be between 3 and 255 characters.";
            string actualErrorMessage;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys("  A  ");
            editCharacteristicPage.ClickSaveButtonSuccess();
            actualErrorMessage = editCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedMinNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void EditCharacteristicIncorrectExistingName()
        {
            string expectedExistingNameErrorMessage = "The entered Characteristics Name value already exists. Please choose another value.";
            string actualErrorMessage;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys("000 - Do not change pls");
            editCharacteristicPage.ClickSaveButtonUnsuccess();
            actualErrorMessage = editCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedExistingNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void EditCharacteristicMaxNameSuccess()
        {
            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string newExpectedCharacteristicName = "A_Selenium_EDITED_" + characteristicTime +
                "_MAX SIZE_255_CHARACTERS_abc def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS TUV WXYZ ! § $% & / () =? *'<> #|;~ @©«»× {} 0123456789 abc def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS TUV WXYZ 0123456789";
            ArrayList characteristicsInTable = new ArrayList();

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys(newExpectedCharacteristicName);
            ManageCharacteristicsPage manageCharacteristicsPage = editCharacteristicPage.ClickSaveButtonSuccess();
            driver.Navigate().Refresh();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplay();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(newExpectedCharacteristicName), "Error. Edited characteristic is not displayed.");
        }

        [Test]
        public void EditCharactericticCancel()
        {
            string expectedText;
            string actualText;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.WaitCharacteristicNameDisplayed();
            expectedText = editCharacteristicPage.GetCharactericticNameText();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys("123NEW");
            editCharacteristicPage.ClickCancelButton();
            editCharacteristicPage.WaitCharacteristicNameDisplayed();
            actualText = editCharacteristicPage.GetCharactericticNameText();

            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        public void UnsavedChangesWindowDisplayed()
        {
            string expectedTitle = "Warning";
            string actualTitle;
            string expectedMessage = "All unsaved changes will be lost. Are you sure you want to leave this page?";
            string actualMessage;
            IList<IWebElement> warningWindowList;


            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.WaitCharacteristicNameDisplayed();
            warningWindowList = editCharacteristicPage.GetWarningWindowList();
            driver.SwitchTo().ActiveElement();
            actualTitle = editCharacteristicPage.GetWarningWindowTitle();
            actualMessage = editCharacteristicPage.GetWarningWindowMessage();

            Assert.That(warningWindowList, Is.Not.Empty, "Error. Warning window is not displayed.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Warning window title.");
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Error. Incorrect Warning window message.");
        }

        [Test]
        public void UnsavedChangesClose()
        {
            string expectedText = "123";
            string actualText;
            IList<IWebElement> editChararacteristicBladeList;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.WaitCharacteristicNameDisplayed();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys(expectedText);
            editCharacteristicPage.ClickCloseButtonWithChanges();
            driver.SwitchTo().ActiveElement();
            editCharacteristicPage.ClickWarningWindowCloseButton();
            editChararacteristicBladeList = editCharacteristicPage.GetEditCharacteristicBladeList();
            actualText = editCharacteristicPage.GetCharactericticNameText();

            Assert.That(editChararacteristicBladeList, Is.Not.Empty);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        public void UnsavedChangesCancel()
        {
            string expectedText = "123NEW123";
            string actualText;
            IList<IWebElement> editChararacteristicBladeList;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.WaitCharacteristicNameDisplayed();
            editCharacteristicPage.ClearCharacteriticName();
            editCharacteristicPage.GetCharacteristicName().SendKeys(expectedText);
            editCharacteristicPage.ClickCloseButtonWithChanges();
            driver.SwitchTo().ActiveElement();
            editCharacteristicPage.ClickWarningWindowCancelButton();
            editChararacteristicBladeList = editCharacteristicPage.GetEditCharacteristicBladeList();
            actualText = editCharacteristicPage.GetCharactericticNameText();

            Assert.That(editChararacteristicBladeList, Is.Not.Empty);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        public void UnsavedChangesContinue()
        {
            IList<IWebElement> editChararacteristicBladeList;

            EditCharacteristicPage editCharacteristicPage = new EditCharacteristicPage(GetDriver());
            editCharacteristicPage.NavigateToEditCharacteristicPage();
            editCharacteristicPage.GetWarningWindow();
            driver.SwitchTo().ActiveElement();
            editCharacteristicPage.ClickWarningWindowContinueButton();
            editChararacteristicBladeList = editCharacteristicPage.GetEditCharacteristicBladeList();

            Assert.That(editChararacteristicBladeList, Is.Empty);
        }
    }
}
