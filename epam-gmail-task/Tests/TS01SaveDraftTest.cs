using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS01SaveDraftTest : BaseTest
    {

        [TestMethod]
        public void TC01_Check_CurrentAccount_Matches()
        {
            SignIn();
            MainPage mainPage = new MainPage();
            mainPage.ManageAccountClick();
            string expectedMail = Configuration.Login + "@gmail.com";
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
            Browser.RestartSession();
        }
    }
}
