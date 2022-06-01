using MediatR;

namespace VmsInform.Business.Commands.Partners.DeletePartnerOffer
{
    public class DeletePartnerOfferCommand : IRequest
    {
        public long PartnerId { get; set; }
        public long GoodId { get; set; }
        public long? FactoryId { get; set; }
    }
}
