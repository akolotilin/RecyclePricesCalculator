using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceFromOffer
{
    public class UpdateBasePriceFromOfferCommand :  IRequest<PricesEditGoodDto>
    {
        public long GoodId { get; set; }
        public PartnerPriceOfferDto Offer { get; set; }
    }
}
