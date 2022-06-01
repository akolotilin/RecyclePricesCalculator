using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartners
{
    public class GetPartnersQuery : IRequest<IEnumerable<PartnerDto>>
    {
        public string SearchString { get; set; }
        public bool? OnlyBuyers { get; set; }
    }
}
