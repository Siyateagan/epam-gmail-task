using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS02DraftExistTest : BaseTest
    {
        [TestMethod]
        public void TC02_Navigate_Draft_PageExist()
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
            DraftPage draftPage = new DraftPage();
            draftPage.ClickDraftLink();

            MailMessage mailMessage = new MailMessage(TestContext);
            Assert.AreEqual(mailMessage.subject, draftPage.GetSubjectValueByText(mailMessage.subject));

            draftPage.SelectLastMessage();
            draftPage.DeleteSelectedDrafts();

            Assert.IsFalse(draftPage.CheckSubjectExistsByText(mailMessage.subject));
        }
    }
}
