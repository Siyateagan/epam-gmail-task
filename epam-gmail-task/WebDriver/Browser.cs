using OpenQA.Selenium;
using System;

namespace epam_gmail_task.WebDriver
{
    public class Browser
    {
        private static Browser _currentInstance = null!;
        private static IWebDriver _driver = null!;
        public static BrowserFactory.BrowserType _currentBrowser;
        public static int ImplWait;
        public static double _timeoutForElement;
        private static string _browserName = string.Empty;

        private Browser()
        {
            InitParams();
            _driver = BrowserFactory.GetDriver(_currentBrowser, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            _timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            _browserName = Configuration.Browser;
        }

        public static Browser Instance => _currentInstance ??= new Browser();

        public static void WindowMaximise() => _driver.Manage().Window.Maximize();

        public static void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);

        public static IWebDriver GetDriver() => _driver;

        public static void Quit() => _driver.Quit();

        public static void RestartSession()
        {
            _driver.Quit();
            _driver = BrowserFactory.GetDriver(_currentBrowser, ImplWait);
        }
    }
}