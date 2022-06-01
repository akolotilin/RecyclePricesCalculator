using MediatR;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.AddNews
{
    public class AddNewsCommand : IRequest<NewsEditDto>
    {
        public NewsEditDto Item { get; set; }
    }
}
