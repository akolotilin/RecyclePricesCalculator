using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.FindByTaxNumber
{
    public class FindByTaxNumberQuery : IRequest<PartnerDto>
    {
        public string TaxNumber { get; set; }
    }
}
