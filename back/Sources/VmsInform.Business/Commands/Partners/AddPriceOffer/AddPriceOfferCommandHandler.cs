using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Events;
using VmsInform.Business.Queries.Partners.Offers.CheckForBestPrice;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Commands.Partners.AddPriceOffer
{
    internal sealed class AddPriceOfferCommandHandler : IRequestHandler<AddPriceOfferCommand, UpdatePriceOfferResultDto>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _offersRepository;
        private readonly ICurrencyService _currencyService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IDateTimeService _dateTimeService; 

        public AddPriceOfferCommandHandler(IVmsInformRepository<PartnerGoodsToSell> offersRepository, ICurrencyService currencyService,
            IUnitOfWork unitOfWork, IMediator mediator, IDateTimeService dateTimeService)
        {
            _offersRepository = offersRepository ?? throw new ArgumentNullException(nameof(offersRepository));
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public async Task<UpdatePriceOfferResultDto> Handle(AddPriceOfferCommand request, CancellationToken cancellationToken)
        {
            var currency = await _currencyService.GetCurrencyByCode(request.Currency, cancellationToken);

            var offer = new PartnerGoodsToSell
            {
                CurrencyId = currency.Id,
                GoodId = request.GoodId,
                FactoryId = request.FactoryId,
                ValidThru = request.ValidThru,
                Price = request.Price,
                PartnerId = request.PartnerId,
            };

            await _offersRepository.AddAsync(offer, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);


            await _mediator.Publish(new OfferUpdatedEvent
            {
                GoodId = request.GoodId,
                FactoryId = request.FactoryId,
                PartnerId = request.PartnerId,
                Price = request.Price,
                Currency = currency,
                ValidThru = request.ValidThru,
                Action = OfferAction.Added
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
