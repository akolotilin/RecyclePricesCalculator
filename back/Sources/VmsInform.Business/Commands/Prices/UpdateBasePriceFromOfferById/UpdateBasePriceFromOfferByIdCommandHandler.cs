using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Prices.UpdateBasePriceFromOffer;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Commands.Prices.UpdateBasePriceFromOfferById
{
    internal sealed class UpdateBasePriceFromOfferByIdCommandHandler : IRequestHandler<UpdateBasePriceFromOfferByIdCommand>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _offerRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateBasePriceFromOfferByIdCommandHandler(IVmsInformRepository<PartnerGoodsToSell> offerRepository, IMediator mediator, IMapper mapper)
        {
            _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdateBasePriceFromOfferByIdCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.Query().FirstOrDefaultAsync(a => a.Id == request.OfferId, cancellationToken);
            await _mediator.Send(new UpdateBasePriceFromOfferCommand {
                GoodId = offer.GoodId,
                Offer = _mapper.Map<PartnerPriceOfferDto>(offer)
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
