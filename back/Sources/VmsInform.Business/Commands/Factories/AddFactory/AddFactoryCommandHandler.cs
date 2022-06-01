using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Commands.Factories.AddFactory
{
    internal sealed class AddFactoryCommandHandler : IRequestHandler<AddFactoryCommand, FactoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Factory> _factoryRepository;
        private readonly IMapper _mapper;

        public AddFactoryCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Factory> factoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<FactoryDto> Handle(AddFactoryCommand request, CancellationToken cancellationToken)
        {
            var factory = _mapper.Map<Factory>(request.Item);
            await _factoryRepository.AddAsync(factory, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<FactoryDto>(factory);
        }
    }
}
