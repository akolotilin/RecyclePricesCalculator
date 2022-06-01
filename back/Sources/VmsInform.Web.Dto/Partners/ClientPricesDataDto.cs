using System.Collections.Generic;

namespace VmsInform.Web.Dto.Clients
{
    public class ClientPricesDataDto
    {
        public string ClientName { get; set; }
        public IEnumerable<PricesGoodGroupDto> Groups { get; set; }
    }
}
