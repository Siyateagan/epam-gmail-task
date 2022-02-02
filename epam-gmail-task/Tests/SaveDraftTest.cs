using epam_gmail_task.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public class SaveDraftTest : BaseTest
    {
        [TestMethod]
        public void TC01_Navigate_ToSignInPage_PageExist()
        {
            AboutPage aboutPage = new AboutPage();
            aboutPage.GoToSignInPage();
        }

        [TestMethod]
        public void TC02_Check_CurrentAccount_Matches()
        {
            SignIn();
            MainPage mainPage = new MainPage();
            mainPage.ManageAccountClick();
            Assert.AreEqual(mainPage.GetCurrentAccountMail(), "gt016618@gmail.com");
        }

        [TestMethod]
        public void TC03_Check_MailMessage_Saved()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickWrite();
            // TODO: Add to data.
            mainPage.EnterMessageData("siyateagan@gmail.com", "Test Subject", "Test Message");
            mainPage.WaitForDraftSave();
            Assert.AreEqual(mainPage.GetDraftStatus(), "Черновик сохранен");

            mainPage.ManageAccountClick();
            mainPage.SignOutClick();

        }
    }
}
