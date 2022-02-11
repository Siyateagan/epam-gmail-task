using epam_gmail_task.WebDriver;

namespace epam_gmail_task.Resourses
{
    public class User
    {
        public readonly string email;
        public readonly string password;
        public User()
        {
            email = Configuration.Login;
            password = Configuration.Password;
        }
    }
}
