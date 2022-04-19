using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HomeCare.SendGrid
{
    public class SendGridNotificationFacade : IPaymentNotificationFacade, IContractFinishedNotificationFacade
    {
        private readonly SendGridClient _sendGridClient;
        private EmailAddress from => new EmailAddress("phduarte87@outlook.com", "Plataforma");

        public SendGridNotificationFacade(SendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public void Notify(Payment payment)
        {
            var client = payment.Contract.Client;
            var to = new EmailAddress(client.Email, client.Name);
            var plainTextContent = "O prestador informou que o serviço já foi concluído. Agora é hora de liberar o dinheiro.";
            var htmlContent = "O prestador informou que o serviço já foi concluído. Clique aqui para liberar o dinheiro.";
            var msg = MailHelper.CreateSingleEmail(from, to, "Serviço concluído", plainTextContent, htmlContent);
            _sendGridClient.SendEmailAsync(msg);
        }

        public void Notify(Contract contract)
        {
            var to = new EmailAddress(contract.Supplier.Email, contract.Supplier.Name);
            var plainTextContent = "Um cliente acabou de te contratar! Fique atento que em breve ele entrará em contato com você para combinar o serviço.";
            var htmlContent = "Um cliente acabou de te contratar! Fique atento que em breve ele entrará em contato com você para combinar o serviço.";
            var msg = MailHelper.CreateSingleEmail(from, to, "Você foi contratado", plainTextContent, htmlContent);
            _sendGridClient.SendEmailAsync(msg);
        }
    }
}
