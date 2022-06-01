using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PartnerGoodsToSell : VmsInformEntity
    {
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public long? FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Good Good { get; set; }
        public long GoodId { get; set; }
        public decimal Price { get; set; }
        public long CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public DateTime ValidThru { get; set; }
    }
}
