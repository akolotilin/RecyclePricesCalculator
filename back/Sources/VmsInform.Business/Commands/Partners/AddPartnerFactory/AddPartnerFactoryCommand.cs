using MediatR;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.AddPartnerFactory
{
    public class AddPartnerFactoryCommand : IRequest<PartnerFactoryDto>
    {
        public long PartnerId { get; set; }
        public long FactoryId { get; set; }
    }
}
