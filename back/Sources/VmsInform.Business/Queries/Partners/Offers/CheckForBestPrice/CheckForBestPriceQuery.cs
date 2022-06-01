using MediatR;

namespace VmsInform.Business.Queries.Partners.Offers.CheckForBestPrice
{
    public class CheckForBestPriceQuery : IRequest<bool>
    {
        public long OfferId { get; set; }
        public long GoodId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
