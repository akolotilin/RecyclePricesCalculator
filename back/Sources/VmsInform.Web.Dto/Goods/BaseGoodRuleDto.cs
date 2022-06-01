using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Goods
{
    public class BaseGoodRuleDto
    {
        public long GoodId { get; set; }
        public string GoodName { get; set; }
        public decimal Multiplier { get; set; }
        public decimal Add { get; set; }
    }
}
