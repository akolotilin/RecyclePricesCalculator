using MediatR;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.UpdateNews
{
    public class UpdateNewsCommand : IRequest
    {
        public NewsEditDto Item { get; set; }
    }
}
