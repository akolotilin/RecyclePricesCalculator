using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartnerFactories
{
    public class GetPartnerFactoriesQuery : IRequest<IEnumerable<PartnerFactoryDto>>
    {
        public long PartnerId { get; set; }
    }
}
