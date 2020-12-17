using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ComputerDatabase_PageObjects
{
    public class EditComputerPage : BasePage
    {

        private IWebDriver _driver;

        public EditComputerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement PageHeader => _driver.FindElement(By.XPath("//*[@id=\"main\"]/h1"));
        public IWebElement ComputerName => _driver.FindElement(By.Id("name"));
        public IWebElement Introduced => _driver.FindElement(By.Id("introduced"));
        public IWebElement Discontinued => _driver.FindElement(By.Id("discontinued"));
        public SelectElement CompanyName => new SelectElement(_driver.FindElement(By.Id("company")));
        public IWebElement ComputerAddButton => _driver.FindElement(By.XPath("//*[@class='btn primary']"));

        public IWebElement DeleteButtonLink => _driver.FindElement(By.XPath("//*[@class='btn danger']"));


        public bool AddNewPageLoad() => PageHeader.Text.Equals("Edit computer");

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

        public string GetCompanyName()
        {
            return CompanyName.SelectedOption.Text;
        }

        public void EditComputerRecord(string introducedDate, string discontinuedDate, string companyName)
        {
            Thread.Sleep(1000);
            _action.SendText(Introduced, introducedDate);
            _action.SendText(Discontinued, discontinuedDate);
            _action.SelectFromDropDown(CompanyName, companyName);
            _action.ClickElement(ComputerAddButton);

        }

        public bool IsDeleteButtonDisplayed()
        {
            Thread.Sleep(1000);
            return _action.isElementDisplayed(DeleteButtonLink);
        }

        public void ClickOnDelete()
        {
            _action.ClickElement(DeleteButtonLink);

        }

    }
}
