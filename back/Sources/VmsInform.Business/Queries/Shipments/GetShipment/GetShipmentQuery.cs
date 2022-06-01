using MediatR;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Queries.Shipments.GetShipment
{
    public class GetShipmentQuery : IRequest<EditShipmentDto>
    {
        public long Id { get; set; }
    }
}
