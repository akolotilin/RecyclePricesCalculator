using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PartnerFactory : VmsInformEntity
    {
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

        public long FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
