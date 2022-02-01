using epam_gmail_task.PageObjects;
using OpenQA.Selenium;

namespace epam_gmail_task.WebDriver
{
    public abstract class BasePage
    {
        protected By _titleLocator;

        protected BasePage(By titleLocator)
        {
            _titleLocator = titleLocator;
            AssertIsOpen();
        }

        private void AssertIsOpen()
        {
            BaseElement label = new BaseElement(_titleLocator);
            label.WaitForIsVisible();
        }
    }
}
