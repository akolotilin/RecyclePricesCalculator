using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Goods.AddGood;
using VmsInform.Business.Commands.Goods.DeleteGood;
using VmsInform.Business.Commands.Goods.HideGoodInPriceList;
using VmsInform.Business.Commands.Goods.UpdateGood;
using VmsInform.Business.Queries.Goods;
using VmsInform.Business.Queries.Goods.GetGoodsByGroup;
using VmsInform.Business.Queries.Goods.GetHiererchy;
using VmsInform.Web.Dto.Common;
using VmsInform.Web.Dto.Goods;
using VmsInform.Web.Dto.Goods.Hierarchy;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GoodsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("hiererchy")]
        public async Task<IEnumerable<GoodsTreeNodeDto>> GetHiererchy()
        {
            return await _mediator.Send(new GetHiererchyQuery { });
        }

        [HttpPost("add")]
        public async Task Add(GoodEditDto good)
        {
            await _mediator.Send(_mapper.Map<AddGoodCommand>(good));
        }

        [HttpGet("{GoodId}")]
        public async Task<GoodEditDto> GetGood([FromRoute] GetGoodQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPut("{goodId}/update")]
        public async Task Update(long goodId, GoodEditDto good)
        {
            var command = _mapper.Map<UpdateGoodCommand>(good);
            command.GoodId = goodId;

            await _mediator.Send(command);
        }

        [HttpDelete("{GoodId}/delete")]
        public async Task Delete([FromRoute] DeleteGoodCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("byGroup/{GroupId}")]
        public async Task<IEnumerable<NamedObjectDto>> GetGoodsByGroup([FromRoute] GetGoodsByGroupQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPost("hide")]
        public async Task HideGood([FromBody] HideGoodInPriceListCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }
    }
}