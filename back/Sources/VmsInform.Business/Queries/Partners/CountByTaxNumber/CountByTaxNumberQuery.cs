using MediatR;

namespace VmsInform.Business.Queries.Partners.CountByTaxNumber
{
    public class CountByTaxNumberQuery : IRequest<int>
    {
        public string TaxNumber { get; set; }
    }
}
