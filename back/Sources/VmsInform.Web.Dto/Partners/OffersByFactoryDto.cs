using System.Collections.Generic;

namespace VmsInform.Web.Dto.Partners
{
    public class OffersByFactoryDto
    {
        public long FactoryId { get; set; }
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
        public IEnumerable<GoodToSellDto> Offers { get; set; }
    }
}
