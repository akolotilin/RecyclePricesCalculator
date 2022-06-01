using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.GetPriceOffers
{
    public class GetPriceOffersQuery : IRequest<GoodPriceOffersResultDto>
    {
        public long GoodId { get; set; }
    }
}
