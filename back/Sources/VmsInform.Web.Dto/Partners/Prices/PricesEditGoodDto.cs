using System.Collections.Generic;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Partners.Prices
{
    public class PricesEditGoodDto : NamedObjectDto
    {
        public bool IsGroup { get; set; }

        public decimal? BasePrice { get; set; }

        public BasePriceDetailsDto PriceDetails { get; set; } 

        public IDictionary<long, PriceItemData> Prices { get; set; }

        public bool InputPriceManual { get; set; }

        public string BaseGood { get; set; }
        
        public string Currency { get; set; }
    }
}
