using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Partners.AddPartner;
using VmsInform.Business.Commands.Partners.AddPartnerFactory;
using VmsInform.Business.Commands.Partners.AddPriceOffer;
using VmsInform.Business.Commands.Partners.AddPriceOffers;
using VmsInform.Business.Commands.Partners.DeletePartnerOffer;
using VmsInform.Business.Commands.Partners.RemovePartnerFactory;
using VmsInform.Business.Commands.Partners.SetUsePriceOffersByFactories;
using VmsInform.Business.Commands.Partners.UpdatePartner;
using VmsInform.Business.Commands.Partners.UpdatePriceOffer;
using VmsInform.Business.Queries.Partners.FindByTaxNumber;
using VmsInform.Business.Queries.Partners.GetPartner;
using VmsInform.Business.Queries.Partners.GetPartnerFactories;
using VmsInform.Business.Queries.Partners.GetPartnerOffers;
using VmsInform.Business.Queries.Partners.GetPartners;
using VmsInform.Common.Extensions;
using VmsInform.Web.Dto.Partners;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    public class PartnersController : BaseApiController
    {
        private readonly IMediator _mediator;
        public PartnersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create")]
        public async Task Create([FromBody] AddPartnerCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<EditPartnerDto> Get(long id)
        {
            return await _mediator.Send(new GetPartnerQuery { Id = id});
        }

        [HttpGet]
        public async Task<IEnumerable<PartnerDto>> GetAll([FromQuery] GetPartnersQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] EditPartnerDto partner)
        {
            await _mediator.Send(new UpdatePartnerCommand { PartnerId = id, Partner = partner });
            return Ok();
        }

        [HttpGet("{PartnerId}/offers")]
        public async Task<ActionResult> GetOffers([FromRoute] GetPartnerOffersQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }

        [HttpPut("{partnerId}/updateOffer")]
        public async Task<ActionResult> UpdateOffer(long partnerId, [FromBody] UpdatePriceOfferDto offerData, CancellationToken cancellationToken)
        {
            var command = new UpdatePriceOfferCommand
            {
                GoodId = offerData.GoodId,
                FactoryId = offerData.FactoryId,
                PartnerId = partnerId,
                Currency = offerData.Currency,
                Price = offerData.Price,
                ValidThru = offerData.ValidThru.WorkaroundFuckingTimeZone()
            };

            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut("{partnerId}/setUsePriceOffersByFactories")]
        public async Task<ActionResult> SetUsePriceOffersByFactories([FromRoute] long partnerId, [FromQuery] bool value, CancellationToken cancellationToken)
        {
            await _mediator.Send(new SetUsePriceOffersByFactoriesCommand
            {
                PartnerId = partnerId,
                UsePriceOffersByFactories = value
            }, cancellationToken);
            return Ok();
        }

        [HttpPut("{partnerId}/addOffers")]
        public async Task<ActionResult> AddOffer(long partnerId, [FromBody] IEnumerable<long> goodIds, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddPriceOffersCommand
            {
                PartnerId = partnerId,
                GoodIds = goodIds
            }, cancellationToken);

            return Ok();
        }

        [HttpPost("{partnerId}/addOffer")]
        public async Task<ActionResult> AddOffer(long partnerId, [FromBody] UpdatePriceOfferDto offerData, CancellationToken cancellationToken)
        {
            var command = new AddPriceOfferCommand
            {
                GoodId = offerData.GoodId,
                FactoryId = offerData.FactoryId,
                PartnerId = partnerId,
                Currency = offerData.Currency,
                Price = offerData.Price,
                ValidThru = offerData.ValidThru.WorkaroundFuckingTimeZone()
            };

            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{partnerId}/offers/{goodId}/{factoryId}/delete")]
        public async Task<ActionResult> DeleteOffer([FromRoute] DeletePartnerOfferCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet("{partnerId}/factories")]
        public async Task<ActionResult> GetPartnerFactories(long partnerId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetPartnerFactoriesQuery { PartnerId = partnerId }, cancellationToken));
        }

        [HttpGet("findByTaxNumber")]
        public async Task<PartnerDto> FindByTaxNumber([FromQuery] FindByTaxNumberQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPost("{partnerId}/addFactory")]
        public async Task<PartnerFactoryDto> AddFactory([FromRoute] long partnerId, [FromQuery] long factoryId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddPartnerFactoryCommand { PartnerId = partnerId, FactoryId = factoryId }, cancellationToken);
        }

        [HttpDelete("{PartnerId}/factories/{FactoryId}")]
        public async Task RemovePartnerFactory([FromRoute] RemovePartnerFactoryCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }
    }
}
