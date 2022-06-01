using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Factories.AddFactory;
using VmsInform.Business.Commands.Factories.DeleteFactory;
using VmsInform.Business.Commands.Factories.UpdateFactory;
using VmsInform.Business.Queries.Factories.GetFactories;
using VmsInform.Web.Dto.Factories;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : BaseCrudController<FactoryDto, AddFactoryCommand, UpdateFactoryCommand, DeleteFactoryCommand>
    {
        public FactoriesController(IMediator mediator)
            :base(mediator)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<FactoryDto>> GetAll([FromQuery] GetFactoriesQuery query, CancellationToken cancellationToken)
        {
            return (IEnumerable<FactoryDto>)await _mediator.Send(query, cancellationToken);
        }
    }
}