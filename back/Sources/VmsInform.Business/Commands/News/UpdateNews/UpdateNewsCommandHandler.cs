using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.News.UpdateNews
{
    internal sealed class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;
        private readonly IMapper _mapper;

        public UpdateNewsCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<NewsEntry> newsRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Query()
                .FirstOrDefaultAsync(a => a.Id == request.Item.Id, cancellationToken);

            if (news == null)
                throw new NotFoundException("News not found");

            _mapper.Map(request.Item, news);

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
