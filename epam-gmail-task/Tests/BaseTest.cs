using epam_gmail_task.Entities;
using epam_gmail_task.PageObjects;
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

        [DeploymentItem(@"Resourses")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\UserData.csv", "UserData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public virtual void TC00_TestPreparation()
        {
            User currentUser = new User(TestContext);

            AboutPage aboutPage = new AboutPage();
            aboutPage.GoToSignInPage();

            SignInPage signInPage = new SignInPage();
            signInPage.EnterEmail(currentUser.email);
            signInPage.ClickNext();

            signInPage.EnterPassword(currentUser.password);
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
