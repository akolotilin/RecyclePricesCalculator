using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners;

namespace VmsInform.Business.Queries.Partners.GetPartnerOffers
{
    internal sealed class GetPartnerOffersQueryHandler : IRequestHandler<GetPartnerOffersQuery, PartnerOffersEditDataDto>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _offersRepository;
        private readonly IVmsInformRepository<Partner> _partnersRepository;
        private readonly IVmsInformRepository<PartnerFactory> _partnerFactoryRepository;
        private readonly IMapper _mapper;

        public GetPartnerOffersQueryHandler(IVmsInformRepository<PartnerGoodsToSell> offersRepository, IVmsInformRepository<Partner> partnersRepository,
            IVmsInformRepository<PartnerFactory> partnerFactoryRepository, IMapper mapper)
        {
            _offersRepository = offersRepository ?? throw new ArgumentNullException(nameof(offersRepository));
            _partnersRepository = partnersRepository ?? throw new ArgumentNullException(nameof(partnersRepository));
            _partnerFactoryRepository = partnerFactoryRepository ?? throw new ArgumentNullException(nameof(partnerFactoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PartnerOffersEditDataDto> Handle(GetPartnerOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await _offersRepository.Query()
                .Include(a => a.Factory)
                .Where(a => a.PartnerId == request.PartnerId)
                .ToListAsync(cancellationToken);

            var factories = _partnerFactoryRepository.Query()
                .Where(a => a.PartnerId == request.PartnerId)
                .Select(a => a.Factory)
                .ToList();

            var hasFactoryOffers = offers.Any(a => a.FactoryId.HasValue);

            var partner = await _partnersRepository.Query().FirstAsync(a => a.Id == request.PartnerId, cancellationToken);

            return new PartnerOffersEditDataDto
            {
                FactoryOffers = factories.Select(a => new OffersByFactoryDto
                {
                    FactoryId = a.Id,
                    FactoryName = a.Name,
                    FactoryAddress = a.Address,
                    Offers = _mapper.Map<IEnumerable<GoodToSellDto>>(offers.Where(offer => offer.FactoryId == a.Id))
                }),
                PartnerName = partner.Name,
                Offers = hasFactoryOffers ? null : _mapper.Map<IEnumerable<GoodToSellDto>>(offers.Where(a => a.FactoryId == null)),
                UsePriceOffersByFactories = partner.UsePriceOffersByFactories
            };
        }
    }
}
