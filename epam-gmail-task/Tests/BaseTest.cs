using epam_gmail_task.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Tests
{
    public class BaseTest
    {
        [TestInitialize]
        public virtual void InitTest()
        {
            Browser Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
