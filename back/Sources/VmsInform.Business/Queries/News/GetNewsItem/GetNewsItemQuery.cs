using MediatR;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Queries.News.GetNewsItem
{
    public class GetNewsItemQuery : IRequest<NewsDto>
    {
        public long Id { get; set; }
    }
}
