using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.GetPrices
{
    public class GetPricesQuery : IRequest<GetPricesResultDto>
    {
    }
}
