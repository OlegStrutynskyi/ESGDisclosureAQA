using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using TestProject1.PageObjects;
using TestProject1.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Tests
{
    public class AddNewCharacterisctic : Base
    {
        [Test]
        public void AddNewCharacteristicBladeDisplayed()
        {
            string expectedTitle = "Add New Characteristic";
            string actualTitle;
            
            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            actualTitle = addNewCharacteristicPage.GetAddNewCharacteristicPageTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Add New Characteristic title.");
        }
        
        [Test]
        public void AddNewCharacteristicEmptyName()
        {
            string expectedEmptyNameErrorMessage = "This field is required to be filled in.";
            string actualErrorMessage;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.ClickSaveButtonUnsuccess();
            actualErrorMessage = addNewCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedEmptyNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void AddNewCharacteristicIncorrectMinName1()
        {
            string expectedMinNameErrorMessage = "The entered text must be between 3 and 255 characters.";
            string actualErrorMessage;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys("1");
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            actualErrorMessage = addNewCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedMinNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void AddNewCharacteristicIncorrectMinName2()
        {
            string expectedMinNameErrorMessage = "The entered text must be between 3 and 255 characters.";
            string actualErrorMessage;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys("  A  ");
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            actualErrorMessage = addNewCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedMinNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void AddNewCharacteristicIncorrectExistingName()
        {
            string expectedExistingNameErrorMessage = "The entered Characteristics Name value already exists. Please choose another value.";
            string actualErrorMessage;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys("000 - Do not change pls");
            addNewCharacteristicPage.ClickSaveButtonUnsuccess();
            actualErrorMessage = addNewCharacteristicPage.GetErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(expectedExistingNameErrorMessage), "Error. Incorrect error message.");
        }

        [Test]
        public void AddNewCharacteristicMaxNameSuccess()
        {
            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime +
                "_MAX SIZE_255_CHARACTERS_abc def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS TUV WXYZ ! § $% & / () =? *'<> #|;~ @©«»× {} 0123456789 abc def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS TUV WXYZ 0123456789 abc DE";
            ArrayList characteristicsInTable = new ArrayList();

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            ManageCharacteristicsPage manageCharacteristicsPage = addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplay();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName), "Error. Created characteristic is not displayed.");
            //CollectionAssert.Contains(characteristicsInTable, expectedCharacteristicName);//it's the same Assert
        }

         [Test]
         public void AddNewCharactericticCancel()
         {
            string actualText;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys("123");
            addNewCharacteristicPage.WaitCharacteristicNameDisplayed();
            addNewCharacteristicPage.ClickCancelButton();
            addNewCharacteristicPage.WaitCharacteristicNameDisplayed();
            actualText = addNewCharacteristicPage.GetCharactericticNameText();

            Assert.That(actualText, Is.Empty);
         }

        [Test]
        public void UnsavedChangesWindowDisplayed()
        {
            string expectedTitle = "Warning";
            string actualTitle;
            string expectedMessage = "All unsaved changes will be lost. Are you sure you want to leave this page?";
            string actualMessage;
            IList<IWebElement> warningWindowList;


            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            warningWindowList = addNewCharacteristicPage.GetWarningWindowList();
            driver.SwitchTo().ActiveElement();
            actualTitle = addNewCharacteristicPage.GetWarningWindowTitle();
            actualMessage = addNewCharacteristicPage.GetWarningWindowMessage();

            Assert.That(warningWindowList, Is.Not.Empty, "Error. Warning window is not displayed.");
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Warning window title.");
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Error. Incorrect Warning window message.");
        }

        [Test]
        public void UnsavedChangesClose()
        {
            string expectedText = "123";
            string actualText;
            IList<IWebElement> addNewChararacteristicBladeList;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedText);
            addNewCharacteristicPage.ClickCloseButtonWithChanges();
            driver.SwitchTo().ActiveElement();
            addNewCharacteristicPage.ClickWarningWindowCloseButton();
            addNewChararacteristicBladeList = addNewCharacteristicPage.GetAddNewCharacteristicBladeList();
            actualText = addNewCharacteristicPage.GetCharactericticNameText();
            
            Assert.That(addNewChararacteristicBladeList, Is.Not.Empty);
            Assert.That(actualText, Is.EqualTo(expectedText));
            Console.WriteLine(actualText);
        }

        [Test]
        public void UnsavedChangesCancel()
        {
            string expectedText = "123";
            string actualText;
            IList<IWebElement> addNewChararacteristicBladeList;

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedText);
            addNewCharacteristicPage.ClickCloseButtonWithChanges();
            driver.SwitchTo().ActiveElement();
            addNewCharacteristicPage.ClickWarningWindowCancelButton();
            addNewChararacteristicBladeList = addNewCharacteristicPage.GetAddNewCharacteristicBladeList();
            actualText = addNewCharacteristicPage.GetCharactericticNameText();

            Assert.That(addNewChararacteristicBladeList, Is.Not.Empty);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        public void UnsavedChangesContinue()
        {
            IList<IWebElement> addNewChararacteristicBladeList;
            ArrayList existingCharacteristics = new ArrayList();
            string notSavedCharacteristic = "123";

            AddNewCharacteristicPage addNewCharacteristicPage = new AddNewCharacteristicPage(GetDriver());
            addNewCharacteristicPage.NavigateToAddNewCharacteristicPage();
            addNewCharacteristicPage.GetWarningWindow();
            driver.SwitchTo().ActiveElement();
            ManageCharacteristicsPage manageCharacteristicsPage = addNewCharacteristicPage.ClickWarningWindowContinueButton();
            addNewChararacteristicBladeList = addNewCharacteristicPage.GetAddNewCharacteristicBladeList();
            existingCharacteristics = manageCharacteristicsPage.GetAllCharacteristicNames();
                        
            Assert.That(addNewChararacteristicBladeList, Is.Empty);
            Assert.That(!existingCharacteristics.Contains(notSavedCharacteristic));
        }

    }
}
