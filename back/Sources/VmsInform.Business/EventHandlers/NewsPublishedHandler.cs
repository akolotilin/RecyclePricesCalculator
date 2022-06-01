using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Events;
using VmsInform.Business.Queries.News.GetNewsItem;
using VmsInform.Common.Commands.Notifications.SendNotification;

namespace VmsInform.Business.EventHandlers
{
    internal sealed class NewsPublishedHandler : INotificationHandler<NewsPublished>
    {
        private readonly IMediator _mediator;

        public NewsPublishedHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(NewsPublished notification, CancellationToken cancellationToken)
        {
            var news = await _mediator.Send(new GetNewsItemQuery { Id = notification.NewsId }, cancellationToken);
            await _mediator.Send(new SendNotificationCommand
            {
                PayloadId = news.Id,
                Subject = news.Title,
                IsImportant = news.IsImportant,
                NotificationType = NotificationType.News
            }, cancellationToken);
        }
    }
}
