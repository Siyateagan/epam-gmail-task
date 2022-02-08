using epam_gmail_task.PageObjects;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: ClassCleanupExecution(ClassCleanupBehavior.EndOfClass)]
namespace epam_gmail_task.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void TestFixtureSetup(TestContext context)
        {
            Browser browser = Browser.Instance;
            Browser.StartDriver();
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
            AboutPage aboutPage = new AboutPage();
            aboutPage.GoToSignInPage();

            SignInPage signInPage = new SignInPage();
            signInPage.EnterEmail(Configuration.Login);
            signInPage.ClickNext();

            signInPage.EnterPassword(Configuration.Password);
            signInPage.ClickNext();
        }

        protected void SignOut(MainPageBase mainPageBase)
        {
            mainPageBase.ManageAccountClick();
            mainPageBase.SignOutClick();
        }
    }
}
