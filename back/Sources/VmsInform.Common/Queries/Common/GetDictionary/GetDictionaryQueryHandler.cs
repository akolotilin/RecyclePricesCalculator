using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Common.Queries.Common.GetDictionary
{
    public class GetDictionaryQueryHandler<TEntity> : IRequestHandler<GetDictionaryQuery<TEntity>, IEnumerable<NamedObjectDto>>
        where TEntity : NamedObject
    {
        private readonly IVmsInformRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GetDictionaryQueryHandler(IVmsInformRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NamedObjectDto>> Handle(GetDictionaryQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<NamedObjectDto>>(await _repository.Query()
                .ToListAsync(cancellationToken));
        }
    }
}
