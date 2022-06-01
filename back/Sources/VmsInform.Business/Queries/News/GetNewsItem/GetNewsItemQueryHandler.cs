using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.Common.Extensions;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Queries.News.GetNewsItem
{
    internal sealed class GetNewsItemQueryHandler : IRequestHandler<GetNewsItemQuery, NewsDto>
    {
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetNewsItemQueryHandler(IVmsInformRepository<NewsEntry> newsRepository, IMapper mapper, IUserService userService)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<NewsDto> Handle(GetNewsItemQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Query()
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            this.ThrowNotFoundIfNull(news, "News not found");

            if (!news.IsPublished && !_userService.CurrentUser.IsAdmin && news.AuthorId != _userService.CurrentUser.Id)
                throw new ForbiddenException();

            return _mapper.Map<NewsDto>(news);
        }
    }
}
