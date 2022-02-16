using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using epam_gmail_task.WebObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Threading;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class TS03SendMailTest : BaseTest
    {
        MailMessage mailMessage;

        [TestInitialize]
        public void TestInitialize()
        {
            string receiver = Configuration.Login + "@gmail.com";
            string subject = Browser.GetRandomSubject();
            mailMessage = new MailMessage(receiver: receiver, subject: subject);
        }

        [TestMethod]
        public void TC05_Check_Message_Sent()
        {
            SignIn();
            MainPage mainPage = new MainPage();
            mainPage.ClickWrite();

            mainPage.EnterMessageData(mailMessage);
            mainPage.ClickSendMessage();

            mainPage.NavigateToSentMessages();
            SentPage sentPage = new SentPage();
            Assert.IsTrue(sentPage.CheckSubjectExistsByText(mailMessage.subject));

            sentPage.NavigateIncomingMessages();
            Assert.IsTrue(mainPage.CheckSubjectExistsByText(mailMessage.subject));
        }
    }
}
