namespace HomeCare.Domain
{
    public interface INotificationFacade
    {
        Task SendEmailAsync(User from, User to, string subject, string text);
        Task SendEmailAsync(User to, string subject, string text);
    }
}
