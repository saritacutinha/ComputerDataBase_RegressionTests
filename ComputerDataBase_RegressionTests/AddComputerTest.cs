using AventStack.ExtentReports;
using ComputerDatabase_PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDataBase_RegressionTests
{
    [TestFixture]
    public class AddComputerTest : BaseTest
    {
        private AddComputerPage addComputer;
        private SearchPage searchPage;

        [SetUp]
        public void SetUpForAddComputerTest()
        {
            addComputer = new AddComputerPage(commonDriver.driver);
            searchPage = new SearchPage(commonDriver.driver);
            searchPage.ClickOnAddNewComputerButtonLink();
        }

        [Test]
        public void AddNewComputerOnPageLoad_ComputerShouldBeAdded()
        {

            extentReportUtils.createTestCase("To check if on filling the form the data is saved successfully");
            extentReportUtils.addTestLog(Status.Info, "Asserting Page Load Successful");
            Assert.That(addComputer.AddNewPageLoad(), Is.True);

            extentReportUtils.addTestLog(Status.Info, "Adding new Computer Details");
            addComputer.AddNewComputerDetails(_configuration["addComputerSucessful:computerName"],
                _configuration["addComputerSucessful:introduced"],
                _configuration["addComputerSucessful:discontinued"],
                _configuration["addComputerSucessful:company"]);

            extentReportUtils.addTestLog(Status.Info, "Verifying the Details are entered");
            Assert.That(addComputer.GetComputerName, Is.EqualTo(_configuration["addComputerSucessful:computerName"]));
            Assert.That(addComputer.GetIntroduced, Is.EqualTo(_configuration["addComputerSucessful:introduced"]));
            Assert.That(addComputer.GetDiscontinued, Is.EqualTo(_configuration["addComputerSucessful:discontinued"]));

            extentReportUtils.addTestLog(Status.Info, "Verifying Submit button is displayed");
            Assert.That(addComputer.isSubmitButtonDisplayed(), Is.True);

            extentReportUtils.addTestLog(Status.Info, "Click Submit");
            addComputer.Submit();

            extentReportUtils.addTestLog(Status.Info, "Verifying if new Computer has been added sucessfully");
            Assert.That(searchPage.GetResultMessage(),
                Is.EqualTo("Done ! Computer " + _configuration["addComputerSucessful:computerName"]
                + " has been created"));
        }

        [Test]
        public void VerifyComputerNameFieldRequired_ShouldThrowValidation()
        {
            extentReportUtils.createTestCase("To check the Computer Name field is mandatory.");
            extentReportUtils.addTestLog(Status.Info, "Asserting Page Load Successful");
            Assert.That(addComputer.AddNewPageLoad(), Is.True);

            extentReportUtils.addTestLog(Status.Info, "Adding record without computer name");
            addComputer.AddNewComputerWithEmptyName();

            extentReportUtils.addTestLog(Status.Info, "Verifying if error messages are thrown");
            Assert.That(addComputer.RequiredMessageText(), Contains.Substring("Failed to refine type : Predicate isEmpty() did not fail."));
        }
    }
}

