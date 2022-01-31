using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace epam_gmail_task.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        // TODO: add chrome security infobars
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        //TODO: Add FirefoxDriver initialization
                        throw new NotImplementedException();
                        break;
                    }
            }

            return driver;
        }
    }
}
