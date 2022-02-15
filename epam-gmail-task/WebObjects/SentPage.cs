using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class SentPage : MainPageBase
    {
        private readonly string pageInput = "in:sent ";
        private static readonly By SentLabel = By.XPath("//input[@aria-label='Поиск в почте']");//Remove

        public SentPage() : base(SentLabel)
        {
            WaitPageIsOpen(pageInput);
        } 
    }
}
