using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using epam_gmail_task.Resourses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace epam_gmail_task.Tests
{
    [DeploymentItem(@"Resourses")]
    [TestClass]
    public class TS01SaveDraftTest : BaseTest
    {
        [TestMethod]
        public void TC01_Check_CurrentAccount_Matches()
        {
            // arrange
            User user = new User();
            string expectedMail = user.email + "@gmail.com";
            SignIn();
            MainPage mainPage = new MainPage();

            // act
            mainPage.ManageAccountClick();

            // assert
            Assert.AreEqual(mainPage.GetCurrentAccountMail(), expectedMail);
        }

        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\MailMessageData.csv", "MailMessageData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC02_Check_MailMessage_Saved()
        {
            // arrange
            MailMessage mailMessage = new MailMessage(TestContext);
            MainPage mainPage = new MainPage();
            string draftCounter = 
                Convert.ToString(TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow) + 1);

            // act
            mainPage.ClickWrite();
            mainPage.EnterMessageData(mailMessage);
            mainPage.WaitForDraftSave();
            mainPage.CloseNewMessageWindow();

            // assert
            Assert.AreEqual(mainPage.GetDraftCount(), draftCounter);
        }
    }
}
