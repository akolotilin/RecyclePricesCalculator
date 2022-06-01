using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class BaseGoodRule : VmsInformEntity
    {
        public long BaseGoodId { get; set; }
        public virtual Good BaseGood { get; set; }
        public decimal Multiplier { get; set; }
        public decimal Add { get; set; }
    }
}
