using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
using epam_gmail_task.Resourses;
using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: ClassCleanupExecution(ClassCleanupBehavior.EndOfClass)]
namespace epam_gmail_task.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void TestFixtureSetup(TestContext context)
        {
            Browser browser = Browser.Instance;
            Browser.StartDriver();
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        protected virtual void SignIn()
        {
            User user = new User();
            AboutPage aboutPage = new AboutPage();
            aboutPage.GoToSignInPage();

            SignInPage signInPage = new SignInPage();
            signInPage.EnterEmail(user.email);
            signInPage.ClickNext();

            signInPage.EnterPassword(user.password);
            signInPage.ClickNext();
        }

        [ClassCleanup(InheritanceBehavior.BeforeEachDerivedClass)]
        public static void TestFixtureTearDown()
        {
            MainPageBase basePage = new MainPageBase();
            SignOut(basePage);
            Browser.Quit();
        }

        protected static void SignOut(MainPageBase mainPageBase)
        {
            mainPageBase.ManageAccountClick();
            mainPageBase.SignOutClick();
        }
    }
}
