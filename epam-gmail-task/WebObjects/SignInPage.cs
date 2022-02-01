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

        private readonly BaseElement _nextButton =
            new BaseElement(By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ" +
                " VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b']"));

        public void EnterEmail(string email) => _emailInput.SendKeys(email);
    }
}
