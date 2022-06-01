using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Web.Dto.Prices
{
    public class PriceListItemDto : PriceDto
    {
        public string Name { get; set; }
        public string GroupName { get; set; }

        public PriceListItemDto(PriceDto priceDto)
        {
            DeltaCash = priceDto.DeltaCash;
            DeltaCashless = priceDto.DeltaCashless;
            PriceCash = priceDto.PriceCash;
            PriceCashless = priceDto.PriceCashless;
        }
    }
}
