using MediatR;

namespace VmsInform.Business.Queries.Prices.GetCurrencyCource
{
    public class GetCurrencyCourceQuery : IRequest<decimal>
    {
        public string Code { get; set; }
    }
}
