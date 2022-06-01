using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Prices;

namespace VmsInform.Business.Queries.Prices.GetPriceList
{
    public class GetPriceListQuery : IRequest<IEnumerable<PriceListItemDto>>
    {
        public long PriceId { get; set; }
    }
}
