using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [DeploymentItem(@"Resourses")]
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

        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\MailMessageData.csv", "MailMessageData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC02_Check_MailMessage_Saved()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickWrite();

            MailMessage mailMessage = new MailMessage(TestContext);
            mainPage.EnterMessageData(mailMessage);
            mainPage.WaitForDraftSave();

            Assert.AreEqual(mainPage.GetDraftStatus(), "Черновик сохранен");
            mainPage.CloseNewMessageWindow();
        }
    }
}
