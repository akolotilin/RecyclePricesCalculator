using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Events;
using VmsInform.Common.Extensions;
using VmsInform.Common.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.PublishNews
{
    internal sealed class PublishNewsCommandHandler : IRequestHandler<PublishNewsCommand, NewsDto>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;

        public PublishNewsCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IVmsInformRepository<NewsEntry> newsRepository,
            IDateTimeService dateTimeService, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<NewsDto> Handle(PublishNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Query().FirstOrDefaultAsync(a => a.Id == request.NewsId, cancellationToken);
            this.ThrowNotFoundIfNull(news, "Новость не найдена");
            
            if (news.IsPublished)
            {
                throw new InvalidOperationException("Новость уже опубликована");
            }

            news.PublishDate = _dateTimeService.Now;
            news.IsPublished = true;
            await _unitOfWork.SaveAsync(cancellationToken);
            await _mediator.Publish(new NewsPublished { NewsId = news.Id }, cancellationToken);

            return _mapper.Map<NewsDto>(news);
        }

    }
}
