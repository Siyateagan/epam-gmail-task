using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS02DraftExistTest : BaseTest
    {
        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\UserData.csv", "UserData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public override void TC00_TestPreparation() //TODO preparement
        {
            base.TC00_TestPreparation();
            MainPage mainPage = new MainPage();
            mainPage.ClickDraftLink();
        }

        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\MailMessageData.csv", "MailMessageData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC03_Remove_Draft_NotExist()
        {
            DraftPage draftPage = new DraftPage();
            draftPage.ClickDraftLink();

            // TODO Move to another layer?
            string receiver = TestContext.DataRow["receiver"].ToString();
            string subject = TestContext.DataRow["subject"].ToString();
            string message = TestContext.DataRow["message"].ToString();
            MailMessage mailMessage = new MailMessage(receiver, subject, message);
            Assert.AreEqual(mailMessage.subject, draftPage.GetSubjectValueByText(mailMessage.subject));

            draftPage.SelectLastMessage();
            draftPage.DeleteSelectedDrafts();

            Assert.IsFalse(draftPage.CheckSubjectExistsByText(mailMessage.subject));
        }
    }
}
