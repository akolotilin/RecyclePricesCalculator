using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Goods.UploadGoodsFrom1C;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IntegrationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("UploadGoods1C")]
        public async Task UploadGoods1C([FromBody] UploadGoodsFrom1CCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }
    }
}