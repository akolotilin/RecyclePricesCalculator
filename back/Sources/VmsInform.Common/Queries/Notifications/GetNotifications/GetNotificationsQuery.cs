using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Notifications;

namespace VmsInform.Common.Queries.Notifications.GetNotifications
{
    public class GetNotificationsQuery : IRequest<IEnumerable<UserNotificationDto>>
    {
    }
}
