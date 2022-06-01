using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.AddNews
{
    internal sealed class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, NewsEditDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;
        private readonly IUserService _userService;

        public AddNewsCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<NewsEntry> newsRepository, IMapper mapper,
            IDateTimeService dateTimeService, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<NewsEditDto> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            var newNews = _mapper.Map<NewsEntry>(request.Item);
            newNews.DateTime = _dateTimeService.Now;
            newNews.AuthorId = _userService.CurrentUser.Id;

            await _newsRepository.AddAsync(newNews, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<NewsEditDto>(newNews);

        }
    }
}
