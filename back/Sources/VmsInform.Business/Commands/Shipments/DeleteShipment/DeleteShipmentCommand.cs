using MediatR;

namespace VmsInform.Business.Commands.Shipments.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest
    {
        public long Id { get; set; }
    }
}
