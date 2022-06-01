using System.Collections.Generic;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Partners.Prices
{
    public class GetPricesResultDto
    {
        public IEnumerable<PriceTypeDto> PriceTypes { get; set; }
        public IEnumerable<PricesEditGoodDto> Goods { get; set; }
    }
}
