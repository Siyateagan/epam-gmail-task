using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Entities
{
    public class User
    {
        public readonly string email;
        public readonly string password;

        public User(TestContext testContext)
        {
            email = testContext.DataRow["login"].ToString();
            password = testContext.DataRow["password"].ToString();
        }
    }
}
