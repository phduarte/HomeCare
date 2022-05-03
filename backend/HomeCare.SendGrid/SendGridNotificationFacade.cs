using HomeCare.Domain;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HomeCare.SendGrid
{
    public class SendGridNotificationFacade : INotificationFacade
    {
        private readonly SendGridClient _sendGridClient;

        public SendGridNotificationFacade(SendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendEmailAsync(User from, User to, string subject, string text)
        {
            var emailFrom = new EmailAddress(from.Email, $"{from.Name} via HomeCare");
            var emailTo = new EmailAddress(to.Email, to.Name);
            var msg = MailHelper.CreateSingleEmail(emailFrom, emailTo, subject, text, text);

            await _sendGridClient.SendEmailAsync(msg);
        }

        public async Task SendEmailAsync(User to, string subject, string text)
        {
            var from = new Admin
            {
                Email = "phduarte87@outlook.com",
                Name = "HomeCare"
            };

            await SendEmailAsync(from, to, subject, text);
        }
    }

    class Admin : User
    {

    }
}