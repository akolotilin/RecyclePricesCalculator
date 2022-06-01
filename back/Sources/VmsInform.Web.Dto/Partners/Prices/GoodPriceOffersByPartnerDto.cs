using System.Collections.Generic;

namespace VmsInform.Web.Dto.Partners.Prices
{
    public class GoodPriceOffersByPartnerDto
    {
        public string PartnerName { get; set; }
        public long PartnerId { get; set; }
        public IEnumerable<PartnerPriceOfferDto> Offers { get; set; }
    }
}
