using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInformWeb.Controllers
{
    public abstract class BaseCrudController<TDto, TAddCommand, TUpdateCommand, TDeleteCommand> : BaseApiController
        where TAddCommand : IRequest<TDto> 
        where TUpdateCommand : IRequest
        where TDeleteCommand : IRequest
    {
        protected readonly IMediator _mediator;

        public BaseCrudController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("add")]
        public async Task<TDto> Add([FromBody] TAddCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] TUpdateCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{Id}/delete")]
        public async Task Delete([FromRoute] TDeleteCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }
    }
}
