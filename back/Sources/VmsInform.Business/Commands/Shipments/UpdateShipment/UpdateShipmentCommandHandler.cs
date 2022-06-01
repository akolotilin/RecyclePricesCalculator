using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Services;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Commands.Shipments.UpdateShipment
{
    internal sealed class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, EditShipmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Shipment> _shipmentsRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public UpdateShipmentCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Shipment> shipmentsRepository, 
            IMapper mapper, IAuthorService authorService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _shipmentsRepository = shipmentsRepository ?? throw new ArgumentNullException(nameof(shipmentsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        public async Task<EditShipmentDto> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentsRepository.GetAsync(request.Id, cancellationToken);

            if (shipment == null)
                throw new NotFoundException("Shipment not found");

            _authorService.SetupEditor(shipment);

            _mapper.Map(request.Shipment, shipment);

            _shipmentsRepository.Update(shipment);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<EditShipmentDto>(shipment);
        }
    }
}
