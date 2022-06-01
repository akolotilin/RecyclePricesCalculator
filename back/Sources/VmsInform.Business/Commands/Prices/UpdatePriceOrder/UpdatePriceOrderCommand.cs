using MediatR;

namespace VmsInform.Business.Commands.Prices.UpdatePriceOrder
{
    public class UpdatePriceOrderCommand : IRequest
    {
        public long GoodId { get; set; }
        public long? MoveAfterGoodId { get; set; }
    }
}
