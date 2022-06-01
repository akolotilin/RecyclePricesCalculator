using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Commands.Notifications.MarkAsRead;
using VmsInform.Common.Queries.Notifications.GetNotifications;
using VmsInform.Common.Queries.Notifications.GetNotificationsCount;
using VmsInform.Web.Dto.Notifications;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("count")]
        public async Task<int> GetNotificationsCount(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetNotificationsCountQuery(), cancellationToken);
        }

        [HttpGet]
        public async Task<IEnumerable<UserNotificationDto>> GetNotifications(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetNotificationsQuery(), cancellationToken);
        }

        [HttpPut("{NotificationId}/markAsRead")]
        public async Task MarkNotificationAsRead([FromRoute] MarkAsReadCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }
    }
}