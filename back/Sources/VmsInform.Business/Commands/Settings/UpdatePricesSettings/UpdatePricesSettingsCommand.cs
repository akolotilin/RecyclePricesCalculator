using MediatR;
using VmsInform.Web.Dto.Settings;

namespace VmsInform.Business.Commands.Settings.UpdatePricesSettings
{
    public class UpdatePricesSettingsCommand : PriceSettingsDto, IRequest
    {
    }
}
