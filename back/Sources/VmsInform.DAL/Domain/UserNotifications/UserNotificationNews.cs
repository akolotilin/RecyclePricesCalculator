namespace VmsInform.DAL.Domain.UserNotifications
{
    public class UserNotificationNews : UserNotification
    {
        public long NewsId { get; set; }
        public virtual NewsEntry News { get; set; }
    }
}
