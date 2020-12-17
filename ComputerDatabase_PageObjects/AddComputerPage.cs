using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ComputerDatabase_PageObjects
{
    public class AddComputerPage : BasePage
    {

        private IWebDriver _driver;
        private DefaultWait<IWebDriver> fluentWait;



        public AddComputerPage(IWebDriver driver)
        {
            _driver = driver;
            fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }



        public IWebElement PageHeader => _driver.FindElement(By.XPath("//*[@id=\"main\"]/h1"));

        public IWebElement ComputerName => fluentWait.Until(x => x.FindElement(By.Id("name")));
        public IWebElement Introduced => fluentWait.Until(x => x.FindElement(By.Id("introduced")));
        public IWebElement Discontinued => fluentWait.Until(x => x.FindElement(By.Id("discontinued")));

        public SelectElement CompanyName => new SelectElement(_driver.FindElement(By.Id("company")));
        public IWebElement ComputerAddButton => _driver.FindElement(By.XPath("//*[@class='btn primary']"));
        public IWebElement CancelButton => _driver.FindElement(By.XPath("//*[@class='btn primary']"));
        public IWebElement ComputerNameRequiredMessage => _driver.FindElement(By.XPath("//*[@id=\"main\"]/form/fieldset/div[1]/div/span"));

        public bool AddNewPageLoad()
        {
            return (PageHeader.Text.Equals("Add a computer") &&
             _action.isElementDisplayed(CancelButton) && isDisplayedComputerName());
        }


        public bool isDisplayedComputerName()
        {
            return _action.isElementDisplayed(ComputerName);
        }

        public string GetComputerName()
        {
            return ComputerName.GetAttribute("value");
        }

        public string GetIntroduced()
        {
            return Introduced.GetAttribute("value");
        }

        public string GetDiscontinued()
        {
            return Discontinued.GetAttribute("value");
        }


        public void AddNewComputerDetails(string computerName, string introducedDate, string discontinuedDate, string companyName)
        {
            Thread.Sleep(1000);
            _action.SendText(ComputerName, computerName);

            _action.SendText(Introduced, introducedDate);

            _action.SendText(Discontinued, discontinuedDate);

            _action.SelectFromDropDown(CompanyName, companyName);

        }

        public bool isSubmitButtonDisplayed()
        {
            return _action.isElementDisplayed(ComputerAddButton);
        }

        public void Submit()
        {
            _action.ClickElement(ComputerAddButton);
        }


        public void AddNewComputerWithEmptyName()
        {
            Thread.Sleep(1000);
            _action.ClickElement(ComputerAddButton);
        }

        public string RequiredMessageText() => ComputerNameRequiredMessage.Text;
        public string GetPageURL()
        {

            return _driver.Url;
        }


    }
}
