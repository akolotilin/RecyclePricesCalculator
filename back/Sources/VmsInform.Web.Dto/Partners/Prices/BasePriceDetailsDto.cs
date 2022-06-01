using System;

namespace VmsInform.Web.Dto.Partners.Prices
{
    public class BasePriceDetailsDto
    {
        public DateTime? LastUpdated { get; set; }
        public string ExpirationDate { get; set; }
        public string Partner { get; set; }
        public string Factory { get; set; }
        public long? PartnerId { get; set; }
        public bool IsExpired { get; set; }
    }
}
