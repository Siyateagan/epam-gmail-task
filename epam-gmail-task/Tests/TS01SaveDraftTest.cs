using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS01SaveDraftTest : BaseTest
    {

        [DataTestMethod]
        [DataRow("gt016618@gmail.com", "mAPM6SWd")]
        public void TC01_Check_CurrentAccount_Matches(string mail, string password)
        {
            SignIn(mail, password);
            MainPage mainPage = new MainPage();
            mainPage.ManageAccountClick();
            Assert.AreEqual(mainPage.GetCurrentAccountMail(), mail);
        }

        [TestMethod]
        public void TC02_Check_MailMessage_Saved()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickWrite();

            mainPage.EnterMessageData("siyateagan@gmail.com", "Test Subject", "Test Message");
            mainPage.WaitForDraftSave();
            Assert.AreEqual(mainPage.GetDraftStatus(), "Черновик сохранен");

            SignOut(mainPage);
            Browser.RestartSession();
        }
    }
}
