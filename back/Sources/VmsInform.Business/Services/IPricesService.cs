using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Services
{
    public interface IPricesService
    {
        Task<PriceDto> CalcPrice(long goodId, decimal surcharge, bool isTransit, CancellationToken cancellationToken = default(CancellationToken));
        (decimal? Price, Currency Currency) GetGoodPrice(Good good);
        Task PreloadData();
    }
}
