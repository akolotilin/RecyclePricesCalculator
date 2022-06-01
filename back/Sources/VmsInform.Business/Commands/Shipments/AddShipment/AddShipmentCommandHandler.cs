using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Services;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Commands.Shipments.AddShipment
{
    internal sealed class AddShipmentCommandHandler : IRequestHandler<AddShipmentCommand, EditShipmentDto>
    {
        private readonly IVmsInformRepository<Shipment> _shipmentsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AddShipmentCommandHandler(IVmsInformRepository<Shipment> shipmentsRepository, IUnitOfWork unitOfWork, 
            IMapper mapper, IAuthorService authorService)
        {
            _shipmentsRepository = shipmentsRepository ?? throw new ArgumentNullException(nameof(shipmentsRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        public async Task<EditShipmentDto> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
        {
            var newShipment = _mapper.Map<Shipment>(request);
            _authorService.SetupCreator(newShipment);
            await _shipmentsRepository.AddAsync(newShipment, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<EditShipmentDto>(newShipment);
        }
    }
}
