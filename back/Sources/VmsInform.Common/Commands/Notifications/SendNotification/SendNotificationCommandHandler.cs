using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.Common.Commands.Notifications.SendNotification
{
    internal sealed class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly IVmsInformRepository<User> _usersRepository;
        private readonly IVmsInformRepository<UserNotification> _userNotificationsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IDateTimeService _dateTimeService;

        public SendNotificationCommandHandler(IVmsInformRepository<User> usersRepository, IVmsInformRepository<UserNotification> userNotificationsRepository,
            IUnitOfWork unitOfWork, IUserService userService, IDateTimeService dateTimeService)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _userNotificationsRepository = userNotificationsRepository ?? throw new ArgumentNullException(nameof(userNotificationsRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public async Task<Unit> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.Query()
                .Where(a => a.IsActive)// && a.Id != _userService.CurrentUser.Id)
                .ToListAsync(cancellationToken);

            foreach(var user in users)
            {
                var notification = GetNotification(request.NotificationType, request.PayloadId.Value);
                notification.IsRead = false;
                notification.Subject = request.Subject;
                notification.DateTime = _dateTimeService.Now;
                notification.IsImportant = request.IsImportant;
                notification.UserId = user.Id;

                await _userNotificationsRepository.AddAsync(notification, cancellationToken);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }

        private UserNotification GetNotification(NotificationType notificationType, long payloadId)
        {
            switch(notificationType)
            {
                case NotificationType.News:
                    return new UserNotificationNews { NewsId = payloadId };
                default:
                    throw new InvalidOperationException("Invalid notification type");
            }
        }
    }
}
