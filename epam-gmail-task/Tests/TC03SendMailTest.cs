using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TC03SendMailTest : BaseTest
    {
        private static MailMessage mailMessage;

        [ClassInitialize]
        public static void StartUp(TestContext context)
        {
            string receiver = Configuration.Login + "@gmail.com";
            string subject = Browser.GetRandomSubject();
            mailMessage = new MailMessage(receiver: receiver, subject: subject);
            SignIn();
        }

        [TestMethod]
        public void TM04_Check_Message_Sent()
        {
            // arrange
            MainPage mainPage = new MainPage();
            SentPage sentPage;

            // act
            mainPage.ClickWrite();
            mainPage.EnterMessageData(mailMessage);
            mainPage.ClickSendMessage();
            sentPage = mainPage.NavigateToSentMessages();

            // assert
            Assert.IsTrue(sentPage.CheckSubjectExistsByText(mailMessage.subject));
        }

        [TestMethod]
        public void TM05_Check_Message_Received()
        {
            // arrange
            MainPage mainPage;
            SentPage sentPage = new SentPage();

            // act
            mainPage = sentPage.NavigateIncomingMessages();

            // assert
            Assert.IsTrue(mainPage.CheckSubjectExistsByText(mailMessage.subject));
        }
    }
}
