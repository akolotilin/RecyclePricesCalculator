using System;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Web.Dto.Partners
{
    public class GoodToSellDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidThru { get; set; }
        public bool IsActive { get; set; }
        public NamedObjectDto Currency { get; set; }
    }
}
