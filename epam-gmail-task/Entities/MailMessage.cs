using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace epam_gmail_task.Entities
{
    public class MailMessage
    {
        public readonly string receiver;
        public readonly string subject;
        public readonly string message;

        public MailMessage(TestContext testContext)
        {
            receiver = testContext.DataRow["receiver"].ToString();
            subject = testContext.DataRow["subject"].ToString();
            message = testContext.DataRow["message"].ToString();
        }
    }
}