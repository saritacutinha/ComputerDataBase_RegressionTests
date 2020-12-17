using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDatabase_CommonLibs.Utilities
{
    public class ExtentReportedUtils
    {
        private ExtentHtmlReporter extenHtmlReporter;
        private ExtentReports extentReports;
        private ExtentTest extentTest;

        public ExtentReportedUtils(string htmlReportFileName)
        {
            extenHtmlReporter = new ExtentHtmlReporter(htmlReportFileName);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extenHtmlReporter);
        }

        public void createTestCase(string testcaseName)
        {
            extentTest = extentReports.CreateTest(testcaseName);
        }
        public void addTestLog(Status status, string comment)
        {
            extentTest.Log(status, comment);
        }
        public void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
