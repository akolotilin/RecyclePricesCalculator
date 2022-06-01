using MediatR;

namespace VmsInform.Business.Commands.Partners.SetUsePriceOffersByFactories
{
    public class SetUsePriceOffersByFactoriesCommand : IRequest
    {
        public long PartnerId { get; set; }
        public bool UsePriceOffersByFactories { get; set; }
    }
}
