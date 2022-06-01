using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.News.AddNews;
using VmsInform.Business.Commands.News.DeleteNews;
using VmsInform.Business.Commands.News.PublishNews;
using VmsInform.Business.Commands.News.UnPublishNews;
using VmsInform.Business.Commands.News.UpdateNews;
using VmsInform.Business.Queries.News.GetNewsIdByNotification;
using VmsInform.Business.Queries.News.GetNewsItem;
using VmsInform.Business.Queries.News.GetNewsList;
using VmsInform.Web.Dto.News;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseCrudController<NewsEditDto, AddNewsCommand, UpdateNewsCommand, DeleteNewsCommand>
    {

        public NewsController(IMediator mediator)
            :base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetNews([FromQuery] GetNewsListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get([FromRoute] GetNewsItemQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        [HttpPost("{NewsId}/publish")]
        public async Task<ActionResult> Publish([FromRoute] PublishNewsCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost("{NewsId}/unpublish")]
        public async Task<ActionResult> UnPublish([FromRoute] UnPublishNewsCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet("byNotification/{NotificationId}")]
        public async Task<ActionResult> GetNewsByNotification([FromRoute] GetNewsIdByNotificationQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}