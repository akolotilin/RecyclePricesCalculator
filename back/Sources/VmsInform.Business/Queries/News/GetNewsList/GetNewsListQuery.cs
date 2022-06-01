using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Queries.News.GetNewsList
{
    public class GetNewsListQuery : IRequest<IEnumerable<NewsDto>>
    {
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
