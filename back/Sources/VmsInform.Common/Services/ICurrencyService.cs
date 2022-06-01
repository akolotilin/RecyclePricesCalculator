using System.Threading;
using System.Threading.Tasks;
using VmsInform.Web.Dto.Goods;

namespace VmsInform.Common.Services
{
    public interface ICurrencyService
    {
        Task<decimal> GetCource(string currencyCode);
        Task<CurrencyDto> GetCurrencyByCode(string code, CancellationToken cancellationToken = default);
    }
}
