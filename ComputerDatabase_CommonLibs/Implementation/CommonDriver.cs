using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDatabase_CommonLibs.Utilities
{
    public class CommonDriver
    {
        private int pageLoadTimeout;
        private int elementDetectionTimeout;
        public IWebDriver driver;

        public CommonDriver(string browserType)
        {
            browserType = browserType.Trim();
            pageLoadTimeout = 5000;
            elementDetectionTimeout = 10;

            if (browserType.Equals("chrome"))
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            else
                throw new Exception("Invalid browser Type " + browserType);
        }
        public void CloseAllBrowser()
        {
            driver.Quit();
        }
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        public void NavigateToUrl(string url)
        {
            url = url.Trim();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);
            driver.Url = url;
        }
    }
}
