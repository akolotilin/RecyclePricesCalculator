using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartnerOffers
{
    public class GetPartnerOffersQuery : IRequest<PartnerOffersEditDataDto>
    {
        public long PartnerId { get; set; }
    }
}
