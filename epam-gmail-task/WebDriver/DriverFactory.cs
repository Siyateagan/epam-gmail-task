using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace epam_gmail_task.WebDriver
{
    public class DriverFactory
    {
        public enum BrowserType
        {
            Chrome,
            RemoteChrome,
            Firefox
        }

        public static IWebDriver InitializeDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null!;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var options = new ChromeOptions();
                        options.AddArgument("disable-infobars");
                        options.AddExcludedArgument("enable-automation");

                        driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var option = new FirefoxOptions();

                        driver = new FirefoxDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        var options = new ChromeOptions();
                        options.AddArgument("disable-infobars");
                        options.AddExcludedArgument("enable-automation");
                        driver = new RemoteWebDriver(new Uri(Configuration.RemoteDriverUri), options);
                        break;
                    }
            }

            return driver;
        }
    }
}
