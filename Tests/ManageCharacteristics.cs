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
    public class ManageCharacteristics : Base
    {
        [Test]
        public void ManageCharacteristicsTitle()
        {
            string expectedTitle = "Manage Characteristics";
            string actualTitle;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            actualTitle = manageCharacteristicsPage.GetManageCharacteristicsPageTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Manage Characteristics title.");
        }
                
        [Test]
        public void AddNewCharacteristicOpened()
        {
            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            var addNewCharacteristicBlade = addNewCharacteristicPage.GetAddNewCharacteristicBlade();

            Assert.That(addNewCharacteristicBlade.Displayed);
        }

        [Test]
        public void DeleteCharacteristicWithDependencyModalContent()
        {
            string expectedModalTitle = "Delete Characteristic";
            string actualModalTitle;
            string expectedModalMessageLine1 = "This characteristic cannot be deleted as it is used in the question configuration of periodic and/or pre-contractual question(s).";
            string actualModalMessageLine1;
            string expectedModalMessageLine2 = "Please modify the following question(s) to proceed.";
            string actualModalMessageLine2;
            string expectedGridLine1Name = "DO NOT DELETE";
            string actualGridLine1Name;
            string expectedGridLine1Link = "Edit Question";
            string actualGridLine1Link;
            IWebElement deleteWindow;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            manageCharacteristicsPage.ClickCharacteristicDeleteIcon();
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            deleteWindow = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindow();
            actualModalTitle = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindowTitle();
            actualModalMessageLine1 = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindowMessageLine1();
            actualModalMessageLine2 = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindowMessageLine2();
            actualGridLine1Name = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindowGridLine1NameText();
            actualGridLine1Link = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindowGridLine1LinkText();

            Assert.That(deleteWindow.Displayed, "Error. Delete pop-up is not displayed.");
            Assert.That(actualModalTitle, Is.EqualTo(expectedModalTitle), "Error. Incorrect Delete Modal title.");
            Assert.That(actualModalMessageLine1, Is.EqualTo(expectedModalMessageLine1), "Error. Incorrect Delete Modal message (line 1).");
            Assert.That(actualModalMessageLine2, Is.EqualTo(expectedModalMessageLine2), "Error. Incorrect Delete Modal message (line 1).");
            Assert.That(actualGridLine1Name, Is.EqualTo(expectedGridLine1Name), "Error. Incorrect 1st Question Name in the grid.");
            Assert.That(actualGridLine1Link, Is.EqualTo(expectedGridLine1Link), "Error. Incorrect 1st Link text in the grid.");
        }

        [Test]
        public void DeleteCharacteristicWithDependencyLink1Click()
        {
            IWebElement editQuestionBlade;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            manageCharacteristicsPage.ClickCharacteristicDeleteIcon();
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            QuestionManagementPageEdit questionManagementPageEdit = manageCharacteristicsPage.ClickCharacteristicUnseccessDeleteWindowGridLine1LinkText();
            editQuestionBlade = questionManagementPageEdit.GetQuestionManagementBladeEdit();

            Assert.That(editQuestionBlade.Displayed, "Error. Question Management blade is not opened.");
        }

        [Test]
        public void DeleteCharacteristicWithDependencyCancel()
        {
            ArrayList characteristicsInTable = new ArrayList();
            string existingCharacteristicName;
            
            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            existingCharacteristicName = manageCharacteristicsPage.GetCharacteristicWithDependencyName();
            manageCharacteristicsPage.ClickCharacteristicDeleteIcon();
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            manageCharacteristicsPage.ClickCharacteristicUnseccessDeleteWindowCancelBtn();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(existingCharacteristicName));//Check characteristic is not deleted
        }

        [Test]
        public void DeleteCharacteristicWithDependencyClose()
        {
            ArrayList characteristicsInTable = new ArrayList();
            string existingCharacteristicName;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            existingCharacteristicName = manageCharacteristicsPage.GetCharacteristicWithDependencyName();
            manageCharacteristicsPage.ClickCharacteristicDeleteIcon();
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            manageCharacteristicsPage.ClickCharacteristicUnseccessDeleteWindowCloseBtn();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(existingCharacteristicName));//Check characteristic is not deleted
        }

        [Test]
        public void DeleteCharacteristicWithDependencyContinue()
        {
            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            manageCharacteristicsPage.ClickCharacteristicDeleteIcon();
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            var stateDisabled = manageCharacteristicsPage.GetCharacteristicUnseccessDeleteWindowContinueBtnState();

            Assert.That(stateDisabled, Is.EqualTo("true"));
        }



        [Test]
        public void DeleteCharacteristicWithoutDependencyConfirm()
        {
            /*FLOW:
             1. Create a new characteristic
             2. Verify it is displayed in the list
             3. Delete characteristic from step-1
             4. Verify it is NOT displayed in the list
             */

            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime;
            ArrayList characteristicsInTable = new ArrayList();

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();
            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
            driver.FindElement(By.XPath("//div[@title='" + expectedCharacteristicName + "']/../following-sibling::td[3]/div/action-button[@icon='delete']/div/i")).Click();//How to move it to PO?
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            manageCharacteristicsPage.ClickCharacteristicDeleteWarningWindowConfirmBtn();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.No.Member(expectedCharacteristicName));
        }

        [Test]
        public void DeleteCharacteristicWithoutDependencyCancel()
        {
            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime;
            ArrayList characteristicsInTable = new ArrayList();

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
            driver.FindElement(By.XPath("//div[@title='" + expectedCharacteristicName + "']/../following-sibling::td[3]/div/action-button[@icon='delete']/div/i")).Click();//How to move it to PO?
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            manageCharacteristicsPage.ClickCharacteristicDeleteWarningWindowCancelBtn();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
        }

        [Test]
        public void DeleteCharacteristicWithoutDependencyClose()
        {
            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime;
            ArrayList characteristicsInTable = new ArrayList();

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
            driver.FindElement(By.XPath("//div[@title='" + expectedCharacteristicName + "']/../following-sibling::td[3]/div/action-button[@icon='delete']/div/i")).Click();//How to move it to PO?
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            manageCharacteristicsPage.ClickCharacteristicDeleteWarningCloseBtn();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
        }

        [Test]
        public void DeleteCharacteristicWithoutDependencyModalContent()
        {
            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime;
            ArrayList characteristicsInTable = new ArrayList();
            string expectedWarningTitle = "Warning";
            string expectedWarningMessage = "Are you sure you want to delete the characteristic?";
            
            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();
            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
            driver.FindElement(By.XPath("//div[@title='" + expectedCharacteristicName + "']/../following-sibling::td[3]/div/action-button[@icon='delete']/div/i")).Click();//How to move it to PO?
            manageCharacteristicsPage.WaitDeleteModalDisplay();
            string actualWarningTitle = manageCharacteristicsPage.GetCharacteristicDeleteWarningWindowTitle();
            string actualWarningMessage = manageCharacteristicsPage.GetCharacteristicDeleteWarningWindowMessage();
            var cancelButton = manageCharacteristicsPage.GetCharacteristicDeleteWarningWindowCancelBtn();

            Assert.That(actualWarningTitle, Is.EqualTo(expectedWarningTitle), "Error. Incorrect Delete Warning window Title.");
            Assert.That(actualWarningMessage, Is.EqualTo(expectedWarningMessage), "Error. Incorrect Delete Warning window Message.");            
        }

        [Test]
        public void PrintExistingCharacteristics()
        {
            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();

            ArrayList characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Is.Not.Empty);
            if (characteristicsInTable.Count > 0)
            {
                foreach (String characteristic in characteristicsInTable)
                {
                    TestContext.Progress.WriteLine(characteristic);
                }
            }
            else
            {
                TestContext.Progress.WriteLine("Characteristics Table is empty.");
            }
        }

        [Test]
        public void EditCharacteristicName()
        {
            /*FLOW:
             1. Create a new characteristic
             2. Verify it is displayed in the list
             3. Edit characteristic from step-1
             4. Verify a new name is displayed in the list
             */

            string characteristicTime = DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string expectedCharacteristicName = "A_Selenium_" + characteristicTime;
            string expectedCharacteristicNameEdited = "A_Selenium_" + characteristicTime + "_EDITED";
            ArrayList characteristicsInTable = new ArrayList();

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            AddNewCharacteristicPage addNewCharacteristicPage = manageCharacteristicsPage.ClickAddNewCharacteristicButton();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicName);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();
            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicName));
            driver.FindElement(By.XPath("//div[@title='" + expectedCharacteristicName + "']/../following-sibling::td[3]/div/action-button[@icon='edit']/div/i")).Click();//How to move it to PO?
            addNewCharacteristicPage.ClearCharacteriticName();
            addNewCharacteristicPage.GetCharacteristicName().SendKeys(expectedCharacteristicNameEdited);
            addNewCharacteristicPage.ClickSaveButtonSuccess();
            manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
            characteristicsInTable = manageCharacteristicsPage.GetAllCharacteristicNames();

            Assert.That(characteristicsInTable, Has.Member(expectedCharacteristicNameEdited));
        }

        [Test]
        public void RowsPerPageDropdownItems()
        {
            List<int> expectedDropdownItems = new List<int> { 10, 25, 50 };
            List<int> actualDropdownItems = new List<int>();

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            var actualDropdownItemsList = manageCharacteristicsPage.GetRowsPerPageDropdownItems();
            foreach(var item in actualDropdownItemsList)
            {
                actualDropdownItems.Add(Int32.Parse(item.Text));
            }

            Assert.That(actualDropdownItems, Is.EqualTo(expectedDropdownItems), "Error. Incorrect items in the Rows per Page dropdown.");
        }
        
        [Test]
        public void SelectRowsPerPage25()
        {
            int countAfter10;
            int countAfter25;
            IList<IWebElement> charList10;
            IList<IWebElement> charList25;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage(); 
            charList10 = manageCharacteristicsPage.GetCharacteristicInTableList();

            if (charList10.Count < 10)
            {
                TestContext.Progress.WriteLine("There are less than 10 characteristics.");
            }
            else
            {
                Assert.That(charList10, Has.Count.EqualTo(10));
                countAfter10 = charList10.Count;
                manageCharacteristicsPage.ClickRowsPerPage25();
                manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
                charList25 = manageCharacteristicsPage.GetCharacteristicInTableList();
                countAfter25 = charList25.Count;
                if (countAfter25 < 11)
                {
                    TestContext.Progress.WriteLine("There are 10 characteristics.");
                }
                else
                {
                    Assert.That(countAfter10, Is.Not.EqualTo(countAfter25));
                }
            }
        }

        [Test]
        public void SelectRowsPerPage50()
        {
            int countAfter10;
            int countAfter50;
            IList<IWebElement> charList10;
            IList<IWebElement> charList50;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            charList10 = manageCharacteristicsPage.GetCharacteristicInTableList();
           
            if (charList10.Count < 10)
            {
                TestContext.Progress.WriteLine("There are less than 10 characteristics.");
            }
            else
            {
                Assert.That(charList10, Has.Count.EqualTo(10));
                countAfter10 = charList10.Count;
                manageCharacteristicsPage.ClickRowsPerPage50();
                manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
                charList50 = manageCharacteristicsPage.GetCharacteristicInTableList();
                countAfter50 = charList50.Count;
                if (countAfter50 < 11)
                {
                    TestContext.Progress.WriteLine("There are 10 characteristics.");
                }
                else
                {
                    Assert.That(countAfter10, Is.Not.EqualTo(countAfter50));
                } 
            }
        }

        [Test]
        public void AllNotDeletedCharacteristicsDisplayed()
        {
            ArrayList characteristicsInUI;
            List<string> characteristicsInDB;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            characteristicsInUI = manageCharacteristicsPage.GetAllCharacteristicNames();
            characteristicsInDB = manageCharacteristicsPage.GetCharacteristicNamesListFromDB();

            Assert.That(characteristicsInUI, Is.EqualTo(characteristicsInDB));   
        }

        [Test]
        public void TotalNumberOfCharacteristics()
        {
            int totalNumberInGrid;
            int numberUnderGrid;
            
            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            var characteristicsInUIList = manageCharacteristicsPage.GetAllCharacteristicNames();
            totalNumberInGrid = characteristicsInUIList.Count;
            numberUnderGrid = manageCharacteristicsPage.GetTotalRecordsCount();

            Assert.That(numberUnderGrid, Is.EqualTo(totalNumberInGrid));
        }

        [Test]
        public void Z_DeleteAllSeleniumCharacteristics()
        {
            string expectedName = "A_Selenium";
            ArrayList characteristicsInUIList;

            ManageCharacteristicsPage manageCharacteristicsPage = new ManageCharacteristicsPage(GetDriver());
            manageCharacteristicsPage.NavigateToManageCharacteristicPage();
            characteristicsInUIList = manageCharacteristicsPage.GetAllCharacteristicNames();
            foreach(string characteristic in characteristicsInUIList)
            {
                if (characteristic.StartsWith(expectedName))
                {
                    manageCharacteristicsPage.ClickSeleniumCharacteristicDeleteIcon();
                    manageCharacteristicsPage.WaitDeleteModalDisplay();
                    driver.SwitchTo().ActiveElement();
                    manageCharacteristicsPage.ClickCharacteristicDeleteWarningWindowConfirmBtn();
                    manageCharacteristicsPage.WaitCharacteristicsGridDisplayed();
                }
                else
                {
                    Assert.That(!characteristicsInUIList.Contains(characteristic.StartsWith(expectedName)));
                }
            }
        }
    }
}
