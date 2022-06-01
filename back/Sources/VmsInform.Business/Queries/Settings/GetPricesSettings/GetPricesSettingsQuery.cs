using MediatR;
using VmsInform.Web.Dto.Settings;

namespace VmsInform.Business.Queries.Settings.GetPricesSettings
{
    public class GetPricesSettingsQuery : IRequest<PriceSettingsDto>
    {
    }
}
