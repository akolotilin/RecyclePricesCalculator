using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Settings.UpdatePricesSettings;
using VmsInform.Business.Queries.Settings.GetPricesSettings;
using VmsInform.Web.Dto.Settings;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SettingsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("prices")]
        public async Task<PriceSettingsDto> GetPricesSettings()
        {
            return await _mediator.Send(new GetPricesSettingsQuery());
        }

        [HttpPut("prices")]
        public async Task UpdatePricesSettings ([FromBody] UpdatePricesSettingsCommand command)
        {
            await _mediator.Send(command);
        }
    }
}