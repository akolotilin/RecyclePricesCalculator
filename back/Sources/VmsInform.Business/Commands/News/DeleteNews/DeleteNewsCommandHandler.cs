using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.News.DeleteNews
{
    internal sealed class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<NewsEntry> _newsRepository;

        public DeleteNewsCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<NewsEntry> newsRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
        }

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Query()
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (news == null)
                throw new NotFoundException("News not found");

            _newsRepository.Delete(news);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
