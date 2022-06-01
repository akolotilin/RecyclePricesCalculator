using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Goods
{
    public class GoodEditDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public long GroupId { get; set; }
        public bool InputPriceManual { get; set; }
        public BaseGoodRuleDto BaseGoodRule { get; set; }
    }
}
