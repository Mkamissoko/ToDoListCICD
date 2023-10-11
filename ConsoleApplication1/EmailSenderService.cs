using System;

namespace ConsoleApplication1
{
    public class EmailSenderService
    {
        public bool sendEmail(User user, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
    
    public interface IEmailSenderService
    {
        bool sendEmail(User user, string subject, string content);
    }
}