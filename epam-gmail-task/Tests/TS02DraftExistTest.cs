using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS02DraftExistTest : BaseTest
    {
        [TestMethod]
        public void TC03_Remove_Draft_NotExist()
        {
            SignIn();

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
