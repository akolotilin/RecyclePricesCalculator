using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class PriceGoodOrder : VmsInformEntity
    {
        public virtual Good Good { get; set; }
        public long GoodId { get; set; }
        public int Order { get; set; }
    }
}
