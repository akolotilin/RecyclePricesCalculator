using System;

namespace VmsInform.Web.Dto.Partners
{
    public class UpdatePriceOfferDto
    {
        public long GoodId { get; set; }
        public long? FactoryId { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidThru { get; set; }
    }
}
