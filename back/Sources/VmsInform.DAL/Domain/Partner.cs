using System;
using System.Collections.Generic;

namespace VmsInform.DAL.Domain
{
    public class Partner : NamedObject
    {
        public DateTime? LastPricesUpdateDate { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public bool IsSeller { get; set; }
        public bool IsBuyer { get; set; }
        public string TaxNumber { get; set; }

        public decimal TransportPrice { get; set; }
        public bool UsePriceOffersByFactories { get; set; }

        public virtual ICollection<PartnerContact> Contacts { get; set; }
        public virtual ICollection<PartnerPriceType> PriceTypes { get; set; }
        public virtual ICollection<PartnerGoodsToSell> GoodsToSell { get; set; }
        public virtual ICollection<PartnerShipmentAddress> ShipmentAddresses { get; set; }
        public virtual ICollection<PartnerFactory> Factories { get; set; }
    }
}
