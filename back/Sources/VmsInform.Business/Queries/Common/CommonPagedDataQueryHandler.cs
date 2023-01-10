using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.MyBoxRepositories;
using VmsInform.Web.Dto.Common;

namespace VmsInform.Business.Queries.Common
{
    internal abstract class CommonPagedDataQueryHandler<TQuery, TDataItem, TEntity> : IRequestHandler<TQuery, PagedDataDto<TDataItem>>
        where TQuery : IPagedDataQuery<TDataItem>
        where TDataItem : class
        where TEntity : VmsInformEntity
    {
        private readonly IVmsInformRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        protected CommonPagedDataQueryHandler(IVmsInformRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedDataDto<TDataItem>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query();
            query = Preprocess(ApplyFilter(query, request));

            var totalCount = await query.CountAsync(cancellationToken);

            var pageIndex = request.PageIndex - 1;

            var data = await _mapper.ProjectTo<TDataItem>(query.Skip(pageIndex * request.PageSize)
                .Take(request.PageSize))
                .ToListAsync(cancellationToken);

            return new PagedDataDto<TDataItem>
            {
                PageNumber = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Data = data
            };
        }

        protected virtual IQueryable<TEntity> Preprocess(IQueryable<TEntity> source)
        {
            return source;
        }

        protected virtual IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source, TQuery request)
        {
            return source;
        }
    }
}
