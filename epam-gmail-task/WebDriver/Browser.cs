using epam_gmail_task.WebObjects;
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
        public static TimeSpan TimeoutForElement;

        private Browser()
        {
            InitParams();
            Enum.TryParse(Configuration.Browser, out _currentBrowser);
        }
        public static void StartDriver() =>
            _driver = DriverFactory.InitializeDriver(_currentBrowser, ImplWait);
        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            TimeoutForElement = TimeSpan.FromSeconds(Convert.ToDouble(Configuration.ElementTimeout));
        }

        public static Browser Instance => _currentInstance ??= new Browser();
        public static void WindowMaximise() => _driver.Manage().Window.Maximize();
        public static void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);
        public static IWebDriver GetDriver() => _driver;
        public static void Quit() => _driver.Quit();
        public static void OpenNewTab(string url)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");
            var newHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(newHandles[1]);
            _driver.Navigate().GoToUrl(url);
        }
        public static string GetRandomSubject()
        {
            string currentHandle = _driver.CurrentWindowHandle;
            OpenNewTab("https://capitalizemytitle.com/random-topic-generator/");
            SubjectPage subjectPage = new SubjectPage();
            string subject = subjectPage.GetSubject();
            _driver.SwitchTo().Window(currentHandle);
            return subject;
        }
    }
}