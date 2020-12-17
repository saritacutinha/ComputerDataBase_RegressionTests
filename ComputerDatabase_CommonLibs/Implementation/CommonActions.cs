using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerDatabase_CommonLibs.Utilities
{
   
    public class CommonActions
    {
        public void Clear(IWebElement element) => element.Clear();
        public void ClickElement(IWebElement element) => element.Click();
        public bool isElementDisplayed(IWebElement element) => element.Displayed;
        public bool isElementEnabled(IWebElement element) => element.Enabled;
        public bool isElementSelected(IWebElement element) => element.Selected;
        public void SendText(IWebElement element, string text) => element.SendKeys(text);

        public void SelectFromDropDown(SelectElement selectElement, string selectListOption)
        {            
            selectElement.Options.ToList().Find(x => x.Text == selectListOption).Click();
        }
    }
}
