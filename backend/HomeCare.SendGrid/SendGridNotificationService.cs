using HomeCare.Domain.Aggregates.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HomeCare.Adapters.SendGrid
{
    public class SendGridNotificationService : INotificationSender
    {
        private readonly SendGridClient _sendGridClient;

        public SendGridNotificationService(SendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendAsync(User from, User to, string subject, string text)
        {
            var emailFrom = new EmailAddress(from.Email, $"{from.Name} via HomeCare");
            var emailTo = new EmailAddress(to.Email, to.Name);
            var msg = MailHelper.CreateSingleEmail(emailFrom, emailTo, subject, text, text);

            await _sendGridClient.SendEmailAsync(msg);
        }

        public async Task SendAsync(User to, string subject, string text)
        {
            var from = new Admin
            {
                Email = "phduarte87@outlook.com",
                Name = "HomeCare"
            };

            await SendAsync(from, to, subject, text);
        }
    }

    class Admin : User
    {

    }
}