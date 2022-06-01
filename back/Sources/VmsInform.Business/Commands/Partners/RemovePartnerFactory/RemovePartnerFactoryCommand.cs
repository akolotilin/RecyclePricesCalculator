using MediatR;

namespace VmsInform.Business.Commands.Partners.RemovePartnerFactory
{
    public class RemovePartnerFactoryCommand : IRequest
    {
        public long PartnerId { get; set; }
        public long FactoryId { get; set; }
    }
}
