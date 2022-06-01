using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Extensions;
using VmsInform.DAL;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.Common.Commands.Notifications.MarkAsRead
{
    internal sealed class MarkAsReadCommandHandler : IRequestHandler<MarkAsReadCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<UserNotification> _notificationRepository;
        public MarkAsReadCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<UserNotification> notificationRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        }

        public async Task<Unit> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.Query().FirstOrDefaultAsync(a=>a.Id == request.NotificationId, cancellationToken);

            this.ThrowNotFoundIfNull(notification, "Уведомление не найдено");

            notification.IsRead = true;
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
