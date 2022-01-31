using OpenQA.Selenium;
using System.Linq;

namespace epam_gmail_task.WebDriver
{
    public abstract class BasePage
    {
        private static IWebDriver _driver;

        protected BasePage(IWebDriver driver) => _driver = driver;

        public IWebDriver GetDriver() => _driver;

        public bool IsElementPresent(By locator) => _driver.FindElements(locator).Count() > 0;
    }
}
