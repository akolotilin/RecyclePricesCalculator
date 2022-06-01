using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Queries.Factories.GetFactories
{
    internal sealed class GetFactoriesQueryHandler : IRequestHandler<GetFactoriesQuery, IEnumerable<FactoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVmsInformRepository<Factory> _factoriesRepository;

        public GetFactoriesQueryHandler(IMapper mapper, IVmsInformRepository<Factory> factoriesRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _factoriesRepository = factoriesRepository ?? throw new ArgumentNullException(nameof(factoriesRepository));
        }

        public async Task<IEnumerable<FactoryDto>> Handle(GetFactoriesQuery request, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<FactoryDto>(_factoriesRepository.Query())
                .ToListAsync(cancellationToken);
        }
    }
}
