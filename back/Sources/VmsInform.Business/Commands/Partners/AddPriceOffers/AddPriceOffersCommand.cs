using MediatR;
using System.Collections.Generic;

namespace VmsInform.Business.Commands.Partners.AddPriceOffers
{
    public class AddPriceOffersCommand : IRequest
    {
        public IEnumerable<long> GoodIds { get; set; }
        public long PartnerId { get; set; }
    }
}
