using epam_gmail_task.WebDriver;
using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public abstract class MainPageBase : BasePage
    {
        protected MainPageBase(By titleLocator) : base(titleLocator) { }

        protected readonly BaseElement _writeDiv =
            new BaseElement(By.XPath("//div[@class='T-I T-I-KE L3']"));

        protected readonly BaseElement _manageAccountLink =
            new BaseElement(By.XPath("(//a[@role='button'])[last()]"));

        protected readonly BaseElement _signOutLink =
            new BaseElement(By.XPath("//a[text()='Выйти']"));

        protected readonly BaseElement _selectMessageDiv =
            new BaseElement(By.XPath("//div[@aria-checked='false']"));

        protected readonly BaseElement _accountMailDiv =
            new BaseElement(By.XPath("//div[@class='gb_mb']"));

        protected readonly BaseElement _draftLink =
            new BaseElement(By.XPath("//a[text()='Черновики']"));

        public void ClickWrite() => _writeDiv.Click();
        public void ManageAccountClick() => _manageAccountLink.Click();
        public void SignOutClick() => _signOutLink.Click();
        public void SelectMessage() => _selectMessageDiv.Click();
        public void ClickDraftLink() => _draftLink.Click();
        public string GetCurrentAccountMail() => _accountMailDiv.GetText();
    }
}
