using System.Collections.Generic;

namespace VmsInform.Web.Dto.Partners
{
    public class PartnerOffersEditDataDto
    {
        public string PartnerName { get; set; }
        public IEnumerable<GoodToSellDto> Offers { get; set; }
        public IEnumerable<OffersByFactoryDto> FactoryOffers { get; set; }
        public bool UsePriceOffersByFactories { get; set; }
    }
}
