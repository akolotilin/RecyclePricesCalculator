using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class BaseGoodPrice : VmsInformEntity
    {
        public long GoodId { get; set; }
        public virtual Good Good { get; set; }

        public decimal Price { get; set; }

        public long? PartnerId { get; set; }

        public virtual Partner Partner { get; set; }

        public long? FactoryId { get; set; }

        public virtual Factory Factory { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? LastUpdated { get; set; }

        public long? CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
