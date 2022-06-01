using MediatR;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceFromOfferById
{
    public class UpdateBasePriceFromOfferByIdCommand : IRequest
    {
        public long OfferId { get; set; }
    }
}
