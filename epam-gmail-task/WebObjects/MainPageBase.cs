using epam_gmail_task.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace epam_gmail_task.PageObjects
{
    public abstract class MainPageBase : BasePage
    {
        private WebDriverWait _frameWait = 
            new WebDriverWait(Browser.GetDriver(), Browser.TimeoutForElement);

        protected MainPageBase(By titleLocator) : base(titleLocator) { }

        protected readonly BaseElement _writeDiv =
            new BaseElement(By.XPath("//div[@class='T-I T-I-KE L3']"));

        protected readonly BaseElement _manageAccountLink =
            new BaseElement(By.XPath("(//a[@role='button'])[last()]"));

        protected readonly BaseElement _signOutDiv =
            new BaseElement(By.XPath("//div[text()='Выйти']"));

        protected readonly BaseElement _selectMessageDiv =
            new BaseElement(By.XPath("//div[@aria-checked='false']"));

        protected readonly BaseElement _accountMailDiv =
            new BaseElement(By.XPath("//div[text()='gt016618@gmail.com']"));

        protected readonly BaseElement _draftLink =
            new BaseElement(By.XPath("//a[text()='Черновики']"));

        protected readonly BaseElement _accountFrame =
            new BaseElement(By.XPath("(//iframe[@role='presentation'])[2]"));

        public void ClickWrite() => _writeDiv.Click();
        public void ManageAccountClick() => _manageAccountLink.Click();
        public void SelectMessage() => _selectMessageDiv.Click();
        public void ClickDraftLink() => _draftLink.Click();
        public string GetCurrentAccountMail()
        {
            _frameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(_accountFrame.Locator));
            var accoutMail = _accountMailDiv.GetText();
            Browser.GetDriver().SwitchTo().DefaultContent();
            return accoutMail;
        }
        public void SignOutClick()
        {
            _frameWait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(_accountFrame.Locator));
            _signOutDiv.Click();
        }
    }
}
