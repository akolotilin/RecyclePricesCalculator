using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Extensions;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain.UserNotifications;
using VmsInform.Web.Dto.Notifications;

namespace VmsInform.Common.Queries.Notifications.GetNotifications
{
    internal sealed class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, IEnumerable<UserNotificationDto>>
    {
        private readonly IVmsInformRepository<UserNotification> _notificationsRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetNotificationsQueryHandler(IVmsInformRepository<UserNotification> notificationsRepository, IMapper mapper, IUserService userService)
        {
            _notificationsRepository = notificationsRepository ?? throw new ArgumentNullException(nameof(notificationsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<IEnumerable<UserNotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<UserNotificationDto>(
                _notificationsRepository.GetNotifications(_userService.CurrentUser.Id))
                .OrderByDescending(a => a.DateTime)
                .ToListAsync(cancellationToken);
        }
    }
}
