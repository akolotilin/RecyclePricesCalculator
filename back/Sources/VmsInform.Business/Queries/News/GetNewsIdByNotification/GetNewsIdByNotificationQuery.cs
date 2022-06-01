using MediatR;

namespace VmsInform.Business.Queries.News.GetNewsIdByNotification
{
    public class GetNewsIdByNotificationQuery : IRequest<long>
    {
        public long NotificationId { get; set; }
    }
}
