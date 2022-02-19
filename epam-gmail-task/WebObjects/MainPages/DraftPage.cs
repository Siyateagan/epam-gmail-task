using OpenQA.Selenium;

namespace epam_gmail_task.PageObjects
{
    public class DraftPage : MainPageBase
    {
        public DraftPage() : base(DraftLabel) { }

        private static readonly By DraftLabel =
            By.XPath("//a[text()='Черновики' and @tabindex='0']");

        private readonly BaseElement _mailMessageSpan =
            new BaseElement(By.XPath("(//td//span[text()='Test Subject'])[2]"));

        private readonly BaseElement _deleteSelectedDraftsDiv =
            new BaseElement(By.XPath("(//div[text()='Удалить черновики'])[1]"));

        private readonly BaseElement _noSavedDraftMessage =
            new BaseElement(By.XPath("//td[contains(text(), 'Нет сохраненных черновиков.')]"));

        public string GetMessageSubject() => _mailMessageSpan.GetText();
        public void DeleteSelectedDrafts() => _deleteSelectedDraftsDiv.Click();
        public string GetNoSavedDraftMessage() => _noSavedDraftMessage.GetText();
    }
}
