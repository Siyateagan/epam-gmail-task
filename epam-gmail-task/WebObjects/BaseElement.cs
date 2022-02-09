using epam_gmail_task.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace epam_gmail_task.PageObjects
{
    public class BaseElement : IWebElement
    {
        public By Locator { get; private set; }
        private IWebDriver _driver = Browser.GetDriver();
        protected IWebElement _element;

        public BaseElement(By locator)
        {
            Locator = locator;
        }

        public void WaitForIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = _driver.FindElement(Locator);
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
            Browser.GetDriver().FindElement(Locator).SendKeys(text);
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(Locator).Click();
        }

        public string GetText()
        {
            WaitForIsVisible();
            return Browser.GetDriver().FindElement(Locator).Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                _element = Browser.GetDriver().FindElement(Locator);
            }
            catch (Exception)
            {
                throw;
            }
            return _element;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string? TagName { get; }
        public string? Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed
        {
            get
            {
                try
                {
                    _driver.FindElement(Locator);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
}
