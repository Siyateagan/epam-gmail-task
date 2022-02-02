using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace epam_gmail_task.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void TestFixtureSetup(TestContext context)
        {
            Browser Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void TestFixtureTearDown()
        {
            Browser.Quit();
        }

        protected void SignIn()
        {
            SignInPage signInPage = new SignInPage();
            signInPage.EnterEmail("gt016618@gmail.com");
            signInPage.ClickNext();

            signInPage.EnterPassword("mAPM6SWd");
            signInPage.ClickNext();
        }
    }
}
