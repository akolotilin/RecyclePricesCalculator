using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Queries.Shipments.GetShipment
{
    internal sealed class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, EditShipmentDto>
    {
        private readonly IVmsInformRepository<Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentQueryHandler(IVmsInformRepository<Shipment> shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EditShipmentDto> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.Query()
                .FirstOrDefaultAsync(a=>a.Id == request.Id, cancellationToken);

            if (shipment == null)
                throw new NotFoundException("Shipment not found");

            return _mapper.Map<EditShipmentDto>(shipment);
        }
    }
}
