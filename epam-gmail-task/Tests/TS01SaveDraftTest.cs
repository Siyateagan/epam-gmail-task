using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [DeploymentItem(@"Resourses")]
    [TestClass]
    public class TS01SaveDraftTest : BaseTest
    {
        //TODO: Check multiple users
        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\UserData.csv", "UserData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC01_Check_CurrentAccount_Matches()
        {
            User currentUser = GetUser();
            MainPage mainPage = new MainPage();
            mainPage.ManageAccountClick();

            string expectedMail = currentUser.email + "@gmail.com";
            Assert.AreEqual(mainPage.GetCurrentAccountMail(), expectedMail);
        }

        [TestMethod]
        public void TC02_Check_MailMessage_Saved()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickWrite();

            mainPage.EnterMessageData("siyateagan@gmail.com", "Test Subject", "Test Message");
            mainPage.WaitForDraftSave();
            Assert.AreEqual(mainPage.GetDraftStatus(), "Черновик сохранен");
            mainPage.CloseNewMessageWindow();

            SignOut(mainPage);
        }
    }
}
