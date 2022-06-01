using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PartnerPriceType : VmsInformEntity
    {
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

        public long PriceTypeId { get; set; }
        public virtual PriceType PriceType { get; set; }
    }
}
