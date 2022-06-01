using System.Collections.Generic;

namespace VmsInform.Web.Dto.Clients
{
    public class PricesGoodGroupDto
    {
        public string Name { get; set; }
        public IEnumerable<ClientPriceDto> Prices { get; set; }
    }
}
