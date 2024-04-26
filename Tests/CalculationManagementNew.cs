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
    public class CalculationManagementNew : Base
    {
        [Test]
        public void CalcManagementTitle()
        {
            string expectedTitle = "Calculation Management";
            string actualTitle;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            actualTitle = calcManagementPage.GetCalcManagementPageNewTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Error. Incorrect Calculation Management title.");
        }

        [Test]
        public void CalcManagementSubTitle()
        {
            string actualSubTitle;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            actualSubTitle = calcManagementPage.GetCalcManagementPageNewSubTitle();

            Assert.That(actualSubTitle, Is.Empty, "Error. Incorrect Calculation Management subtitle.");
        }

        [Test]
        public void CalcManagementTopButtons()
        {
            bool actualEnableDisableToggleState;
            string expectedDuplicateButtonState = "disabled";
            string actualDuplicateButtonState;
            string expectedDependenciesButtonState = "disabled";
            string actualDependenciesButtonState;
            string expectedDeleteButtonState = "disabled";
            string actualDeleteButtonState;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            actualEnableDisableToggleState = calcManagementPage.GetEnableDisableToggle().Enabled;
            actualDuplicateButtonState = calcManagementPage.GetDuplicateButtonState();
            actualDependenciesButtonState = calcManagementPage.GetDependenciesButtonState();
            actualDeleteButtonState = calcManagementPage.GetDeleteButtonState();

            Assert.That(actualEnableDisableToggleState, Is.False, "Error. Enable/Disable toggle is not disabled.");
            Assert.That(actualDuplicateButtonState, Is.EqualTo(expectedDuplicateButtonState), "Error. Duplicate button is not disabled.");
            Assert.That(actualDependenciesButtonState, Is.EqualTo(expectedDependenciesButtonState), "Error. Dependencies button is not disabled.");
            Assert.That(actualDeleteButtonState, Is.EqualTo(expectedDeleteButtonState), "Error. Delete button is not disabled.");
        }

        [Test]
        public void CalculationNameIncorrectEmpty()
        {
            string expectedError = "This field is required to be filled in.";
            string actualError;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.ClickSaveButtonError();
            actualError = calcManagementPage.GetCalculationNameErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void CalculationNameIncorrectLow1()
        {
            string expectedError = "The entered text must be between 3 and 255 characters.";
            string actualError;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.GetCalculationName().SendKeys("1");
            calcManagementPage.ClickSaveButtonError();
            actualError = calcManagementPage.GetCalculationNameErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void CalculationNameIncorrectLow2()
        {
            string expectedError = "The entered text must be between 3 and 255 characters.";
            string actualError;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.GetCalculationName().SendKeys("  AA  ");
            calcManagementPage.ClickSaveButtonError();
            actualError = calcManagementPage.GetCalculationNameErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void CalculationNameIncorrectDuplicated()
        {
            string expectedError = "The entered Calculation Name value already exists. Please choose another value.";
            string actualError;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.GetCalculationName().SendKeys("000 - Don't change pls");
            calcManagementPage.ClickSaveButtonError();
            actualError = calcManagementPage.GetCalculationNameErrorMessage();

            Assert.That(actualError, Is.EqualTo(expectedError), "Error. Incorrect error message.");
        }

        [Test]
        public void HoldingFileSelectionDropdownItems()
        {
            string[] expectedItems = { "Year End", "Q1", "Q2", "Q3" };
            ArrayList actualItems;
            
            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.ClickHoldingFileSelectionDropdown();
            actualItems = calcManagementPage.GetHoldingFileSelectionDropdownItemsList();

            Assert.That(actualItems, Is.EquivalentTo(expectedItems), "Error. Incorrect Holding File Selection Dropdown items.");
        }

        [Test]
        public void HoldingFileSelectionSelectedItemsDefault()
        {
            string[] expectedItems = { "Year End" };
            ArrayList actualItems;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            actualItems = calcManagementPage.GetHoldingFileSelectionSelectedItems();

            Assert.That(actualItems, Is.EquivalentTo(expectedItems), "Error. Incorrect Holding File Selection Dropdown items.");
        }

        [Test]
        public void HoldingFileSelectionSelectDeselectAllItemsInDropdown()
        {
            string[] expectedItemsAfterSelect = { "Year End", "Q1", "Q2", "Q3" };
            string[] expectedItemsAfterDeselect = { "Year End" };
            ArrayList actualItems;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.ClickHoldingFileSelectionDropdown();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ1Name();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ2Name();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ3Name();
            actualItems = calcManagementPage.GetHoldingFileSelectionSelectedItems();
            var yearEndCheckbox = calcManagementPage.GetHoldingFileSelectionDropdownYearEndCheckbox();
            var q1Checkbox = calcManagementPage.GetHoldingFileSelectionDropdownQ1Checkbox();
            var q2Checkbox = calcManagementPage.GetHoldingFileSelectionDropdownQ2Checkbox();
            var q3Checkbox = calcManagementPage.GetHoldingFileSelectionDropdownQ3Checkbox();

            Assert.That(actualItems, Is.EquivalentTo(expectedItemsAfterSelect), "Error. All Quarters are not selected.");
            Assert.That(yearEndCheckbox.Selected, Is.True, "Error. Year End is not selected.");
            Assert.That(q1Checkbox.Selected, Is.True, "Error. Q1 is not selected.");
            Assert.That(q2Checkbox.Selected, Is.True, "Error. Q2 is not selected.");
            Assert.That(q3Checkbox.Selected, Is.True, "Error. Q3 is not selected.");

            calcManagementPage.ClickHoldingFileSelectionDropdownQ1Name();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ2Name();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ3Name();
            actualItems = calcManagementPage.GetHoldingFileSelectionSelectedItems();
            yearEndCheckbox = calcManagementPage.GetHoldingFileSelectionDropdownYearEndCheckbox();
            q1Checkbox = calcManagementPage.GetHoldingFileSelectionDropdownQ1Checkbox();
            q2Checkbox = calcManagementPage.GetHoldingFileSelectionDropdownQ2Checkbox();
            q3Checkbox = calcManagementPage.GetHoldingFileSelectionDropdownQ3Checkbox();

            Assert.That(actualItems, Is.EquivalentTo(expectedItemsAfterDeselect), "Error. Q1, Q2, Q3 are not deselected.");
            Assert.That(yearEndCheckbox.Selected, Is.True, "Error. Year End is not selected.");
            Assert.That(q1Checkbox.Selected, Is.Not.True, "Error. Q1 is not deselected.");
            Assert.That(q2Checkbox.Selected, Is.Not.True, "Error. Q2 is not deselected.");
            Assert.That(q3Checkbox.Selected, Is.Not.True, "Error. Q3 is not deselected.");
        }

        [Test]
        public void HoldingFileSelectionDeselectInField()
        {
            string[] expectedItemsAfterSelect = { "Year End", "Q1", "Q2", "Q3" };
            string[] expectedItemsAfterDeselect = { "Year End" };
            ArrayList actualItems;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.ClickHoldingFileSelectionDropdown();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ1Name();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ2Name();
            calcManagementPage.ClickHoldingFileSelectionDropdownQ3Name();
            actualItems = calcManagementPage.GetHoldingFileSelectionSelectedItems();

            Assert.That(actualItems, Is.EquivalentTo(expectedItemsAfterSelect), "Error. All Quarters are not selected.");

            calcManagementPage.ClickHoldingFileSelectionSelectedItemQ1DeleteIcon();
            calcManagementPage.ClickHoldingFileSelectionSelectedItemQ2DeleteIcon();
            calcManagementPage.ClickHoldingFileSelectionSelectedItemQ3DeleteIcon();
            actualItems = calcManagementPage.GetHoldingFileSelectionSelectedItems();

            Assert.That(actualItems, Is.EquivalentTo(expectedItemsAfterDeselect), "Error. Q1, Q2, Q3 are not deselected.");
        }

        [Test]
        public void HoldingFileSelectionYearEndDisabled()
        {
            string expectedSelectedState = "disabled";
            string actualSelectedState;
            string expectedStateInDropdown = "disabled";
            string actualStateInDropdown;

            CalculationManagementPageNew calcManagementPage = new CalculationManagementPageNew(GetDriver());
            calcManagementPage.NavigateToCalcManagementPageNew();
            calcManagementPage.ClickHoldingFileSelectionDropdown();
            actualSelectedState = calcManagementPage.GetHoldingFileSelectionSelectedItemYearEndState();
            actualStateInDropdown = calcManagementPage.GetHoldingFileSelectionDropdownYearEndNameState();

            Assert.That(actualSelectedState, Is.EqualTo(expectedSelectedState), "Error. Year End is not disabled in the Field.");
            Assert.That(actualStateInDropdown, Is.EqualTo(expectedStateInDropdown), "Error. Year End is not disabled in the Dropdown.");

        }

    }
}
