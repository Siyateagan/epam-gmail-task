using epam_gmail_task.WebDriver;
using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class SignInPage : BasePage
    {
        public SignInPage() : base(SignInLabel) { }

        private static readonly By SignInLabel =
            By.XPath("//span[text()='Перейти в Gmail']");

        private readonly BaseElement _emailInput = 
            new BaseElement(By.XPath("//input[@type='email']"));

        private readonly BaseElement _NextButton =
            new BaseElement(By.XPath("//button[@type='button' and @jsname='LgbsSe']"));

        public void EnterEmail(string email) => _emailInput.SendKeys(email);
    }
}
