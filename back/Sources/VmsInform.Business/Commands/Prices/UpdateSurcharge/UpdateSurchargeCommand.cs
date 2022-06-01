using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateSurcharge
{
    public class UpdateSurchargeCommand : IRequest<PriceItemData>
    {
        public long PriceId { get; set; }
        public long GoodId { get; set; }
        public long Surcharge { get; set; }
    }
}
