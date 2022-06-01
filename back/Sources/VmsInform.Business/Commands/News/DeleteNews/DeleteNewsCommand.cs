using MediatR;

namespace VmsInform.Business.Commands.News.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {
        public long Id { get; set; }
    }
}
