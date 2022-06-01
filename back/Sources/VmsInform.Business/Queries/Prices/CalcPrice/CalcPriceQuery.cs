using MediatR;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.CalcPrice
{
    public class CalcPriceQuery : IRequest<PriceDto>
    {
        public long GoodId { get; set; }
        public decimal Surcharge { get; set; }
        public long PriceTypeId { get; set; }
    }
}
