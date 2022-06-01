using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Events;
using VmsInform.Business.Queries.Partners.Offers.CheckForBestPrice;
using VmsInform.Common.Exceptions;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.UpdatePriceOffer
{
    internal sealed class UpdatePriceOfferCommandHandler : IRequestHandler<UpdatePriceOfferCommand, UpdatePriceOfferResultDto>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _offersRepository;
        private readonly ICurrencyService _currencyService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public UpdatePriceOfferCommandHandler(IVmsInformRepository<PartnerGoodsToSell> offersRepository, ICurrencyService currencyService, 
            IUnitOfWork unitOfWork, IMediator mediator)
        {
            _offersRepository = offersRepository ?? throw new ArgumentNullException(nameof(offersRepository));
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<UpdatePriceOfferResultDto> Handle(UpdatePriceOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offersRepository.Query().FirstOrDefaultAsync(a => a.PartnerId == request.PartnerId 
            && request.GoodId == a.GoodId
            && request.FactoryId == a.FactoryId, cancellationToken);

            if (offer == null)
                throw new NotFoundException("Offer not found");

            var currency = await _currencyService.GetCurrencyByCode(request.Currency, cancellationToken);

            offer.Currency = null;
            offer.CurrencyId = currency.Id;
            offer.Price = request.Price;
            offer.ValidThru = request.ValidThru;

            _offersRepository.Update(offer);
            await _unitOfWork.SaveAsync(cancellationToken);

            var price = request.Price;

            await _mediator.Publish(new OfferUpdatedEvent
            {
                GoodId = request.GoodId,
                PartnerId = request.PartnerId,
                FactoryId = request.FactoryId,
                Price = request.Price,
                Currency = currency,
                ValidThru = request.ValidThru,
                Action = OfferAction.Updated
            }, cancellationToken);

            var isBestPrice = await _mediator.Send(new CheckForBestPriceQuery
            {
                Currency = request.Currency,
                GoodId = request.GoodId,
                OfferId = offer.Id,
                Price = request.Price
            }, cancellationToken);
            return new UpdatePriceOfferResultDto { IsBest = isBestPrice, OfferId = offer.Id };
        }
    }
}
