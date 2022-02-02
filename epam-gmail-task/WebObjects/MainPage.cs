using epam_gmail_task.WebDriver;
using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class MainPage : BasePage
    {
        public MainPage() : base(SignInLabel) { }

        private static readonly By SignInLabel = By.XPath("//div[text()='Несортированные']");

        private readonly BaseElement _writeDiv =
            new BaseElement(By.XPath("//div[@class='T-I T-I-KE L3']"));

        private readonly BaseElement _receiverTextArea =
            new BaseElement(By.XPath("//textarea[@aria-label='Кому']"));

        private readonly BaseElement _subjectTextArea =
            new BaseElement(By.XPath("//input[@name='subjectbox']"));

        private readonly BaseElement _textOfTheLetterDiv =
            new BaseElement(By.XPath("//div[@aria-label='Текст письма']"));

        private readonly BaseElement _draftSavedSpan =
            new BaseElement(By.XPath("//span[text()='Черновик сохранен']"));

        private readonly BaseElement _manageAccountLink =
            new BaseElement(By.XPath("(//a[@role='button'])[last()]"));

        private readonly BaseElement _signOutLink =
            new BaseElement(By.XPath("//a[text()='Выйти']"));

        private readonly BaseElement _accountMailDiv =
            new BaseElement(By.XPath("//div[@class='gb_mb']"));

        public void ClickWrite() => _writeDiv.Click();
        public void EnterMessageData(string receiver, string subject, string textOfTheLetter)
        {
             _receiverTextArea.SendKeys(receiver);
             _subjectTextArea.SendKeys(subject);
             _textOfTheLetterDiv.SendKeys(textOfTheLetter);
        }

        public string[] GetMessageData(string receiver, string subject, string textOfTheLetter)
        {
            string[] messageData = { _receiverTextArea.GetText(),
                _subjectTextArea.GetText(),
                _textOfTheLetterDiv.GetText()};

            return messageData;
        }

        public void WaitForDraftSave() => _draftSavedSpan.WaitForIsVisible();
        public string GetDraftStatus() => _draftSavedSpan.GetText();
        public void ManageAccountClick() => _manageAccountLink.Click();
        public void SignOutClick() => _signOutLink.Click();
        public string GetCurrentAccountMail() => _accountMailDiv.GetText();
    }
}
