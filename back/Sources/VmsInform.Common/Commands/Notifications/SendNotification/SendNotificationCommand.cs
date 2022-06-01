using MediatR;

namespace VmsInform.Common.Commands.Notifications.SendNotification
{
    public enum NotificationType
    {
        News
    }

    public class SendNotificationCommand : IRequest
    {
        public string Subject { get; set; }
        public NotificationType NotificationType { get; set; }
        public long? PayloadId { get; set; }
        public bool IsImportant { get; set; }
    }
}
