using epam_gmail_task.WebDriver;
using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class AboutPage : BasePage
    {
        private static readonly By AboutLabel = 
            By.XPath("//div[@class='feature__chapter__title feature__chapter__title--long']");

        private readonly BaseElement _signInLink = new BaseElement(By.XPath("//a[text()='Войти']"));
        public AboutPage() : base(AboutLabel) { }

        public SignInPage GoToSignInPage()
        {
            _signInLink.Click();
            return new SignInPage();
        }
    }
}
