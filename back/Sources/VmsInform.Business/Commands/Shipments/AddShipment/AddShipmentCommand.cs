using MediatR;
using System.Collections.Generic;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Commands.Shipments.AddShipment
{
    public class AddShipmentCommand : BaseShipmentDto, IRequest<EditShipmentDto>
    {
        public long PartnerId { get; set; }
        public long FactoryId { get; set; }
        public IEnumerable<long> Pictures { get; set; }
    }
}
