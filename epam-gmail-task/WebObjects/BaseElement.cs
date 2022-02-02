using epam_gmail_task.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace epam_gmail_task.PageObjects
{
    public class BaseElement
    {
        protected By _locator;
        private IWebDriver _driver = Browser.GetDriver();

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public void WaitForIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = _driver.FindElement(_locator);
                    return elementToBeDisplayed.Displayed;
                }
                catch (Exception exception)
                when (exception is StaleElementReferenceException || exception is NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public string GetText()
        {
            WaitForIsVisible();
            return Browser.GetDriver().FindElement(_locator).Text;
        }
    }
}
