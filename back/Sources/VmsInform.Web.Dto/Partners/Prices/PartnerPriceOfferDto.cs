namespace VmsInform.Web.Dto.Partners.Prices
{
    public class PartnerPriceOfferDto
    {
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public long? FactoryId { get; set; }
        public string FactoryName { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string ValidThru { get; set; }
        public bool IsActual { get; set; }
        public bool IsBest { get; set; }
    }
}
