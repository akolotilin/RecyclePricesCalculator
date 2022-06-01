using MediatR;

namespace VmsInform.Business.Commands.Goods.DeleteGood
{
    public class DeleteGoodCommand : IRequest
    {
        public long GoodId { get; set; }
    }
}
