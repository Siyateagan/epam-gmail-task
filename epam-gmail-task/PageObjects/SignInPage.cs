using epam_gmail_task.WebDriver;
using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class SignInPage : BasePage
    {
        private static readonly By SignInLabel = 
            By.XPath("//span[text()='Перейти в Gmail']");

        public SignInPage() : base(SignInLabel) { }
    }
}
