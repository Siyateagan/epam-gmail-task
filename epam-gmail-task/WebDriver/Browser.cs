using OpenQA.Selenium;
using System;

namespace epam_gmail_task.WebDriver
{
    public class Browser
    {
        private static Browser _currentInstance = null!;
        private static IWebDriver _driver = null!;
        private static DriverFactory.BrowserType _currentBrowser;
        public static int ImplWait;
        public static double TimeoutForElement;

        private Browser()
        {
            InitParams();
            Enum.TryParse(Configuration.Browser, out _currentBrowser);
            _driver = DriverFactory.InitializeDriver(_currentBrowser, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            TimeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
        }

        public static Browser Instance => _currentInstance ??= new Browser();

        public static void WindowMaximise() => _driver.Manage().Window.Maximize();

        public static void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);

        public static IWebDriver GetDriver() => _driver;

        public static void Quit() => _driver.Quit();

        public static void RestartSession()
        {
            _driver.Quit();
            _driver = DriverFactory.InitializeDriver(_currentBrowser, ImplWait);
        }
    }
}