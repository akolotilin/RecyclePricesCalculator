using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Queries.Shipments.GetShipments
{
    internal sealed class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, IEnumerable<ShipmentDto>>
    {
        private readonly IVmsInformRepository<Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentsQueryHandler(IVmsInformRepository<Shipment> shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ShipmentDto>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
        {
            var shipments = await _shipmentRepository.Query()
                .Where(a => a.ShipmentDate >= (request.DateFrom ?? DateTime.MinValue) && a.ShipmentDate <= (request.DateTo ?? DateTime.MaxValue))
                .Where(a => !request.PartnerId.HasValue || request.PartnerId.Value == a.PartnerId)
                .Where(a => !request.FactoryId.HasValue || request.FactoryId.Value == a.FactoryId)
                .Include(a => a.Partner)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ShipmentDto>>(shipments);
        }
    }
}
