using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Factories.DeleteFactory
{
    internal class DeleteFactoryCommandHandler : IRequestHandler<DeleteFactoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Factory> _factoryRepository;

        public DeleteFactoryCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Factory> factoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));
        }

        public async Task<Unit> Handle(DeleteFactoryCommand request, CancellationToken cancellationToken)
        {
            var factory = await _factoryRepository.Query()
                .FirstOrDefaultAsync(a=>a.Id == request.Id, cancellationToken);

            if (factory == null)
                throw new NotFoundException($"Factory not found");

            _factoryRepository.Delete(factory);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
