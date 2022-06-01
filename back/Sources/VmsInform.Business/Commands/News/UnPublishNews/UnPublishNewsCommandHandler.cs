using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Events;
using VmsInform.Common.Extensions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.UnPublishNews
{
    internal sealed class UnPublishNewsCommandHandler : IRequestHandler<UnPublishNewsCommand, NewsDto>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;
        private readonly IMapper _mapper;

        public UnPublishNewsCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IVmsInformRepository<NewsEntry> newsRepository,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<NewsDto> Handle(UnPublishNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Query().FirstOrDefaultAsync(a => a.Id == request.NewsId, cancellationToken);
            this.ThrowNotFoundIfNull(news, "Новость не найдена");
            
            news.PublishDate = null;
            news.IsPublished = false;
            await _unitOfWork.SaveAsync(cancellationToken);
            await _mediator.Publish(new NewsUnPublished { NewsId = news.Id }, cancellationToken);

            return _mapper.Map<NewsDto>(news);
        }
    }
}
