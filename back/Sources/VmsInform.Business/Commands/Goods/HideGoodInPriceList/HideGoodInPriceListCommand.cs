using MediatR;

namespace VmsInform.Business.Commands.Goods.HideGoodInPriceList
{
    public class HideGoodInPriceListCommand : IRequest
    {
        public long GoodId { get; set; }
    }
}
