using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.Business.Queries.News.GetNewsIdByNotification
{
    internal sealed class GetNewsIdByNotificationQueryHandler : IRequestHandler<GetNewsIdByNotificationQuery, long>
    {
        private readonly IVmsInformRepository<UserNotificationNews> _notificationRepository;

        public GetNewsIdByNotificationQueryHandler(IVmsInformRepository<UserNotificationNews> notificationRepository)
        {
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        }

        public async Task<long> Handle(GetNewsIdByNotificationQuery request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.Query()
                .FirstOrDefaultAsync(a => a.Id == request.NotificationId, cancellationToken);

            if (notification == null)
                throw new NotFoundException("Notification not found");

            return notification.NewsId;
        }
    }
}
