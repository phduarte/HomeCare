namespace HomeCare.Domain.Aggregates.Shared
{
    public interface INotificationSender : IAntiCorruptionLayer
    {
        Task SendAsync(User from, User to, string subject, string text);
        Task SendAsync(User to, string subject, string text);
    }
}
