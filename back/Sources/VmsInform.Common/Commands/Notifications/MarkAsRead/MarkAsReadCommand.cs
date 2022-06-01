using MediatR;

namespace VmsInform.Common.Commands.Notifications.MarkAsRead
{
    public class MarkAsReadCommand : IRequest
    {
        public long NotificationId { get; set; }
    }
}
