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

        private readonly BaseElement _passwordInput =
            new BaseElement(By.XPath("//input[@type='password']"));

        private readonly BaseElement _nextButton =
            new BaseElement(By.XPath("//span[text()='Далее']"));

        public void EnterEmail(string email) => _emailInput.SendKeys(email);
        public void EnterPassword(string password) => _passwordInput.SendKeys(password);
        public void ClickNext() => _nextButton.Click();
    }
}
