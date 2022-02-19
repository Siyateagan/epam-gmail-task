using epam_gmail_task.Entities;
using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class MainPage : MainPageBase
    {
        public MainPage() : base(SignInLabel) { }

        private static readonly By SignInLabel = By.XPath("//div[text()='Несортированные']");

        private readonly BaseElement _receiverTextArea =
            new BaseElement(By.XPath("//textarea[@aria-label='Кому']"));

        private readonly BaseElement _subjectTextArea =
            new BaseElement(By.XPath("//input[@name='subjectbox']"));

        private readonly BaseElement _textOfTheLetterDiv =
            new BaseElement(By.XPath("//div[@aria-label='Текст письма']"));

        private readonly BaseElement _draftSavedSpan =
            new BaseElement(By.XPath("//span[text()='Черновик сохранен']"));

        public void EnterMessageData(MailMessage mailMessage)
        {
             _receiverTextArea.SendKeys(mailMessage.receiver);
             _subjectTextArea.SendKeys(mailMessage.subject);
             _textOfTheLetterDiv.SendKeys(mailMessage.message);
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
    }
}
