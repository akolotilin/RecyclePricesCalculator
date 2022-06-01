using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Shipments.DeleteShipment
{
    internal sealed class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Shipment> _shipmentRepository;

        public DeleteShipmentCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Shipment> shipmentRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
        }

        public async Task<Unit> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.Query().FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (shipment == null)
                throw new NotFoundException("shipment not found");

            _shipmentRepository.Delete(shipment);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
