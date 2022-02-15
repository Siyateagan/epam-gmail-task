using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using OpenQA.Selenium;

namespace epam_gmail_task.WebObjects
{
    public class SubjectPage : BasePage
    {
        private static readonly By SubjectLabel = By.Id("blog-ideas-output");
        private readonly BaseElement _subjectLabel = new BaseElement(By.XPath("//div[@id='blog-ideas-output']"));

        public SubjectPage() : base(SubjectLabel) { }

        public string GetSubject() => _subjectLabel.GetText();
    }
}
