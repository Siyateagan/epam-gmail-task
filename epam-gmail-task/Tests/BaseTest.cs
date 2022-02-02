using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        protected void SignIn(string mail, string password)
        {
            AboutPage aboutPage = new AboutPage();
            aboutPage.GoToSignInPage();

            SignInPage signInPage = new SignInPage();
            signInPage.EnterEmail(mail);
            signInPage.ClickNext();

            signInPage.EnterPassword(password);
            signInPage.ClickNext();
        }

        protected void SignOut(MainPageBase mainPageBase)
        {
            mainPageBase.ManageAccountClick();
            mainPageBase.SignOutClick();
        }
    }
}
