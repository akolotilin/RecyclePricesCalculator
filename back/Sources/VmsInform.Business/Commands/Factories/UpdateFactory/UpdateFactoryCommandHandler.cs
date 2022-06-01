using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Factories.UpdateFactory
{
    internal sealed class UpdateFactoryCommandHandler : IRequestHandler<UpdateFactoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Factory> _factoryRepository;
        private readonly IMapper _mapper;

        public UpdateFactoryCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Factory> factoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdateFactoryCommand request, CancellationToken cancellationToken)
        {
            var factory = await _factoryRepository.Query()
                .FirstOrDefaultAsync(a => a.Id == request.Item.Id, cancellationToken);

            _mapper.Map(request.Item, factory);
            
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
