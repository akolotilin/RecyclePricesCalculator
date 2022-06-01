using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Queries.News.GetNewsList
{
    internal class GetNewsListQueryHandler : IRequestHandler<GetNewsListQuery, IEnumerable<NewsDto>>
    {
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetNewsListQueryHandler(IVmsInformRepository<NewsEntry> newsRepository, IMapper mapper, IUserService userService)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<IEnumerable<NewsDto>> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<NewsDto>(_newsRepository.Query()
                .Where(a => a.IsPublished || a.AuthorId == _userService.CurrentUser.Id || _userService.CurrentUser.IsAdmin)
                .OrderBy(a => a.IsPublished)
                .ThenByDescending(a => a.PublishDate)
                .ThenByDescending(a => a.DateTime)
                .Skip(request.Offset)
                .Take(request.Count)
                )
                 .ToListAsync(cancellationToken);
        }
    }
}
