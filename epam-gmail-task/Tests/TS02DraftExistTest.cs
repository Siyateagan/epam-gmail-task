using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS02DraftExistTest : BaseTest
    {
        [ClassInitialize]
        public static void StartUp(TestContext context)
        {
            SignIn();
            MainPage mainPage = new MainPage();
            mainPage.ClickDraftLink();
        }

        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\MailMessageData.csv", "MailMessageData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC03_Remove_Draft_NotExist()
        {
            // arrange
            DraftPage draftPage = new DraftPage();
            MailMessage mailMessage = new MailMessage(TestContext);

            // act
            draftPage.ClickDraftLink();

            // assert
            Assert.AreEqual(mailMessage.subject, draftPage.GetSubjectValueByText(mailMessage.subject));  
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            DraftPage draftPage = new DraftPage();
            draftPage.SelectAllMessages();
            draftPage.DeleteSelectedDrafts();
        }
    }
}
