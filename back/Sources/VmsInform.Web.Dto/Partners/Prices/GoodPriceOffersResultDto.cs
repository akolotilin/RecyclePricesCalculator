using System.Collections.Generic;

namespace VmsInform.Web.Dto.Partners.Prices
{
    public class GoodPriceOffersResultDto
    {
        public IEnumerable<PartnerPriceOfferDto> Offers { get; set; }
        public IEnumerable<GoodPriceOffersByPartnerDto> OffersByFactories { get; set; }
    }
}
