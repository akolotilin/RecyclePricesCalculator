using MediatR;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Commands.Shipments.UpdateShipment
{
    public class UpdateShipmentCommand : IRequest<EditShipmentDto>
    {
        public long Id { get; set; }
        public EditShipmentDto Shipment { get; set; }
    }
}
