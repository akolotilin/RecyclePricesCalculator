using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.GetPriceType
{
    public class GetPriceTypeQuery : IRequest<PriceTypeDto>
    {
        public long PriceTypeId { get; set; }
    }
}
