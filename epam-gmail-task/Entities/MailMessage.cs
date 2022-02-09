namespace epam_gmail_task.Entities
{
    public class MailMessage
    {
        public readonly string receiver;
        public readonly string subject;
        public readonly string message;

        public MailMessage(string receiver, string subject, string message)
        {
            this.receiver = receiver;
            this.subject = subject;
            this.message = message;
        }
    }
}
