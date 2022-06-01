using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartner
{
    public class GetPartnerQuery : IRequest<EditPartnerDto>
    {
        public long Id { get; set; }
    }
}
