using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS02DraftExistTest : BaseTest
    {
        [TestMethod]
        public void TC04_Remove_Draft_NotExist()
        {
            SignIn();

            MainPage mainPage = new MainPage();
            mainPage.ClickDraftLink();
            string subject = mainPage.GetMessageSubject();
            Assert.AreEqual("Test Subject", subject);

            mainPage.SelectMessage();
            mainPage.DeleteSelectedDrafts();
            Assert.IsTrue(mainPage.GetNoSavedDraftMessage().Contains("Нет сохраненных черновиков."));

            mainPage.ManageAccountClick();
            mainPage.SignOutClick();
        }
    }
}
