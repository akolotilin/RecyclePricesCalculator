using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Extensions;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.Common.Queries.Notifications.GetNotificationsCount
{
    internal sealed class GetNotificationsCountQueryHandler : IRequestHandler<GetNotificationsCountQuery, int>
    {
        private readonly IVmsInformRepository<UserNotification> _notificationsRepository;
        private readonly IUserService _userService;

        public GetNotificationsCountQueryHandler(IVmsInformRepository<UserNotification> notificationsRepository, IUserService userService)
        {
            _notificationsRepository = notificationsRepository ?? throw new ArgumentNullException(nameof(notificationsRepository));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<int> Handle(GetNotificationsCountQuery request, CancellationToken cancellationToken)
        {
            return await _notificationsRepository.GetNotifications(_userService.CurrentUser.Id)
                .CountAsync(cancellationToken);
        }
    }
}
