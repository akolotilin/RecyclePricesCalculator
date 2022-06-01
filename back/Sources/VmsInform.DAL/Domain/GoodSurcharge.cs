using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class GoodSurcharge : VmsInformEntity
    {
        public long GoodId { get; set; }
        public virtual Good Good { get; set; }

        public long PriceTypeId { get; set; }
        public virtual PriceType PriceType { get; set; }

        public decimal Surcharge { get; set; }
    }
}
