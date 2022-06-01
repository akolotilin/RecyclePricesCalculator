using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Extensions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Partners.Prices;

namespace VmsInform.Business.Queries.Prices.GetPriceType
{
    internal sealed class GetPriceTypeQueryHandler : IRequestHandler<GetPriceTypeQuery, PriceTypeDto>
    {
        private readonly IVmsInformRepository<PriceType> _priceTypeRepository;
        private readonly IMapper _mapper;

        public GetPriceTypeQueryHandler(IVmsInformRepository<PriceType> priceTypeRepository, IMapper mapper)
        {
            _priceTypeRepository = priceTypeRepository ?? throw new ArgumentNullException(nameof(priceTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PriceTypeDto> Handle(GetPriceTypeQuery request, CancellationToken cancellationToken)
        {
            var priceType = await _priceTypeRepository.Query()
                .FirstOrDefaultAsync(a=>a.Id == request.PriceTypeId, cancellationToken);

            this.ThrowNotFoundIfNull(priceType, "Price type not found");

            return _mapper.Map<PriceTypeDto>(priceType);

        }
    }
}
