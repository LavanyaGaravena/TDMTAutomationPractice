using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TDMTAutomation
{
    public class BasePage
    {

        public IWebDriver Driver;
        public WebDriverWait Wait;

        public BasePage()
        {
            Driver = BaseTest.GetDriver();
            Wait = BaseTest.GetWait();

        }
        public IWebElement GetWebElement(By xpath)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath));
            var element = Driver.FindElement(xpath);
            return element;
        }

        public IList<IWebElement> GetWebElements(By xpath)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(xpath));
            var elements = Driver.FindElements(xpath);
            return elements;
        }

        public SelectElement GetSelect(By xpath)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath));
            var element = new SelectElement(Driver.FindElement(xpath));
            return element;
        }

        public string GetTextFrom(By xpath)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath));
            var element = Driver.FindElement(xpath);
            return element.Text;

        }
    }
}
