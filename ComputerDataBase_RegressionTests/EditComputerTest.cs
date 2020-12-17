using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using ComputerDatabase_PageObjects;
using NUnit.Framework;

namespace ComputerDataBase_RegressionTests
{
    public class EditComputerTest : BaseTest
    {
        private EditComputerPage editComputer;

        [SetUp]
        public void SetUpForAddComputerTest()
        {
            editComputer = new EditComputerPage(commonDriver.driver);
            new SearchPage(commonDriver.driver).TableDataComputerName.Click();
        }

        [Test]
        public void VerifyEditComputerPageLoad_PageShouldBeDisplayed()
        {
            extentReportUtils.createTestCase("To check if on clicking the name of the computer the edit page is loaded");
            extentReportUtils.addTestLog(Status.Info, "Asserting Page Load Successful");
            Assert.That(editComputer.AddNewPageLoad(), Is.True);
        }

        [Test]
        public void VerifyPrePopulatedValues_ShouldBeDisplayed()
        {
            extentReportUtils.createTestCase("To verify on the edit computer page the record values are pre populated");
            extentReportUtils.addTestLog(Status.Info, "Checking the Prepopulated Values");
            extentReportUtils.addTestLog(Status.Info, "Checking the Computer Name");
            Assert.That(editComputer.GetComputerName(), Is.EqualTo(_configuration["editComputerPopulatedValues:computerName"]));

            extentReportUtils.addTestLog(Status.Info, "Checking the Introduced Field");
            Assert.That(editComputer.GetIntroduced(), Is.EqualTo(_configuration["editComputerPopulatedValues:introduced"]));

            extentReportUtils.addTestLog(Status.Info, "Checking the Discontinued Field");
            Assert.That(editComputer.GetDiscontinued(), Is.EqualTo(_configuration["editComputerPopulatedValues:discontinued"]));

            extentReportUtils.addTestLog(Status.Info, "Checking the Company Name");
            Assert.That(editComputer.GetCompanyName(), Is.EqualTo(_configuration["editComputerPopulatedValues:company"]));

        }

        [Test]
        public void VerifySaveOnEditingAllFields_ShouldSave()
        {
            extentReportUtils.createTestCase("To verify on updating all the fields the updated value is saved and sucess message appears");
            extentReportUtils.addTestLog(Status.Info, "Updating the record");
            editComputer.EditComputerRecord(_configuration["editComputerAddNewValues:introduced"],
                _configuration["editComputerAddNewValues:discontinued"], _configuration["editComputerAddNewValues:company"]);

            extentReportUtils.addTestLog(Status.Info, "Verifying if newly edited Computer has been added");
            Assert.That(new SearchPage(commonDriver.driver).GetResultMessage(),
                Is.EqualTo("Done ! Computer " + _configuration["editComputerAddNewValues:computerName"]
                + " has been updated"));
        }

        [Test]
        public void VerifyDeleteComputer_ShouldBeDeletedSuccessfully()
        {
            extentReportUtils.createTestCase("To verify if the delete this computer button is clicked the computer is deleted");
            extentReportUtils.addTestLog(Status.Info, "Click Delete Button");

            if (editComputer.IsDeleteButtonDisplayed())
                editComputer.ClickOnDelete();
            extentReportUtils.addTestLog(Status.Info, "Click Delete Button");

            Assert.That(new SearchPage(commonDriver.driver).SearchPageloaded(), Is.True);
            Assert.That(new SearchPage(commonDriver.driver).GetResultMessage(), Is.EqualTo("Done ! Computer " + _configuration["editComputerAddNewValues:computerName"] + " has been deleted"));
        }

    }
}
