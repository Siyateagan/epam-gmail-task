using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS02DraftExistTest : BaseTest
    {
        [DataTestMethod]
        [DataRow("gt016618@gmail.com", "mAPM6SWd")]
        public void TC04_Remove_Draft_NotExist(string mail, string password)
        {
            SignIn(mail, password);

            MainPage mainPage = new MainPage();
            mainPage.ClickDraftLink();
            DraftPage draftPage = new DraftPage();

            string subject = draftPage.GetMessageSubject();
            Assert.AreEqual("Test Subject", subject);

            draftPage.SelectMessage();
            draftPage.DeleteSelectedDrafts();
            Assert.IsTrue(draftPage.GetNoSavedDraftMessage().Contains("Нет сохраненных черновиков."));

            SignOut(mainPage);
        }
    }
}
