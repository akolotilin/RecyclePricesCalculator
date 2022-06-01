using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PartnerShipmentAddress : VmsInformEntity
    {
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
