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
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.GetPriceOffers
{
    internal sealed class GetPriceOffersQueryHandler : IRequestHandler<GetPriceOffersQuery, GoodPriceOffersResultDto>
    {
        private readonly IVmsInformRepository<PartnerGoodsToSell> _goodsToSellReposiory;
        private readonly IMapper _mapper;

        public GetPriceOffersQueryHandler(IVmsInformRepository<PartnerGoodsToSell> goodsToSellReposiory, IMapper mapper)
        {
            _goodsToSellReposiory = goodsToSellReposiory ?? throw new ArgumentNullException(nameof(goodsToSellReposiory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GoodPriceOffersResultDto> Handle(GetPriceOffersQuery request, CancellationToken cancellationToken)
        {
            var allOffers = await _goodsToSellReposiory.Query()
                .Include(a => a.Partner)
                .Include(a => a.Factory)
                .Where(a => a.GoodId == request.GoodId && a.Partner.IsBuyer && a.Price > 0)
                .Where(a => a.Partner.Factories.Any(x => x.FactoryId == a.FactoryId) || !a.FactoryId.HasValue)
                .ToListAsync(cancellationToken);

            var offersWithFactory = allOffers
                .Where(a => a.FactoryId.HasValue)
                .Where(a => a.Partner.UsePriceOffersByFactories)
                .ToList();

            var offersWithoutFactory = allOffers
                .Where(a => !a.FactoryId.HasValue)
                .Where(a => !a.Partner.UsePriceOffersByFactories)
                .Where(a => !offersWithFactory.Any(x => x.GoodId == a.GoodId && a.PartnerId == x.PartnerId))
                .ToList();

            var offersByFactories = offersWithFactory
                .GroupBy(a => a.Partner)
                .Select(a => new GoodPriceOffersByPartnerDto
                {
                    PartnerId = a.Key.Id,
                    PartnerName = a.Key.Name,
                    Offers = _mapper.Map<IEnumerable<PartnerPriceOfferDto>>(a)
                })
                .ToList();

            return new GoodPriceOffersResultDto
            {
                OffersByFactories = offersByFactories,
                Offers = _mapper.Map<IEnumerable<PartnerPriceOfferDto>>(offersWithoutFactory)
            };
        }
    }
}
