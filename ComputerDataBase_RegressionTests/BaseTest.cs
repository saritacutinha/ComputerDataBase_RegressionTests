using AventStack.ExtentReports;
using ComputerDatabase_CommonLibs.Utilities;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDataBase_RegressionTests
{
    public class BaseTest
    {
        protected CommonDriver commonDriver;
        protected CommonActions _actions;
        protected IConfiguration _configuration;
        private string reportFileName;
        public ExtentReportedUtils extentReportUtils;

        [OneTimeSetUp]
        public void PreSetUp()
        {
            string workingDirectory = Environment.CurrentDirectory;
            reportFileName = workingDirectory + "/ComputerDatabase_RegressionTestReport";
            _configuration = new ConfigurationBuilder()
                            .AddJsonFile("appSetting.json")
                            .Build();
            extentReportUtils = new ExtentReportedUtils(reportFileName);
        }

        [SetUp]
        public void SetUp()
        {
            extentReportUtils.createTestCase("SetUp");
            commonDriver = new CommonDriver(_configuration["browserType"]);
            extentReportUtils.addTestLog(Status.Info, "Browser Type is" + _configuration["browserType"]);

            commonDriver.NavigateToUrl(_configuration["baseUrl"]);
            extentReportUtils.addTestLog(Status.Info, "Navigation to BaseURL" + _configuration["baseUrl"]);
            _actions = new CommonActions();

        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                extentReportUtils.addTestLog(Status.Fail, "Failed Assertions in the Test");
            }
            commonDriver.CloseBrowser();
        }

        [OneTimeTearDown]
        public void PostCleanUp()
        {
            extentReportUtils.FlushReport();
        }

    }
}
