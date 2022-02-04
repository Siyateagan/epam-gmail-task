using OpenQA.Selenium;
using System;

namespace epam_gmail_task.WebDriver
{
    public class Browser
    {
        private static Browser _currentInstance = null!;
        private static IWebDriver _driver = null!;
        private static BrowserFactory.BrowserType _currentBrowser;
        private static int ImplWait;
        private static double _timeoutForElement;

        private Browser()
        {
            InitParams();
            Enum.TryParse(Configuration.Browser, out _currentBrowser);
            _driver = BrowserFactory.InitializeDriver(_currentBrowser, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            _timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
        }

        public static Browser Instance => _currentInstance ??= new Browser();

        public static void WindowMaximise() => _driver.Manage().Window.Maximize();

        public static void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);

        public static IWebDriver GetDriver() => _driver;

        public static void Quit() => _driver.Quit();

        public static void RestartSession()
        {
            _driver.Quit();
            _driver = BrowserFactory.InitializeDriver(_currentBrowser, ImplWait);
        }
    }
}