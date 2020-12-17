using ComputerDatabase_CommonLibs.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDatabase_PageObjects
{
    public class SearchPage : BasePage
    {
        private IWebDriver _driver;
        private DefaultWait<IWebDriver> fluentWait;
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public IWebElement PageHeader => _driver.FindElement(By.XPath("//*[@id=\"main\"]/h1"));
        public IWebElement AddNewComputerButtonLink => fluentWait.Until(x => x.FindElement(By.Id("add")));
        public IWebElement ResultMessage => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"main\"]/div[1]")));

        public IWebElement TableDataComputerName => _driver.FindElement(By.XPath("//*[@id=\"main\"]/table/tbody/tr/td[1]/a"));
        public IWebElement TableDataIntroduced => _driver.FindElement(By.XPath("//*[@id=\"main\"]/table/tbody/tr/td[2]"));

        public IWebElement TableDataDiscontinued => _driver.FindElement(By.XPath("//*[@id=\"main\"]/table/tbody/tr/td[3]"));
        public IWebElement TableDataCompanyName => _driver.FindElement(By.XPath("//*[@id=\"main\"]/table/tbody/tr/td[4]"));

        public string GetPageURL() => _driver.Url;

        public void ClickOnAddNewComputerButtonLink()
        {

            _action.ClickElement(AddNewComputerButtonLink);

        }

        public string GetResultMessage() => ResultMessage.Text;

        public bool SearchPageloaded() => PageHeader.Text.Equals("574 computers found");




    }
}
