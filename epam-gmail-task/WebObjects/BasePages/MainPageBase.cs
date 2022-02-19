using epam_gmail_task.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace epam_gmail_task.PageObjects
{
    public class MainPageBase : BasePage
    {
        private static readonly By SignInLabel = By.XPath("//input[@aria-label]");
        public MainPageBase() : base(SignInLabel) { }

        protected MainPageBase(By titleLocator) : base(titleLocator) { }

        protected readonly BaseElement _searchInput =
            new BaseElement(By.XPath("//input[@aria-label='Поиск в почте']"));

        protected readonly BaseElement _writeDiv =
            new BaseElement(By.XPath("//div[@class='T-I T-I-KE L3']"));

        protected readonly BaseElement _manageAccountLink =
            new BaseElement(By.XPath("(//a[@role='button'])[last()]"));

        protected readonly BaseElement _signOutDiv =
            new BaseElement(By.XPath("//div[text()='Выйти']"));

        protected readonly BaseElement _lastMessageDiv =
            new BaseElement(By.XPath("(//div[@aria-checked='false'])[last()]"));

        protected readonly BaseElement _accountMailDiv =
            new BaseElement(By.XPath("//div[text()='gt016618@gmail.com']"));

        protected readonly BaseElement _draftLink =
            new BaseElement(By.XPath("//a[text()='Черновики']"));

        protected readonly BaseElement _accountFrame =
            new BaseElement(By.XPath("(//iframe[@role='presentation'])[2]"));

        protected readonly BaseElement _closeNewMessageImg =
            new BaseElement(By.XPath("//img[@alt='Закрыть']"));

        protected readonly BaseElement _sendMessageDiv =
            new BaseElement(By.XPath("//div[text()='Отправить']"));

        protected readonly BaseElement _sentMessagesLink =
            new BaseElement(By.XPath("//a[text()='Отправленные']"));

        protected readonly BaseElement _incomingMessagesLink =
            new BaseElement(By.XPath("//a[text()='Входящие']"));

        public void ClickWrite() => _writeDiv.Click();
        public void ManageAccountClick() => _manageAccountLink.Click();
        public void SelectLastMessage() => _lastMessageDiv.Click();
        public void ClickDraftLink() => _draftLink.Click();
        public void ClickSendMessage() => _sendMessageDiv.Click();
        public void NavigateToSentMessages() => _sentMessagesLink.Click();
        public void NavigateIncomingMessages() => _incomingMessagesLink.Click();
        public void CloseNewMessageWindow() => _closeNewMessageImg.Click();
        public string GetCurrentAccountMail()
        {
            SwitchToAccountFrame();
            var accoutMail = _accountMailDiv.GetText();
            Browser.GetDriver().SwitchTo().DefaultContent();
            return accoutMail;
        }
        public void SignOutClick()
        {
            SwitchToAccountFrame();
            _signOutDiv.Click();
        }
        private void SwitchToAccountFrame()
        {
            WebDriverWait _frameWait = new WebDriverWait(Browser.GetDriver(), Browser.TimeoutForElement);
            _frameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(_accountFrame.Locator));
        }
        public bool CheckSubjectExistsByText(string subject)
        {
            BaseElement _subjectSpan =
                new BaseElement(By.XPath($"(//span[text()='{subject}'])[2]"));
            return _subjectSpan.Displayed;
        }
        public string GetSubjectValueByText(string subject)
        {
            BaseElement _subjectSpan =
                new BaseElement(By.XPath($"(//span[text()='{subject}'])[2]"));
            return _subjectSpan.GetText();
        }
    }
}