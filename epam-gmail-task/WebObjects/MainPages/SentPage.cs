using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class SentPage : MainPageBase
    {
        private static readonly By SentLabel = By.XPath("//a[text()='Отправленные' and @tabindex='0']");

        public SentPage() : base(SentLabel) { }
    }
}
