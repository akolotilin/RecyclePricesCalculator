using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Shipments.AddShipment;
using VmsInform.Business.Commands.Shipments.DeleteShipment;
using VmsInform.Business.Commands.Shipments.UpdateShipment;
using VmsInform.Business.Queries.Shipments.GetShipment;
using VmsInform.Business.Queries.Shipments.GetShipments;
using VmsInform.Web.Dto.Shipments;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ShipmentsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("add")]
        public async Task<EditShipmentDto> AddShipment([FromBody] AddShipmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<IEnumerable<ShipmentDto>> GetShipments([FromQuery] GetShipmentsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<EditShipmentDto> Get([FromRoute] GetShipmentQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<EditShipmentDto> Update([FromRoute] long id, [FromBody] EditShipmentDto shipmentDto)
        {
            return await _mediator.Send(new UpdateShipmentCommand { Id = id, Shipment = shipmentDto });
        }

        [HttpDelete("{Id}/delete")]
        public async Task<ActionResult> DeleteShipment([FromRoute] DeleteShipmentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}