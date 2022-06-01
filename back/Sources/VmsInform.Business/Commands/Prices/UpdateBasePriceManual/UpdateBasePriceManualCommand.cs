using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceManual
{
    public class UpdateBasePriceManualCommand : IRequest<PricesEditGoodDto>
    {
        public long GoodId { get; set; }
        public decimal BasePrice { get; set; }
        public string ValidThru { get; set; }
    }
}
