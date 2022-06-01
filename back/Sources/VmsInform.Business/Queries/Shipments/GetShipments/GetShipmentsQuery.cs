using MediatR;
using System;
using System.Collections.Generic;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.Queries.Shipments.GetShipments
{
    public class GetShipmentsQuery : IRequest<IEnumerable<ShipmentDto>>
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long? PartnerId { get; set; }
        public long? FactoryId { get; set; }
    }
}
