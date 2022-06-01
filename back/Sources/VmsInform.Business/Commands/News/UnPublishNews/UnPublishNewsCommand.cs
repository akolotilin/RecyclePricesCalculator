using MediatR;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.UnPublishNews
{
    public class UnPublishNewsCommand : IRequest<NewsDto>
    {
        public long NewsId { get; set; }
    }
}
