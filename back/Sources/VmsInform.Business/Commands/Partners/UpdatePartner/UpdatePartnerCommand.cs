using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.UpdatePartner
{
    public class UpdatePartnerCommand : IRequest
    {
        public long PartnerId { get; set; }
        public EditPartnerDto Partner { get; set; }
    }
}
