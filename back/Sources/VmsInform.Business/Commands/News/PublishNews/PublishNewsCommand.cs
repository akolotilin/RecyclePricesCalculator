using MediatR;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.PublishNews
{
    public class PublishNewsCommand : IRequest<NewsDto>
    {
        public long NewsId { get; set; }
    }
}
