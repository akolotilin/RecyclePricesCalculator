using System.Collections.Generic;

namespace VmsInform.Web.Dto.Partners
{
    public class EditPartnerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool IsSeller { get; set; }
        public bool IsBuyer { get; set; }
        public string TaxNumber { get; set; }
        public decimal TransportPrice { get; set; }

        public string CellPhone { get; set; }
        public string OfficePhone { get; set; }
        public string Email { get; set; }
        public string Viber { get; set; }
        public string WhatsApp { get; set; }
        public string Skype { get; set; }

        public IEnumerable<PartnerContactDto> Contacts { get; set; }
        public IEnumerable<PartnerPriceTypeToBuyDto> PriceTypesForBuy { get; set; }
        public IEnumerable<ShipmentAddressDto> ShipmentAddresses { get; set; }
        public IEnumerable<PartnerFactoryDto> Factories { get; set; }
    }
}
